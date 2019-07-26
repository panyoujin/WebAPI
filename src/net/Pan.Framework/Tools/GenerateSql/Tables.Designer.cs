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
            this.btnQD = new System.Windows.Forms.Button();
            this.cbbTableList = new System.Windows.Forms.ComboBox();
            this.cbbJoinList = new System.Windows.Forms.ComboBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnQD
            // 
            this.btnQD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQD.Font = new System.Drawing.Font("宋体", 15F);
            this.btnQD.Location = new System.Drawing.Point(52, 176);
            this.btnQD.Name = "btnQD";
            this.btnQD.Size = new System.Drawing.Size(170, 39);
            this.btnQD.TabIndex = 2;
            this.btnQD.Text = "确定";
            this.btnQD.UseVisualStyleBackColor = true;
            this.btnQD.Click += new System.EventHandler(this.btnQD_Click);
            // 
            // cbbTableList
            // 
            this.cbbTableList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbTableList.Font = new System.Drawing.Font("宋体", 20F);
            this.cbbTableList.FormattingEnabled = true;
            this.cbbTableList.Items.AddRange(new object[] {
            "LEFT JOIN",
            "RIGHT JOIN",
            "JOIN"});
            this.cbbTableList.Location = new System.Drawing.Point(52, 105);
            this.cbbTableList.Name = "cbbTableList";
            this.cbbTableList.Size = new System.Drawing.Size(420, 35);
            this.cbbTableList.TabIndex = 3;
            // 
            // cbbJoinList
            // 
            this.cbbJoinList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbJoinList.Font = new System.Drawing.Font("宋体", 20F);
            this.cbbJoinList.FormattingEnabled = true;
            this.cbbJoinList.Items.AddRange(new object[] {
            "LEFT JOIN",
            "RIGHT JOIN",
            "JOIN"});
            this.cbbJoinList.Location = new System.Drawing.Point(52, 37);
            this.cbbJoinList.Name = "cbbJoinList";
            this.cbbJoinList.Size = new System.Drawing.Size(420, 35);
            this.cbbJoinList.TabIndex = 4;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Font = new System.Drawing.Font("宋体", 15F);
            this.btnClose.Location = new System.Drawing.Point(302, 176);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(170, 39);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "结束";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // Tables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 238);
            this.ControlBox = false;
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.cbbJoinList);
            this.Controls.Add(this.cbbTableList);
            this.Controls.Add(this.btnQD);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Tables";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "选择表";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnQD;
        private System.Windows.Forms.ComboBox cbbTableList;
        private System.Windows.Forms.ComboBox cbbJoinList;
        private System.Windows.Forms.Button btnClose;
    }
}

