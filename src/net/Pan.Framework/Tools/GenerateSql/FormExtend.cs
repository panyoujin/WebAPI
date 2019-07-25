using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GenerateSql
{
    public static class FormExtend
    {
        public static void SetEnable(this Form form, bool enable)
        {
            foreach (Control c in form.Controls)
            {
                c.Enabled = enable;
            }
        }
    }
}
