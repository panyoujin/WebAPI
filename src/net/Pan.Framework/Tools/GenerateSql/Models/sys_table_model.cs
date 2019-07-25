using System;
using System.Collections.Generic;
using System.Text;

namespace GenerateSql
{
    public class sys_table_model
    {
        public string table_name { get; set; }
        public string table_rows { get; set; }
        public string table_comment { get; set; }
        public string columns { get; set; }

        public int? ss;

        public sys_table_model()
        {
            if(ss.HasValue)
            {

            }
        }
    }
}
