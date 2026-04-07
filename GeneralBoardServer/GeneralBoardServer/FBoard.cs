using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using MySqlX.XDevAPI;

namespace GeneralBoardServer
{
    public partial class FBoard : UIForm
    {
        public FBoard()
        {
            InitializeComponent();
        }

        DataTable DeviceListDataTable = new DataTable();
        private void FBoard_Load(object sender, EventArgs e)
        {
            //初始化数据
            InitData();

            //初始化设备表
            DeviceListDataTable.Columns.Add("序号");
            DeviceListDataTable.Columns.Add("设备名称");
            DeviceListDataTable.Columns.Add("设备地址");
            DeviceListDataTable.Columns.Add("连接时间");
        }




        private void FBoard_Shown(object sender, EventArgs e)
        {
            //打开服务器
            if (IsStartServer.Checked)
            {
                Task ServerListenTask = new Task(ServerListen);
                ServerListenTask.Start();
            }
        }


        private void FBoard_FormClosed(object sender, FormClosedEventArgs e)
        {
            string sql = "update devicelist set Status='Close';";
            RepositoryFactory.BaseRepository("connectionstring").ExecuteSql(sql);
        }


        public void InitData()
        {
            string sql = "SELECT * FROM boardserver.systemset where id='1';";
            DataTable dataTable = RepositoryFactory.BaseRepository("connectionstring").GetDataTable(sql);
            if (dataTable.Rows.Count > 0)
            {
                IPSaveTextBox.Text = dataTable.Rows[0]["ip"].ToString();
                PortSaveTextBox.Text = dataTable.Rows[0]["port"].ToString();
                BoardIPTextBox.Text = dataTable.Rows[0]["ip"].ToString();
                BoardPortTextBox.Text = dataTable.Rows[0]["port"].ToString();

                if (dataTable.Rows[0]["isUse"].ToString() == "1")
                {
                    IsStartServer.Checked = true;
                }
            }

            string sql2 = "SELECT * FROM formulainfo;";
            DataTable dataTable2 = RepositoryFactory.BaseRepository("connectionstring").GetDataTable(sql2);
            if (dataTable2.Rows.Count > 0)
            {
                for (int i = 0; i < dataTable2.Rows.Count; i++)
                {
                    FormulaComboBox.Items.Add(dataTable2.Rows[i]["formulaName"].ToString());
                }
            }
            FormulaListDataGridView.DataSource = dataTable2;
        }

        #region 设备状态

        private void ServerStopButton_Click(object sender, EventArgs e)
        {
            socketWatch?.Close();
            isServerOpen = false;
            LogBoardMsg("服务器关闭!");
        }

        private void ServerStartButton_Click(object sender, EventArgs e)
        {
            Task ServerListenTask = new Task(ServerListen);
            ServerListenTask.Start();
        }



        Dictionary<string, System.Net.Sockets.Socket> clientList = new Dictionary<string, System.Net.Sockets.Socket>();
        bool isServerOpen = false;
        Socket socketWatch;
        public void ServerListen()
        {
            try
            {
                socketWatch = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPAddress ip = IPAddress.Parse(BoardIPTextBox.Text);
                IPEndPoint point = new IPEndPoint(ip, Convert.ToInt32(BoardPortTextBox.Text));

                socketWatch.Bind(point);
                socketWatch.Listen(50);//允许连接的客户端数量

                LogBoardMsg("服务器已打开!");
                isServerOpen = true;

                Task.Factory.StartNew(() =>
                {
                    while (isServerOpen)
                    {
                        //接受接入的一个客户端
                        Socket connectClient = socketWatch.Accept();
                        if (connectClient != null)
                        {
                            string infor = connectClient.RemoteEndPoint.ToString();
                            clientList.Add(infor, connectClient);
                            //接收消息
                            ReceiveMessage(connectClient);
                        }
                    }
                });

                // ShowBtnState();
            }
            catch (Exception ex)
            {
                LogBoardMsg("ServerListen:" + ex);
            }

        }



