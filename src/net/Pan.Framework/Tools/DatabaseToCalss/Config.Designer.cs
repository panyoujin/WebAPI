namespace DatabaseToCalss
{
    partial class Config
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
            this.label1 = new System.Windows.Forms.Label();
            this.txt_ip = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_user = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_start = new System.Windows.Forms.Button();
            this.cb_dblist = new System.Windows.Forms.ComboBox();
            this.llab_query = new System.Windows.Forms.LinkLabel();
            this.txt_port = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15F);
            this.label1.Location = new System.Drawing.Point(75, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "服务器:";
            // 
            // txt_ip
            // 
            this.txt_ip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_ip.Font = new System.Drawing.Font("宋体", 15F);
            this.txt_ip.Location = new System.Drawing.Point(165, 41);
            this.txt_ip.Name = "txt_ip";
            this.txt_ip.Size = new System.Drawing.Size(255, 30);
            this.txt_ip.TabIndex = 1;
            this.txt_ip.Text = "127.0.0.1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 15F);
            this.label2.Location = new System.Drawing.Point(75, 223);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "数据库:";
            // 
            // txt_password
            // 
            this.txt_password.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_password.Font = new System.Drawing.Font("宋体", 15F);
            this.txt_password.Location = new System.Drawing.Point(165, 155);
            this.txt_password.Name = "txt_password";
            this.txt_password.Size = new System.Drawing.Size(340, 30);
            this.txt_password.TabIndex = 5;
            this.txt_password.Text = "123456";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 15F);
            this.label3.Location = new System.Drawing.Point(95, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "密码:";
            // 
            // txt_user
            // 
            this.txt_user.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_user.Font = new System.Drawing.Font("宋体", 15F);
            this.txt_user.Location = new System.Drawing.Point(165, 99);
            this.txt_user.Name = "txt_user";
            this.txt_user.Size = new System.Drawing.Size(340, 30);
            this.txt_user.TabIndex = 7;
            this.txt_user.Text = "root";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 15F);
            this.label4.Location = new System.Drawing.Point(95, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "帐号:";
            // 
            // btn_start
            // 
            this.btn_start.Font = new System.Drawing.Font("宋体", 15F);
            this.btn_start.Location = new System.Drawing.Point(233, 288);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(129, 48);
            this.btn_start.TabIndex = 8;
            this.btn_start.Text = "开始";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // cb_dblist
            // 
            this.cb_dblist.Font = new System.Drawing.Font("宋体", 15F);
            this.cb_dblist.FormattingEnabled = true;
            this.cb_dblist.Location = new System.Drawing.Point(165, 219);
            this.cb_dblist.Name = "cb_dblist";
            this.cb_dblist.Size = new System.Drawing.Size(340, 28);
            this.cb_dblist.TabIndex = 9;
            // 
            // llab_query
            // 
            this.llab_query.AutoSize = true;
            this.llab_query.Font = new System.Drawing.Font("宋体", 15F);
            this.llab_query.Location = new System.Drawing.Point(512, 223);
            this.llab_query.Name = "llab_query";
            this.llab_query.Size = new System.Drawing.Size(69, 20);
            this.llab_query.TabIndex = 10;
            this.llab_query.TabStop = true;
            this.llab_query.Text = "库列表";
            this.llab_query.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llab_query_LinkClicked);
            // 
            // txt_port
            // 
            this.txt_port.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_port.Font = new System.Drawing.Font("宋体", 15F);
            this.txt_port.Location = new System.Drawing.Point(426, 41);
            this.txt_port.Name = "txt_port";
            this.txt_port.Size = new System.Drawing.Size(79, 30);
            this.txt_port.TabIndex = 11;
            this.txt_port.Text = "3306";
            // 
            // Config
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 363);
            this.Controls.Add(this.txt_port);
            this.Controls.Add(this.llab_query);
            this.Controls.Add(this.cb_dblist);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.txt_user);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_password);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_ip);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(610, 402);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(610, 402);
            this.Name = "Config";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MySql 连接配置";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_ip;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_user;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.ComboBox cb_dblist;
        private System.Windows.Forms.LinkLabel llab_query;
        private System.Windows.Forms.TextBox txt_port;
    }
}