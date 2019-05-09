using System;
using System.Collections.Generic;
using System.Text;

namespace DatabaseToCalss
{
    public class sys_table_column_model
    {
        public string column_name { get; set; }
        public string column_comment { get; set; }
        public string ordinal_position { get; set; }
        public string column_key { get; set; }
        public string column_type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string data_type { get; set; }
        
    }
}
