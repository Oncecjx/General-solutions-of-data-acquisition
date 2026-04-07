using GeneralFrameSystem.Properties;
using GeneralFrameSystem.SQL;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using NModbus;
using System.Net.Sockets;
using GeneralFrameSystem.Model;
using MySqlX.XDevAPI.Common;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using NPOI.SS.UserModel.Charts;
using System.Windows.Forms.DataVisualization.Charting;
using SkiaSharp;
using static NPOI.HSSF.Util.HSSFColor;
using NPOI.SS.Formula.Functions;
using System.Net;
using Newtonsoft.Json;

namespace GeneralFrameSystem
{
    public partial class FMain : UIForm
    {
        #region   接收参数
        private int access { get; set; }
        public void SetAccess(int data)
        {
            access = data;
        }

        private string username { get; set; }
        public void SetUsername(string data)
        {
            username = data;
        }

        #endregion

        public FMain()
        {
            InitializeComponent();

            this.MaximizedBounds = Screen.PrimaryScreen.WorkingArea;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        private void FMain_Load(object sender, EventArgs e)
        {
            //运行界面 数据初始化
            InitOperationScreen();

            //历史数据 初始化
            InitHistoryData();

            //系统设置 初始化
            InitSystemSet();

            //用户管理 初始化
            InitUserManage();

            //数据统计 初始化
            InitDataStatistics();
        }

        private void FMain_Shown(object sender, EventArgs e)
        {
            //MessageBox.Show(
            //    "access:" + access + "\n" +
            //    "username:" + username);

            //分配权限
            DistributionAccess();

            //连接PLC
            PLCConnectButton_Click(null, null);

            //连接看板
            if (BoardSwitch.Active)
            {
                BoardConnectButton_Click(null, null);
            }

            //MES用户验证
            if (MESSwitch.Active)
            {
                VertifyMesUser();
            }

            TipLabel.Text = "待机中";
            TipLabel.ForeColor = Color.Black;

            //状态灯显示
            Task taskProcess_Light = new Task(Process_Light);
            taskProcess_Light.Start();

            //读取生产信息
            Task taskReadProductInfo = new Task(Process_ReadProductInfo);
            taskReadProductInfo.Start();

            //读取条码
            Task taskReadBarCode = new Task(Process_ReadBarCode);
            taskReadBarCode.Start();

            //读取生产数据
            Task taskReadProductData = new Task(Process_ReadProductData);
            taskReadProductData.Start();

            //读取实时值数据
            Task taskReadRealTimeData = new Task(Process_ReadRealTimeData);
            taskReadRealTimeData.Start();

        }


        //分配权限
        public void DistributionAccess()
        {
            switch (access)
            {
                //操作员
                case 1:
                    this.tabPage1.Parent = this.uiTabControlMenu1;
                    this.tabPage2.Parent = this.uiTabControlMenu1;
                    this.tabPage3.Parent = this.uiTabControlMenu1;
                    this.tabPage4.Parent = null;
                    this.tabPage5.Parent = null;
                    this.tabPage6.Parent = this.uiTabControlMenu1;
                    break;
                //质量工程师
                case 2:
                    this.tabPage1.Parent = this.uiTabControlMenu1;
                    this.tabPage2.Parent = this.uiTabControlMenu1;
                    this.tabPage3.Parent = this.uiTabControlMenu1;
                    this.tabPage4.Parent = this.uiTabControlMenu1;
                    this.tabPage5.Parent = null;
                    this.tabPage6.Parent = this.uiTabControlMenu1;
                    break;
                //设备工程师
                case 3:
                    this.tabPage1.Parent = this.uiTabControlMenu1;
                    this.tabPage2.Parent = this.uiTabControlMenu1;
                    this.tabPage3.Parent = this.uiTabControlMenu1;
                    this.tabPage4.Parent = this.uiTabControlMenu1;
                    this.tabPage5.Parent = null;
                    this.tabPage6.Parent = this.uiTabControlMenu1;
                    break;
                //管理员
                case 4:
                    this.tabPage1.Parent = this.uiTabControlMenu1;
                    this.tabPage2.Parent = this.uiTabControlMenu1;
                    this.tabPage3.Parent = this.uiTabControlMenu1;
                    this.tabPage4.Parent = this.uiTabControlMenu1;
                    this.tabPage5.Parent = this.uiTabControlMenu1;
                    this.tabPage6.Parent = this.uiTabControlMenu1;
                    break;
                //开发者
                case 5:
                    this.tabPage1.Parent = this.uiTabControlMenu1;
                    this.tabPage2.Parent = this.uiTabControlMenu1;
                    this.tabPage3.Parent = this.uiTabControlMenu1;
                    this.tabPage4.Parent = this.uiTabControlMenu1;
                    this.tabPage5.Parent = this.uiTabControlMenu1;
                    this.tabPage6.Parent = this.uiTabControlMenu1;
                    break;
                default:
                    this.tabPage1.Parent = this.uiTabControlMenu1;
                    this.tabPage2.Parent = this.uiTabControlMenu1;
                    this.tabPage3.Parent = this.uiTabControlMenu1;
                    this.tabPage4.Parent = null;
                    this.tabPage5.Parent = null;
                    this.tabPage6.Parent = this.uiTabControlMenu1;
                    break;
            }


        }


        #region 运行界面

        public void InitOperationScreen()
        {
            //生产信息初始化
            InitProductInformation();

            //生产数据表格初始化
            InitProductData();

            //实时显示数据表格初始化
            InitRealTimeData();

            //记录数据表格初始化
            InitRecordData();
        }

        DataTable formulaInfoDataTable;
        DataTable systemSetDataTable;
        string barCodeVertify = "";
        public void InitProductInformation()
        {
            //当前时间
            InitializeTimer();

            //当前用户
            UserNameTextBox.Text = username;

            //工单与设备名称
            string sql = "SELECT DeviceName,ToolName FROM systemset where id='1';";
            systemSetDataTable = RepositoryFactory.BaseRepository("connectionstring").GetDataTable(sql);
            if (systemSetDataTable.Rows.Count > 0)
            {
                ProductToolTextBox.Text = systemSetDataTable.Rows[0]["ToolName"].ToString();
                DeviceNameLabel.Text = systemSetDataTable.Rows[0]["DeviceName"].ToString();
            }
            else
            {

            }


            //产品型号
            string sql2 = "SELECT * FROM formulainfo;";
            formulaInfoDataTable = RepositoryFactory.BaseRepository("connectionstring").GetDataTable(sql2);
            if (formulaInfoDataTable.Rows.Count > 0)
            {
                for (int i = 0; i < formulaInfoDataTable.Rows.Count; i++)
                {
                    FormulaComboBox.Items.Add(formulaInfoDataTable.Rows[i]["formulaName"].ToString());
                }
                FormulaComboBox.SelectedIndex = 0;
                barCodeVertify = formulaInfoDataTable.Rows[0]["Vertify"].ToString();
            }
            else
            {

            }
            FormulaShowflag++;

        }
        private System.Windows.Forms.Timer CurrentTimer;  // 用于实时更新时间
        private void InitializeTimer()
        {
            CurrentTimer = new System.Windows.Forms.Timer();
            CurrentTimer.Interval = 1000;
            CurrentTimer.Tick += CurrentTimer_Tick;
            CurrentTimer.Start();
        }
        private void CurrentTimer_Tick(object sender, EventArgs e)
        {
            CurrentTimeLabel.Text = DateTime.Now.ToString();
        }

        //切换配方
        int FormulaShowflag = 0;
        private void FormulaComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FormulaShowflag > 0)
            {
                if (MessageBox.Show("是否确定切换配方", "生产操作", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    int index = FormulaComboBox.SelectedIndex;
                    barCodeVertify = formulaInfoDataTable.Rows[index]["Vertify"].ToString();
                    //MessageBox.Show(barCodeVertify);
                }
            }



            //string selectedOption = FormulaComboBox.SelectedItem.ToString();
            //MessageBox.Show(selectedOption);
        }

