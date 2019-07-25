namespace GenerateSql
{
    partial class Tables
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
            this.clb_tablelist = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // clb_tablelist
            // 
            this.clb_tablelist.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clb_tablelist.FormattingEnabled = true;
            this.clb_tablelist.Location = new System.Drawing.Point(12, 16);
            this.clb_tablelist.Name = "clb_tablelist";
            this.clb_tablelist.Size = new System.Drawing.Size(314, 388);
            this.clb_tablelist.TabIndex = 1;
            this.clb_tablelist.SelectedIndexChanged += new System.EventHandler(this.clb_tablelist_SelectedIndexChanged);
            // 
            // Tables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 419);
            this.Controls.Add(this.clb_tablelist);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Tables";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "选择表";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox clb_tablelist;
    }
}

