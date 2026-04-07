namespace DemoPrint
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.pdControl = new System.Drawing.Printing.PrintDocument();
            this.ppVControl = new System.Windows.Forms.PrintPreviewControl();
            this.ptDControl = new System.Windows.Forms.PrintDialog();
            this.spControl = new System.Windows.Forms.SplitContainer();
            this.gbContent = new System.Windows.Forms.GroupBox();
            this.L12 = new System.Windows.Forms.TextBox();
            this.L6 = new System.Windows.Forms.TextBox();
            this.L11 = new System.Windows.Forms.TextBox();
            this.L5 = new System.Windows.Forms.TextBox();
            this.L10 = new System.Windows.Forms.TextBox();
            this.L4 = new System.Windows.Forms.TextBox();
            this.L9 = new System.Windows.Forms.TextBox();
            this.L3 = new System.Windows.Forms.TextBox();
            this.L8 = new System.Windows.Forms.TextBox();
            this.L2 = new System.Windows.Forms.TextBox();
            this.L7 = new System.Windows.Forms.TextBox();
            this.L1 = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.T12 = new System.Windows.Forms.TextBox();
            this.T6 = new System.Windows.Forms.TextBox();
            this.T11 = new System.Windows.Forms.TextBox();
            this.T5 = new System.Windows.Forms.TextBox();
            this.T10 = new System.Windows.Forms.TextBox();
            this.T4 = new System.Windows.Forms.TextBox();
            this.T9 = new System.Windows.Forms.TextBox();
            this.T3 = new System.Windows.Forms.TextBox();
            this.T8 = new System.Windows.Forms.TextBox();
            this.T2 = new System.Windows.Forms.TextBox();
            this.T7 = new System.Windows.Forms.TextBox();
            this.T1 = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.gbTitle = new System.Windows.Forms.GroupBox();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.chkBold = new System.Windows.Forms.CheckBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.txtSize = new System.Windows.Forms.TextBox();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblColor = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.gbTable = new System.Windows.Forms.GroupBox();
            this.txtEnd = new System.Windows.Forms.TextBox();
            this.txtColumn = new System.Windows.Forms.TextBox();
            this.txtStart = new System.Windows.Forms.TextBox();
            this.txtRow = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.btnRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.spControl)).BeginInit();
            this.spControl.Panel1.SuspendLayout();
            this.spControl.Panel2.SuspendLayout();
            this.spControl.SuspendLayout();
            this.gbContent.SuspendLayout();
            this.gbTitle.SuspendLayout();
            this.gbTable.SuspendLayout();
            this.SuspendLayout();
            // 
            // pdControl
            // 
            this.pdControl.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.pdControl_BeginPrint);
            this.pdControl.EndPrint += new System.Drawing.Printing.PrintEventHandler(this.pdControl_EndPrint);
            this.pdControl.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.pdControl_PrintPage);
            // 
            // ppVControl
            // 
            this.ppVControl.AutoZoom = false;
            this.ppVControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ppVControl.Document = this.pdControl;
            this.ppVControl.Location = new System.Drawing.Point(0, 0);
            this.ppVControl.Name = "ppVControl";
            this.ppVControl.Size = new System.Drawing.Size(790, 284);
            this.ppVControl.TabIndex = 0;
            this.ppVControl.UseAntiAlias = true;
            this.ppVControl.Zoom = 1D;
            // 
            // ptDControl
            // 
            this.ptDControl.AllowCurrentPage = true;
            this.ptDControl.AllowSomePages = true;
            this.ptDControl.Document = this.pdControl;
            this.ptDControl.UseEXDialog = true;
            // 
            // spControl
            // 
            this.spControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spControl.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spControl.IsSplitterFixed = true;
            this.spControl.Location = new System.Drawing.Point(0, 0);
            this.spControl.Name = "spControl";
            this.spControl.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spControl.Panel1
            // 
            this.spControl.Panel1.Controls.Add(this.gbContent);
            this.spControl.Panel1.Controls.Add(this.gbTitle);
            this.spControl.Panel1.Controls.Add(this.gbTable);
            // 
            // spControl.Panel2
            // 
            this.spControl.Panel2.Controls.Add(this.ppVControl);
            this.spControl.Size = new System.Drawing.Size(790, 518);
            this.spControl.SplitterDistance = 230;
            this.spControl.TabIndex = 1;
            // 
            // gbContent
            // 
            this.gbContent.Controls.Add(this.L12);
            this.gbContent.Controls.Add(this.L6);
            this.gbContent.Controls.Add(this.L11);
            this.gbContent.Controls.Add(this.L5);
            this.gbContent.Controls.Add(this.L10);
            this.gbContent.Controls.Add(this.L4);
            this.gbContent.Controls.Add(this.L9);
            this.gbContent.Controls.Add(this.L3);
            this.gbContent.Controls.Add(this.L8);
            this.gbContent.Controls.Add(this.L2);
            this.gbContent.Controls.Add(this.L7);
            this.gbContent.Controls.Add(this.L1);
            this.gbContent.Controls.Add(this.label31);
            this.gbContent.Controls.Add(this.label19);
            this.gbContent.Controls.Add(this.label30);
            this.gbContent.Controls.Add(this.label15);
            this.gbContent.Controls.Add(this.label29);
            this.gbContent.Controls.Add(this.label11);
            this.gbContent.Controls.Add(this.label28);
            this.gbContent.Controls.Add(this.label18);
            this.gbContent.Controls.Add(this.label27);
            this.gbContent.Controls.Add(this.label14);
            this.gbContent.Controls.Add(this.label26);
            this.gbContent.Controls.Add(this.label9);
            this.gbContent.Controls.Add(this.T12);
            this.gbContent.Controls.Add(this.T6);
            this.gbContent.Controls.Add(this.T11);
            this.gbContent.Controls.Add(this.T5);
            this.gbContent.Controls.Add(this.T10);
            this.gbContent.Controls.Add(this.T4);
            this.gbContent.Controls.Add(this.T9);
            this.gbContent.Controls.Add(this.T3);
            this.gbContent.Controls.Add(this.T8);
            this.gbContent.Controls.Add(this.T2);
            this.gbContent.Controls.Add(this.T7);
            this.gbContent.Controls.Add(this.T1);
            this.gbContent.Controls.Add(this.label25);
            this.gbContent.Controls.Add(this.label17);
            this.gbContent.Controls.Add(this.label24);
            this.gbContent.Controls.Add(this.label13);
            this.gbContent.Controls.Add(this.label23);
            this.gbContent.Controls.Add(this.label10);
            this.gbContent.Controls.Add(this.label22);
            this.gbContent.Controls.Add(this.label16);
            this.gbContent.Controls.Add(this.label21);
            this.gbContent.Controls.Add(this.label12);
            this.gbContent.Controls.Add(this.label20);
            this.gbContent.Controls.Add(this.label5);
            this.gbContent.Location = new System.Drawing.Point(12, 91);
            this.gbContent.Name = "gbContent";
            this.gbContent.Size = new System.Drawing.Size(765, 136);
            this.gbContent.TabIndex = 4;
            this.gbContent.TabStop = false;
            this.gbContent.Text = "内容设置";
            // 
            // L12
            // 
            this.L12.Location = new System.Drawing.Point(695, 98);
            this.L12.Name = "L12";
            this.L12.Size = new System.Drawing.Size(52, 21);
            this.L12.TabIndex = 14;
            this.L12.Text = "(145,50)";
            // 
            // L6
            // 
            this.L6.Location = new System.Drawing.Point(420, 46);
            this.L6.Name = "L6";
            this.L6.Size = new System.Drawing.Size(52, 21);
            this.L6.TabIndex = 14;
            this.L6.Text = "(60,35)";
            // 
            // L11
            // 
            this.L11.Location = new System.Drawing.Point(695, 73);
            this.L11.Name = "L11";
            this.L11.Size = new System.Drawing.Size(52, 21);
            this.L11.TabIndex = 14;
            this.L11.Text = "(110,50)";
            // 
            // L5
            // 
            this.L5.Location = new System.Drawing.Point(420, 21);
            this.L5.Name = "L5";
            this.L5.Size = new System.Drawing.Size(52, 21);
            this.L5.TabIndex = 14;
            this.L5.Text = "(30,35)";
            // 
            // L10
            // 
            this.L10.Location = new System.Drawing.Point(695, 46);
            this.L10.Name = "L10";
            this.L10.Size = new System.Drawing.Size(52, 21);
            this.L10.TabIndex = 14;
            this.L10.Text = "(60,50)";
            // 
            // L4
            // 
            this.L4.Location = new System.Drawing.Point(171, 98);
            this.L4.Name = "L4";
            this.L4.Size = new System.Drawing.Size(52, 21);
            this.L4.TabIndex = 14;
            this.L4.Text = "(145,20)";
            // 
            // L9
            // 
            this.L9.Location = new System.Drawing.Point(695, 21);
            this.L9.Name = "L9";
            this.L9.Size = new System.Drawing.Size(52, 21);
            this.L9.TabIndex = 14;
            this.L9.Text = "(30,50)";
            // 
            // L3
            // 
            this.L3.Location = new System.Drawing.Point(171, 73);
            this.L3.Name = "L3";
            this.L3.Size = new System.Drawing.Size(52, 21);
            this.L3.TabIndex = 14;
            this.L3.Text = "(110,20)";
            // 
            // L8
            // 
            this.L8.Location = new System.Drawing.Point(420, 98);
            this.L8.Name = "L8";
            this.L8.Size = new System.Drawing.Size(52, 21);
            this.L8.TabIndex = 14;
            this.L8.Text = "(145,35)";
            // 
            // L2
            // 
            this.L2.Location = new System.Drawing.Point(171, 46);
            this.L2.Name = "L2";
            this.L2.Size = new System.Drawing.Size(52, 21);
            this.L2.TabIndex = 14;
            this.L2.Text = "(60,20)";
            // 
            // L7
            // 
            this.L7.Location = new System.Drawing.Point(420, 73);
            this.L7.Name = "L7";
            this.L7.Size = new System.Drawing.Size(52, 21);
            this.L7.TabIndex = 14;
            this.L7.Text = "(110,35)";
            // 
            // L1
            // 
            this.L1.Location = new System.Drawing.Point(171, 21);
            this.L1.Name = "L1";
            this.L1.Size = new System.Drawing.Size(52, 21);
            this.L1.TabIndex = 14;
            this.L1.Text = "(30,20)";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(645, 102);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(53, 12);
            this.label31.TabIndex = 13;
            this.label31.Text = "位置12：";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(381, 50);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(47, 12);
            this.label19.TabIndex = 13;
            this.label19.Text = "位置6：";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(645, 77);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(53, 12);
            this.label30.TabIndex = 13;
            this.label30.Text = "位置11：";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(381, 25);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(47, 12);
            this.label15.TabIndex = 13;
            this.label15.Text = "位置5：";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(645, 50);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(53, 12);
            this.label29.TabIndex = 13;
            this.label29.Text = "位置10：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(128, 102);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 12);
            this.label11.TabIndex = 13;
            this.label11.Text = "位置4：";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(651, 25);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(47, 12);
            this.label28.TabIndex = 13;
            this.label28.Text = "位置9：";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(128, 77);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(47, 12);
            this.label18.TabIndex = 13;
            this.label18.Text = "位置3：";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(381, 102);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(47, 12);
            this.label27.TabIndex = 13;
            this.label27.Text = "位置8：";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(128, 50);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(47, 12);
            this.label14.TabIndex = 13;
            this.label14.Text = "位置2：";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(381, 77);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(47, 12);
            this.label26.TabIndex = 13;
            this.label26.Text = "位置7：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(128, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 12);
            this.label9.TabIndex = 13;
            this.label9.Text = "位置1：";
            // 
            // T12
            // 
            this.T12.Location = new System.Drawing.Point(571, 98);
            this.T12.Name = "T12";
            this.T12.Size = new System.Drawing.Size(69, 21);
            this.T12.TabIndex = 12;
            this.T12.Text = "深圳XXX区";
            // 
            // T6
            // 
            this.T6.Location = new System.Drawing.Point(305, 46);
            this.T6.Name = "T6";
            this.T6.Size = new System.Drawing.Size(69, 21);
            this.T6.TabIndex = 12;
            this.T6.Text = "IT工程师";
            // 
            // T11
            // 
            this.T11.Location = new System.Drawing.Point(571, 73);
            this.T11.Name = "T11";
            this.T11.Size = new System.Drawing.Size(69, 21);
            this.T11.TabIndex = 12;
            this.T11.Text = "现住地";
            // 
            // T5
            // 
            this.T5.Location = new System.Drawing.Point(305, 21);
            this.T5.Name = "T5";
            this.T5.Size = new System.Drawing.Size(69, 21);
            this.T5.TabIndex = 12;
            this.T5.Text = "职业";
            // 
            // T10
            // 
            this.T10.Location = new System.Drawing.Point(571, 46);
            this.T10.Name = "T10";
            this.T10.Size = new System.Drawing.Size(69, 21);
            this.T10.TabIndex = 12;
            this.T10.Text = "Boy";
            // 
            // T4
            // 
            this.T4.Location = new System.Drawing.Point(55, 98);
            this.T4.Name = "T4";
            this.T4.Size = new System.Drawing.Size(69, 21);
            this.T4.TabIndex = 12;
            this.T4.Text = "25岁";
            // 
            // T9
            // 
            this.T9.Location = new System.Drawing.Point(571, 21);
            this.T9.Name = "T9";
            this.T9.Size = new System.Drawing.Size(69, 21);
            this.T9.TabIndex = 12;
            this.T9.Text = "性别";
            // 
            // T3
            // 
            this.T3.Location = new System.Drawing.Point(55, 73);
            this.T3.Name = "T3";
            this.T3.Size = new System.Drawing.Size(69, 21);
            this.T3.TabIndex = 12;
            this.T3.Text = "年龄";
            // 
            // T8
            // 
            this.T8.Location = new System.Drawing.Point(305, 98);
            this.T8.Name = "T8";
            this.T8.Size = new System.Drawing.Size(69, 21);
            this.T8.TabIndex = 12;
            this.T8.Text = "北京XXX大学";
            // 
            // T2
            // 
            this.T2.Location = new System.Drawing.Point(55, 46);
            this.T2.Name = "T2";
            this.T2.Size = new System.Drawing.Size(69, 21);
            this.T2.TabIndex = 12;
            this.T2.Text = "Alan.hsiang";
            // 
            // T7
            // 
            this.T7.Location = new System.Drawing.Point(305, 73);
            this.T7.Name = "T7";
            this.T7.Size = new System.Drawing.Size(69, 21);
            this.T7.TabIndex = 12;
            this.T7.Text = "学校";
            // 
            // T1
            // 
            this.T1.Location = new System.Drawing.Point(55, 21);
            this.T1.Name = "T1";
            this.T1.Size = new System.Drawing.Size(69, 21);
            this.T1.TabIndex = 12;
            this.T1.Text = "姓名";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(521, 102);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(53, 12);
            this.label25.TabIndex = 11;
            this.label25.Text = "文本12：";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(264, 50);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(47, 12);
            this.label17.TabIndex = 11;
            this.label17.Text = "文本6：";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(521, 77);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(53, 12);
            this.label24.TabIndex = 11;
            this.label24.Text = "文本11：";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(264, 25);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(47, 12);
            this.label13.TabIndex = 11;
            this.label13.Text = "文本5：";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(521, 50);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(53, 12);
            this.label23.TabIndex = 11;
            this.label23.Text = "文本10：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 102);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 12);
            this.label10.TabIndex = 11;
            this.label10.Text = "文本4：";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(527, 25);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(47, 12);
            this.label22.TabIndex = 11;
            this.label22.Text = "文本9：";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(10, 77);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(47, 12);
            this.label16.TabIndex = 11;
            this.label16.Text = "文本3：";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(264, 102);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(47, 12);
            this.label21.TabIndex = 11;
            this.label21.Text = "文本8：";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(10, 50);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(47, 12);
            this.label12.TabIndex = 11;
            this.label12.Text = "文本2：";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(264, 77);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(47, 12);
            this.label20.TabIndex = 11;
            this.label20.Text = "文本7：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "文本1：";
            // 
            // gbTitle
            // 
            this.gbTitle.Controls.Add(this.txtLocation);
            this.gbTitle.Controls.Add(this.label32);
            this.gbTitle.Controls.Add(this.chkBold);
            this.gbTitle.Controls.Add(this.btnRefresh);
            this.gbTitle.Controls.Add(this.btnPrint);
            this.gbTitle.Controls.Add(this.txtSize);
            this.gbTitle.Controls.Add(this.txtTitle);
            this.gbTitle.Controls.Add(this.label6);
            this.gbTitle.Controls.Add(this.lblColor);
            this.gbTitle.Controls.Add(this.label7);
            this.gbTitle.Controls.Add(this.label8);
            this.gbTitle.Location = new System.Drawing.Point(281, 4);
            this.gbTitle.Name = "gbTitle";
            this.gbTitle.Size = new System.Drawing.Size(496, 86);
            this.gbTitle.TabIndex = 3;
            this.gbTitle.TabStop = false;
            this.gbTitle.Text = "标题设置";
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(291, 51);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(69, 21);
            this.txtLocation.TabIndex = 13;
            this.txtLocation.Text = "(75,5)";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(254, 55);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(41, 12);
            this.label32.TabIndex = 12;
            this.label32.Text = "位置：";
            // 
            // chkBold
            // 
            this.chkBold.AutoSize = true;
            this.chkBold.Checked = true;
            this.chkBold.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBold.Location = new System.Drawing.Point(201, 53);
            this.chkBold.Name = "chkBold";
            this.chkBold.Size = new System.Drawing.Size(48, 16);
            this.chkBold.TabIndex = 11;
            this.chkBold.Text = "加粗";
            this.chkBold.UseVisualStyleBackColor = true;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(427, 21);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(62, 51);
            this.btnPrint.TabIndex = 0;
            this.btnPrint.Text = "打印";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // txtSize
            // 
            this.txtSize.Location = new System.Drawing.Point(43, 51);
            this.txtSize.Name = "txtSize";
            this.txtSize.Size = new System.Drawing.Size(79, 21);
            this.txtSize.TabIndex = 8;
            this.txtSize.Text = "16";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(53, 20);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(307, 21);
            this.txtTitle.TabIndex = 10;
            this.txtTitle.Text = "XXXX公司电子单据";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 4;
            this.label6.Text = "字号：";
            // 
            // lblColor
            // 
            this.lblColor.BackColor = System.Drawing.Color.Black;
            this.lblColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblColor.Location = new System.Drawing.Point(166, 54);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(15, 15);
            this.lblColor.TabIndex = 5;
            this.lblColor.Text = "C";
            this.lblColor.Click += new System.EventHandler(this.lblColor_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(128, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 5;
            this.label7.Text = "颜色：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 6;
            this.label8.Text = "文本：";
            // 
            // gbTable
            // 
            this.gbTable.Controls.Add(this.txtEnd);
            this.gbTable.Controls.Add(this.txtColumn);
            this.gbTable.Controls.Add(this.txtStart);
            this.gbTable.Controls.Add(this.txtRow);
            this.gbTable.Controls.Add(this.label4);
            this.gbTable.Controls.Add(this.label2);
            this.gbTable.Controls.Add(this.label1);
            this.gbTable.Controls.Add(this.label3);
            this.gbTable.Location = new System.Drawing.Point(12, 4);
            this.gbTable.Name = "gbTable";
            this.gbTable.Size = new System.Drawing.Size(265, 86);
            this.gbTable.TabIndex = 2;
            this.gbTable.TabStop = false;
            this.gbTable.Text = "表格设置";
            // 
            // txtEnd
            // 
            this.txtEnd.Location = new System.Drawing.Point(180, 47);
            this.txtEnd.Name = "txtEnd";
            this.txtEnd.Size = new System.Drawing.Size(69, 21);
            this.txtEnd.TabIndex = 2;
            this.txtEnd.Text = "(185,60)";
            // 
            // txtColumn
            // 
            this.txtColumn.Location = new System.Drawing.Point(57, 47);
            this.txtColumn.Name = "txtColumn";
            this.txtColumn.Size = new System.Drawing.Size(69, 21);
            this.txtColumn.TabIndex = 2;
            this.txtColumn.Text = "4";
            // 
            // txtStart
            // 
            this.txtStart.Location = new System.Drawing.Point(180, 20);
            this.txtStart.Name = "txtStart";
            this.txtStart.Size = new System.Drawing.Size(69, 21);
            this.txtStart.TabIndex = 2;
            this.txtStart.Text = "(15,15)";
            // 
            // txtRow
            // 
            this.txtRow.Location = new System.Drawing.Point(57, 20);
            this.txtRow.Name = "txtRow";
            this.txtRow.Size = new System.Drawing.Size(69, 21);
            this.txtRow.TabIndex = 2;
            this.txtRow.Text = "3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(143, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "终点：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "列数：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "行数：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(143, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "起点：";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(364, 21);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(62, 51);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 518);
            this.Controls.Add(this.spControl);
            this.Name = "MainForm";
            this.Text = "打印的小例子";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.spControl.Panel1.ResumeLayout(false);
            this.spControl.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spControl)).EndInit();
            this.spControl.ResumeLayout(false);
            this.gbContent.ResumeLayout(false);
            this.gbContent.PerformLayout();
            this.gbTitle.ResumeLayout(false);
            this.gbTitle.PerformLayout();
            this.gbTable.ResumeLayout(false);
            this.gbTable.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Drawing.Printing.PrintDocument pdControl;
        private System.Windows.Forms.PrintPreviewControl ppVControl;
        private System.Windows.Forms.PrintDialog ptDControl;
        private System.Windows.Forms.SplitContainer spControl;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.GroupBox gbTable;
        private System.Windows.Forms.TextBox txtEnd;
        private System.Windows.Forms.TextBox txtColumn;
        private System.Windows.Forms.TextBox txtStart;
        private System.Windows.Forms.TextBox txtRow;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbTitle;
        private System.Windows.Forms.TextBox txtSize;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chkBold;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.GroupBox gbContent;
        private System.Windows.Forms.TextBox L12;
        private System.Windows.Forms.TextBox L6;
        private System.Windows.Forms.TextBox L11;
        private System.Windows.Forms.TextBox L5;
        private System.Windows.Forms.TextBox L10;
        private System.Windows.Forms.TextBox L4;
        private System.Windows.Forms.TextBox L9;
        private System.Windows.Forms.TextBox L3;
        private System.Windows.Forms.TextBox L8;
        private System.Windows.Forms.TextBox L2;
        private System.Windows.Forms.TextBox L7;
        private System.Windows.Forms.TextBox L1;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox T12;
        private System.Windows.Forms.TextBox T6;
        private System.Windows.Forms.TextBox T11;
        private System.Windows.Forms.TextBox T5;
        private System.Windows.Forms.TextBox T10;
        private System.Windows.Forms.TextBox T4;
        private System.Windows.Forms.TextBox T9;
        private System.Windows.Forms.TextBox T3;
        private System.Windows.Forms.TextBox T8;
        private System.Windows.Forms.TextBox T2;
        private System.Windows.Forms.TextBox T7;
        private System.Windows.Forms.TextBox T1;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Button btnRefresh;
    }
}

