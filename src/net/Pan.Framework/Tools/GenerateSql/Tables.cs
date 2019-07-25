using System;
using System.Windows.Forms;

namespace GenerateSql
{
    public partial class Tables : Form
    {
        public Action<string> SelectTableAction;
        public Tables()
        {
            InitializeComponent();
            this.clb_tablelist.DataSource = StaticValue.TableList;
        }

        private void clb_tablelist_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (var i = 0; i < this.clb_tablelist.Items.Count; i++)
            {
                if (!this.clb_tablelist.GetItemChecked(i))
                {
                    continue;
                }
                var name = this.clb_tablelist.Items[i].ToString();
                this.Close();
                SelectTableAction?.Invoke(name);
            }
        }
    }
}
