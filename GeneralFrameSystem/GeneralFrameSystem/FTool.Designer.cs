namespace GeneralFrameSystem
{
    partial class FTool
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FTool));
            this.ToolIDTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ToolIDTextBox
            // 
            this.ToolIDTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.ToolIDTextBox.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold);
            this.ToolIDTextBox.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ToolIDTextBox.Location = new System.Drawing.Point(217, 93);
            this.ToolIDTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.ToolIDTextBox.Name = "ToolIDTextBox";
            this.ToolIDTextBox.Size = new System.Drawing.Size(315, 42);
            this.ToolIDTextBox.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(103, 96);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 30);
            this.label1.TabIndex = 12;
            this.label1.Text = "工单号";
            // 
            // ConfirmButton
            // 
            this.ConfirmButton.BackColor = System.Drawing.SystemColors.Control;
            this.ConfirmButton.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold);
            this.ConfirmButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ConfirmButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.ConfirmButton.Location = new System.Drawing.Point(230, 179);
            this.ConfirmButton.Margin = new System.Windows.Forms.Padding(4);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(160, 51);
            this.ConfirmButton.TabIndex = 14;
            this.ConfirmButton.Text = "确定";
            this.ConfirmButton.UseVisualStyleBackColor = true;
            this.ConfirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // FTool
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(634, 277);
            this.Controls.Add(this.ConfirmButton);
            this.Controls.Add(this.ToolIDTextBox);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FTool";
            this.Text = "添加工单操作";
            this.ZoomScaleRect = new System.Drawing.Rectangle(19, 19, 800, 450);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ToolIDTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ConfirmButton;
    }
}