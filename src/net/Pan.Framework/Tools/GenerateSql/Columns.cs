using DBHelper.SQLHelper;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GenerateSql
{
    public partial class Columns : Form
    {
        public Action<List<String>> SelectColumnsAction;
        public Columns(string name)
        {
            InitializeComponent();
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic["DBName"] = StaticValue.Database;
            dic["TableName"] = name;
            var list = SQLHelperFactory.Instance.QueryForListByT<sys_table_column_model>("GetTableColumnList", dic);
            this.clb_ColumnList.DataSource = list;
            this.clb_ColumnList.DisplayMember = "column_name";
        }

        private void btn_confire_Click(object sender, EventArgs e)
        {
            List<string> names = new List<string>();
            for (var i = 0; i < this.clb_ColumnList.Items.Count; i++)
            {
                if (!this.clb_ColumnList.GetItemChecked(i))
                {
                    continue;
                }
                var name = this.clb_ColumnList.Items[i] as sys_table_column_model;
                names.Add(name.column_name);
            }
            this.Close();
            SelectColumnsAction?.Invoke(names);
            
        }

        private void cb_all_CheckedChanged(object sender, EventArgs e)
        {
            for (var i = 0; i < this.clb_ColumnList.Items.Count; i++)
            {
                this.clb_ColumnList.SetItemChecked(i, this.cb_all.Checked);
            }
        }
    }
}
