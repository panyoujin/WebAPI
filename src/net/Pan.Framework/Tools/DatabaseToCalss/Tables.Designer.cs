namespace DatabaseToCalss
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btn_create = new System.Windows.Forms.Button();
            this.cb_all = new System.Windows.Forms.CheckBox();
            this.txt_namespace = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // clb_tablelist
            // 
            this.clb_tablelist.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.clb_tablelist.FormattingEnabled = true;
            this.clb_tablelist.Location = new System.Drawing.Point(12, 48);
            this.clb_tablelist.Name = "clb_tablelist";
            this.clb_tablelist.Size = new System.Drawing.Size(214, 596);
            this.clb_tablelist.TabIndex = 1;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(255, 48);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(533, 596);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // btn_create
            // 
            this.btn_create.Font = new System.Drawing.Font("宋体", 15F);
            this.btn_create.Location = new System.Drawing.Point(99, 13);
            this.btn_create.Name = "btn_create";
            this.btn_create.Size = new System.Drawing.Size(127, 30);
            this.btn_create.TabIndex = 3;
            this.btn_create.Text = "生成API";
            this.btn_create.UseVisualStyleBackColor = true;
            this.btn_create.Click += new System.EventHandler(this.btn_create_Click);
            // 
            // cb_all
            // 
            this.cb_all.AutoSize = true;
            this.cb_all.Font = new System.Drawing.Font("宋体", 15F);
            this.cb_all.Location = new System.Drawing.Point(12, 16);
            this.cb_all.Name = "cb_all";
            this.cb_all.Size = new System.Drawing.Size(68, 24);
            this.cb_all.TabIndex = 4;
            this.cb_all.Text = "全选";
            this.cb_all.UseVisualStyleBackColor = true;
            this.cb_all.CheckedChanged += new System.EventHandler(this.cb_all_CheckedChanged);
            // 
            // txt_namespace
            // 
            this.txt_namespace.Font = new System.Drawing.Font("宋体", 15F);
            this.txt_namespace.Location = new System.Drawing.Point(367, 13);
            this.txt_namespace.Name = "txt_namespace";
            this.txt_namespace.Size = new System.Drawing.Size(421, 30);
            this.txt_namespace.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 15F);
            this.label3.Location = new System.Drawing.Point(255, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "命名空间:";
            // 
            // Tables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 651);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_namespace);
            this.Controls.Add(this.cb_all);
            this.Controls.Add(this.btn_create);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.clb_tablelist);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Tables";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "生成使用CoreDBHelper操作数据库的API解决方案";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox clb_tablelist;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button btn_create;
        private System.Windows.Forms.CheckBox cb_all;
        private System.Windows.Forms.TextBox txt_namespace;
        private System.Windows.Forms.Label label3;
    }
}

