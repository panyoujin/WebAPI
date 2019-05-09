using DBHelper.SQLHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseToCalss
{
    public class ToConsole
    {

        public ToConsole(string ns, List<string> names)
        {
            foreach (var name in names)
            {
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic["DBName"] = StaticValue.Database;
                dic["TableName"] = name;
                var list = SQLHelperFactory.Instance.QueryForListByT<sys_table_column_model>("GetTableColumnList", dic);
                ToModel(ns, name, list);
                ToSql(ns, name, list);
                ToIRepository(ns, name, list);
                ToRepository(ns, name, list);
                ToMainClass(ns, name, list);
            }
            ToCsproject(ns, names);
        }
        public string ToModel(string ns, string name, List<sys_table_column_model> list)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("using System;\n");
            sb.Append("\n");
            sb.AppendFormat("namespace {0}.models\n", !string.IsNullOrWhiteSpace(ns) ? ns : StaticValue.Database);
            sb.Append("{\n");
            sb.AppendFormat("    public class {0}_Model\n", name);
            sb.Append("    {\n");
            foreach (var item in list)
            {
                sb.Append("        /// <summary>\n");
                sb.AppendFormat("        /// {0}\n", item.column_comment);
                sb.Append("        /// <summary>\n");
                sb.AppendFormat("        public {0} {1} {2}\n", ConvrtType(item.data_type), item.column_name, "{ get; set; }");

                sb.Append("\n");
            }
            sb.Append("    }\n");
            sb.Append("}");
            var path = AppDomain.CurrentDomain.BaseDirectory + "/" + ns + "/models/";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            path += name + "_Model.cs";
            WriteFile(path, sb.ToString());
            return sb.ToString();
        }



        public string ToSql(string ns, string name, List<sys_table_column_model> list)
        {
            StringBuilder sb = new StringBuilder();
            var namelist = list.Select(s => s.column_name);
            var insertvaluselist = list.Select(s => "@@" + s.column_name + "@@");
            var setlist = list.Select(s => s.column_name + "=@@" + s.column_name + "@@");
            var wherelist = list.Select(s => s.column_name + "=@@" + s.column_name + "@@");
            sb.Append("<?xml version=\"1.0\" encoding=\"utf-8\" ?>\n");
            sb.Append("<SqlSetting>\n");
            #region Insert
            sb.AppendFormat("    <Data name=\"Insert_{0}\">\n", name);
            sb.Append("        <SqlDefinition type=\"MySql\" ConnStringName=\"backstage_connection\">\n");
            sb.Append("            <SqlCommand>\n");
            sb.Append("                <![CDATA[\n");
            sb.AppendFormat("                INSERT INTO {0} ({1}) VALUES({2});\n", name, string.Join(",", namelist), string.Join(",", insertvaluselist));
            sb.Append("                ]]>\n");
            sb.Append("            </SqlCommand>\n");
            sb.Append("        </SqlDefinition>\n");
            sb.Append("    </Data>\n");
            #endregion Insert

            #region Update
            sb.AppendFormat("    <Data name=\"Update_{0}\">\n", name);
            sb.Append("        <SqlDefinition type=\"MySql\" ConnStringName=\"backstage_connection\">\n");
            sb.Append("            <SqlCommand>\n");
            sb.Append("                <![CDATA[\n");
            sb.AppendFormat("                UPDATE {0} SET {1} WHERE {2};\n", name, string.Join(",", setlist), setlist.FirstOrDefault());
            sb.Append("                ]]>\n");
            sb.Append("            </SqlCommand>\n");
            sb.Append("        </SqlDefinition>\n");
            sb.Append("    </Data>\n");
            #endregion Update

            #region Delete
            sb.AppendFormat("    <Data name=\"Delete_{0}\">\n", name);
            sb.Append("        <SqlDefinition type=\"MySql\" ConnStringName=\"backstage_connection\">\n");
            sb.Append("            <SqlCommand>\n");
            sb.Append("                <![CDATA[\n");
            sb.AppendFormat("                DELETE FROM {0} WHERE {1};\n", name, wherelist.FirstOrDefault());
            sb.Append("                ]]>\n");
            sb.Append("            </SqlCommand>\n");
            sb.Append("        </SqlDefinition>\n");
            sb.Append("    </Data>\n");
            #endregion Delete

            #region Select
            sb.AppendFormat("    <Data name=\"Select_{0}\">\n", name);
            sb.Append("        <SqlDefinition type=\"MySql\" ConnStringName=\"backstage_connection\">\n");
            sb.Append("            <SqlCommand>\n");
            sb.Append("                <![CDATA[\n");
            sb.AppendFormat("                SELECT {0} FROM {1} WHERE {2};\n", string.Join(",", namelist), name, wherelist.FirstOrDefault());
            sb.Append("                ]]>\n");
            sb.Append("            </SqlCommand>\n");
            sb.Append("        </SqlDefinition>\n");
            sb.Append("    </Data>\n");
            #endregion Select

            #region Select
            sb.AppendFormat("    <Data name=\"Select_{0}_List\">\n", name);
            sb.Append("        <SqlDefinition type=\"MySql\" ConnStringName=\"backstage_connection\">\n");
            sb.Append("            <SqlCommand>\n");
            sb.Append("                <![CDATA[\n");
            sb.AppendFormat("                SELECT COUNT(0) AS row_count FROM {0} WHERE {1};\n", name, string.Join(",", wherelist));
            sb.AppendFormat("                SELECT {0} FROM {1} WHERE {2} LIMIT <R%= @@StartIndex@@, @@SelectCount@@ %R> ;\n", string.Join(",", namelist), name, string.Join(",", wherelist));
            sb.Append("                ]]>\n");
            sb.Append("            </SqlCommand>\n");
            sb.Append("        </SqlDefinition>\n");
            sb.Append("    </Data>\n");
            #endregion Select

            sb.Append("</SqlSetting>\n");
            var path = AppDomain.CurrentDomain.BaseDirectory + "/" + ns + "/SqlConfig/";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            path += name + "Sql.xml";
            WriteFile(path, sb.ToString());
            return sb.ToString();
        }


        public string ToIRepository(string ns, string name, List<sys_table_column_model> list)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("using System;\n");
            sb.Append("using System.Collections.Generic;\n");
            sb.AppendFormat("using {0}.models;\n", !string.IsNullOrWhiteSpace(ns) ? ns : StaticValue.Database);
            sb.Append("\n");
            sb.AppendFormat("namespace {0}.IRepository\n", !string.IsNullOrWhiteSpace(ns) ? ns : StaticValue.Database);
            sb.Append("{\n");
            sb.AppendFormat("    public interface I{0}_Repository\n", name);
            sb.Append("    {\n");

            #region Insert
            sb.Append("        /// <summary>\n");
            sb.Append("        /// 新增\n");
            sb.Append("        /// <summary>\n");
            sb.AppendFormat("        bool insert_{0}({0}_Model model);\n", name);
            sb.Append("\n");
            #endregion Insert

            #region Update
            sb.Append("        /// <summary>\n");
            sb.Append("        /// 修改\n");
            sb.Append("        /// <summary>\n");
            sb.AppendFormat("        bool update_{0}({0}_Model model);\n", name);
            sb.Append("\n");
            #endregion Update

            #region Delete
            sb.Append("        /// <summary>\n");
            sb.Append("        /// 删除\n");
            sb.Append("        /// <summary>\n");
            sb.AppendFormat("        bool delete_{0}({0}_Model model);\n", name);
            sb.Append("\n");
            #endregion Delete

            #region Select
            sb.Append("        /// <summary>\n");
            sb.Append("        /// 获取单个\n");
            sb.Append("        /// <summary>\n");
            sb.AppendFormat("        {0}_Model select_{0}({0}_Model model);\n", name);
            sb.Append("\n");
            #endregion Select

            #region SelectList
            sb.Append("        /// <summary>\n");
            sb.Append("        /// 获取列表\n");
            sb.Append("        /// <summary>\n");
            sb.AppendFormat("        (IEnumerable<{0}_Model>,int) select_{0}_list({0}_Model model,int pageindex,int pagesize);\n", name);
            sb.Append("\n");
            #endregion SelectList

            sb.Append("    }\n");
            sb.Append("}");
            var path = AppDomain.CurrentDomain.BaseDirectory + "/" + ns + "/IRepository/";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            path += "I" + name + "_Repository.cs";
            WriteFile(path, sb.ToString());
            return sb.ToString();
        }

        public string ToRepository(string ns, string name, List<sys_table_column_model> list)
        {
            StringBuilder sb = new StringBuilder();
            StringBuilder dicsb = new StringBuilder();
            dicsb.Append("            Dictionary<string, object> dic = new Dictionary<string, object>();\n");
            foreach (var item in list)
            {
                dicsb.AppendFormat("            dic[\"{0}\"] = model.{0};\n", item.column_name);
            }
            sb.Append("using System;\n");
            sb.Append("using System.Collections.Generic;\n");
            sb.Append("using DBHelper.SQLHelper;\n");
            sb.AppendFormat("using {0}.models;\n", !string.IsNullOrWhiteSpace(ns) ? ns : StaticValue.Database);
            sb.AppendFormat("using {0}.IRepository;\n", !string.IsNullOrWhiteSpace(ns) ? ns : StaticValue.Database);
            sb.Append("\n");
            sb.AppendFormat("namespace {0}.Repository\n", !string.IsNullOrWhiteSpace(ns) ? ns : StaticValue.Database);
            sb.Append("{\n");
            sb.AppendFormat("    public class {0}_Repository : I{0}_Repository\n", name);
            sb.Append("    {\n");

            #region Insert
            sb.Append("        /// <summary>\n");
            sb.Append("        /// 新增\n");
            sb.Append("        /// <summary>\n");
            sb.AppendFormat("        public bool insert_{0}({0}_Model model)\n", name);
            sb.Append("        {\n");
            sb.Append(dicsb);
            sb.AppendFormat("            return SQLHelperFactory.Instance.ExecuteNonQuery(\"Insert_{0}\", dic) >0 ;\n", name);
            sb.Append("        }\n\n");
            #endregion Insert

            #region Update
            sb.Append("        /// <summary>\n");
            sb.Append("        /// 修改\n");
            sb.Append("        /// <summary>\n");
            sb.AppendFormat("        public bool update_{0}({0}_Model model)\n", name);
            sb.Append("        {\n");
            sb.Append(dicsb);
            sb.AppendFormat("            return SQLHelperFactory.Instance.ExecuteNonQuery(\"Update_{0}\", dic) >0 ;\n", name);
            sb.Append("        }\n\n");
            #endregion Update

            #region Delete
            sb.Append("        /// <summary>\n");
            sb.Append("        /// 删除\n");
            sb.Append("        /// <summary>\n");
            sb.AppendFormat("        public bool delete_{0}({0}_Model model)\n", name);
            sb.Append("        {\n");
            sb.Append(dicsb);
            sb.AppendFormat("            return SQLHelperFactory.Instance.ExecuteNonQuery(\"Delete_{0}\", dic) >0 ;\n", name);
            sb.Append("        }\n\n");
            #endregion Delete

            #region Select
            sb.Append("        /// <summary>\n");
            sb.Append("        /// 获取单个\n");
            sb.Append("        /// <summary>\n");
            sb.AppendFormat("        public {0}_Model select_{0}({0}_Model model)\n", name);
            sb.Append("        {\n");
            sb.Append(dicsb);
            sb.AppendFormat("            return SQLHelperFactory.Instance.QueryForObjectByT<{0}_Model>(\"Select_{0}\", dic);\n", name);
            sb.Append("        }\n\n");
            #endregion Select

            #region SelectList
            sb.Append("        /// <summary>\n");
            sb.Append("        /// 获取列表\n");
            sb.Append("        /// <summary>\n");
            sb.AppendFormat("        public (IEnumerable<{0}_Model>,int) select_{0}_list({0}_Model model,int pageindex,int pagesize)\n", name);
            sb.Append("        {\n");
            sb.Append(dicsb);
            sb.AppendFormat("            var list = SQLHelperFactory.Instance.QueryMultipleByPage<{0}_Model>(\"Select_{0}_List\", dic,out int total);\n", name);
            sb.Append("            return (list,total);\n");
            sb.Append("        }\n\n");
            #endregion SelectList

            sb.Append("    }\n");
            sb.Append("}");
            var path = AppDomain.CurrentDomain.BaseDirectory + "/" + ns + "/Repository/";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            path += name + "_Repository.cs";
            WriteFile(path, sb.ToString());
            return sb.ToString();
        }


        public string ToMainClass(string ns, string name, List<sys_table_column_model> list)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("using System;\n");
            sb.Append("using DBHelper.SQLHelper;\n");
            sb.AppendFormat("using {0}.models;\n", !string.IsNullOrWhiteSpace(ns) ? ns : StaticValue.Database);
            sb.AppendFormat("using {0}.IRepository;\n", !string.IsNullOrWhiteSpace(ns) ? ns : StaticValue.Database);
            sb.AppendFormat("using {0}.Repository;\n", !string.IsNullOrWhiteSpace(ns) ? ns : StaticValue.Database);
            sb.Append("\n");
            sb.AppendFormat("namespace {0}\n", !string.IsNullOrWhiteSpace(ns) ? ns : StaticValue.Database);
            sb.Append("{\n");
            sb.AppendFormat("    public class Program\n", name);
            sb.Append("    {\n");
            sb.Append("        static void Main(string[] args)\n");
            sb.Append("        {\n");
            sb.AppendFormat("            SQLHelperFactory.Instance.ConnectionStringsDic[\"backstage_connection\"]=\"{0}\";\n", SQLHelperFactory.Instance.ConnectionStringsDic["backstage_connection"]);
            sb.AppendFormat("            {0}_Model model = new {0}_Model();\n", name);
            sb.AppendFormat("            {0}_Repository repository = new {0}_Repository();\n", name);
            foreach (var item in list)
            {
                sb.AppendFormat("            model.{0}= DateTime.Now.Ticks + \"\";\n", item.column_name);
            }
            sb.AppendFormat("            var row = repository.insert_{0}(model);\n", name);
            sb.Append("            Console.WriteLine(row);\n");
            sb.AppendFormat("            var item = repository.select_{0}(model);\n", name);
            foreach (var item in list)
            {
                sb.AppendFormat("            Console.WriteLine(item.{0});\n", item.column_name);
            }
            sb.Append("            Console.Read();\n");
            sb.Append("        }\n");
            sb.Append("\n");
            sb.Append("    }\n");
            sb.Append("}");
            var path = AppDomain.CurrentDomain.BaseDirectory + "/" + ns + "/";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            path += "Program.cs";
            WriteFile(path, sb.ToString());
            return sb.ToString();
        }

        public string ToCsproject(string ns, List<string> names)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<Project Sdk=\"Microsoft.NET.Sdk\">\n");
            sb.Append("    <PropertyGroup>\n");
            sb.Append("        <OutputType>Exe</OutputType>\n");
            sb.Append("        <TargetFramework>netcoreapp2.0</TargetFramework>\n");
            sb.Append("    </PropertyGroup>\n");
            sb.Append("    <ItemGroup>\n");
            foreach (var name in names)
            {
                sb.AppendFormat("        <Content Include=\"SqlConfig\\{0}Sql.xml\">\n", name);
                sb.Append("        <CopyToOutputDirectory>Always</CopyToOutputDirectory>\n");
                sb.Append("        </Content>\n");
            }
            sb.Append("    </ItemGroup>\n");

            sb.Append("    <ItemGroup>\n");
            sb.Append("        <PackageReference Include=\"CoreDBHelper\" Version=\"1.0.2\" />\n");
            sb.Append("    </ItemGroup>\n");

            sb.Append("</Project>\n");
            var path = AppDomain.CurrentDomain.BaseDirectory + "/" + ns + "/";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            path += ns + ".csproj";
            WriteFile(path, sb.ToString());
            return sb.ToString();
        }

        public string ConvrtType(string db_type)
        {

            switch (db_type)
            {
                case "char":
                case "varchar":
                case "text":
                    return "string";
                case "date":
                case "datetime":
                    return "DateTime";
                case "decimal":
                    return "decimal";
                case "int":
                case "tinyint":
                    return "int";
                case "smallint":
                    return "short";
                case "float":
                    return "float";
                case "double":
                    return "double";
                case "bit":
                    return "bool";
                default:
                    return "string";
            }
        }

        /// <summary>
        /// 写文件
        /// </summary>
        /// <param name="Path">文件路径</param>
        /// <param name="Strings">文件内容</param>
        public void WriteFile(string Path, string Strings)
        {
            if (File.Exists(Path))
                File.Delete(Path);
            System.IO.FileStream f = System.IO.File.Create(Path);
            f.Close();
            f.Dispose();
            System.IO.StreamWriter f2 = new System.IO.StreamWriter(Path, true, System.Text.Encoding.UTF8);
            f2.WriteLine(Strings);
            f2.Close();
            f2.Dispose();


        }
    }
}
