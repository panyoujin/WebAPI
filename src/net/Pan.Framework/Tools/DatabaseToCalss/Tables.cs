using DatabaseToCalss.Extend;
using DBHelper.SQLHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseToCalss
{
    public partial class Tables : Form
    {
        public Tables(List<string> db_list)
        {
            InitializeComponent();
            this.txt_namespace.Text = StaticValue.Database;
            this.clb_tablelist.DataSource = db_list;
        }


        private void btn_create_Click(object sender, EventArgs e)
        {
            try
            {
                this.SetEnable(false);
                this.richTextBox1.Text = "";
                List<string> names = new List<string>();
                for (var i = 0; i < this.clb_tablelist.Items.Count; i++)
                {
                    if (!this.clb_tablelist.GetItemChecked(i))
                    {
                        continue;
                    }
                    var name = this.clb_tablelist.Items[i].ToString();
                    names.Add(name);
                }
                ToWebDemo toWebDemo = new ToWebDemo();
                toWebDemo.SetMessage = SetMessage;
                toWebDemo.Start(txt_namespace.Text.Trim(), names);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.SetEnable(true);
        }

        private void cb_all_CheckedChanged(object sender, EventArgs e)
        {
            for (var i = 0; i < this.clb_tablelist.Items.Count; i++)
            {
                this.clb_tablelist.SetItemChecked(i, this.cb_all.Checked);
            }
        }

        private void SetMessage(string message)
        {
            this.richTextBox1.Text += message + "\n";
        }
    }
}
