using System;
using System.Windows.Forms;

namespace GenerateSql
{
    public partial class Tables : Form
    {
        public string TableName;
        public string JoinType;

        public Tables(int index)
        {
            InitializeComponent();
            if (index == 0)
            {
                cbbJoinList.Enabled = false;
            }
            else
            {
                cbbJoinList.SelectedIndex = 0;
            }
            cbbTableList.DataSource = StaticValue.TableList;
        }

        private void btnQD_Click(object sender, EventArgs e)
        {
            JoinType = cbbJoinList.Text;
            TableName = cbbTableList.Text;
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
