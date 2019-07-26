namespace GenerateSql
{
    partial class Columns
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
            this.clb_ColumnList = new System.Windows.Forms.CheckedListBox();
            this.btn_confire = new System.Windows.Forms.Button();
            this.cb_all = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // clb_ColumnList
            // 
            this.clb_ColumnList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clb_ColumnList.Font = new System.Drawing.Font("宋体", 15F);
            this.clb_ColumnList.FormattingEnabled = true;
            this.clb_ColumnList.Location = new System.Drawing.Point(12, 32);
            this.clb_ColumnList.Name = "clb_ColumnList";
            this.clb_ColumnList.Size = new System.Drawing.Size(314, 372);
            this.clb_ColumnList.TabIndex = 1;
            // 
            // btn_confire
            // 
            this.btn_confire.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_confire.Font = new System.Drawing.Font("宋体", 15F);
            this.btn_confire.Location = new System.Drawing.Point(98, 424);
            this.btn_confire.Name = "btn_confire";
            this.btn_confire.Size = new System.Drawing.Size(118, 42);
            this.btn_confire.TabIndex = 2;
            this.btn_confire.Text = "确定";
            this.btn_confire.UseVisualStyleBackColor = true;
            this.btn_confire.Click += new System.EventHandler(this.btn_confire_Click);
            // 
            // cb_all
            // 
            this.cb_all.AutoSize = true;
            this.cb_all.Font = new System.Drawing.Font("宋体", 15F);
            this.cb_all.Location = new System.Drawing.Point(12, 2);
            this.cb_all.Name = "cb_all";
            this.cb_all.Size = new System.Drawing.Size(68, 24);
            this.cb_all.TabIndex = 5;
            this.cb_all.Text = "全选";
            this.cb_all.UseVisualStyleBackColor = true;
            this.cb_all.CheckedChanged += new System.EventHandler(this.cb_all_CheckedChanged);
            // 
            // Columns
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 478);
            this.Controls.Add(this.cb_all);
            this.Controls.Add(this.btn_confire);
            this.Controls.Add(this.clb_ColumnList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Columns";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "选择表";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox clb_ColumnList;
        private System.Windows.Forms.Button btn_confire;
        private System.Windows.Forms.CheckBox cb_all;
    }
}