        //添加或切换工单
        private void SwitchAddToolButton_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                Invoke(new Action(() =>
                {
                    RunStatusLabel.Text = "请输入工单ID！";
                    RunStatusLabel.ForeColor = Color.Red;

                    FTool fTool = new FTool();
                    fTool.MdiParent = this.ParentForm;
                    fTool.ToolEvent += (toolID) =>
                    {
                        ProductToolTextBox.Text = toolID;
                    };
                    fTool.ShowDialog();

                    RunStatusLabel.Text = "请继续生产";
                    RunStatusLabel.ForeColor = Color.Green;
                }));
            });
        }

        DataTable productPointDataTable = new DataTable();

        public void InitProductData()
        {
            string sql = "select name as'名称',point as'值' from productpoint;";
            productPointDataTable = RepositoryFactory.BaseRepository("connectionstring").GetDataTable(sql);
            ProductDataGridView.DataSource = productPointDataTable;

            //用于读取数据
            readProductInfoDataTable = productPointDataTable;
            productPointStartPosition = productPointDataTable.Rows[0]["值"].ToString();
            readProductInfoDataTableLength = readProductInfoDataTable.Rows.Count.ToString();
        }

        DataTable realTimeDataPointDataTable;
        DataTable realTimeDataTable;
        public void InitRealTimeData()
        {
            string sql = "SELECT * FROM realtimedata;";
            realTimeDataPointDataTable = RepositoryFactory.BaseRepository("connectionstring").GetDataTable(sql);

            //不能这样写 realTimeDataTable = realTimeDataPointDataTable，对新表的操作会同时影响另一个表
            //需要加上copy方法
            realTimeDataTable = realTimeDataPointDataTable.Copy();
            //方便更新数据
            RealTimeDataGridView.DataSource = realTimeDataTable;
        }


        List<string> BoardNameList = new List<string>();
        public void InitRecordData()
        {
            BoardNameList.Add("序号");         // 序号
            BoardNameList.Add("产品条码");     // 产品条码
            BoardNameList.Add("产品结果");     // 产品结果
            BoardNameList.Add("生产型号");     // 产品编号
            BoardNameList.Add("工单号");     // 产品编号
            BoardNameList.Add("操作员");       // 操作员
            BoardNameList.Add("上传状态");     // 上传状态
            BoardNameList.Add("生产时间");     // 测试时间

            if (realTimeDataPointDataTable.Rows.Count > 0)
            {
                for (int i = 0; i < realTimeDataPointDataTable.Rows.Count; i++)
                {
                    BoardNameList.Add(realTimeDataPointDataTable.Rows[i]["测试项目"].ToString() + "结果");
                }
            }


            for (int i = 0; i < BoardNameList.Count; i++)
            {
                //添加一列
                RecordDataGridView.Columns.Add(new DataGridViewTextBoxColumn());
                //设置列自适应宽度
                RecordDataGridView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                //设置列标题
                RecordDataGridView.Columns[i].HeaderText = BoardNameList[i];
            }

        }

        bool isRunning = true;
        bool isPLCConnected = false;
        bool isMesConnected = false;
        bool isBoardConnected = false;
        public void Process_Light()
        {
            while (isRunning)
            {
                this.BeginInvoke(new Action(() =>
                {

                    if (isPLCConnected)
                    {
                        PLCLight.State = UILightState.On;
                    }
                    else
                    {
                        PLCLight.State = UILightState.Off;
                    }

                    if (isMesConnected)
                    {
                        MESLight.State = UILightState.On;
                    }
                    else
                    {
                        MESLight.State = UILightState.Off;
                    }

                    if (isBoardConnected)
                    {
                        BoardLight.State = UILightState.On;
                    }
                    else
                    {
                        BoardLight.State = UILightState.Off;
                    }


                })).AsyncWaitHandle.WaitOne();


                Thread.Sleep(3000);
            }
        }


        bool isReadProductInfoFlag = true;
        ushort[] readMaxMinDataRegisterBuffer;
        DataTable readProductInfoDataTable;
        string productPointStartPosition = "";
        string readProductInfoDataTableLength = "";
        public void Process_ReadProductInfo()
        {
            if (isPLCConnected)
            {
                while (isReadProductInfoFlag)
                {
                    //读取更新数据
                    Invoke(new Action(() =>
                    {
                        readMaxMinDataRegisterBuffer = modbusMaster.ReadHoldingRegisters(byte.Parse("1"), ushort.Parse(productPointStartPosition), ushort.Parse(readProductInfoDataTableLength));
                        for (int i = 0; i < readProductInfoDataTable.Rows.Count; i++)
                        {
                            readProductInfoDataTable.Rows[i]["值"] = readMaxMinDataRegisterBuffer[i].ToString();
                        }
                    }));

                    Thread.Sleep(3000);
                }

            }

        }

        bool isReadBarCodeFlag = true;
        public void Process_ReadBarCode()
        {
            if (isPLCConnected)
            {
                while (isReadBarCodeFlag)
                {
                    string tiggerValue = ReadModbusData("1", generalPointDataTable.Rows[0]["是否读取条码"].ToString(), "1");

                    //如果tiggerValue值为1触发读条码
                    if (tiggerValue == "1")
                    {
                        ReadBarCode();
                    }

                    Thread.Sleep(200);
                }


                
            }
        }

        string barCodeValue;
        public void ReadBarCode()
        {
            Invoke(new Action(() =>
            {
                LogProductMsg("准备读取条码");
                RunStatusLabel.Text = "读取条码中";
                RunStatusLabel.ForeColor = Color.Black;

                //读取条码
                barCodeValue = ReadModbusData("1", generalPointDataTable.Rows[0]["条码点位"].ToString(), generalPointDataTable.Rows[0]["条码长度"].ToString());
                ProductBarCodeTextBox.Text = barCodeValue;
                LogProductMsg("读取条码值为:" + barCodeValue);

                

                //判断条码是否为空
                if (string.IsNullOrWhiteSpace(barCodeValue))
                {
                    TipLabel.ForeColor = Color.Red;
                    TipLabel.Text = "未获取到条码";
                    LogProductMsg("未获取到条码");

                    //写失败返回
                    WriteReturn("1", generalPointDataTable.Rows[0]["条码返回"].ToString(),"0");
                    return;
                }

                //条码验证
                if (IsBarCodeVertifyCheckBox.Checked == false)
                {
                    //本地查询历史数据验证
                    if(IsHistoryDataVertifyCheckBox.Checked == false)
                    {
                        string selectSql = "SELECT * FROM history_data where 产品条码='"+ barCodeValue + "'";
                        //屏蔽本地NG结果历史数据验证
                        if(IsNGHistoryDataVertifyCheckBox.Checked == false)
                        {
                            selectSql += " and 产品结果='OK'";
                        }
                        selectSql += ";";

                        DataTable selectReusltDataTable = RepositoryFactory.BaseRepository("connectionstring").GetDataTable(selectSql);
                        if (selectReusltDataTable.Rows.Count > 0)
                        {
                            ProductBarCodeTextBox.ForeColor = Color.Red;
                            TipLabel.ForeColor = Color.Red;
                            TipLabel.Text = "条码重复，请重新扫描！";
                            LogProductMsg("条码重复，请重新扫描！");

                            //写失败返回
                            WriteReturn("1", generalPointDataTable.Rows[0]["条码返回"].ToString(), "0");
                            return;
                        }
                    }

                    //本地条码验证（条码内容是否包含验证规则）
                    if (!barCodeValue.Contains(barCodeVertify))
                    {
                        ProductBarCodeTextBox.ForeColor = Color.Red;
                        TipLabel.ForeColor = Color.Green;
                        TipLabel.Text = "条码验证失败";

                        WriteReturn("1", generalPointDataTable.Rows[0]["条码返回"].ToString(), "0");
                        return;
                    }
                    
                }

                //判断是否打开MES，MES是否连接
                bool barCodeMESVertifyResult = false;
                if (MESSwitch.Active == true && isMesConnected)
                {
                    // 上传MES进行条码验证

                    if (barCodeMESVertifyResult)
                    {
                        TipLabel.ForeColor = Color.Green;
                        TipLabel.Text = "条码验证通过";
                        //写成功返回
                        WriteReturn("1", generalPointDataTable.Rows[0]["条码返回"].ToString(), "0");
                    }
                    else
                    {
                        ProductBarCodeTextBox.ForeColor = Color.Red;
                        TipLabel.ForeColor = Color.Green;
                        TipLabel.Text = "条码验证失败";
                        //写失败返回
                        WriteReturn("1", generalPointDataTable.Rows[0]["条码返回"].ToString(), "0");
                    }

                }
                else
                {
                    TipLabel.ForeColor = Color.Green;
                    TipLabel.Text = "条码验证通过";
                    //写成功返回
                    WriteReturn("1", generalPointDataTable.Rows[0]["条码返回"].ToString(), "0");
                }

                RunStatusLabel.Text = "扫码完成";
                RunStatusLabel.ForeColor = Color.Black;
                LogProductMsg("条码读取完成");

            }));
        }





        bool isReadProductDataFlag = true;
        public void Process_ReadProductData()
        {
            while (isPLCConnected)
            {
                while (isReadProductDataFlag)
                {
                    string tiggerValue = ReadModbusData("1", generalPointDataTable.Rows[0]["是否读生产数据"].ToString(),"1");

                    //如果tiggerValue值为1触发
                    if (tiggerValue == "1")
                    {
                        ReadProductData();
                    }

                    Thread.Sleep(200);
                }
            }
        }

        List<string> maxMinDataResultList = new List<string>();
        string productResult;
        bool UpdateDataToMESReturnFlag;
        public void ReadProductData()
        {
            Invoke(new Action(() =>
            {
                LogProductMsg("开始读取生产数据");

                RunStatusLabel.Text = "读取生产数据中";
                RunStatusLabel.ForeColor = Color.Black;

                TipLabel.ForeColor = Color.Black;
                TipLabel.Text = "请等待";

                //读取产品结果
                productResult = ReadModbusData("1", generalPointDataTable.Rows[0]["生产结果点位"].ToString(),"1");
                if (productResult == "OK")
                {
                    ProductResultLabel.Text ="OK";
                    ProductResultLabel.ForeColor = Color.White;
                    ProductResultLabel.BackColor = Color.Green;
                }
                else
                {
                    ProductResultLabel.Text = "NG";
                    ProductResultLabel.ForeColor = Color.White;
                    ProductResultLabel.BackColor = Color.Red;
                }
                LogProductMsg("产品结果为:" + productResult);


                //读取上下限数据
                if (maxMinDataResultList.Count > 0)
                {
                    maxMinDataResultList.Clear();
                }
                for (int i = 0; i < realTimeDataPointDataTable.Rows.Count; i++)
                {
                    maxMinDataResultList.Add(ReadModbusData("1", realTimeDataPointDataTable.Rows[i]["测试结果"].ToString(),"1"));
                }
                LogProductMsg("读取测试项目结果数据完成");



                //如果为在线模式且MES正常连接
                UpdateDataToMESReturnFlag = false;
                if (MESSwitch.Active && isMesConnected)
                {
                    //产品结果和数据上传
                    

                    if (UpdateDataToMESReturnFlag)
                    {
                        TipLabel.ForeColor = Color.Green;
                        TipLabel.Text = "数据上传MES成功";
                    }
                    else
                    {
                        TipLabel.ForeColor = Color.Red;
                        TipLabel.Text = "数据上传MES失败";
                    }
                }

                //插入数据的SQL语句
                string insertSql = "insert into history_data(产品条码,产品结果,生产型号,工单号,操作员,上传状态,生产时间";
                for (int i = 8; i < BoardNameList.Count; i++)
                {
                    insertSql += "," + BoardNameList[i];
                }
                insertSql += ") values('" + barCodeValue + "','" + productResult + "','" + FormulaComboBox.Text + "','" + ProductToolTextBox.Text + "','" + username + "','";
                if (UpdateDataToMESReturnFlag)
                {
                    insertSql += "成功','";
                }
                else
                {
                    insertSql += "本地','";
                }
                insertSql += DateTime.Now + "'";
                for (int i = 0; i < maxMinDataResultList.Count; i++)
                {
                    insertSql += ",'" + maxMinDataResultList[i] + "'";
                }
                insertSql += ");";


                //如果启用看板且正常连接
                if (BoardSwitch.Active && isBoardConnected)
                {
                    //发送产品结果和数据
                    SendProductDataToBoard(insertSql);
                }


                //显示结果
                if (RecordDataGridView.RowCount > 5000)
                {
                    this.RecordDataGridView.Rows.Clear();
                }

                DataGridViewRow insertRow = new DataGridViewRow();
                insertRow.CreateCells(this.RecordDataGridView);
                // 序号
                insertRow.Cells[0].Value = RecordDataGridView.Rows.Count+1;
                // 产品条码
                insertRow.Cells[1].Value = barCodeValue;
                // 产品结果
                insertRow.Cells[2].Value = productResult;

                if (productResult == "OK")
                {
                    insertRow.Cells[2].Style.BackColor = Color.Green;
                }
                else if(productResult == "NG")
                {
                    insertRow.Cells[2].Style.BackColor = Color.Red;
                }

                // 生产型号
                insertRow.Cells[3].Value = FormulaComboBox.Text;
                // 工单号
                insertRow.Cells[4].Value = ProductToolTextBox.Text;
                // 操作员
                insertRow.Cells[5].Value = username;
                // 上传状态
                insertRow.Cells[6].Value = UpdateDataToMESReturnFlag ? "成功":"本地";
                // 生产时间
                insertRow.Cells[7].Value = DateTime.Now;

                int j = 8;
                for (int i = 0; i < maxMinDataResultList.Count; i++)
                {
                    insertRow.Cells[j].Value = maxMinDataResultList[i];
                    j++;
                }
                this.RecordDataGridView.Rows.Insert(0,insertRow);


                //数据保存
                SaveProductData(insertSql);
                LogProductMsg("生产数据保存完成");

                //写返回值
                WriteReturn("1", generalPointDataTable.Rows[0]["生产结果返回"].ToString(), "0");

                TipLabel.ForeColor = Color.Black;
                TipLabel.Text = "请取下产品继续生产";
                RunStatusLabel.Text = "等待扫描条码";
                RunStatusLabel.ForeColor = Color.Green;

            }));
        }

        public void SendProductDataToBoard(string insertSql)
        {
            Task.Run(() =>
            {
                string sendMessag = "Insert#";

                sendMessag += insertSql.Replace("history_data", StationNameTextBox.Text);

                byte[] sendMessagArray = System.Text.Encoding.UTF8.GetBytes(sendMessag);
                socket.Send(sendMessagArray);
            });
        }

        public void SaveProductData(string insertSql)
        {
            Task.Run(() =>
            {
                int saveFlag = RepositoryFactory.BaseRepository("connectionstring").ExecuteSql(insertSql);
                if(saveFlag > 0)
                {
                    LogProductMsg("生产数据保存成功");
                }
                else
                {
                    LogProductMsg("生产数据保存失败");
                }

            });
        }


        bool isReadRealTimeDataFlag = true;
        public void Process_ReadRealTimeData()
        {
            if (isPLCConnected)
            {
                while (isReadRealTimeDataFlag)
                {
                    MethodInvoker readRealTimeDataMethodInvoker = new MethodInvoker(() =>
                    {
                        if (realTimeDataTable.Rows.Count > 0)
                        {
                            for (int i = 0; i < realTimeDataTable.Rows.Count; i++)
                            {
                                realTimeDataTable.Rows[i]["标准值"] = ReadModbusData("1", realTimeDataPointDataTable.Rows[i]["标准值"].ToString(), "1");
                                realTimeDataTable.Rows[i]["上限值"] = ReadModbusData("1", realTimeDataPointDataTable.Rows[i]["上限值"].ToString(), "1");
                                realTimeDataTable.Rows[i]["下限值"] = ReadModbusData("1", realTimeDataPointDataTable.Rows[i]["下限值"].ToString(), "1");
                                realTimeDataTable.Rows[i]["实际值"] = ReadModbusData("1", realTimeDataPointDataTable.Rows[i]["实际值"].ToString(), "1");
                                realTimeDataTable.Rows[i]["测试结果"] = ReadModbusData("1", realTimeDataPointDataTable.Rows[i]["测试结果"].ToString(), "1");

                                if (RealTimeDataGridView.Rows[i].Cells[6].Value.ToString() == "OK")
                                {
                                    RealTimeDataGridView.Rows[i].Cells[6].Style.BackColor = Color.Green;
                                }
                                else if (RealTimeDataGridView.Rows[i].Cells[6].Value.ToString() == "NG")
                                {
                                    RealTimeDataGridView.Rows[i].Cells[6].Style.BackColor = Color.Red;
                                }
                                else
                                {
                                    RealTimeDataGridView.Rows[i].Cells[6].Style.BackColor = Color.White;
                                }


                            }
                        }


                    });
                    this.BeginInvoke(readRealTimeDataMethodInvoker);

                    Thread.Sleep(3000);
                }

            }
        }


        public void WriteReturn(string slaveID, string position, string value)
        {
            //写成功返回/写失败返回
            ushort[] writeReturnBuffer = new ushort[] { ushort.Parse(value) };
            modbusMaster.WriteMultipleRegistersAsync(byte.Parse("1"), ushort.Parse(position), writeReturnBuffer);
            LogProductMsg("反馈验证【"+ position + "】=" + value);
        }


        //读取Modbus数据方法封装
        public string ReadModbusData(string slaveID,string StartPosition,string Length)
        {
            string value = "";
            if (StartPosition != "NO")
            {
                //用-符号分开
                string[] valueArray = StartPosition.Split('-');
                if(valueArray.Length > 1)
                {
                    ushort[] readDataRegisterBuffer = modbusMaster.ReadHoldingRegisters(byte.Parse(slaveID), ushort.Parse(valueArray[0]), ushort.Parse(Length));
                    for (int i = 0; i < readDataRegisterBuffer.Length; i++)
                    {
                        value += readDataRegisterBuffer[i].ToString();
                    }

                    switch (valueArray[1])
                    {
                        //判断结果方式
                        case "R":
                            if(value == "1")
                            {
                                value = "OK";
                            }
                            else
                            {
                                value = "NG";
                            }
                            break;
                    }
                }
                else
                {
                    ushort[] readDataRegisterBuffer = modbusMaster.ReadHoldingRegisters(byte.Parse(slaveID), ushort.Parse(StartPosition), ushort.Parse(Length));
                    for (int i = 0; i < readDataRegisterBuffer.Length; i++)
                    {
                        value += readDataRegisterBuffer[i].ToString();
                    }
                }

                
            }
            else
            {
                value = "/";
            }


            return value;

        }


        #endregion

        #region 生产日志

        private void LogProductMsg(string msg)
        {
            string hour = DateTime.Now.Hour.ToString();
            string minute = DateTime.Now.Minute.ToString();
            string second = DateTime.Now.Second.ToString();
            string millisecond = DateTime.Now.Millisecond.ToString();

            this.Invoke(new Action(() =>
            {
                if (ProductRichTextBox.TextLength > 50000)
                {
                    ProductRichTextBox.Clear();
                }
                ProductRichTextBox.AppendText($"{hour}{minute}{second}{millisecond}:{msg}\r\n");
                ProductRichTextBox.ScrollToCaret();
                SaveCsvLog(msg);
            }));
        }

        private void LogMESMsg(string msg)
        {
            string hour = DateTime.Now.Hour.ToString();
            string minute = DateTime.Now.Minute.ToString();
            string second = DateTime.Now.Second.ToString();
            string millisecond = DateTime.Now.Millisecond.ToString();

            this.Invoke(new Action(() =>
            {
                if (MesRichTextBox.TextLength > 50000)
                {
                    MesRichTextBox.Clear();
                }
                MesRichTextBox.AppendText($"{hour}{minute}{second}{millisecond}:{msg}\r\n");
                MesRichTextBox.ScrollToCaret();
                SaveCsvLog(msg);
            }));
        }

        private void LogBoardMsg(string msg)
        {
            string hour = DateTime.Now.Hour.ToString();
            string minute = DateTime.Now.Minute.ToString();
            string second = DateTime.Now.Second.ToString();
            string millisecond = DateTime.Now.Millisecond.ToString();

            this.Invoke(new Action(() =>
            {
                if (BoardRichTextBox.TextLength > 50000)
                {
                    BoardRichTextBox.Clear();
                }
                BoardRichTextBox.AppendText($"{hour}{minute}{second}{millisecond}:{msg}\r\n");
                BoardRichTextBox.ScrollToCaret();
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
                if (System.IO.Directory.Exists("D:\\Log\\GeneralFrameSystem") == false)
                {
                    System.IO.Directory.CreateDirectory("D:\\Log\\GeneralFrameSystem");
                }
                StringBuilder DataLine = new StringBuilder();

                string strT = $"{hour}时{minute}分{second}秒";

                //列标题
                // i.Append(log);
                //行数据
                DataLine.Append(strT + ":" + log);
                string FileName = $"{year}-{month}-{day}";
                string FilePath = $@"D:\Log\GeneralFrameSystem\{FileName}.txt";

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
                MessageBox.Show(ex.Message);
            }

            return;

        }

        #endregion


        #region 历史数据


        public void InitHistoryData()
        {
            StartDateTimePicker.Value = DateTime.Now.AddDays(-7);
            EndDateTimePicker.Value = DateTime.Now;

            for (int i = 0; i < formulaInfoDataTable.Rows.Count; i++)
            {
                ModelSelectComboBox.Items.Add(formulaInfoDataTable.Rows[i]["formulaName"].ToString());
            }

            string sql = "select TABLE_NAME from INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA='generalframe' and TABLE_NAME='history_data'";
            DataTable selectDT = RepositoryFactory.BaseRepository("connectionstring").GetDataTable(sql);
            if (selectDT.Rows.Count == 0)
            {
                string insertSql = "CREATE TABLE IF NOT EXISTS history_data ( ";

                for (int i = 0; i < BoardNameList.Count; i++)
                {
                    if (BoardNameList[i] =="序号")
                    {
                        insertSql += "`"+ BoardNameList[i] + "` int NOT NULL AUTO_INCREMENT PRIMARY KEY,";
                    }
                    else
                    {
                        insertSql += "`"+ BoardNameList[i] + "` varchar(255) DEFAULT NULL,";
                    }
                    
                }

                insertSql += "INDEX id_index (产品条码)," +
                    "INDEX time_index (生产时间)," +
                    "INDEX type_index (生产型号)";

                insertSql +=  ")";

                RepositoryFactory.BaseRepository("connectionstring").ExecuteSql(insertSql);

                DataTable selectDT2 = RepositoryFactory.BaseRepository("connectionstring").GetDataTable(sql);
                if (selectDT2.Rows.Count != 0)
                {
                    LogProductMsg("historyData 数据表创建成功");
                }
                
            }

        }

        //历史数据查询
        Pager pager = null;
        private void SelectDataButton_Click(object sender, EventArgs e)
        {
            string startTime = StartDateTimePicker.Value.ToString("yyyy/MM/dd HH:mm:ss");
            string endTime = EndDateTimePicker.Value.ToString("yyyy/MM/dd HH:mm:ss");

            string sql = "SELECT * FROM generalframe.history_data where 生产时间 between '"+ startTime +"' and '"+ endTime +"'";
            if(BarCodeSelectTextBox.Text.Trim() != "")
            {
                sql += " and 产品条码 ='"+ BarCodeSelectTextBox.Text.Trim() + "'";
            }
            if(ModelSelectComboBox.Text.Trim() != "")
            {
                sql += " and 生产型号='"+ ModelSelectComboBox.Text.Trim() + "'";
            }
            sql += ";";

            DataTable dataTable = RepositoryFactory.BaseRepository("connectionstring").GetDataTable(sql);

            pager = new Pager(dataTable);
            if (pager != null)
            {
                pager.Paging();
                PageLoad();
            }
        }

        //导出数据
        private void ExportButton_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Title = "保存文件";
            saveFileDialog1.Filter = "Excel文件(*.xls,*.xlsx,*.xlsm)|*.xls,*.xlsx,*.xlsm";
            saveFileDialog1.FileName = "导出数据.xls"; //设置默认另存为的名字
            if (this.saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string txtPath = this.saveFileDialog1.FileName;

                string startTime = StartDateTimePicker.Value.ToString("yyyy/MM/dd HH:mm:ss");
                string endTime = EndDateTimePicker.Value.ToString("yyyy/MM/dd HH:mm:ss");

                string sql = "SELECT * FROM generalframe.history_data where 生产时间 between '" + startTime + "' and '" + endTime + "'";
                if (BarCodeSelectTextBox.Text.Trim() != "")
                {
                    sql += " and 产品条码 ='" + BarCodeSelectTextBox.Text.Trim() + "'";
                }
                if (ModelSelectComboBox.Text.Trim() != "")
                {
                    sql += " and 生产型号='" + ModelSelectComboBox.Text.Trim() + "'";
                }
                sql += ";";

                DataTable dataTableExport = RepositoryFactory.BaseRepository("connectionstring").GetDataTable(sql);

                if (dataTableExport != null)
                {
                    bool isExport = NPOIHelper.DataTableToExcel(dataTableExport, "Sheel", txtPath);
                    if (isExport)
                    {
                        MessageBox.Show("导出成功", "数据库操作", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("导出失败", "数据库操作", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }

        //
        private void HistoryDataDataGridView_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            try
            {
                string status = HistoryDataDataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                switch (status)
                {
                    case "NG":
                        HistoryDataDataGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
                        break;
                    case "OK":
                        //dataGridViewDynamic1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Green;
                        break;
                }
            }
            catch
            {

            }

        }

        public void PageLoad()
        {
            HistoryDataDataGridView.DataSource = pager.LoadPage();
            PageSizeTextBox.Text = pager.pageSize.ToString();
            CurrentPagelabel.Text = pager.currentPage.ToString() + "/" + pager.pageCount;
            TotalPagelabel.Text = pager.recordCount.ToString();
        }

        private void FristPageButton_Click(object sender, EventArgs e)
        {
            if (pager != null)
            {
                pager.currentPage = 1;
                PageLoad();
            }
        }

        private void ForwardPageButton_Click(object sender, EventArgs e)
        {
            if (pager != null)
            {
                pager.currentPage--;
                PageLoad();
            }
        }

        private void NextPageButton_Click(object sender, EventArgs e)
        {
            if (pager != null)
            {
                pager.currentPage++;
                PageLoad();
            }
        }

        private void LastPageButton_Click(object sender, EventArgs e)
        {
            if (pager != null)
            {
                pager.currentPage = pager.pageCount;
                PageLoad();
            }
        }

        private void SkipButton_Click(object sender, EventArgs e)
        {
            if (pager != null)
            {
                int i;
                if (int.TryParse(this.SkipPageTextBox.Text, out i))
                {
                    pager.currentPage = i;
                    PageLoad();
                }
            }
        }

        private void PageSizeTextBox_TextChanged(object sender, EventArgs e)
        {
            if (pager != null)
            {
                int i;
                if (int.TryParse(this.PageSizeTextBox.Text, out i))
                {
                    if (i != 0) pager.pageSize = i;
                    pager.Paging();
                    PageLoad();
                }
            }
        }




        #endregion 



        #region 系统设置

        public void InitSystemSet()
        {
            //PLC数据初始化
            InitPLCSet();

            //系统设置初始化
            InitSystemInfo();

            //屏蔽数据初始化
            InitShieldPart();

            //测试项目点位设置
            InitTestProjectPoint();

            //通用设置
            InitGeneralPoint();

            //生产指标点位设置
            InitProductPoint();

            //配方设置
            InitFormula();

            //看板设置
            InitBoard();

            //MES设置
            InitMES();
        }

        DataTable plcSetDataTable;
        public void InitPLCSet()
        {
            string sql = "SELECT * FROM plcset where id='1';";
            plcSetDataTable = RepositoryFactory.BaseRepository("connectionstring").GetDataTable(sql);
            PLCIPTextBox.Text = plcSetDataTable.Rows[0]["PLCIP"].ToString();
            PLCPortTextBox.Text = plcSetDataTable.Rows[0]["PLCPort"].ToString();
            PLCTypeCombox.Text = plcSetDataTable.Rows[0]["PLCType"].ToString();
        }

        public void InitSystemInfo()
        {
            DeviceNameTextBox.Text = systemSetDataTable.Rows[0]["DeviceName"].ToString();
        }

        DataTable shieldDataTable;
        public void InitShieldPart()
        {
            string sql = "select * from shield where id='1'";
            shieldDataTable = RepositoryFactory.BaseRepository("connectionstring").GetDataTable(sql);

            if (shieldDataTable.Rows[0]["屏蔽本地条码验证"].ToString() == "1")
            {
                IsBarCodeVertifyCheckBox.Checked = true;
            }
            else
            {
                IsBarCodeVertifyCheckBox.Checked = false;
            }

            if (shieldDataTable.Rows[0]["屏蔽本地历史数据"].ToString() == "1")
            {
                IsHistoryDataVertifyCheckBox.Checked = true;
            }
            else
            {
                IsHistoryDataVertifyCheckBox.Checked = false;
            }

            if (shieldDataTable.Rows[0]["屏蔽本地NG历史数据"].ToString() == "1")
            {
                IsNGHistoryDataVertifyCheckBox.Checked = true;
            }
            else
            {
                IsNGHistoryDataVertifyCheckBox.Checked = false;
            }

        }

        //保存初始化设置
        private void SaveInitSettingButton_Click(object sender, EventArgs e)
        {
            string sqlSave1 = "update plcset set PLCIP='"+ PLCIPTextBox.Text.Trim() + "',PLCPort='"+ PLCPortTextBox.Text.Trim() + "',PLCType='"+ PLCTypeCombox.Text + "';";
            RepositoryFactory.BaseRepository("connectionstring").ExecuteSql(sqlSave1);

            string sqlSave2 = "update systemset set DeviceName='"+ DeviceNameTextBox.Text.Trim() + "' where id='1';";
            RepositoryFactory.BaseRepository("connectionstring").ExecuteSql(sqlSave2);

            string sqlSave3 = "update shield set ";
            if (IsBarCodeVertifyCheckBox.Checked)
            {
                sqlSave3 += "屏蔽本地条码验证='1',";
            }
            else
            {
                sqlSave3 += "屏蔽本地条码验证='0',";
            }

            if (IsHistoryDataVertifyCheckBox.Checked)
            {
                sqlSave3 += "屏蔽本地历史数据='1',";
            }
            else
            {
                sqlSave3 += "屏蔽本地历史数据='0',";
            }

            if (IsNGHistoryDataVertifyCheckBox.Checked)
            {
                sqlSave3 += "屏蔽本地NG历史数据='1'";
            }
            else
            {
                sqlSave3 += "屏蔽本地NG历史数据='0'";
            }

            sqlSave3 += " where id ='1';";
            RepositoryFactory.BaseRepository("connectionstring").ExecuteSql(sqlSave3);

            MessageBox.Show("保存成功", "数据库操作", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        public void InitTestProjectPoint()
        {
            TestProjectPointSetDataGridView.DataSource = realTimeDataPointDataTable;

            // 为 DataGridView4 添加 ButtonColumn 列，标题为操作，按钮Text默认显示为 “NO保存”
            DataGridViewButtonColumn btnNOSave = new DataGridViewButtonColumn();
            btnNOSave.HeaderText = "操作";
            btnNOSave.Text = "保存";
            btnNOSave.Name = "save1";
            btnNOSave.DefaultCellStyle.NullValue = "保存";
            TestProjectPointSetDataGridView.Columns.Add(btnNOSave);

            // 为 DataGridView4 添加 ButtonColumn 列，标题为操作，按钮Text默认显示为 “删除”
            DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
            btnDelete.HeaderText = "操作"; // 第二个按钮的标题文本
            btnDelete.Name = "delete1"; // 第二个按钮的名称
            btnDelete.DefaultCellStyle.NullValue = "删除";
            TestProjectPointSetDataGridView.Columns.Add(btnDelete);
        }

        private void TestProjectPointSetDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            { return; }
            //MessageBox.Show(e.RowIndex.ToString());

            string no = this.TestProjectPointSetDataGridView.Rows[e.RowIndex].Cells["序号"].Value.ToString();
            string project = this.TestProjectPointSetDataGridView.Rows[e.RowIndex].Cells["测试项目"].Value.ToString();
            string standard = this.TestProjectPointSetDataGridView.Rows[e.RowIndex].Cells["标准值"].Value.ToString();
            string max = this.TestProjectPointSetDataGridView.Rows[e.RowIndex].Cells["上限值"].Value.ToString();
            string min = this.TestProjectPointSetDataGridView.Rows[e.RowIndex].Cells["下限值"].Value.ToString();
            string real = this.TestProjectPointSetDataGridView.Rows[e.RowIndex].Cells["实际值"].Value.ToString();
            string result = this.TestProjectPointSetDataGridView.Rows[e.RowIndex].Cells["测试结果"].Value.ToString();

            //MessageBox.Show("序号:" + no + "\n" +
            //    "测试项目:" + project + "\n" +
            //    "标准值:" + stantard + "\n" +
            //    "上限值:" + max + "\n" +
            //    "下限值:" + min + "\n" +
            //    "实际值:" + real + "\n" +
            //    "测试结果:" + result + "\n" );
            //return;
            bool flag = false;
            if (TestProjectPointSetDataGridView.Columns[e.ColumnIndex].Name == "save1")
            {
                flag = true;
                string finSql = "SELECT * FROM realtimedata where 序号='" + no + "';";
                DataTable findDataTable = RepositoryFactory.BaseRepository("connectionstring").GetDataTable(finSql);
                //修改
                if (findDataTable.Rows.Count > 0)
                {
                    string updateSql = "update realtimedata set 测试项目='"+ project +"',标准值='"+ standard +"',上限值='"+ max +"',下限值='"+ min +"',实际值='"+ real +"',测试结果='"+ result +"' where 序号='"+ no +"';";
                    int updateResult = RepositoryFactory.BaseRepository("connectionstring").ExecuteSql(updateSql);
                    if (updateResult > 0)
                    {
                        MessageBox.Show("修改成功", "数据库操作", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                //添加
                else
                {
                    int insertID = TestProjectPointSetDataGridView.Rows.Count + 1;
                    string insertSql = "insert into realtimedata values("+ no +",'"+ project +"','"+ standard +"','"+ max +"','"+ min +"','"+ real +"','"+ result +"');";
                    int insertResult = RepositoryFactory.BaseRepository("connectionstring").ExecuteSql(insertSql);
                    if (insertResult > 0)
                    {
                        MessageBox.Show("添加成功", "数据库操作", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            }

            if (TestProjectPointSetDataGridView.Columns[e.ColumnIndex].Name == "delete1")
            {
                flag = true;
                string deleteSql = "delete from realtimedata where 序号='" + no + "';";
                int deleteResult = RepositoryFactory.BaseRepository("connectionstring").ExecuteSql(deleteSql);
                if (deleteResult > 0)
                {
                    MessageBox.Show("删除成功", "数据库操作", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


            }


            //刷新
            if (flag)
            {
                string refreshSql = "SELECT * FROM realtimedata;";
                realTimeDataPointDataTable = RepositoryFactory.BaseRepository("connectionstring").GetDataTable(refreshSql);
                if (realTimeDataPointDataTable.Rows.Count > 0)
                {
                    TestProjectPointSetDataGridView.DataSource = realTimeDataPointDataTable;
                }
            }

        }

        DataTable generalPointDataTable;
        public void InitGeneralPoint()
        {
            string sql = "SELECT * FROM generalpoint;";
            generalPointDataTable = RepositoryFactory.BaseRepository("connectionstring").GetDataTable(sql);
            GeneralPointSetDataGridView.DataSource = generalPointDataTable;

            // 为 DataGridView4 添加 ButtonColumn 列，标题为操作，按钮Text默认显示为 “NO保存”
            DataGridViewButtonColumn btnNOSave = new DataGridViewButtonColumn();
            btnNOSave.HeaderText = "操作";
            btnNOSave.Text = "保存";
            btnNOSave.Name = "save2";
            btnNOSave.DefaultCellStyle.NullValue = "保存";
            GeneralPointSetDataGridView.Columns.Add(btnNOSave);

            // 为 DataGridView4 添加 ButtonColumn 列，标题为操作，按钮Text默认显示为 “删除”
            DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
            btnDelete.HeaderText = "操作"; // 第二个按钮的标题文本
            btnDelete.Name = "delete2"; // 第二个按钮的名称
            btnDelete.DefaultCellStyle.NullValue = "删除";
            GeneralPointSetDataGridView.Columns.Add(btnDelete);
        }

        private void GeneralPointSetDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            { return; }
            //MessageBox.Show(e.RowIndex.ToString());

            string no = this.GeneralPointSetDataGridView.Rows[e.RowIndex].Cells["序号"].Value.ToString();
            string isReadBarCode = this.GeneralPointSetDataGridView.Rows[e.RowIndex].Cells["是否读取条码"].Value.ToString();
            string barCodePoint = this.GeneralPointSetDataGridView.Rows[e.RowIndex].Cells["条码点位"].Value.ToString();
            string barCodeLength = this.GeneralPointSetDataGridView.Rows[e.RowIndex].Cells["条码长度"].Value.ToString();
            string barCodeReturn = this.GeneralPointSetDataGridView.Rows[e.RowIndex].Cells["条码返回"].Value.ToString();
            string isReadData = this.GeneralPointSetDataGridView.Rows[e.RowIndex].Cells["是否读生产数据"].Value.ToString();
            string resultPoint = this.GeneralPointSetDataGridView.Rows[e.RowIndex].Cells["生产结果点位"].Value.ToString();
            string resultReturn = this.GeneralPointSetDataGridView.Rows[e.RowIndex].Cells["生产结果返回"].Value.ToString();

            //MessageBox.Show("序号:" + no + "\n" +
            //    "测试项目:" + project + "\n" +
            //    "标准值:" + stantard + "\n" +
            //    "上限值:" + max + "\n" +
            //    "下限值:" + min + "\n" +
            //    "实际值:" + real + "\n" +
            //    "测试结果:" + result + "\n" );
            //return;

            bool flag= false;
            if (GeneralPointSetDataGridView.Columns[e.ColumnIndex].Name == "save2")
            {
                flag = true;
                string finSql = "SELECT * FROM generalpoint where 序号='" + no + "';";
                DataTable findDataTable = RepositoryFactory.BaseRepository("connectionstring").GetDataTable(finSql);
                //修改
                if (findDataTable.Rows.Count > 0)
                {
                    string updateSql = "update generalpoint set 是否读取条码='" + isReadBarCode + "',条码点位='" + barCodePoint + "',条码长度='" + barCodeLength + "',条码返回='" + barCodeReturn + "',是否读生产数据='" + isReadData + "',生产结果点位='" + resultPoint + "' ,生产结果返回='" + resultReturn + "' where 序号='" + no + "';";
                    int updateResult = RepositoryFactory.BaseRepository("connectionstring").ExecuteSql(updateSql);
                    if (updateResult > 0)
                    {
                        MessageBox.Show("修改成功", "数据库操作", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                //添加
                else
                {
                    int insertID = GeneralPointSetDataGridView.Rows.Count + 1;
                    string insertSql = "insert into generalpoint values(" + no + ",'" + isReadBarCode + "','" + barCodePoint + "','" + barCodeLength + "','" + barCodeReturn + "','" + isReadData + "','" + resultPoint + "','"+ resultReturn +"');";
                    int insertResult = RepositoryFactory.BaseRepository("connectionstring").ExecuteSql(insertSql);
                    if (insertResult > 0)
                    {
                        MessageBox.Show("添加成功", "数据库操作", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            }

            if (GeneralPointSetDataGridView.Columns[e.ColumnIndex].Name == "delete2")
            {
                flag = true;
                string deleteSql = "delete from generalpoint where 序号='" + no + "';";
                int deleteResult = RepositoryFactory.BaseRepository("connectionstring").ExecuteSql(deleteSql);
                if (deleteResult > 0)
                {
                    MessageBox.Show("删除成功", "数据库操作", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


            }


            //刷新
            if (flag)
            {
                string refreshSql = "SELECT * FROM generalpoint;";
                generalPointDataTable = RepositoryFactory.BaseRepository("connectionstring").GetDataTable(refreshSql);
                if (generalPointDataTable.Rows.Count > 0)
                {
                    GeneralPointSetDataGridView.DataSource = generalPointDataTable;
                }
            }

        }

        DataTable productPointDataTableSet = new DataTable();
        public void InitProductPoint()
        {
            string sql = "select * from productpoint;";
            productPointDataTableSet = RepositoryFactory.BaseRepository("connectionstring").GetDataTable(sql);
            if (productPointDataTableSet.Rows.Count > 0)
            {
                ProductPointSetDataGridView.DataSource = productPointDataTableSet;
            }

            // 为 DataGridView4 添加 ButtonColumn 列，标题为操作，按钮Text默认显示为 “NO保存”
            DataGridViewButtonColumn btnNOSave = new DataGridViewButtonColumn();
            btnNOSave.HeaderText = "操作";
            btnNOSave.Text = "保存";
            btnNOSave.Name = "save3";
            btnNOSave.DefaultCellStyle.NullValue = "保存";
            ProductPointSetDataGridView.Columns.Add(btnNOSave);

            // 为 DataGridView4 添加 ButtonColumn 列，标题为操作，按钮Text默认显示为 “删除”
            DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
            btnDelete.HeaderText = "操作"; // 第二个按钮的标题文本
            btnDelete.Name = "delete3"; // 第二个按钮的名称
            btnDelete.DefaultCellStyle.NullValue = "删除";
            ProductPointSetDataGridView.Columns.Add(btnDelete);
        }

        private void ProductPointSetDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            { return; }
            //MessageBox.Show(e.RowIndex.ToString());

            string id = this.ProductPointSetDataGridView.Rows[e.RowIndex].Cells["id"].Value.ToString();
            string name = this.ProductPointSetDataGridView.Rows[e.RowIndex].Cells["name"].Value.ToString();
            string point = this.ProductPointSetDataGridView.Rows[e.RowIndex].Cells["point"].Value.ToString();
            
            bool flag = false;
            if (ProductPointSetDataGridView.Columns[e.ColumnIndex].Name == "save3")
            {
                flag = true;
                string finSql = "SELECT * FROM productpoint where id='" + id + "';";
                DataTable findDataTable = RepositoryFactory.BaseRepository("connectionstring").GetDataTable(finSql);
                //修改
                if (findDataTable.Rows.Count > 0)
                {
                    string updateSql = "update productpoint set name='" + name + "', point='" + point + "' where id='" + id + "';";
                    int updateResult = RepositoryFactory.BaseRepository("connectionstring").ExecuteSql(updateSql);
                    if (updateResult > 0)
                    {
                        MessageBox.Show("修改成功", "数据库操作", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                //添加
                else
                {
                    int insertID = ProductPointSetDataGridView.Rows.Count + 1;
                    string insertSql = "insert into productpoint values("+ insertID +",'"+ name +"','"+ point +"');";
                    int insertResult = RepositoryFactory.BaseRepository("connectionstring").ExecuteSql(insertSql);
                    if (insertResult > 0)
                    {
                        MessageBox.Show("添加成功", "数据库操作", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            }

            if (ProductPointSetDataGridView.Columns[e.ColumnIndex].Name == "delete3")
            {
                flag = true;
                string deleteSql = "delete from productpoint where id='" + id + "';";
                int deleteResult = RepositoryFactory.BaseRepository("connectionstring").ExecuteSql(deleteSql);
                if (deleteResult > 0)
                {
                    MessageBox.Show("删除成功", "数据库操作", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


            }


            //刷新
            if (flag)
            {
                string refreshSql = "select * from productpoint;";
                productPointDataTableSet = RepositoryFactory.BaseRepository("connectionstring").GetDataTable(refreshSql);
                if (productPointDataTableSet.Rows.Count > 0)
                {
                    ProductPointSetDataGridView.DataSource = productPointDataTableSet;
                }
            }

        }

        public void InitFormula()
        {
            if (formulaInfoDataTable.Rows.Count > 0)
            {
                FormulaSetDataGridView.DataSource= formulaInfoDataTable;
            }

            // 为 DataGridView4 添加 ButtonColumn 列，标题为操作，按钮Text默认显示为 “NO保存”
            DataGridViewButtonColumn btnNOSave = new DataGridViewButtonColumn();
            btnNOSave.HeaderText = "操作";
            btnNOSave.Text = "保存";
            btnNOSave.Name = "save4";
            btnNOSave.DefaultCellStyle.NullValue = "保存";
            FormulaSetDataGridView.Columns.Add(btnNOSave);

            // 为 DataGridView4 添加 ButtonColumn 列，标题为操作，按钮Text默认显示为 “删除”
            DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
            btnDelete.HeaderText = "操作"; // 第二个按钮的标题文本
            btnDelete.Name = "delete4"; // 第二个按钮的名称
            btnDelete.DefaultCellStyle.NullValue = "删除";
            FormulaSetDataGridView.Columns.Add(btnDelete);
        }

        private void FormulaSetDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            { return; }
            //MessageBox.Show(e.RowIndex.ToString());

            string id = this.FormulaSetDataGridView.Rows[e.RowIndex].Cells["id"].Value.ToString();
            string formulaName = this.FormulaSetDataGridView.Rows[e.RowIndex].Cells["formulaName"].Value.ToString();
            string Vertify = this.FormulaSetDataGridView.Rows[e.RowIndex].Cells["Vertify"].Value.ToString();
            //MessageBox.Show("id:" + id +"\n"+
            //    "formulaName:" + formulaName + "\n"+
            //    "Vertify:" + Vertify + "\n");

            bool flag = false;
            if (FormulaSetDataGridView.Columns[e.ColumnIndex].Name == "save4")
            {
                flag = true;
                string finSql = "SELECT * FROM generalframe.formulainfo where id='"+ id +"';";
                DataTable findDataTable = RepositoryFactory.BaseRepository("connectionstring").GetDataTable(finSql);
                //修改
                if (findDataTable.Rows.Count > 0)
                {
                    string updateSql = "update formulainfo set formulaName='"+ formulaName +"',Vertify='"+ Vertify +"' where id='"+ id +"';";
                    int updateResult = RepositoryFactory.BaseRepository("connectionstring").ExecuteSql(updateSql);
                    if(updateResult > 0)
                    {
                        MessageBox.Show("修改成功","数据库操作",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                }
                //添加
                else
                {
                    int insertID = FormulaSetDataGridView.Rows.Count + 1;
                    string insertSql = "insert into formulainfo (id,formulaName,Vertify) values("+ insertID +",'"+ formulaName +"','"+ Vertify +"');";
                    int insertResult = RepositoryFactory.BaseRepository("connectionstring").ExecuteSql(insertSql);
                    if (insertResult > 0)
                    {
                        MessageBox.Show("添加成功", "数据库操作", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            }

            if (FormulaSetDataGridView.Columns[e.ColumnIndex].Name == "delete4")
            {
                flag = true;
                string deleteSql = "delete from formulainfo where id='"+ id + "';";
                int deleteResult = RepositoryFactory.BaseRepository("connectionstring").ExecuteSql(deleteSql);
                if (deleteResult > 0)
                {
                    MessageBox.Show("删除成功", "数据库操作", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


            }


            //刷新
            if (flag)
            {
                string refreshSql = "SELECT * FROM formulainfo;";
                formulaInfoDataTable = RepositoryFactory.BaseRepository("connectionstring").GetDataTable(refreshSql);
                if (formulaInfoDataTable.Rows.Count > 0)
                {
                    FormulaSetDataGridView.DataSource = formulaInfoDataTable;
                }
            }



        }

        DataTable boardSetDataTable;
        public void InitBoard()
        {
            string sql = "SELECT * FROM board where id='1';";
            boardSetDataTable = RepositoryFactory.BaseRepository("connectionstring").GetDataTable(sql);

            if (boardSetDataTable.Rows[0]["isUse"].ToString() == "1")
            {
                BoardSwitch.Active = true;
            }
            else
            {
                BoardSwitch.Active = false;
            }
            BoardIPTextBox.Text = boardSetDataTable.Rows[0]["IP"].ToString();
            BoardPortTextBox.Text = boardSetDataTable.Rows[0]["Port"].ToString();
            StationIDTextBox.Text = boardSetDataTable.Rows[0]["workID"].ToString();
            StationNameTextBox.Text = boardSetDataTable.Rows[0]["workName"].ToString();
        }
        private void BoardSwitch_ActiveChanging(object sender, CancelEventArgs e)
        {
            if (!BoardSwitch.Active)
            {
                e.Cancel = !this.ShowAskDialog("是否打开看板？");
            }
            else
            {
                e.Cancel = !this.ShowAskDialog("是否关闭看板？");
            }

            
        }

        private void BoardSwitch_ValueChanged(object sender, bool value)
        {
            //MessageBox.Show(BoardSwitch.Active.ToString());
        }
        private void BoardSaveButton_Click(object sender, EventArgs e)
        {
            string sql = "update board set ";
            if (BoardSwitch.Active)
            {
                sql += "isUse ='"+ 1 +"',";
            }
            else
            {
                sql += "isUse ='"+ 0 +"',";
            }
            sql += "IP='"+ BoardIPTextBox.Text.Trim() + "',Port='"+ BoardPortTextBox.Text.Trim() +"',workID='"+ StationIDTextBox.Text.Trim() + "',workName='"+ StationNameTextBox.Text.Trim() +"' where id='1';";

            RepositoryFactory.BaseRepository("connectionstring").ExecuteSql(sql);

            MessageBox.Show("保存成功", "数据库操作", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }



        DataTable mesDataTable;
        public void InitMES()
        {
            string sql = "SELECT * FROM mes where id='1';";
            mesDataTable = RepositoryFactory.BaseRepository("connectionstring").GetDataTable(sql);

            if (mesDataTable.Rows[0]["isUse"].ToString() == "1")
            {
                MESSwitch.Active = true;
            }
            else
            {
                MESSwitch.Active = false;
            }
            MESIPTextBox.Text = mesDataTable.Rows[0]["IP"].ToString();
            MESPortTextBox.Text = mesDataTable.Rows[0]["Port"].ToString();
            MESTimeOutTextBox.Text = mesDataTable.Rows[0]["timeout"].ToString();
            MESUrlTextBox.Text = mesDataTable.Rows[0]["url"].ToString();
        }

        private void MESSwitch_ActiveChanging(object sender, CancelEventArgs e)
        {
            if (!MESSwitch.Active)
            {
                e.Cancel = !this.ShowAskDialog("是否改变状态为在线？");
            }
            else
            {
                e.Cancel = !this.ShowAskDialog("是否改变状态为本地？");
            }
        }
        private void MESSwitch_ValueChanged(object sender, bool value)
        {
            //MessageBox.Show(MESSwitch.Active.ToString());
        }


        private void MESSaveButton_Click(object sender, EventArgs e)
        {
            string sql = "update mes set ";
            if (MESSwitch.Active)
            {
                sql += "isUse ='" + 1 + "',";
            }
            else
            {
                sql += "isUse ='" + 0 + "',";
            }
            sql += "IP='" + MESIPTextBox.Text.Trim() + "',Port='" + MESPortTextBox.Text.Trim() + "',timeout='"+ MESTimeOutTextBox.Text.Trim() + "',url='"+ MESUrlTextBox.Text.Trim() + "' where id='1';";

            RepositoryFactory.BaseRepository("connectionstring").ExecuteSql(sql);

            MessageBox.Show("保存成功", "数据库操作", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //实例化
        private static ModbusFactory modbusFactory;
        private static IModbusMaster modbusMaster;
        private void PLCConnectButton_Click(object sender, EventArgs e)
        {
            try
            {
                switch (PLCTypeCombox.Text) 
                {
                    case "ModbusTCP":
                        //初始化modbusFactory
                        modbusFactory = new ModbusFactory();
                        //在本地测试 所以使用回环地址,modbus协议规定端口号 502
                        modbusMaster = modbusFactory.CreateMaster(new TcpClient(PLCIPTextBox.Text, Convert.ToInt16(PLCPortTextBox.Text)));
                        //设置读取超时时间
                        modbusMaster.Transport.ReadTimeout = 2000;
                        modbusMaster.Transport.Retries = 2000;
                        isPLCConnected = true;
                        break;
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Modbus连接失败", MessageBoxButtons.OK,MessageBoxIcon.Information);
                isPLCConnected = false;
            }


            

            
        }


        Socket socket;
        private async void BoardConnectButton_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                if (BoardSwitch.Active == true)
                {
                    while (true)
                    {
                        try
                        {
                            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse(BoardIPTextBox.Text), Convert.ToInt32(BoardPortTextBox.Text));
                            socket.Connect(iPEndPoint);
                            isBoardConnected = true;
                            LogBoardMsg(BoardIPTextBox.Text + ":" + BoardPortTextBox.Text + "Connected Success");

                            if (isBoardConnected)
                            {
                                //发送心跳包
                                System.Threading.Thread sendHeartBeatThread = new System.Threading.Thread(SendHeartBeat);
                                sendHeartBeatThread.IsBackground = true;
                                sendHeartBeatThread.Start();

                                //读取消息
                                System.Threading.Thread receiveMessageThread = new System.Threading.Thread(ReceiveMessage);
                                receiveMessageThread.IsBackground = true;
                                receiveMessageThread.Start();

                                Thread.Sleep(200);
                                //发送设备名称、数据库表创建SQL语句
                                string sendStr = "Name#" + StationNameTextBox.Text;
                                sendStr += "|Create#";
                                sendStr += "CREATE TABLE `"+ StationNameTextBox.Text + "` (" +
                                    "`序号` int NOT NULL AUTO_INCREMENT," +
                                    "`产品条码` varchar(255) DEFAULT NULL," +
                                    "`产品结果` varchar(255) DEFAULT NULL," +
                                    "`生产型号` varchar(255) DEFAULT NULL," +
                                    "`工单号` varchar(255) DEFAULT NULL," +
                                    "`操作员` varchar(255) DEFAULT NULL," +
                                    "`上传状态` varchar(255) DEFAULT NULL," +
                                    "`生产时间` varchar(255) DEFAULT NULL," ;

                                if (realTimeDataPointDataTable.Rows.Count > 0)
                                {
                                    for (int i = 0; i < realTimeDataPointDataTable.Rows.Count; i++)
                                    {
                                        sendStr +="`" + realTimeDataPointDataTable.Rows[i]["测试项目"].ToString() + "结果` varchar(255) DEFAULT NULL,";
                                    }
                                }

                                sendStr += " PRIMARY KEY (`序号`)," +
                                    "KEY `id_index` (`产品条码`)," +
                                    "KEY `time_index` (`生产时间`)," +
                                    "KEY `type_index` (`生产型号`)) " +
                                    "ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci";

                                byte[] sendArray = System.Text.Encoding.UTF8.GetBytes(sendStr);
                                socket.Send(sendArray);
                                break;
                            }


                            

                        }
                        catch (Exception ex)
                        {
                            isBoardConnected = false;
                            Thread.Sleep(10000);
                            LogBoardMsg("Connected Fail:" + ex.Message);
                        }
                    }

                }
            });


        }

        // 定时发送心跳包并检测连接状态
        public async void SendHeartBeat()
        {
            await Task.Run(() =>
            {
                while (isBoardConnected)
                {
                    try
                    {
                        // 发送心跳包
                        byte[] heartbeatData = System.Text.Encoding.UTF8.GetBytes("HeartBeat");
                        socket.Send(heartbeatData);
                        Thread.Sleep(10000);
                    }
                    catch(Exception ex)
                    {
                        socket.Close();
                        LogBoardMsg("SendHeartBeat Error:" + ex.Message);

                        isBoardConnected = false;
                        BoardConnectButton_Click(null,null);
                    }
                }
            });
        }

        public async void ReceiveMessage()
        {
            await Task.Run(() =>
            {
                while (isBoardConnected)
                {
                    try
                    {
                        byte[] buffer = new byte[1024 * 1024 * 3];
                        // 实际接收到的有效字节数
                        int len = socket.Receive(buffer);
                        if (len == 0)
                        {
                            break;
                        }
                        string str = Encoding.UTF8.GetString(buffer, 0, len);
                        LogBoardMsg(socket.RemoteEndPoint.ToString() + ":" + str);
                        if(str != "OK")
                        {
                            //得到是json字符串
                            if(str.Substring(0,1) == "{")
                            {
                                MessageSendtem messageSendtem = JsonConvert.DeserializeObject<MessageSendtem>(str);
                                LogBoardMsg("改变配方:" + messageSendtem.FormulaName);
                                LogBoardMsg("改变工单:" + messageSendtem.ToolName);
                                Invoke(new Action(() =>
                                {
                                    FormulaComboBox.Text = messageSendtem.FormulaName;
                                    ProductToolTextBox.Text = messageSendtem.ToolName;
                                }));

                            }
                        }
                    }
                    catch (Exception ex)
                    {     
                        socket.Close();
                        LogBoardMsg("ReceiveMessage Error:" + ex.Message);

                        isBoardConnected = false;
                        BoardConnectButton_Click(null, null);
                    }
                }
            });
        }



        public void VertifyMesUser()
        {
            if (MESSwitch.Active == true)
            {
                LogMESMsg("MES设置为在线模式");
            }
        }


        #endregion





        #region 用户管理

        DataTable userDataTable;
        public void InitUserManage()
        {
            string sql = "SELECT * FROM userinfo;";
            userDataTable = RepositoryFactory.BaseRepository("connectionstring").GetDataTable(sql);
            UserDataGridView.DataSource = userDataTable;

            // 为 DataGridView4 添加 ButtonColumn 列，标题为操作，按钮Text默认显示为 “NO保存”
            DataGridViewButtonColumn btnNOSave = new DataGridViewButtonColumn();
            btnNOSave.HeaderText = "操作";
            btnNOSave.Text = "保存";
            btnNOSave.Name = "user_Save";
            btnNOSave.DefaultCellStyle.NullValue = "保存";
            UserDataGridView.Columns.Add(btnNOSave);

            // 为 DataGridView4 添加 ButtonColumn 列，标题为操作，按钮Text默认显示为 “删除”
            DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
            btnDelete.HeaderText = "操作"; // 第二个按钮的标题文本
            btnDelete.Name = "user_Delete"; // 第二个按钮的名称
            btnDelete.DefaultCellStyle.NullValue = "删除";
            UserDataGridView.Columns.Add(btnDelete);

        }

        private void UserDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            { return; }
            //MessageBox.Show(e.RowIndex.ToString());

            string id = this.UserDataGridView.Rows[e.RowIndex].Cells["id"].Value.ToString();
            string username = this.UserDataGridView.Rows[e.RowIndex].Cells["username"].Value.ToString();
            string pwd = this.UserDataGridView.Rows[e.RowIndex].Cells["pwd"].Value.ToString();
            string type = this.UserDataGridView.Rows[e.RowIndex].Cells["type"].Value.ToString();

            //MessageBox.Show("id:" + id + "\n" +
            //    "username:" + username + "\n" +
            //    "pwd:" + pwd + "\n" +
            //    "type:" + type + "\n" );
            //return;

            bool flag = false;
            if (UserDataGridView.Columns[e.ColumnIndex].Name == "user_Save")
            {
                flag = true;
                string finSql = "SELECT * FROM userinfo where id='" + id + "';";
                DataTable findDataTable = RepositoryFactory.BaseRepository("connectionstring").GetDataTable(finSql);
                //修改
                if (findDataTable.Rows.Count > 0)
                {
                    string updateSql = "update userinfo set username='"+ username +"',pwd='"+ pwd +"',type='"+ type +"' where id='"+ id +"';";
                    int updateResult = RepositoryFactory.BaseRepository("connectionstring").ExecuteSql(updateSql);
                    if (updateResult > 0)
                    {
                        MessageBox.Show("修改成功", "数据库操作", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                //添加
                else
                {
                    int insertID = userDataTable.Rows.Count + 1;
                    string insertSql = "INSERT INTO userinfo VALUES ("+ insertID +",'"+ username +"','"+ pwd +"','"+ type +"');";
                    int insertResult = RepositoryFactory.BaseRepository("connectionstring").ExecuteSql(insertSql);
                    if (insertResult > 0)
                    {
                        MessageBox.Show("添加成功", "数据库操作", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            }

            if (UserDataGridView.Columns[e.ColumnIndex].Name == "user_Delete")
            {
                flag = true;
                string deleteSql = "delete from userinfo where id='" + id + "';";
                int deleteResult = RepositoryFactory.BaseRepository("connectionstring").ExecuteSql(deleteSql);
                if (deleteResult > 0)
                {
                    MessageBox.Show("删除成功", "数据库操作", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


            }


            //刷新
            if (!flag)
            {
                string refreshSql = "SELECT * FROM userinfo;";
                userDataTable = RepositoryFactory.BaseRepository("connectionstring").GetDataTable(refreshSql);
                if (userDataTable.Rows.Count > 0)
                {
                    UserDataGridView.DataSource = userDataTable;
                }
            }

        }


        private void RefreshButton_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM userinfo";
            if (userTextBox.Text.Trim() != "")
            {
                sql += " where username='"+ userTextBox.Text.Trim() +"'";
                if (userTypeCombox.Text != "")
                {
                    sql += " and type='"+ userTypeCombox.Text +"';";
                }
            }
            else
            {
                if(userTypeCombox.Text != "")
                {
                    sql += " where type='" + userTypeCombox.Text + "'";
                }
            }

            DataTable dataTable = RepositoryFactory.BaseRepository("connectionstring").GetDataTable(sql);
            if(dataTable.Rows.Count > 0)
            {
                UserDataGridView.DataSource = dataTable;
            }
            

        }

        #endregion






        #region 数据统计

        public void InitDataStatistics()
        {
            StartDateTimePicker2.Value = DateTime.Now.AddDays(-15);
            EndDateTimePicker2.Value = DateTime.Now;

            ModeCombox.Items.Add("所有型号");
            for (int i = 0; i < formulaInfoDataTable.Rows.Count; i++)
            {
                ModeCombox.Items.Add(formulaInfoDataTable.Rows[i]["formulaName"].ToString());
            }

            //lineChart.Width = this.panel1.Width / 2;

        }



        List<string> columnNameList = new List<string>();
        List<string> OKQtyList = new List<string>();
        List<string> OKRateList = new List<string>();
        List<string> NGQtyList = new List<string>();
        List<int> TotalNumList = new List<int>();
        private void DataSelectButton_Click(object sender, EventArgs e)
        {
            columnNameList.Clear();
            OKQtyList.Clear();
            OKRateList.Clear();
            NGQtyList.Clear();
            TotalNumList.Clear();

            chart1.Series["Series4"].Points.Clear();
            chart1.Series["Series2"].Points.Clear();
            chart1.Series["Series5"].Points.Clear();

            string selectSQL = "select DATE_FORMAT(生产时间, '%Y-%m-%d') as 生产时间," +
                "SUM(CASE WHEN 产品结果 = 'OK' THEN 1 else 0 END) AS OKNum," +
                "SUM(CASE WHEN 产品结果 = 'NG' THEN 1 else 0 END) AS NGNum," +
                "count(*) as Total from history_data  where ";

            if (!string.IsNullOrEmpty(ModeCombox.Text) && ModeCombox.Text != "所有型号")
            {
                selectSQL += "生产型号='"+ ModeCombox.Text + "' and ";
            }


            string startTime = StartDateTimePicker2.Value.ToString("yyyy/MM/dd") + " 00:00:00";
            string endTime = EndDateTimePicker2.Value.ToString("yyyy/MM/dd") + " 23:59:59";

            selectSQL += "生产时间 between '"+ startTime + "' and '"+ endTime + "'";
            selectSQL += " GROUP BY DATE_FORMAT(生产时间, '%Y-%m-%d');";

            DataTable dataTableSelect = RepositoryFactory.BaseRepository("connectionstring").GetDataTable(selectSQL);

            if (dataTableSelect.Rows.Count > 0)
            {

                int OKNum, TotalNum;
                for (int i = 0; i < dataTableSelect.Rows.Count; i++)
                {
                    columnNameList.Add(dataTableSelect.Rows[i]["生产时间"].ToString());

                    int.TryParse(dataTableSelect.Rows[i]["OKNum"].ToString(), out OKNum);
                    int.TryParse(dataTableSelect.Rows[i]["Total"].ToString(), out TotalNum);

                    OKRateList.Add(((double)OKNum / TotalNum * 100).ToString("0.00"));
                    OKQtyList.Add(OKNum.ToString());
                    NGQtyList.Add(dataTableSelect.Rows[i]["NGNum"].ToString());
                    TotalNumList.Add(TotalNum);
                }


                chart1.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.NotSet; //设置网格类型为虚线
                chart1.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash; //设置网格类型为虚线
                chart1.Series[0].IsValueShownAsLabel = true;//设置显示示数

                //设置左边Y轴刻度  数量
                chart1.ChartAreas[0].AxisY.Minimum = 0;
                chart1.ChartAreas[0].AxisY.Maximum = TotalNumList.Max() < 100 ? TotalNumList.Max() + 50 : TotalNumList.Max() + 100;
                //设置右边Y轴刻度  概率
                chart1.ChartAreas[0].AxisY2.Minimum = 0;
                chart1.ChartAreas[0].AxisY2.Maximum = 100;

                chart1.ChartAreas[0].AxisX.LabelStyle.Angle = 90;

                chart1.Series["Series4"].Points.DataBindXY(columnNameList, OKQtyList); //良品数
                chart1.Series["Series2"].Points.DataBindY(OKRateList); //良率
                chart1.Series["Series5"].Points.DataBindY(NGQtyList); //不良品数
            }


        }




        #endregion

    }
}
