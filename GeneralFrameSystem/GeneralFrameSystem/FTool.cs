using GeneralFrameSystem.SQL;
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

namespace GeneralFrameSystem
{
    public partial class FTool : UIForm
    {
        public FTool()
        {
            InitializeComponent();
        }
        public delegate void ToolEventHandler(String str);
        public event ToolEventHandler ToolEvent;

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            string toolID = ToolIDTextBox.Text.Trim();
            if (ToolIDTextBox.Text.Length < 1)
            {
                MessageBox.Show("工单号不能为空!","输入错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            string sql = "update systemset set ToolName='"+ toolID + "' where id='1';";
            int result = RepositoryFactory.BaseRepository("connectionstring").ExecuteSql(sql);
            if (result > 0)
            {
                ToolEvent?.Invoke(toolID);
                this.Close();
            }

        }
    }
}
