
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
        TableModel _tableModel;
        private void btn_start_Click(object sender, EventArgs e)
        {
            _tableModel = ShowTable(0);
            if (_tableModel != null && !string.IsNullOrWhiteSpace(_tableModel.TableName))
            {
                try
                {
                    StringBuilder showSql = new StringBuilder();
                    StringBuilder joinSql = new StringBuilder();
                    StringBuilder whereSql = new StringBuilder();
                    var t = _tableModel;
                    while (t != null && !string.IsNullOrWhiteSpace(t.TableName))
                    {
                        if (t.ShowColumns != null)
                        {
                            foreach (var c in t.ShowColumns)
                            {
                                if (showSql.Length == 0)
                                {
                                    showSql.AppendFormat("{0}.{1}", t.Alias, c);
                                }
                                else
                                {
                                    showSql.AppendFormat(",{0}.{1}", t.Alias, c);
                                }
                            }
                        }
                        if (string.IsNullOrWhiteSpace(t.PreJoinType))
                        {
                            joinSql.AppendFormat("FROM {0} AS {1} ", t.TableName, t.Alias);
                        }
                        else
                        {
                            joinSql.AppendFormat("{0} {1} AS {2} ON ", t.PreJoinType, t.TableName, t.Alias);
                            if (t.JoinWhere == null || t.JoinWhere.LeftTable == null)
                            {
                                joinSql.AppendFormat(" 1 = 1");
                            }
                            else
                            {
                                var c = t.JoinWhere;
                                while (c != null && c.LeftTable != null)
                                {
                                    if (c.RightTable == null)
                                    {
                                        joinSql.AppendFormat("{0} {1}.{2} {3} {4}", c.PreJoinWhereType, c.LeftTable.Alias, c.LeftTableColumnName, c.ConditionType, c.RightTableColumnName);
                                    }
                                    else
                                    {
                                        joinSql.AppendFormat("{0} {1}.{2} {3} {4}.{5}", c.PreJoinWhereType, c.LeftTable.Alias, c.LeftTableColumnName, c.ConditionType, c.RightTable.Alias, c.RightTableColumnName);
                                    }
                                    c = c.NextJoinWhere;
                                }
                            }
                        }
                        joinSql.Append("\n");

                        t = t.NextJoinTable;
                    }
                    rtb_Sql.Text = string.Format("SELECT {0} \n{1}", showSql.ToString(), joinSql.ToString());
                }
                catch (Exception ex)
                {

                }
            }
        }
        private TableModel ShowTable(int count)
        {
            TableModel tableModel = new TableModel();
            Tables tables = new Tables(count);
            tables.ShowDialog();
            tableModel.PreJoinType = tables.JoinType;
            var name = tables.TableName;
            if (string.IsNullOrWhiteSpace(name))
            {
                return tableModel;
            }
            tableModel.TableName = name;
            tableModel.Alias = "t" + count;
            Columns columns = new Columns(name);
            columns.ShowDialog();
            var list = columns.ColumnsList;
            if (list != null && list.Count > 0)
            {
                tableModel.ShowColumns = list;
            }
            if (count > 0)
            {
                //组装 on后面的内容
                tableModel.JoinWhere = new JoinWhereModel();
            }
            tableModel.NextJoinTable = ShowTable(++count);
            return tableModel;
        }

    }

    public class TableModel
    {
        public string TableName { get; set; }
        /// <summary>
        /// 别名
        /// </summary>
        public string Alias { get; set; }
        /// <summary>
        /// 显示的列
        /// </summary>
        public List<string> ShowColumns { get; set; }
        /// <summary>
        /// join ，left join，right join
        /// </summary>
        public TableModel NextJoinTable { get; set; }
        /// <summary>
        /// 和上一个关联的类型 join ，left join，right join
        /// </summary>
        public string PreJoinType { get; set; }
        /// <summary>
        /// join 后面on部分
        /// </summary>
        public JoinWhereModel JoinWhere { get; set; }
    }
    public class JoinWhereModel
    {
        public TableModel LeftTable { get; set; }
        public string LeftTableColumnName { get; set; }
        /// <summary>
        /// =,>,<,>=,<=
        /// </summary>
        public string ConditionType { get; set; }
        /// <summary>
        /// 条件对应的表名，如果为空则表示 是一个常量或者一个变量
        /// </summary>
        public TableModel RightTable { get; set; }

        public string RightTableColumnName { get; set; }
        /// <summary>
        /// and or
        /// </summary>
        public string PreJoinWhereType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public JoinWhereModel NextJoinWhere { get; set; }
    }

    public class WhereModel
    {
        public TableModel LeftTable { get; set; }
        public string LeftColumn { get; set; }
        /// <summary>
        /// =,>,<,>=,<=
        /// </summary>
        public string ConditionType { get; set; }
        /// <summary>
        /// 条件对应的表名，如果为空则表示 是一个常量或者一个变量
        /// </summary>
        public TableModel RightTable { get; set; }

        public string RightColumn { get; set; }
        /// <summary>
        /// key: and or
        /// </summary>
        public Dictionary<string, JoinWhereModel> NextWhere { get; set; }
    }
}
