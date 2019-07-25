
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

namespace GenerateSql
{
    public partial class Index : Form
    {
        public Index()
        {
            InitializeComponent();
        }



        private void TableColumn(string name)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic["DBName"] = StaticValue.Database;
            dic["TableName"] = name;
            var list = SQLHelperFactory.Instance.QueryForListByT<sys_table_column_model>("GetTableColumnList", dic);
        }

        StringBuilder showColumn = new StringBuilder();
        List<string> tableList = new List<string>();
        private void btn_start_Click(object sender, EventArgs e)
        {
            showColumn = new StringBuilder();
            tableList = new List<string>();
            ShowTable();
        }
        private void ShowTable()
        {
            Tables tables = new Tables();
            tables.SelectTableAction = (name) =>
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    return;
                }
                tableList.Add(name);
                Columns columns = new Columns(name);
                columns.SelectColumnsAction = (list) =>
                {
                    if (list != null && list.Count > 0)
                    {
                        foreach (var c in list)
                        {
                            if (showColumn.Length > 0)
                            {
                                showColumn.Append(",");
                            }
                            showColumn.AppendFormat("{0}.{1}", name, c);
                        }
                    }
                    else
                    {
                        showColumn.AppendFormat("{0}.*", name);
                    }
                };
                columns.ShowDialog();
                rtb_Sql.Text = string.Format("SELECT {0} FROM {1}\n", showColumn.ToString(), tableList[0]);
                for (var i = 1; i < tableList.Count; i++)
                {
                    rtb_Sql.Text += string.Format("LEFT JOIN {0} ON 1=1\n", tableList[i]);
                }
                ShowTable();
            };
            tables.ShowDialog();
        }

    }
}