        /// <summary>
        /// 接收消息
        /// </summary>
        /// <param name="client"></param>
        public void ReceiveMessage(Socket client)
        {
            Task.Factory.StartNew(() =>
            {
                while (isServerOpen)
                {
                    try
                    {
                        //定义服务器接收的字节大小
                        byte[] arrMsg = new byte[1024 * 1024 * 3];
                        //接收到的信息大小(所占字节数)
                        int length = client.Receive(arrMsg);
                        if (length > 0)
                        {
                            string receiveStr = Encoding.UTF8.GetString(arrMsg, 0, length);
                            //获取客户端的端口号
                            IPEndPoint endPoint = client.RemoteEndPoint as IPEndPoint;
                            if (receiveStr == "HeartBeat")
                            {
                                LogBoardMsg("收到【" + client.RemoteEndPoint.ToString() + "】心跳：" + receiveStr);
                                // 发送确认消息给客户端
                                SendMessage(client, "OK");
                            }
                            else
                            {
                                //服务器显示客户端的端口号和消息
                                Task.Run(() =>
                                {
                                    string[] receiveStr_Arr1 = receiveStr.Split(new char[] { '|' });
                                    for (int i = 0; i < receiveStr_Arr1.Length; i++)
                                    {
                                        string[] receiveStr_Arr2 = receiveStr_Arr1[i].Split(new char[] { '#' });
                                        switch (receiveStr_Arr2[0])
                                        {
                                            //设备机台名称添加
                                            case "Name":

                                                Invoke(new Action(() =>
                                                {
                                                    DataRow[] rows = DeviceListDataTable.Select("设备名称 = '" + receiveStr_Arr2[1] + "'");
                                                    if (rows.Length == 0)
                                                    {
                                                        DeviceListDataTable.Rows.Add(ConnectedDeviceDataGridView.Rows.Count + 1, receiveStr_Arr2[1], client.RemoteEndPoint.ToString(), DateTime.Now);

                                                    }
                                                    else
                                                    {
                                                        if (rows[0]["设备名称"].Equals(receiveStr_Arr2[1]))
                                                        {
                                                            rows[0]["连接时间"] = DateTime.Now;
                                                            rows[0]["设备地址"] = client.RemoteEndPoint.ToString();
                                                        }
                                                    }

                                                    ConnectedDeviceDataGridView.DataSource = DeviceListDataTable;
                                                }));



                                                //数据库DeviceList中添加/更新该设备
                                                string selectDeviceSQL = "SELECT * FROM devicelist where DeviceName='"+ receiveStr_Arr2[1] + "';";
                                                int selectDeviceFlag = RepositoryFactory.BaseRepository("connectionstring").ExecuteSql(selectDeviceSQL);
                                                if (selectDeviceFlag > 0)
                                                {
                                                    string updateDeviceSQL = "update devicelist set Adress='"+ client.RemoteEndPoint.ToString() + "',ConnectedTime='"+ DateTime.Now +"',Status='Open' where DeviceName='"+ receiveStr_Arr2[1] + "';";
                                                    RepositoryFactory.BaseRepository("connectionstring").ExecuteSql(updateDeviceSQL);
                                                }
                                                else
                                                {
                                                    string addDeviceSQL = "insert into devicelist(DeviceName,Adress,ConnectedTime,Status) values ('"+ receiveStr_Arr2[1] + "','"+ client.RemoteEndPoint.ToString() + "','"+ DateTime.Now +"','Open');";
                                                    RepositoryFactory.BaseRepository("connectionstring").ExecuteSql(addDeviceSQL);
                                                }



                                                break;


                                            case "Create":
                                                //创建对应机台数据库
                                                LogBoardMsg("创建语句:" + receiveStr_Arr2[1]);
                                                //string sql = "select count(*) as A from information_schema.tables where table_name = 'test' and table_schema ='boardserver'";
                                                int createFlag = RepositoryFactory.BaseRepository("connectionstring").ExecuteSql(receiveStr_Arr2[1]);
                                                if (createFlag > 0)
                                                {
                                                    LogBoardMsg("创建表成功");
                                                }
                                                break;


                                            case "Insert":
                                                //将数据保存到对应设备的数据表
                                                LogBoardMsg("插入语句:" + receiveStr_Arr2[1]);
                                                int insertFlag = RepositoryFactory.BaseRepository("connectionstring").ExecuteSql(receiveStr_Arr2[1]);
                                                if (insertFlag > 0)
                                                {
                                                    LogBoardMsg("添加生产数据成功");
                                                }
                                                break;


                                            case "Update":
                                                //将数据保存到对应设备的数据表
                                                LogBoardMsg("更新语句:" + receiveStr_Arr2[1]);
                                                int updateFlag = RepositoryFactory.BaseRepository("connectionstring").ExecuteSql(receiveStr_Arr2[1]);
                                                if (updateFlag > 0)
                                                {
                                                    LogBoardMsg("更新生产数据成功");
                                                }
                                                break;
                                        }
                                    }
                                });
                            }
                        }

                    }
                    catch (Exception)
                    {
                        Invoke(new Action(() =>
                        {
                            for (int i = 0; i < DeviceListDataTable.Rows.Count; i++)
                            {
                                if (DeviceListDataTable.Rows[i]["设备地址"].Equals(client.RemoteEndPoint.ToString()))
                                {
                                    DeviceListDataTable.Rows.RemoveAt(i);
                                }
                            }
                            ConnectedDeviceDataGridView.DataSource = DeviceListDataTable;
                        }));


                        //移除添加在字典中的服务器和客户端之间的线程
                        clientList.Remove(client.RemoteEndPoint.ToString());
                        //关闭客户端
                        client.Close();


                        break;

                    }
                }
            });
        }



