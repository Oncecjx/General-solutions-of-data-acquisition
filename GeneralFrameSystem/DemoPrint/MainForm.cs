using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoPrint
{
    public partial class MainForm : Form
    {
        private int width_p = 200;//单位是mm

        private int height_p = 70;//单位是mm

        private int margin_lr = 2;//左右边距

        private int margin_tb = 2;//上下边距

        /// <summary>
        /// 需要打印的内容
        /// </summary>
        public List<PrintInfo> PrintInfos { get; set; }

        private PrintHelper printHelper = new PrintHelper();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            InitInfo();
            InitDocument();
        }

        private void InitInfo() {
            PrinterSettings printSetting = new PrinterSettings();
            printSetting.PrintRange = PrintRange.AllPages;

        
            int width_in = MM2Inch(width_p);
            int height_in = MM2Inch(height_p);
            PageSettings pageSetting = new PageSettings(printSetting);
            pageSetting.PaperSize = new PaperSize("customer",width_in, height_in);
            
            int margin_lr_in = MM2Inch(margin_lr);
            int margin_tb_in = MM2Inch(margin_tb);
            pageSetting.Margins = new Margins(margin_lr_in, margin_lr_in, margin_tb_in, margin_tb_in);
            this.pdControl.DefaultPageSettings = pageSetting;
        }

        private void InitDocument() {
            List<PrintInfo> lstPrintInfos = new List<PrintInfo>();
            PrintInfo p0 = new PrintInfo()
            {
                PrtType = PrintType.Table,
                PrtColor = Color.Brown,
                Row = int.Parse(this.txtRow.Text.Trim()),
                Column = int.Parse(this.txtColumn.Text.Trim()),
                Start = new Point(int.Parse(this.txtStart.Text.Trim(new char[] { '(', ')' }).Split(',')[0]), int.Parse(this.txtStart.Text.Trim(new char[] { '(', ')' }).Split(',')[1])),
                End = new Point(int.Parse(this.txtEnd.Text.Trim(new char[] { '(', ')' }).Split(',')[0]), int.Parse(this.txtEnd.Text.Trim(new char[] { '(', ')' }).Split(',')[1]))
                
            };
            lstPrintInfos.Add(p0);
            printHelper.PrintInfos = lstPrintInfos;
        }

        /// <summary>
        /// 转换毫米到百分之一英寸
        /// </summary>
        /// <param name="mm"></param>
        /// <returns></returns>
        private int MM2Inch(int mm) {
           return (int)(mm * 100.0f / 25.4f);
        }

        /// <summary>
        /// 打印开始事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pdControl_BeginPrint(object sender, PrintEventArgs e)
        {

        }

        /// <summary>
        /// 打印事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pdControl_PrintPage(object sender, PrintPageEventArgs e)
        {
            Font font = new Font("Arial", 14f, FontStyle.Regular);
            Graphics g = e.Graphics;
            g.PageScale = 1;
            g.PageUnit = GraphicsUnit.Millimeter;//单位
            //先画一个矩形
            Pen lineColor = new Pen(Color.Black, 0.2f);
            g.FillRectangle(Brushes.Linen,0,0,width_p,height_p);
            printHelper.Print(g);
        }

        /// <summary>
        /// 打印结束事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pdControl_EndPrint(object sender, PrintEventArgs e)
        {

        }


        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            //打印对话框
            if (this.ptDControl.ShowDialog() == DialogResult.OK)
            {
                this.pdControl.Print();
            }

        }

        private void lblColor_Click(object sender, EventArgs e)
        {
            ColorDialog f = new ColorDialog();
            if (f.ShowDialog() == DialogResult.OK)
            {

                this.lblColor.BackColor = f.Color;
            }
        }

        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            List<PrintInfo> lstPrintInfos = new List<PrintInfo>();
            //表格配置
            PrintInfo p0 = new PrintInfo()
            {
                PrtType = PrintType.Table,
                PrtColor = Color.Brown,
                Row = int.Parse(this.txtRow.Text.Trim()),
                Column = int.Parse(this.txtColumn.Text.Trim()),
                Start = new Point(int.Parse(this.txtStart.Text.Trim(new char[] { '(', ')' }).Split(',')[0]), int.Parse(this.txtStart.Text.Trim(new char[] { '(', ')' }).Split(',')[1])),
                End = new Point(int.Parse(this.txtEnd.Text.Trim(new char[] { '(', ')' }).Split(',')[0]), int.Parse(this.txtEnd.Text.Trim(new char[] { '(', ')' }).Split(',')[1]))

            };
            lstPrintInfos.Add(p0);
            //标题配置
            PrintInfo p1 = new PrintInfo()
            {
                PrtType = PrintType.Text,
                PrtColor = this.lblColor.BackColor,
                Content = this.txtTitle.Text.Trim(),
                Size = int.Parse(this.txtSize.Text.Trim()),
                FontStyle = chkBold.Checked ? FontStyle.Bold : FontStyle.Regular,
                Start = new Point(int.Parse(this.txtLocation.Text.Trim(new char[] { '(', ')' }).Split(',')[0]), int.Parse(this.txtLocation.Text.Trim(new char[] { '(', ')' }).Split(',')[1]))
            };
            lstPrintInfos.Add(p1);
            //内容
            TextBox[] T = new TextBox[12] { T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12 };
            TextBox[] L = new TextBox[12] { L1, L2, L3, L4, L5, L6, L7, L8, L9, L10, L11, L12 };
            for (int i = 0; i < 12; i++)
            {
                PrintInfo p = new PrintInfo()
                {
                    PrtType = PrintType.Text,
                    PrtColor = Color.Black,
                    Content = T[i].Text.Trim(),
                    Size = 12,
                    FontStyle = FontStyle.Regular,
                    Start = new Point(int.Parse(L[i].Text.Trim(new char[] { '(', ')' }).Split(',')[0]), int.Parse(L[i].Text.Trim(new char[] { '(', ')' }).Split(',')[1]))
                };
                lstPrintInfos.Add(p);
            }
            //打印时间
            PrintInfo p2 = new PrintInfo()
            {
                PrtType = PrintType.Text,
                PrtColor = this.lblColor.BackColor,
                Content = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                Size =11,
                FontStyle =FontStyle.Regular,
                Start = new Point(145,63)
            };
            lstPrintInfos.Add(p2);

            printHelper.PrintInfos = lstPrintInfos;
            this.ppVControl.InvalidatePreview();//刷新文档的预览，重新调用PrintDocument的Print方法
        }
    }
}
