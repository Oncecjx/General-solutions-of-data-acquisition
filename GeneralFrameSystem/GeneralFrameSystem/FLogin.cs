using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GeneralFrameSystem.SQL;
using GeneralFrameSystem.Model;

namespace GeneralFrameSystem
{
    public partial class FLogin : UILoginForm
    {
        public FLogin()
        {
            InitializeComponent();
        }

        private void FLogin_Load(object sender, EventArgs e)
        {
            //获取设备名称
            GetDeviceName();

            //获取用户信息
            GetUserInfo();
        }

        /// <summary>
        /// 获取设备名称
        /// </summary>
        string DeviceName;
        public void GetDeviceName()
        {
            string sql = "SELECT DeviceName from systemset where id='1'";
            DataTable dtFind = RepositoryFactory.BaseRepository("connectionstring").GetDataTable(sql);
            for (int i = 0; i < dtFind.Rows.Count; i++)
            {
                DeviceName = dtFind.Rows[i]["DeviceName"].ToString();
            }

            lblTitle.Text = DeviceName;
        }

        //获取用户信息
        List<UserInfo> userInfoList = new List<UserInfo>();
        public void GetUserInfo()
        {
            string sql = "select userName,pwd,type from userinfo";
            DataTable dataTableUser = RepositoryFactory.BaseRepository("connectionstring").GetDataTable(sql);
            for (int i = 0; i < dataTableUser.Rows.Count; i++)
            {
                UserInfo userInfo = new UserInfo();
                userInfo.userName = dataTableUser.Rows[i]["username"].ToString();
                userInfo.pwd = dataTableUser.Rows[i]["pwd"].ToString();
                userInfo.type = dataTableUser.Rows[i]["type"].ToString();
                userInfoList.Add(userInfo);
            }
        }

        //登录校验
        int access = 0;
        private bool FLogin_OnLogin(string userName, string password)
        {

            //用户名和密码验证
            if (userName != "" && password != "")
            {
                List<UserInfo> list = userInfoList.Where(x => x.userName == userName && x.pwd == password).ToList();
                if (list.Count > 0)
                {
                    //根据职位确定权限
                    switch (list[0].type)
                    {
                        //操作员
                        case "OP":
                            access = 1;
                            break;
                        //质量工程师
                        case "QE":
                            access = 2;
                            break;
                        //设备工程师
                        case "ME":
                            access = 3;
                            break;
                        //管理员
                        case "ADM":
                            access = 4;
                            break;
                        //开发者
                        case "DEV":
                            access = 5;
                            break;
                    }

                    if (access > 0)
                    {
                        this.Hide();
                        FMain fMain = new FMain();
                        //传参数
                        fMain.SetAccess(access);
                        fMain.SetUsername(userName);

                        fMain.ShowDialog();

                        return true;
                    }
                    else
                    {
                        MessageBox.Show("没有登录权限", "登录失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("用户名或密码错误", "登录失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("请输入用户名和密码", "登录失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false;
        }
    }
}