        /// <summary>
        /// 单个客户端 发送消息
        /// </summary>
        /// <param name="str"></param>
        public void SendMessage(Socket client, string str)
        {
            try
            {
                byte[] buffer = Encoding.UTF8.GetBytes(str);
                client.Send(buffer);
            }
            catch (Exception ex)
            {
                clientList.Remove(client.RemoteEndPoint.ToString());
                client.Close();
                LogBoardMsg(ex.Message);
            }

        }


        private void LogBoardMsg(string msg)
        {
            Invoke(new Action(() =>
            {
                string hour = DateTime.Now.Hour.ToString();
                string minute = DateTime.Now.Minute.ToString();
                string second = DateTime.Now.Second.ToString();
                string millisecond = DateTime.Now.Millisecond.ToString();

                if (LogRichTextBox.Text.Length > 50000)
                {
                    this.LogRichTextBox.Clear();
                }
                LogRichTextBox.AppendText($"{hour}{minute}{second}{millisecond}:{msg}\r\n");
                LogRichTextBox.ScrollToCaret();
                SaveCsvLog(msg);
            }));

        }


        public void SaveCsvLog(string log)
        {
            string year = DateTime.Now.Year.ToString();
            string month = DateTime.Now.Month.ToString();
            string day = DateTime.Now.Day.ToString();
            string hour = DateTime.Now.Hour.ToString();
            string minute = DateTime.Now.Minute.ToString();
            string second = DateTime.Now.Second.ToString();
            string millisecond = DateTime.Now.Millisecond.ToString();

            try
            {
                if (System.IO.Directory.Exists("D:\\Log\\BoardServer") == false)
                {
                    System.IO.Directory.CreateDirectory("D:\\Log\\BoardServer");
                }
                StringBuilder DataLine = new StringBuilder();

                string strT = $"{hour}时{minute}分{second}秒";

                //列标题
                // i.Append(log);
                //行数据
                DataLine.Append(strT + ":" + log);
                string FileName = $"{year}-{month}-{day}";
                string FilePath = $@"D:\Log\GeneralBoardServer\{FileName}.txt";

                if (System.IO.File.Exists(FilePath) == false)
                {
                    System.IO.StreamWriter stream = new System.IO.StreamWriter(FilePath, true, Encoding.UTF8);
                    stream.WriteLine(DataLine);
                    stream.Flush();
                    stream.Close();
                    stream.Dispose();
                }
                else
                {
                    System.IO.StreamWriter stream = new System.IO.StreamWriter(FilePath, true, Encoding.UTF8);
                    stream.WriteLine(DataLine);
                    stream.Flush();
                    stream.Close();
                    stream.Dispose();
                }
            }
            catch (Exception ex)
            {

            }

            return;

        }

        #endregion


        #region 切换操作

        private void SwitchButton_Click(object sender, EventArgs e)
        {
            //发送工单和配方名称
            try
            {
                foreach (var client in clientList)
                {
                    MessageSendtem messageSendtem = new MessageSendtem();
                    messageSendtem.FormulaName = FormulaComboBox.Text;
                    messageSendtem.ToolName = ToolTextBox.Text;
                    string str = JsonConvert.SerializeObject(messageSendtem);
                    byte[] buffer = Encoding.UTF8.GetBytes(str);
                    client.Value.Send(buffer);
                }

                LogBoardMsg("配方和工单号切换成功");
            }
            catch (Exception ex)
            {
                LogBoardMsg("配方和工单号切换失败" + ex.Message);
            }

        }

        #endregion



        #region 系统设置

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string updateSql = "update systemset set ip='" + IPSaveTextBox.Text + "',port='" + PortSaveTextBox.Text + "',";
            if (IsStartServer.Checked)
            {
                updateSql += "isUse='1'";
            }
            else
            {
                updateSql += "isUse='0'";
            }
            updateSql += " where id='1';";

            int result = RepositoryFactory.BaseRepository("connectionstring").ExecuteSql(updateSql);
            if (result > 0)
            {
                MessageBox.Show("保存成功", "数据保存操作", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }



        #endregion


    }
}
