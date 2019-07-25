using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateSql
{
    public class StaticValue
    {
        public static string ConnectionString = "Server ={0};PORT={1}; Database ={2}; Uid ={3}; Pwd ={4};Pooling=true; Max Pool Size=100;Min Pool Size=10;Allow Batch=true; Allow User Variables=True;Charset=utf8";

        public static string Database = "";
        public static List<string> TableList;
    }
}
