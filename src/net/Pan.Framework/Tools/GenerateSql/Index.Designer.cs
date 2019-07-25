namespace GenerateSql
{
    partial class Index
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
            this.btn_start = new System.Windows.Forms.Button();
            this.txt_Key = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rtb_Sql = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btn_start
            // 
            this.btn_start.Font = new System.Drawing.Font("宋体", 15F);
            this.btn_start.Location = new System.Drawing.Point(552, 17);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(127, 30);
            this.btn_start.TabIndex = 3;
            this.btn_start.Text = "开始";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // txt_Key
            // 
            this.txt_Key.Font = new System.Drawing.Font("宋体", 15F);
            this.txt_Key.Location = new System.Drawing.Point(101, 12);
            this.txt_Key.Name = "txt_Key";
            this.txt_Key.Size = new System.Drawing.Size(421, 30);
            this.txt_Key.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 15F);
            this.label3.Location = new System.Drawing.Point(37, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Key:";
            // 
            // rtb_Sql
            // 
            this.rtb_Sql.Location = new System.Drawing.Point(41, 71);
            this.rtb_Sql.Name = "rtb_Sql";
            this.rtb_Sql.Size = new System.Drawing.Size(638, 409);
            this.rtb_Sql.TabIndex = 7;
            this.rtb_Sql.Text = "";
            // 
            // Index
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 651);
            this.Controls.Add(this.rtb_Sql);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_Key);
            this.Controls.Add(this.btn_start);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Index";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "生成SQL";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.TextBox txt_Key;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox rtb_Sql;
    }
}

