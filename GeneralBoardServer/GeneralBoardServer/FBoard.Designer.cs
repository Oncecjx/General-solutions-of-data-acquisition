namespace GeneralBoardServer
{
    partial class FBoard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FBoard));
            this.uiTabControlMenu1 = new Sunny.UI.UITabControlMenu();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.LogRichTextBox = new Sunny.UI.UIRichTextBox();
            this.ConnectedDeviceDataGridView = new System.Windows.Forms.DataGridView();
            this.uiGroupBox2 = new Sunny.UI.UIGroupBox();
            this.ServerStartButton = new System.Windows.Forms.Button();
            this.ServerStopButton = new System.Windows.Forms.Button();
            this.label42 = new System.Windows.Forms.Label();
            this.BoardIPTextBox = new System.Windows.Forms.TextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.BoardPortTextBox = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.FormulaListDataGridView = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.SwitchButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.FormulaComboBox = new System.Windows.Forms.ComboBox();
            this.ToolTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.uiGroupBox1 = new Sunny.UI.UIGroupBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.IPSaveTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.PortSaveTextBox = new System.Windows.Forms.TextBox();
            this.IsStartServer = new System.Windows.Forms.CheckBox();
            this.uiTabControlMenu1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ConnectedDeviceDataGridView)).BeginInit();
            this.uiGroupBox2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FormulaListDataGridView)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.uiGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // uiTabControlMenu1
            // 
            this.uiTabControlMenu1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.uiTabControlMenu1.Controls.Add(this.tabPage1);
            this.uiTabControlMenu1.Controls.Add(this.tabPage2);
            this.uiTabControlMenu1.Controls.Add(this.tabPage3);
            this.uiTabControlMenu1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTabControlMenu1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.uiTabControlMenu1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTabControlMenu1.ItemSize = new System.Drawing.Size(200, 60);
            this.uiTabControlMenu1.Location = new System.Drawing.Point(0, 35);
            this.uiTabControlMenu1.Multiline = true;
            this.uiTabControlMenu1.Name = "uiTabControlMenu1";
            this.uiTabControlMenu1.SelectedIndex = 0;
            this.uiTabControlMenu1.Size = new System.Drawing.Size(1277, 750);
            this.uiTabControlMenu1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.uiTabControlMenu1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.LogRichTextBox);
            this.tabPage1.Controls.Add(this.ConnectedDeviceDataGridView);
            this.tabPage1.Controls.Add(this.uiGroupBox2);
            this.tabPage1.Location = new System.Drawing.Point(201, 0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(1076, 750);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "设备状态";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // LogRichTextBox
            // 
            this.LogRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogRichTextBox.FillColor = System.Drawing.Color.White;
            this.LogRichTextBox.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LogRichTextBox.Location = new System.Drawing.Point(0, 438);
            this.LogRichTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.LogRichTextBox.MinimumSize = new System.Drawing.Size(1, 1);
            this.LogRichTextBox.Name = "LogRichTextBox";
            this.LogRichTextBox.Padding = new System.Windows.Forms.Padding(2);
            this.LogRichTextBox.ShowText = false;
            this.LogRichTextBox.Size = new System.Drawing.Size(1076, 312);
            this.LogRichTextBox.TabIndex = 85;
            this.LogRichTextBox.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ConnectedDeviceDataGridView
            // 
            this.ConnectedDeviceDataGridView.AllowUserToAddRows = false;
            this.ConnectedDeviceDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.ConnectedDeviceDataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ConnectedDeviceDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ConnectedDeviceDataGridView.Dock = System.Windows.Forms.DockStyle.Top;
            this.ConnectedDeviceDataGridView.Location = new System.Drawing.Point(0, 183);
            this.ConnectedDeviceDataGridView.Name = "ConnectedDeviceDataGridView";
            this.ConnectedDeviceDataGridView.RowHeadersVisible = false;
            this.ConnectedDeviceDataGridView.RowHeadersWidth = 51;
            this.ConnectedDeviceDataGridView.RowTemplate.Height = 27;
            this.ConnectedDeviceDataGridView.Size = new System.Drawing.Size(1076, 255);
            this.ConnectedDeviceDataGridView.TabIndex = 84;
            // 
            // uiGroupBox2
            // 
            this.uiGroupBox2.Controls.Add(this.ServerStartButton);
            this.uiGroupBox2.Controls.Add(this.ServerStopButton);
            this.uiGroupBox2.Controls.Add(this.label42);
            this.uiGroupBox2.Controls.Add(this.BoardIPTextBox);
            this.uiGroupBox2.Controls.Add(this.label40);
            this.uiGroupBox2.Controls.Add(this.BoardPortTextBox);
            this.uiGroupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiGroupBox2.FillColor = System.Drawing.Color.White;
            this.uiGroupBox2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiGroupBox2.Location = new System.Drawing.Point(0, 0);
            this.uiGroupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox2.Name = "uiGroupBox2";
            this.uiGroupBox2.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox2.Size = new System.Drawing.Size(1076, 183);
            this.uiGroupBox2.TabIndex = 83;
            this.uiGroupBox2.Text = null;
            this.uiGroupBox2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ServerStartButton
            // 
            this.ServerStartButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ServerStartButton.Location = new System.Drawing.Point(613, 66);
            this.ServerStartButton.Margin = new System.Windows.Forms.Padding(2);
            this.ServerStartButton.Name = "ServerStartButton";
            this.ServerStartButton.Size = new System.Drawing.Size(137, 69);
            this.ServerStartButton.TabIndex = 83;
            this.ServerStartButton.Text = "启动";
            this.ServerStartButton.UseVisualStyleBackColor = true;
            this.ServerStartButton.Click += new System.EventHandler(this.ServerStartButton_Click);
            // 
            // ServerStopButton
            // 
            this.ServerStopButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ServerStopButton.Location = new System.Drawing.Point(817, 66);
            this.ServerStopButton.Margin = new System.Windows.Forms.Padding(2);
            this.ServerStopButton.Name = "ServerStopButton";
            this.ServerStopButton.Size = new System.Drawing.Size(137, 69);
            this.ServerStopButton.TabIndex = 82;
            this.ServerStopButton.Text = "关闭";
            this.ServerStopButton.UseVisualStyleBackColor = true;
            this.ServerStopButton.Click += new System.EventHandler(this.ServerStopButton_Click);
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label42.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label42.Location = new System.Drawing.Point(64, 50);
            this.label42.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(57, 23);
            this.label42.TabIndex = 76;
            this.label42.Text = "IP：";
            // 
            // BoardIPTextBox
            // 
            this.BoardIPTextBox.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BoardIPTextBox.Location = new System.Drawing.Point(133, 47);
            this.BoardIPTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.BoardIPTextBox.Name = "BoardIPTextBox";
            this.BoardIPTextBox.Size = new System.Drawing.Size(324, 34);
            this.BoardIPTextBox.TabIndex = 77;
            this.BoardIPTextBox.Text = "127.0.0.1";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label40.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label40.Location = new System.Drawing.Point(42, 112);
            this.label40.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(79, 23);
            this.label40.TabIndex = 79;
            this.label40.Text = "端口：";
            // 
            // BoardPortTextBox
            // 
            this.BoardPortTextBox.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BoardPortTextBox.Location = new System.Drawing.Point(133, 109);
            this.BoardPortTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.BoardPortTextBox.Name = "BoardPortTextBox";
            this.BoardPortTextBox.Size = new System.Drawing.Size(324, 34);
            this.BoardPortTextBox.TabIndex = 78;
            this.BoardPortTextBox.Text = "303";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.FormulaListDataGridView);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(201, 0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(1076, 750);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "切换操作";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // FormulaListDataGridView
            // 
            this.FormulaListDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.FormulaListDataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.FormulaListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FormulaListDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FormulaListDataGridView.Location = new System.Drawing.Point(0, 233);
            this.FormulaListDataGridView.Name = "FormulaListDataGridView";
            this.FormulaListDataGridView.RowHeadersWidth = 51;
            this.FormulaListDataGridView.RowTemplate.Height = 27;
            this.FormulaListDataGridView.Size = new System.Drawing.Size(1076, 517);
            this.FormulaListDataGridView.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.SwitchButton);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.FormulaComboBox);
            this.groupBox2.Controls.Add(this.ToolTextBox);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1076, 233);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // SwitchButton
            // 
            this.SwitchButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.SwitchButton.Location = new System.Drawing.Point(588, 77);
            this.SwitchButton.Margin = new System.Windows.Forms.Padding(2);
            this.SwitchButton.Name = "SwitchButton";
            this.SwitchButton.Size = new System.Drawing.Size(137, 69);
            this.SwitchButton.TabIndex = 82;
            this.SwitchButton.Text = "切换";
            this.SwitchButton.UseVisualStyleBackColor = true;
            this.SwitchButton.Click += new System.EventHandler(this.SwitchButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(93, 136);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 23);
            this.label2.TabIndex = 81;
            this.label2.Text = "配方：";
            // 
            // FormulaComboBox
            // 
            this.FormulaComboBox.FormattingEnabled = true;
            this.FormulaComboBox.Location = new System.Drawing.Point(177, 132);
            this.FormulaComboBox.Name = "FormulaComboBox";
            this.FormulaComboBox.Size = new System.Drawing.Size(324, 33);
            this.FormulaComboBox.TabIndex = 80;
            // 
            // ToolTextBox
            // 
            this.ToolTextBox.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ToolTextBox.Location = new System.Drawing.Point(177, 60);
            this.ToolTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.ToolTextBox.Name = "ToolTextBox";
            this.ToolTextBox.Size = new System.Drawing.Size(324, 34);
            this.ToolTextBox.TabIndex = 79;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(71, 63);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 23);
            this.label1.TabIndex = 78;
            this.label1.Text = "工单号：";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.uiGroupBox1);
            this.tabPage3.Location = new System.Drawing.Point(201, 0);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1076, 750);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "系统设置";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.Controls.Add(this.SaveButton);
            this.uiGroupBox1.Controls.Add(this.label3);
            this.uiGroupBox1.Controls.Add(this.IPSaveTextBox);
            this.uiGroupBox1.Controls.Add(this.label4);
            this.uiGroupBox1.Controls.Add(this.PortSaveTextBox);
            this.uiGroupBox1.Controls.Add(this.IsStartServer);
            this.uiGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiGroupBox1.FillColor = System.Drawing.Color.White;
            this.uiGroupBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.uiGroupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox1.Size = new System.Drawing.Size(1076, 388);
            this.uiGroupBox1.TabIndex = 1;
            this.uiGroupBox1.Text = null;
            this.uiGroupBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SaveButton
            // 
            this.SaveButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.SaveButton.Location = new System.Drawing.Point(822, 267);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(2);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(137, 69);
            this.SaveButton.TabIndex = 84;
            this.SaveButton.Text = "保存";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(48, 120);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 23);
            this.label3.TabIndex = 80;
            this.label3.Text = "IP：";
            // 
            // IPSaveTextBox
            // 
            this.IPSaveTextBox.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.IPSaveTextBox.Location = new System.Drawing.Point(139, 117);
            this.IPSaveTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.IPSaveTextBox.Name = "IPSaveTextBox";
            this.IPSaveTextBox.Size = new System.Drawing.Size(324, 34);
            this.IPSaveTextBox.TabIndex = 81;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(48, 182);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 23);
            this.label4.TabIndex = 83;
            this.label4.Text = "端口：";
            // 
            // PortSaveTextBox
            // 
            this.PortSaveTextBox.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PortSaveTextBox.Location = new System.Drawing.Point(139, 179);
            this.PortSaveTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.PortSaveTextBox.Name = "PortSaveTextBox";
            this.PortSaveTextBox.Size = new System.Drawing.Size(324, 34);
            this.PortSaveTextBox.TabIndex = 82;
            // 
            // IsStartServer
            // 
            this.IsStartServer.AutoSize = true;
            this.IsStartServer.Location = new System.Drawing.Point(52, 52);
            this.IsStartServer.Name = "IsStartServer";
            this.IsStartServer.Size = new System.Drawing.Size(191, 24);
            this.IsStartServer.TabIndex = 0;
            this.IsStartServer.Text = "是否自启动服务器";
            this.IsStartServer.UseVisualStyleBackColor = true;
            // 
            // FBoard
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1277, 785);
            this.Controls.Add(this.uiTabControlMenu1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FBoard";
            this.Text = "看板服务器";
            this.ZoomScaleRect = new System.Drawing.Rectangle(19, 19, 800, 450);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FBoard_FormClosed);
            this.Load += new System.EventHandler(this.FBoard_Load);
            this.Shown += new System.EventHandler(this.FBoard_Shown);
            this.uiTabControlMenu1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ConnectedDeviceDataGridView)).EndInit();
            this.uiGroupBox2.ResumeLayout(false);
            this.uiGroupBox2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FormulaListDataGridView)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.uiGroupBox1.ResumeLayout(false);
            this.uiGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UITabControlMenu uiTabControlMenu1;
        private System.Windows.Forms.TabPage tabPage1;
        private Sunny.UI.UIRichTextBox LogRichTextBox;
        private System.Windows.Forms.DataGridView ConnectedDeviceDataGridView;
        private Sunny.UI.UIGroupBox uiGroupBox2;
        private System.Windows.Forms.Button ServerStartButton;
        private System.Windows.Forms.Button ServerStopButton;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.TextBox BoardIPTextBox;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.TextBox BoardPortTextBox;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView FormulaListDataGridView;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button SwitchButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox FormulaComboBox;
        private System.Windows.Forms.TextBox ToolTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage3;
        private Sunny.UI.UIGroupBox uiGroupBox1;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox IPSaveTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox PortSaveTextBox;
        private System.Windows.Forms.CheckBox IsStartServer;
    }
}