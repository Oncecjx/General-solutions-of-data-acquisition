namespace GeneralFrameSystem
{
    partial class FLogin
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("宋体", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTitle.Location = new System.Drawing.Point(44, 24);
            this.lblTitle.Size = new System.Drawing.Size(694, 45);
            this.lblTitle.Text = "机台名称";
            // 
            // lblSubText
            // 
            this.lblSubText.Location = new System.Drawing.Point(338, 421);
            this.lblSubText.Text = "Develop by CJX";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::GeneralFrameSystem.Properties.Resources.shujucaijifenxi;
            this.pictureBox1.Location = new System.Drawing.Point(134, 195);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(169, 131);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // FLogin
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(750, 450);
            this.Controls.Add(this.pictureBox1);
            this.Name = "FLogin";
            this.SubText = "Develop by CJX";
            this.Text = "Form1";
            this.Title = "机台名称";
            this.OnLogin += new Sunny.UI.UILoginForm.OnLoginHandle(this.FLogin_OnLogin);
            this.Load += new System.EventHandler(this.FLogin_Load);
            this.Controls.SetChildIndex(this.lblTitle, 0);
            this.Controls.SetChildIndex(this.lblSubText, 0);
            this.Controls.SetChildIndex(this.uiPanel1, 0);
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

