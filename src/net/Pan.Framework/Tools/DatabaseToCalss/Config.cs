using DatabaseToCalss.Extend;
using DBHelper.SQLHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseToCalss
{
    public partial class Config : Form
    {
        public Config()
        {
            InitializeComponent();
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            try
            {
                this.SetEnable(false);
                SQLHelperFactory.Instance.ConnectionStringsDic["backstage_connection"] = string.Format(StaticValue.ConnectionString, this.txt_ip.Text.Trim(), this.txt_port.Text.Trim(), this.cb_dblist.Text.Trim(), this.txt_user.Text.Trim(), this.txt_password.Text.Trim());
                StaticValue.Database = this.cb_dblist.Text.Trim();

                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic["DBName"] = StaticValue.Database;
                var db_list = SQLHelperFactory.Instance.QueryForListByT<string>("GetTableList", dic);
                Tables t = new Tables(db_list);
                this.Hide();
                t.ShowDialog();
                this.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误，请检查数据库连接信息");
            }
            this.SetEnable(true);
        }

        private void llab_query_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                this.SetEnable(false);
                SQLHelperFactory.Instance.ConnectionStringsDic["db_connection"] = string.Format(StaticValue.ConnectionString, this.txt_ip.Text.Trim(), this.txt_port.Text.Trim(), "information_schema", this.txt_user.Text.Trim(), this.txt_password.Text.Trim());
                var db_list = SQLHelperFactory.Instance.QueryForListByT<string>("GetDBList", null);
                this.cb_dblist.DataSource = db_list;
                this.llab_query.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误，请检查数据库连接信息");
            }
            this.SetEnable(true);
        }
    }
}
