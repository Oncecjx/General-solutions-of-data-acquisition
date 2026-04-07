using GeneralSystemBoard.Tool;
using GeneralSystemBoard.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Runtime.Remoting.Contexts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using LiveCharts;

namespace GeneralSystemBoard
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        long _start;
        public MainWindow()
        {
            InitializeComponent();

            DispatcherTimer timer = new DispatcherTimer();
            _start = Environment.TickCount;
            timer.Tick += timer_Click;
            timer.IsEnabled = true;
        }

        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        public void timer_Click(object sender, EventArgs e)
        {
            CurrentTimeTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }





        private void Window_ContentRendered(object sender, EventArgs e)
        {
            //设备运行状态
            GetDeviceStatusListData();
            //使用者列表
            GetUserListData();
            //报警信息
            GetAlarmInfoData();

            TodayProductNumText.Text = "31975";
            TodayProductRateText.Text = "90%";
            AProductRateText.Value = 80;
            BProductRateText.Value = 95;

            this.DataContext = new MainViewModel();

        }

        ObservableCollection<DeviceListItem> DeviceStatusList = new ObservableCollection<DeviceListItem>();
        //设备运行状态
        public void GetDeviceStatusListData()
        {
            if (DeviceStatusList.Count > 0)
            {
                DeviceStatusList.Clear();
            }

            string selectDeviceStatusSQL = "SELECT * FROM devicelist;";
            MySqlDataReader DeviceStatusReader = RepositoryFactory.BaseRepository("connectionstring").ExecuteReader(selectDeviceStatusSQL);
            int DeviceStatusListCount = 1;
            while (DeviceStatusReader.Read())
            {
                DeviceStatusList.Add(
                    new DeviceListItem
                    {
                        ID = DeviceStatusListCount.ToString(),
                        DeviceName = DeviceStatusReader["DeviceName"].ToString(),
                        Address = DeviceStatusReader["Adress"].ToString(),
                        ConnectedTime = DeviceStatusReader["ConnectedTime"].ToString(),
                        Status = DeviceStatusReader["Status"].ToString()
                    }
                );
                DeviceStatusListCount++;
            }
            DeviceStatusDG.ItemsSource = DeviceStatusList;
        }


        ObservableCollection<UserListItem> UserList = new ObservableCollection<UserListItem>();
        //使用者列表
        public void GetUserListData()
        {
            if (UserList.Count > 0)
            {
                UserList.Clear();
            }

            string selectUserSQL = "SELECT * FROM userlist;";
            MySqlDataReader UserListReader = RepositoryFactory.BaseRepository("connectionstring").ExecuteReader(selectUserSQL);
            int UserListCount = 1;
            while (UserListReader.Read())
            {
                UserList.Add(
                    new UserListItem
                    {
                        ID = UserListCount.ToString(),
                        DeviceName = UserListReader["DeviceName"].ToString(),
                        UserName = UserListReader["UserName"].ToString(),
                        ConnectedTime = UserListReader["ConnectedTime"].ToString(),
                    }
                );
                UserListCount++;
            }
            UserListDG.ItemsSource = UserList;
        }


        ObservableCollection<AlarmInfoItem> AlarmInfoList = new ObservableCollection<AlarmInfoItem>();
        //报警信息
        public void GetAlarmInfoData()
        {
            if (AlarmInfoList.Count > 0)
            {
                AlarmInfoList.Clear();
            }

            string selectAlarmSQL = "SELECT * FROM alarminfolist;";
            MySqlDataReader AlarmInfoReader = RepositoryFactory.BaseRepository("connectionstring").ExecuteReader(selectAlarmSQL);
            int AlarmInfoCount = 1;
            while (AlarmInfoReader.Read())
            {
                AlarmInfoList.Add(
                    new AlarmInfoItem
                    {
                        ID = AlarmInfoCount.ToString(),
                        DeviceName = AlarmInfoReader["DeviceName"].ToString(),
                        AlarmInfo = AlarmInfoReader["AlarmInfo"].ToString(),
                    }
                );
                AlarmInfoCount++;
            }
            AlarmInfoDG.ItemsSource = AlarmInfoList;
        }


        //数据刷新
        private void RefreshData_Click(object sender, RoutedEventArgs e)
        {
            //设备运行状态
            GetDeviceStatusListData();
            //使用者列表
            GetUserListData();
            //报警信息
            GetAlarmInfoData();

            TodayProductNumText.Text = "31976";
            TodayProductRateText.Text = "95%";
            AProductRateText.Value = 70;
            BProductRateText.Value = 90;

            this.DataContext = new MainViewModel();
        }
    }



}
