using DBHelper.SQLHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseToCalss
{
    public class ToWebDemo
    {
        string BasePath = "D:/ToDemo";
        string TargetFramework = "netcoreapp2.2";
        string LangVersion = "7.3";
        string PanCodeVersion = "1.0.1";
        string CoreDBHelperVersion = "1.0.3";

        List<string> udList = new List<string>() { "Update_Time", "Update_UserId", "Update_User" };
        List<string> crList = new List<string>() { "Create_Time", "Create_UserId", "Create_User" };

        StringBuilder GetCsprojectStart()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<Project Sdk=\"Microsoft.NET.Sdk\">\n");
            sb.Append("    <PropertyGroup>\n");
            sb.AppendFormat("        <TargetFramework>{0}</TargetFramework>\n", TargetFramework);
            sb.AppendFormat("        <LangVersion>{0}</LangVersion>\n", LangVersion);
            sb.Append("    </PropertyGroup>\n");

            return sb;
        }
        StringBuilder GetCsprojectEnd(StringBuilder sb)
        {
            sb.Append("</Project>\n");
            return sb;
        }
        public Action<string> SetMessage;
        public ToWebDemo()
        {
        }
        public void Start(string ns, List<string> names)
        {
            foreach (var name in names)
            {
                Dictionary<string, object> dic = new Dictionary<string, object>();
                dic["DBName"] = StaticValue.Database;
                dic["TableName"] = name;
                var list = SQLHelperFactory.Instance.QueryForListByT<sys_table_column_model>("GetTableColumnList", dic);
                ToEntity(ns, name, list);
                ToIRepository(ns, name, list);
                ToRepository(ns, name, list);
                ToControllers(ns, name, list);
                ToSql(ns, name, list);
                ToViewModels(ns, name, list);
            }
            ToValuesController(ns);
            ToDockerfile(ns);
            ToLoginFilter(ns);
            ToAuthTokenFilter(ns);
            ToDependencyExtention(ns, names);
            ToRequesrExtention(ns, names);
            ToAppsettings(ns);
            ToNLog(ns);
            ToLaunchSettings(ns);
            ToProgram(ns);
            ToStartup(ns);
            ToConstant(ns);
            ToEntityCsproject(ns);
            ToIRepositoryCsproject(ns);
            ToRepositoryCsproject(ns);
            ToAPICsproject(ns, names);
            ToLoginViewModels(ns);
            ToFramework(ns);
            SetMessage?.Invoke("创建完成");
            var path = string.Format("{0}/{1}/", BasePath, ns);
            System.Diagnostics.Process.Start(path);
        }
        #region  Framework

        private string ToFramework(string ns)
        {
            var ProjectID = Guid.NewGuid().ToString().ToUpper();
            var RepositoryID = Guid.NewGuid().ToString().ToUpper();
            var IRepositoryID = Guid.NewGuid().ToString().ToUpper();
            var EntityID = Guid.NewGuid().ToString().ToUpper();
            var APIID = Guid.NewGuid().ToString().ToUpper();
            //var TestID = Guid.NewGuid().ToString().ToUpper();
            StringBuilder sb = new StringBuilder();
            sb.Append("\n");
            sb.Append("Microsoft Visual Studio Solution File, Format Version 12.00\n");
            sb.Append("# Visual Studio 15\n");
            sb.Append("VisualStudioVersion = 15.0.28307.168\n");
            sb.Append("MinimumVisualStudioVersion = 10.0.40219.1\n");


            sb.Append("Project(\"{");
            sb.Append(ProjectID);
            sb.Append("}\") = ");
            sb.AppendFormat("\"{0}.API\", \"{0}.API\\{0}.API.csproj\", \"", ns);
            sb.Append("{");
            sb.Append(APIID);
            sb.Append("}\"\n");
            sb.Append("EndProject\n");

            sb.Append("Project(\"{");
            sb.Append(ProjectID);
            sb.Append("}\") = ");
            sb.AppendFormat("\"{0}.Entity\", \"{0}.Entity\\{0}.Entity.csproj\", \"", ns);
            sb.Append("{");
            sb.Append(EntityID);
            sb.Append("}\"\n");
            sb.Append("EndProject\n");

            sb.Append("Project(\"{");
            sb.Append(ProjectID);
            sb.Append("}\") = ");
            sb.AppendFormat("\"{0}.IRepository\", \"{0}.IRepository\\{0}.IRepository.csproj\", \"", ns);
            sb.Append("{");
            sb.Append(IRepositoryID);
            sb.Append("}\"\n");
            sb.Append("EndProject\n");

            sb.Append("Project(\"{");
            sb.Append(ProjectID);
            sb.Append("}\") = ");
            sb.AppendFormat("\"{0}.Repository\", \"{0}.Repository\\{0}.Repository.csproj\", \"", ns);
            sb.Append("{");
            sb.Append(RepositoryID);
            sb.Append("}\"\n");
            sb.Append("EndProject\n");

            //sb.Append("Project(\"{");
            //sb.Append(ProjectID);
            //sb.Append("}\") = ");
            //sb.AppendFormat("\"{0}.Test\", \"{0}.Test\\{0}.Test.csproj\", \"", ns);
            //sb.Append("{");
            //sb.Append(TestID);
            //sb.Append("}\"\n");
            //sb.Append("EndProject\n");

            sb.Append("Global\n");
            sb.Append("	GlobalSection(SolutionConfigurationPlatforms) = preSolution\n");
            sb.Append("		Debug|Any CPU = Debug|Any CPU\n");
            sb.Append("		Release|Any CPU = Release|Any CPU\n");
            sb.Append("	EndGlobalSection\n");
            sb.Append("	GlobalSection(ProjectConfigurationPlatforms) = postSolution\n");

            sb.Append("		{");
            sb.Append(APIID);
            sb.Append("}.Debug|Any CPU.ActiveCfg = Debug|Any CPU\n");
            sb.Append("		{");
            sb.Append(APIID);
            sb.Append("}.Debug|Any CPU.Build.0 = Debug|Any CPU\n");
            sb.Append("		{");
            sb.Append(APIID);
            sb.Append("}.Release|Any CPU.ActiveCfg = Release|Any CPU\n");
            sb.Append("		{");
            sb.Append(APIID);
            sb.Append("}.Release|Any CPU.Build.0 = Release|Any CPU\n");

            sb.Append("		{");
            sb.Append(EntityID);
            sb.Append("}.Debug|Any CPU.ActiveCfg = Debug|Any CPU\n");
            sb.Append("		{");
            sb.Append(EntityID);
            sb.Append("}.Debug|Any CPU.Build.0 = Debug|Any CPU\n");
            sb.Append("		{");
            sb.Append(EntityID);
            sb.Append("}.Release|Any CPU.ActiveCfg = Release|Any CPU\n");
            sb.Append("		{");
            sb.Append(EntityID);
            sb.Append("}.Release|Any CPU.Build.0 = Release|Any CPU\n");

            sb.Append("		{");
            sb.Append(IRepositoryID);
            sb.Append("}.Debug|Any CPU.ActiveCfg = Debug|Any CPU\n");
            sb.Append("		{");
            sb.Append(IRepositoryID);
            sb.Append("}.Debug|Any CPU.Build.0 = Debug|Any CPU\n");
            sb.Append("		{");
            sb.Append(IRepositoryID);
            sb.Append("}.Release|Any CPU.ActiveCfg = Release|Any CPU\n");
            sb.Append("		{");
            sb.Append(IRepositoryID);
            sb.Append("}.Release|Any CPU.Build.0 = Release|Any CPU\n");

            sb.Append("		{");
            sb.Append(RepositoryID);
            sb.Append("}.Debug|Any CPU.ActiveCfg = Debug|Any CPU\n");
            sb.Append("		{");
            sb.Append(RepositoryID);
            sb.Append("}.Debug|Any CPU.Build.0 = Debug|Any CPU\n");
            sb.Append("		{");
            sb.Append(RepositoryID);
            sb.Append("}.Release|Any CPU.ActiveCfg = Release|Any CPU\n");
            sb.Append("		{");
            sb.Append(RepositoryID);
            sb.Append("}.Release|Any CPU.Build.0 = Release|Any CPU\n");

            //sb.Append("		{");
            //sb.Append(TestID);
            //sb.Append("}.Debug|Any CPU.ActiveCfg = Debug|Any CPU\n");
            //sb.Append("		{");
            //sb.Append(TestID);
            //sb.Append("}.Debug|Any CPU.Build.0 = Debug|Any CPU\n");
            //sb.Append("		{");
            //sb.Append(TestID);
            //sb.Append("}.Release|Any CPU.ActiveCfg = Release|Any CPU\n");
            //sb.Append("		{");
            //sb.Append(TestID);
            //sb.Append("}.Release|Any CPU.Build.0 = Release|Any CPU\n");

            sb.Append("	EndGlobalSection\n");
            sb.Append("	GlobalSection(SolutionProperties) = preSolution\n");
            sb.Append("		HideSolutionNode = FALSE\n");
            sb.Append("	EndGlobalSection\n");
            sb.Append("	GlobalSection(ExtensibilityGlobals) = postSolution\n");
            sb.Append("		SolutionGuid = {");
            sb.Append(Guid.NewGuid().ToString().ToUpper());
            sb.Append("}\n");
            sb.Append("	EndGlobalSection\n");
            sb.Append("EndGlobal\n");
            var path = string.Format("{0}/{1}/{1}.Framework.sln", BasePath, ns);
            WriteFile(path, sb.ToString());
            return sb.ToString();
        }
        #endregion

        #region WEB
        #region Filters
        private string ToLoginFilter(string ns)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("using System;\n");
            sb.Append("using Microsoft.AspNetCore.Mvc.Filters;\n");
            sb.Append("\n");
            sb.AppendFormat("namespace {0}.API.Filters\n", ns);
            sb.Append(@"{
    /// <summary>
    /// 登录权限过滤
    /// </summary>
    public class LoginFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            //检查是否已登录
            //ApiResult<int> apiResult = new ApiResult<int>();
            //apiResult.IsOk = false;
            //apiResult.Message = EnumType.ApiCodeEnum.NotLogin.Description();
            //apiResult.Code = EnumType.ApiCodeEnum.NotLogin.ToInt();
            //apiResult.Result= EnumType.ApiCodeEnum.NotLogin.ToInt();
            //context.HttpContext.Response.WriteAsync(apiResult.ToJson());
        }
    }
}");
            sb.Append("\n");
            var path = string.Format("{0}/{1}/{1}.API/Filters/LoginFilter.cs", BasePath, ns);
            WriteFile(path, sb.ToString());
            return sb.ToString();
        }

        private string ToAuthTokenFilter(string ns)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("using System.Collections.Generic;\n");
            sb.Append("using System.Linq;\n");
            sb.Append("using Microsoft.AspNetCore.Authorization;\n");
            sb.Append("using Microsoft.AspNetCore.Mvc.Controllers;\n");
            sb.Append("using Swashbuckle.AspNetCore.Swagger;\n");
            sb.Append("using Swashbuckle.AspNetCore.SwaggerGen;\n");
            sb.Append("\n");
            sb.AppendFormat("namespace {0}.API.Filters\n", ns);
            sb.Append(@"{
    /// <summary>
    /// 控制swagger中是否需要添加accesstoken验证 KEY:Authorization
    /// </summary>
    public class AddAuthTokenHeaderParameter : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null) operation.Parameters = new List<IParameter>();
            var attrs = context.ApiDescription.ActionDescriptor.AttributeRouteInfo;
            var descriptor = context.ApiDescription.ActionDescriptor as ControllerActionDescriptor;
            if (descriptor != null)
            {
                var actionAttributes = descriptor.MethodInfo.GetCustomAttributes(inherit: true);
                bool isAuthorize = actionAttributes.Any(a => a is AuthorizeAttribute);
                operation.Parameters.Add(new NonBodyParameter()
                {
                  ");
            sb.Append("                    Name = \"Authorization\",\n");
            sb.Append("                    In = \"header\",//query header body path formData\n");
            sb.Append("                    Type = \"string\",\n");
            sb.Append("                    Required = isAuthorize //是否必选\n");
            sb.Append(@"                });
                }
            }
        }
    }
}");
            sb.Append("\n");
            var path = string.Format("{0}/{1}/{1}.API/Filters/AddAuthTokenHeaderParameter.cs", BasePath, ns);
            WriteFile(path, sb.ToString());
            return sb.ToString();
        }
        #endregion
        #region Extention
        private string ToDependencyExtention(string ns, List<string> names)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("using System;\n");
            sb.Append("using Microsoft.Extensions.DependencyInjection;\n");
            sb.AppendFormat("using {0}.Repository;", ns);
            sb.AppendFormat("using {0}.IRepository;", ns);
            sb.Append("\n");
            sb.AppendFormat("namespace {0}.API.Extentions", ns);
            sb.Append(@"{
    public static class DependencyExtention
    {
        public static void RegisDependency(this IServiceCollection services)
        {");
            sb.Append("\n");
            foreach (var name in names)
            {
                sb.AppendFormat("            services.AddScoped<I{0}_Repository, {0}_Repository>();\n", name);
            }
            sb.Append(@"
        }
    }
}");
            sb.Append("\n");
            var path = string.Format("{0}/{1}/{1}.API/Extentions/DependencyExtention.cs", BasePath, ns);
            WriteFile(path, sb.ToString());
            return sb.ToString();
        }

        private string ToRequesrExtention(string ns, List<string> names)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Pan.Code.Extentions;
using Pan.Code.UserException;\n");
            sb.Append("\n");
            sb.AppendFormat("namespace {0}.API.Extentions", ns);
            sb.Append(@"{
    public static class RequesrExtention
    {
        public static LoginUserModel GetLoginUser(this ControllerBase controller)
        {
            try
            {
                var token = controller.Request.Headers[Constant.LoginToken_Key].ToString();
                if (!string.IsNullOrWhiteSpace(token))
                {
                    var temp = new JwtSecurityTokenHandler().ReadJwtToken(token.Replace(Constant.JwtTokenPrefix, ""));
                    if (temp != null && temp.Claims != null && temp.Claims.Count() > 0)
                    {
                        return temp.Claims.FirstOrDefault().Value.ToModel<LoginUserModel>();
                    }
                }
            }
            catch
            {
            }
            throw new NotLoginException();
        }");
            sb.Append(@"
    }
}");
            sb.Append("\n");
            var path = string.Format("{0}/{1}/{1}.API/Extentions/RequesrExtention.cs", BasePath, ns);
            WriteFile(path, sb.ToString());
            return sb.ToString();
        }

        #endregion
        #region Controllers

        private string ToControllers(string ns, string name, List<sys_table_column_model> list)
        {
            var firstColumn = list.FirstOrDefault();
            StringBuilder sb = new StringBuilder();
            sb.Append("using System;\n");
            sb.Append("using System.Collections.Generic;\n");
            sb.Append("using Microsoft.AspNetCore.Mvc;\n");
            sb.Append("using Microsoft.Extensions.Logging;\n");
            sb.Append("using Pan.Code;\n");
            sb.Append("using Pan.Code.Extentions;\n");
            sb.AppendFormat("using {0}.API.Filters;\n", ns);
            sb.AppendFormat("using {0}.Entity;\n", ns);
            sb.AppendFormat("using {0}.IRepository;\n", ns);
            sb.AppendFormat("using Microsoft.AspNetCore.Authorization;\n", ns);
            sb.AppendFormat("using Hoshino.API.ViewModels;\n", ns);
            sb.Append("\n");
            sb.AppendFormat("namespace {0}.API.Controllers\n", ns);
            sb.Append("{\n");
            sb.Append("    /// <summary>\n");
            sb.AppendFormat("    /// {0}\n", name);
            sb.Append("    /// </summary>\n");
            sb.Append("    [Route(\"api/[controller]/[action]\")]\n");
            sb.Append("    [ApiController]\n");
            sb.AppendFormat("    public class {0}Controller : ControllerBase\n", name);
            sb.Append("    {\n");
            sb.AppendFormat("        private readonly ILogger<{0}Controller> _logger;\n", name);
            sb.AppendFormat("        private readonly I{0}_Repository _repository;\n", name);
            sb.Append("        /// <summary>\n");
            sb.Append("        /// 构造函数\n");
            sb.Append("        /// </summary>\n");
            sb.AppendFormat("        public {0}Controller(ILogger<{0}Controller> logger,I{0}_Repository repository)\n", name);
            sb.Append("        {\n");
            sb.Append("            this._logger = logger;\n");
            sb.Append("            this._repository = repository;\n");
            sb.Append("        }\n");

            #region Insert
            sb.Append("        /// <summary>\n");
            sb.Append("        /// 新增\n");
            sb.Append("        /// </summary>\n");
            sb.Append("        [Authorize]\n");
            sb.Append("        [HttpPost]\n");
            sb.Append("        [ProducesResponseType(200, Type = typeof(ApiResult<bool>))]\n");
            sb.AppendFormat("        public ActionResult<object> Post([FromBody]{0}VM model)\n", name);
            sb.Append("        {\n");
            sb.AppendFormat("            {0}_Entity entity = model.ConvertToT<{0}_Entity>();\n", name);
            sb.Append("            return this._repository.Insert(entity).ResponseSuccess();\n");
            sb.Append("        }\n\n");
            #endregion Insert

            #region Update
            sb.Append("        /// <summary>\n");
            sb.Append("        /// 修改\n");
            sb.Append("        /// </summary>\n");
            sb.Append("        [Authorize]\n");
            sb.Append("        [HttpPut]\n");
            sb.Append("        [ProducesResponseType(200, Type = typeof(ApiResult<bool>))]\n");
            sb.AppendFormat("        public ActionResult<object> Update([FromBody]{0}VM model)\n", name);
            sb.Append("        {\n");
            sb.AppendFormat("            {0}_Entity entity = model.ConvertToT<{0}_Entity>();\n", name);
            sb.Append("            return this._repository.Update(entity).ResponseSuccess();\n");
            sb.Append("        }\n\n");
            #endregion Update

            #region Delete
            sb.Append("        /// <summary>\n");
            sb.Append("        /// 删除\n");
            sb.Append("        /// </summary>\n");
            sb.Append("        [Authorize]\n");
            sb.Append("        [HttpDelete]\n");
            sb.Append("        [ProducesResponseType(200, Type = typeof(ApiResult<bool>))]\n");
            sb.AppendFormat("        public ActionResult<object> Delete({0} {1})\n", ConvrtType(firstColumn.data_type, firstColumn.is_nullable), firstColumn.column_name);
            sb.Append("        {\n");
            sb.AppendFormat("            return this._repository.Delete({0}).ResponseSuccess();\n", firstColumn.column_name);
            sb.Append("        }\n\n");
            #endregion Delete

            #region Select
            sb.Append("        /// <summary>\n");
            sb.Append("        /// 获取单个\n");
            sb.Append("        /// </summary>\n");
            sb.Append("        [Authorize]\n");
            sb.Append("        [HttpGet]\n");
            sb.AppendFormat("        [ProducesResponseType(200, Type = typeof(ApiResult<{0}_Entity>))]\n", name);
            sb.AppendFormat("        public ActionResult<object> Get({0} {1})\n", ConvrtType(firstColumn.data_type, firstColumn.is_nullable), firstColumn.column_name);
            sb.Append("        {\n");
            sb.AppendFormat("            return this._repository.Get({0}).ResponseSuccess();\n", firstColumn.column_name);
            sb.Append("        }\n\n");
            #endregion Select


            #region SelectList
            sb.Append("        /// <summary>\n");
            sb.Append("        /// 获取列表\n");
            sb.Append("        /// </summary>\n");
            sb.Append("        [HttpPost]\n");
            sb.AppendFormat("        [ProducesResponseType(200, Type = typeof(ApiResult<List<{0}_Entity>>))]\n", name);
            sb.AppendFormat("        public ActionResult<object> GetList([FromBody]{0}VM model,int pageindex,int pagesize)\n", name);
            sb.Append("        {\n");
            sb.AppendFormat("            {0}_Entity entity = model.ConvertToT<{0}_Entity>();\n", name);
            sb.Append("            var (list,total) = this._repository.GetList(entity, pageindex, pagesize) ;\n");
            sb.Append("            return list.ResponseSuccess(\"\",total);\n");
            sb.Append("        }\n\n");
            #endregion SelectList


            sb.Append("    }\n");
            sb.Append("}");
            var path = string.Format("{0}/{1}/{1}.API/Controllers/{2}Controller.cs", BasePath, ns, name);
            WriteFile(path, sb.ToString());
            return sb.ToString();
        }

        private string ToValuesController(string ns)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("using System;\n");
            sb.Append("using System.Collections.Generic;\n");
            sb.Append("using System.Linq;\n");
            sb.Append("using System.Threading.Tasks;\n");
            sb.Append("using Microsoft.AspNetCore.Mvc;\n");
            sb.Append("using Pan.Code.Common;\n");
            sb.Append("\n");
            sb.AppendFormat("namespace {0}.API.Controllers\n", ns);
            sb.Append("{\n");
            sb.Append("    [Route(\"api/[controller]/[action]\")]\n");
            sb.Append("    [ApiController]\n");
            sb.Append("    public class ValuesController : ControllerBase\n");
            sb.Append("    {\n");

            sb.Append("        /// <summary>\n");
            sb.Append("        /// 获取验证码\n");
            sb.Append("        /// </summary>\n");
            sb.Append("        [HttpGet]\n");
            sb.Append("        public FileResult GetValidateCode()\n");
            sb.Append("        {\n");

            sb.Append("            byte[] imageFile = VerificationCodeImage.CreateImage(out string code);\n");
            sb.Append("            HttpContext.Session.Set(Constant.Session_CheckCode, Encoding.UTF8.GetBytes(code));\n");
            sb.Append("            return File(imageFile, \"image/gif\");\n");

            sb.Append("        }\n");
            sb.Append("\n");

            sb.Append("        /// <summary>\n");
            sb.Append("        /// 登录接口\n");
            sb.Append("        /// </summary>\n");
            sb.Append("        [AllowAnonymous]\n");
            sb.Append("        [HttpPost]\n");
            sb.Append("        [ProducesResponseType(200, Type = typeof(ApiResult<string>))]\n");
            sb.Append("       public ActionResult<object> Login([FromBody]LoginVM model)\n");
            sb.Append("        {\n");
            sb.Append("            if (string.IsNullOrWhiteSpace(code) || string.IsNullOrWhiteSpace(HttpContext.Session.GetString(Constant.Session_CheckCode)) || !code.ToLower().Equals(HttpContext.Session.GetString(Constant.Session_CheckCode).ToLower()))\n");
            sb.Append("            {\n");
            sb.Append("                return this.ResponseUnknown(\"验证码错误\");\n");
            sb.Append("            }\n");
            sb.Append("            Object user = null;\n");
            sb.Append("            //user = this._repository.GetUserByAccount(model.Account);\n");
            sb.Append("            //if (user == null || !model.Password.Equals(user.Password))\n");
            sb.Append("            //{\n");
            sb.Append("                //{model.ResponseNotLogin(\"登录失败\");\n");
            sb.Append("            //}\n");
            sb.Append("            LoginUserModel loginUser = new LoginUserModel();\n");
            sb.Append("            loginUser.UserID = \"1\";\n");
            sb.Append("            loginUser.UserName = \"admin\";\n");

            sb.Append("            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this._configuration[\"JWT: SecurityKey\"]));\n");
            sb.Append("            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);\n");
            sb.Append("            var claims = new[] {new Claim(ClaimTypes.Name,loginUser.ToJson())};\n");
            sb.Append("            var authTime = DateTime.UtcNow;\n");
            sb.Append("            var expiresAt = authTime.AddDays(1);\n");
            sb.Append("            var token = new JwtSecurityToken(issuer: \"*\", audience: \"*\", claims: claims, expires: expiresAt, signingCredentials: creds);\n");
            sb.Append("            loginUser.token = Constant.JwtTokenPrefix + new JwtSecurityTokenHandler().WriteToken(token);\n");
            sb.Append("            return loginUser.ResponseSuccess();\n");

            sb.Append("        }\n");

            sb.Append("    }\n");
            sb.Append("}\n");
            var path = string.Format("{0}/{1}/{1}.API/Controllers/ValuesController.cs", BasePath, ns);
            WriteFile(path, sb.ToString());
            return sb.ToString();
        }
        #endregion

        #region ViewModel

        private string ToViewModels(string ns, string name, List<sys_table_column_model> list)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("using System;\n");
            sb.Append("using System.ComponentModel.DataAnnotations;\n");
            sb.Append("\n");
            sb.AppendFormat("namespace {0}.API.ViewModels\n", ns);
            sb.Append("{\n");
            sb.Append("    /// <summary>\n");
            sb.AppendFormat("    /// {0}\n", name);
            sb.Append("    /// </summary>\n");
            sb.AppendFormat("    public class {0}VM\n", name);
            sb.Append("    {\n");
            foreach (var item in list)
            {
                if (udList.Contains(item.column_name) || crList.Contains(item.column_name))
                {
                    continue;
                }
                sb.Append("        /// <summary>\n");

                sb.AppendFormat("        /// {0}\n", item.column_comment);
                sb.Append("        /// </summary>\n");
                if (item.character_maximum_length.HasValue)
                {
                    sb.AppendFormat("        [MaxLength(length:{0},ErrorMessage =\"长度不能超过{0}字符\")]\n", item.character_maximum_length.Value);
                }
                sb.AppendFormat("        public {0} {1} {2}\n", ConvrtType(item.data_type, item.is_nullable), item.column_name, "{ get; set; }");

                sb.Append("\n");
            }
            sb.Append("    }\n");
            sb.Append("}");
            var path = string.Format("{0}/{1}/{1}.API/ViewModels/{2}VM.cs", BasePath, ns, name);
            WriteFile(path, sb.ToString());
            return sb.ToString();
        }
        private string ToLoginViewModels(string ns)
        {
            string name = "Login";
            StringBuilder sb = new StringBuilder();
            sb.Append("using System;\n");
            sb.Append("\n");
            sb.AppendFormat("namespace {0}.API.ViewModels\n", ns);
            sb.Append("{\n");
            sb.AppendFormat("    public class {0}VM\n", name);
            sb.Append("    {\n");
            sb.Append("        /// <summary>\n");
            sb.Append("        /// 登录名\n");
            sb.Append("        /// </summary>\n");
            sb.Append("        public string Account { get; set; }\n");

            sb.Append("        /// <summary>\n");
            sb.Append("        /// 密码\n");
            sb.Append("        /// </summary>\n");
            sb.Append("        public string Password { get; set; }\n");

            sb.Append("        /// <summary>\n");
            sb.Append("        /// 验证码\n");
            sb.Append("        /// </summary>\n");
            sb.Append("        public string VerificationCode { get; set; }\n");

            sb.Append("\n");

            sb.Append("    }\n");
            sb.Append("}");
            var path = string.Format("{0}/{1}/{1}.API/ViewModels/{2}VM.cs", BasePath, ns, name);
            WriteFile(path, sb.ToString());
            return sb.ToString();
        }

        #endregion ViewModel
        #region Dockerfile

        private string ToDockerfile(string ns)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base\n");
            sb.Append(" WORKDIR /app\n");
            sb.Append(" EXPOSE 80\n");
            sb.Append(" EXPOSE 443\n");
            sb.Append(" \n");
            sb.Append(" FROM microsoft/dotnet:2.2-sdk AS build\n");
            sb.Append(" WORKDIR /src\n");
            sb.AppendFormat(" COPY [\"{0}.API/{0}.API.csproj\", \"{0}.API/\"]\n", ns);
            sb.AppendFormat(" RUN dotnet restore \"{0}.API/{0}.API.csproj\"\n", ns);
            sb.Append(" COPY . .\n");
            sb.AppendFormat(" WORKDIR \"/src/{0}.API\"\n", ns);
            sb.AppendFormat(" RUN dotnet build \"{0}.API.csproj\" -c Release -o /app\n", ns);
            sb.Append(" \n");
            sb.Append(" FROM build AS publish\n");
            sb.AppendFormat(" RUN dotnet publish \"{0}.API.csproj\" -c Release -o /app\n", ns);
            sb.Append(" \n");
            sb.Append(" FROM base AS final\n");
            sb.Append(" WORKDIR /app\n");
            sb.Append(" COPY --from=publish /app .\n");
            sb.AppendFormat(" ENTRYPOINT [\"dotnet\", \"{0}.API.dll\"]", ns);
            var path = string.Format("{0}/{1}/{1}.API/Dockerfile", BasePath, ns);
            WriteFile(path, sb.ToString());
            return sb.ToString();
        }

        #endregion
        #region Sql

        private string ToSql(string ns, string name, List<sys_table_column_model> list)
        {
            StringBuilder sb = new StringBuilder();
            var namelist = list.Select(s => s.column_name);
            var insertvaluselist = list.Select(s => "@@" + s.column_name + "@@");
            var setlist = list.Select(s => "<%=," + s.column_name + "=@@" + s.column_name + "@@%>").ToList();
            setlist.RemoveAt(0);
            var wherelist = list.Select(s => "<%= AND " + s.column_name + "=@@" + s.column_name + "@@%>");
            var firstWherelist = list.Select(s => s.column_name + "=@@" + s.column_name + "@@").FirstOrDefault();
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
            sb.AppendFormat("                UPDATE {0} SET {1} {2} WHERE {3};\n", name, firstWherelist, string.Join("", setlist), firstWherelist);
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
            sb.AppendFormat("                DELETE FROM {0} WHERE {1};\n", name, firstWherelist);
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
            sb.AppendFormat("                SELECT {0} FROM {1} WHERE 1=1 {2};\n", string.Join(",", namelist), name, string.Join(" ", wherelist));
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
            sb.AppendFormat("                SELECT {0} FROM {1} WHERE 1=1 {2} LIMIT <R%= @@StartIndex@@, @@SelectCount@@ %R> ;\n", string.Join(",", namelist), name, string.Join(" ", wherelist));
            sb.AppendFormat("                SELECT COUNT(0) AS row_count FROM {0} WHERE 1=1 {1};\n", name, string.Join(" ", wherelist));
            sb.Append("                ]]>\n");
            sb.Append("            </SqlCommand>\n");
            sb.Append("        </SqlDefinition>\n");
            sb.Append("    </Data>\n");
            #endregion Select

            sb.Append("</SqlSetting>\n");
            var path = string.Format("{0}/{1}/{1}.API/SqlConfig/{2}Sql.xml", BasePath, ns, name);
            WriteFile(path, sb.ToString());
            return sb.ToString();
        }

        #endregion
        #region appsettings & Program & Startup & Csproject

        private string ToAppsettings(string ns)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{  \"ConnectionStrings\": {\n    \"Connections\":\"backstage_connection\",\n    \"backstage_connection\":\"");
            sb.Append(SQLHelperFactory.Instance.ConnectionStringsDic["backstage_connection"]);
            sb.Append("  \"},\n  \"JWT\": {\n    \"SecurityKey\": \"");
            sb.Append(Guid.NewGuid().ToString());
            sb.Append("\"\n  },\n  \"Logging\":{\n    \"LogLevel\":{\n      \"Default\":\"Information\",\n      \"Microsoft\":\"Warning\",\n      \"System\":\"Warning\"\n    }\n  },\n  \"AllowedHosts\":\"*\"\n}\n");
            var path = string.Format("{0}/{1}/{1}.API/appsettings.json", BasePath, ns);
            WriteFile(path, sb.ToString());
            return sb.ToString();
        }
        private string ToNLog(string ns)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?><nlog xmlns=\"http://www.nlog-project.org/schemas/NLog.xsd\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" autoReload=\"true\" internalLogLevel=\"info\" internalLogFile=\"c:TempGrapefruitVuCoreinternal-nlog.txt\"> <extensions> <add assembly=\"NLog.Web.AspNetCore\"/> </extensions> <!--internal-nlog:NLog启动及加载config信息--> <!--nlog-all:所有日志记录信息--> <!--nlog-own:自定义日志记录信息--> <!--the targets to write to --> <targets> <!--write logs to file --> <target xsi:type=\"File\" name=\"allfile\" fileName=\"all-${shortdate}.log\" layout=\"日志记录时间：${longdate}${newline}日志级别：${uppercase:${level}}${newline}日志来源：${logger}${newline}日志信息：${message}${newline}错误信息：${exception:format=tostring}${newline}==============================================================${newline}\"/> <!--another file log, only own logs. Uses some ASP.NET core renderers --> <target xsi:type=\"File\" name=\"ownFile-web\" fileName=\"own-${shortdate}.log\"  layout=\"日志记录时间：${longdate}${newline}日志级别：${uppercase:${level}}${newline}日志来源：${logger}${newline}日志信息：${message}${newline}错误信息：${exception:format=tostring}${newline}url: ${aspnet-request-url}${newline}action: ${aspnet-mvc-action}${newline}==============================================================${newline}\"/> </targets> <!--rules to map from logger name to target --> <rules> <!--All logs, including from Microsoft--> <logger name=\"*\" minlevel=\"Trace\" writeTo=\"allfile\"/> <!--Skip non-critical Microsoft logs and so log only own logs--> <logger name=\"Microsoft.*\" maxLevel=\"WARN\" final=\"true\"/> <!--BlackHole without writeTo --> <logger name=\"*\" minlevel=\"Trace\" writeTo=\"ownFile-web\"/> </rules></nlog>\n");
            var path = string.Format("{0}/{1}/{1}.API/nlog.config", BasePath, ns);
            WriteFile(path, sb.ToString());
            return sb.ToString();
        }

        private string ToLaunchSettings(string ns)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{\"iisSettings\":{\"windowsAuthentication\":false,\"anonymousAuthentication\":true,\"iisExpress\":{\"applicationUrl\":\"http://localhost:60737\"}},\"$schema\":\"http://json.schemastore.org/launchsettings.json\",\"profiles\":{\"IIS Express\":{\"commandName\":\"IISExpress\",\"launchBrowser\":true,\"launchUrl\":\"api/values\",\"environmentVariables\":{\"ASPNETCORE_ENVIRONMENT\":\"Development\"}},\"");
            sb.Append(ns);
            sb.Append(".API\":{\"commandName\":\"Project\",\"launchBrowser\":true,\"launchUrl\":\"api/values\",\"environmentVariables\":{\"ASPNETCORE_ENVIRONMENT\":\"Development\"},\"applicationUrl\":\"http://localhost:5000\"},\"Docker\":{\"commandName\":\"Docker\",\"launchBrowser\":true,\"launchUrl\":\"{Scheme}://{ServiceHost}:{ServicePort}/api/values\"}}}\n");
            var path = string.Format("{0}/{1}/{1}.API/Properties/launchSettings.json", BasePath, ns);
            WriteFile(path, sb.ToString());
            return sb.ToString();
        }

        private string ToProgram(string ns)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("using  System;\n");
            sb.Append("using System.Collections.Generic;\n");
            sb.Append("using System.IO;\n");
            sb.Append("using System.Linq;\n");
            sb.Append("using System.Threading.Tasks;\n");
            sb.Append("using Microsoft.AspNetCore;\n");
            sb.Append("using Microsoft.AspNetCore.Hosting;\n");
            sb.Append("using Microsoft.Extensions.Configuration;\n");
            sb.Append("using Microsoft.Extensions.Logging;\n");
            sb.Append("using NLog.Web;\n");
            sb.Append("using DBHelper.SQLHelper;\n");
            sb.Append("\n");
            sb.AppendFormat("namespace {0}.API\n", ns);
            sb.Append("{\n");
            sb.Append("    public class Program\n");
            sb.Append("    {\n");
            sb.Append("        public static void Main(string[] args)\n");
            sb.Append("        {\n");
            //sb.AppendFormat("            SQLHelperFactory.Instance.ConnectionStringsDic[\"backstage_connection\"]=\"{0}\";\n", SQLHelperFactory.Instance.ConnectionStringsDic["backstage_connection"]);
            sb.Append("            var logger = NLogBuilder.ConfigureNLog(\"nlog.config\").GetCurrentClassLogger();\n");
            sb.Append("            logger.Info(\"Init Log API Information\");\n");
            sb.Append("            CreateWebHostBuilder(args).Build().Run();\n");
            sb.Append("        }\n");
            sb.Append("\n");
            sb.Append("        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>\n");
            sb.Append("            WebHost.CreateDefaultBuilder(args)\n");
            sb.Append("                .UseStartup<Startup>()\n");
            sb.Append("            .ConfigureLogging((logging) =>\n");
            sb.Append("            {\n");
            sb.Append("                logging.AddFilter(\"System\", LogLevel.Warning);\n");
            sb.Append("                logging.AddFilter(\"Microsoft\", LogLevel.Warning);\n");
            sb.Append("                logging.ClearProviders();//移除其它已经注册的日志处理程序\n");
            sb.Append("                logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace); //记录最小日志级别\n");
            sb.Append("            }).UseNLog();//注入 NLog 服务;\n");
            sb.Append("    }\n");
            sb.Append("}");
            var path = string.Format("{0}/{1}/{1}.API/Program.cs", BasePath, ns);
            WriteFile(path, sb.ToString());
            return sb.ToString();
        }

        /// <summary>
        /// 启用jwt session 默认页
        /// </summary>
        /// <param name="ns"></param>
        /// <returns></returns>
        private string ToStartup(string ns)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("using Microsoft.AspNetCore.Builder;\n");
            sb.Append("using Microsoft.AspNetCore.Hosting;\n");
            sb.Append("using Microsoft.AspNetCore.Mvc;\n");
            sb.Append("using Microsoft.Extensions.Configuration;\n");
            sb.Append("using Microsoft.Extensions.DependencyInjection;\n");
            sb.AppendFormat("using {0}.API.Extentions;\n", ns);
            sb.Append("using Pan.Code.Middleware;\n");
            sb.Append("using Swashbuckle.AspNetCore.Swagger;\n");
            sb.Append("using Newtonsoft.Json.Serialization;\n");
            sb.Append("using System.IO;\n");
            sb.Append("using Microsoft.AspNetCore.Authentication.JwtBearer;\n");
            sb.Append("using Microsoft.IdentityModel.Tokens;\n");
            sb.Append("using System.Text;\n");
            sb.Append("using Hoshino.API.Filters;\n");
            sb.Append("\n");
            sb.AppendFormat("namespace {0}.API\n", ns);
            sb.Append("{\n");
            sb.Append("    public class Startup\n");
            sb.Append("    {\n");
            sb.Append("        public Startup(IConfiguration configuration)\n");
            sb.Append("        {\n");
            sb.Append("            Configuration = configuration;\n");
            sb.Append("        }\n");
            sb.Append("\n");
            sb.Append("        public IConfiguration Configuration { get; }\n");
            sb.Append("\n");
            sb.Append("        public void ConfigureServices(IServiceCollection services)\n");
            sb.Append("        {\n");
            sb.Append("            var Connections = Configuration.GetConnectionString(\"Connections\") ?? \"\";\n");
            sb.Append("            foreach (var con in Connections.Split(','))\n");
            sb.Append("            {\n");
            sb.Append("                DBHelper.SQLHelper.SQLHelperFactory.Instance.ConnectionStringsDic[con] = Configuration.GetConnectionString(con);\n");
            sb.Append("            }\n");
            sb.Append("            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)\n                .AddJwtBearer(options =>\n                {\n                    options.TokenValidationParameters = new TokenValidationParameters\n                    {\n                        ValidateIssuer = true,\n                        ValidateAudience = true,\n                        ValidateLifetime = true,\n                        ValidateIssuerSigningKey = true,\n                        ValidIssuer = \"*\",\n                        ValidAudience = \"*\",\n                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration[\"JWT:SecurityKey\"]))\n                    };\n                });\n");
            sb.Append("            services.AddMvc(config =>{}).AddJsonOptions(options =>\n            {\n                options.SerializerSettings.ContractResolver = new DefaultContractResolver();//设置时间格式\n                 options.SerializerSettings.DateFormatString = \"yyyy-MM-dd HH:mm:ss\";\n            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);\n");
            sb.Append("            services.RegisDependency();\n");
            sb.Append("            services.AddSwaggerGen(c =>{c.SwaggerDoc(\"v1\", new Info { Title = \"My API\", Version = \"v1\" });});\n                c.OperationFilter<AddAuthTokenHeaderParameter>();\n                // 为 Swagger JSON and UI设置xml文档注释路径\n                var basePath = Path.GetDirectoryName(typeof(Program).Assembly.Location);//获取应用程序所在目录（绝对，不受工作目录影响，建议采用此方法获取路径）\n                var xmlPath = Path.Combine(basePath, \"SwaggerDemo.xml\");\n                c.IncludeXmlComments(xmlPath);\n");
            sb.Append("        }\n");
            sb.Append("\n");
            sb.Append("        public void Configure(IApplicationBuilder app, IHostingEnvironment env)\n");
            sb.Append("        {\n");
            sb.Append("            if (env.IsDevelopment()){ app.UseDeveloperExceptionPage(); }\n");
            sb.Append("            else{ app.UseHsts(); }\n");
            sb.Append("            app.UseMiddleware<UserExceptionHandlerMiddleware>();\n");
            sb.Append("            app.UseAuthentication();\n");
            sb.Append("            app.UseHttpsRedirection();\n");
            sb.Append("            DefaultFilesOptions options = new DefaultFilesOptions();\n");
            sb.Append("            options.DefaultFileNames.Add(\"index.html\");    //将index.html改为需要默认起始页的文件名.\n");
            sb.Append("            app.UseDefaultFiles(options);\n");
            sb.Append("            app.UseStaticFiles();\n");
            sb.Append("            app.UseSwagger();\n");
            sb.Append("            app.UseSwaggerUI(c =>{ c.SwaggerEndpoint(\"/swagger/v1/swagger.json\", \"My API V1\"); });\n");
            sb.Append("            app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials());\n");
            sb.Append("            app.UseSession();\n");
            sb.Append("            app.UseMvc();\n");
            sb.Append("        }\n");
            sb.Append("    }\n");
            sb.Append("}");
            var path = string.Format("{0}/{1}/{1}.API/Startup.cs", BasePath, ns);
            WriteFile(path, sb.ToString());
            return sb.ToString();
        }


        private string ToAPICsproject(string ns, List<string> names)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<Project Sdk=\"Microsoft.NET.Sdk.Web\">\n");
            sb.Append("    <PropertyGroup>\n");
            sb.AppendFormat("        <TargetFramework>{0}</TargetFramework>\n", TargetFramework);
            sb.Append("        <AspNetCoreHostingModel>InProcess</AspNetCoreHostingModel>\n");
            sb.Append("        <DockerDefaultTargetOS>Linux</DockerDefaultTargetOS>\n");
            sb.AppendFormat("        <UserSecretsId>{0}</UserSecretsId>\n", Guid.NewGuid().ToString());
            sb.Append("    </PropertyGroup>\n");

            sb.Append("    <PropertyGroup Condition=\"'$(Configuration)|$(Platform)' == 'Debug|AnyCPU'\">\n");
            sb.Append("        <DocumentationFile>bin\\Debug\\netcoreapp2.2\\SwaggerDemo.xml</DocumentationFile>\n");
            sb.Append("        <NoWarn>1701;1702:1591</NoWarn>\n");
            sb.Append("    </PropertyGroup>\n");


            sb.Append("    <ItemGroup>\n");
            sb.Append("        <PackageReference Include=\"Microsoft.AspNetCore.App\" />\n");
            sb.Append("        <PackageReference Include=\"Microsoft.AspNetCore.Razor.Design\" Version=\"2.2.0\" PrivateAssets=\"All\" />\n");
            sb.Append("        <PackageReference Include=\"Microsoft.VisualStudio.Azure.Containers.Tools.Targets\" Version=\"1.0.2105168\" />\n");
            sb.Append("        <PackageReference Include=\"NLog\" Version=\"4.5.11\" />\n");
            sb.Append("        <PackageReference Include=\"NLog.Mongo\" Version=\"4.6.0.68\" />\n");
            sb.Append("        <PackageReference Include=\"NLog.Web.AspNetCore\" Version=\"4.7.1\" />\n");
            sb.Append("        <PackageReference Include=\"Swashbuckle.AspNetCore\" Version=\"4.0.1\" />\n");
            sb.AppendFormat("        <PackageReference Include=\"Pan.Code\" Version=\"{0}\" />\n", PanCodeVersion);
            sb.Append("    </ItemGroup>\n");

            sb.Append("    <ItemGroup>\n");
            sb.AppendFormat("        <ProjectReference Include=\"..\\{0}.Entity\\{0}.Entity.csproj\" />\n", ns);
            sb.AppendFormat("        <ProjectReference Include=\"..\\{0}.IRepository\\{0}.IRepository.csproj\" />\n", ns);
            sb.AppendFormat("        <ProjectReference Include=\"..\\{0}.Repository\\{0}.Repository.csproj\" />\n", ns);
            sb.Append("    </ItemGroup>\n");


            sb.Append("    <ItemGroup>\n");
            foreach (var name in names)
            {
                sb.AppendFormat("        <None Include=\"SqlConfig\\{0}Sql.xml\">\n", name);
                sb.Append("        <CopyToOutputDirectory>Always</CopyToOutputDirectory>\n");
                sb.Append("        </None>\n");
            }
            sb.Append("    </ItemGroup>\n");
            sb.Append("    <ItemGroup>\n");
            sb.Append("        <Content Update=\"appsettings.json\">\n");
            sb.Append("        <CopyToOutputDirectory>Always</CopyToOutputDirectory>\n");
            sb.Append("        </Content>\n");
            sb.Append("        <Content Update=\"nlog.config\">\n");
            sb.Append("        <CopyToOutputDirectory>Always</CopyToOutputDirectory>\n");
            sb.Append("        </Content>\n");

            sb.Append("    </ItemGroup>\n");


            sb.Append("</Project>\n");
            var path = string.Format("{0}/{1}/{1}.API/{1}.API.csproj", BasePath, ns);
            WriteFile(path, sb.ToString());
            return sb.ToString();
        }

        #endregion

        #endregion


        #region Entity

        private string ToEntity(string ns, string name, List<sys_table_column_model> list)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("using System;\n");
            sb.Append("\n");
            sb.AppendFormat("namespace {0}.Entity\n", ns);
            sb.Append("{\n");
            sb.AppendFormat("    public class {0}_Entity\n", name);
            sb.Append("    {\n");
            foreach (var item in list)
            {
                sb.Append("        /// <summary>\n");
                sb.AppendFormat("        /// {0}\n", item.column_comment);
                sb.Append("        /// </summary>\n");
                sb.AppendFormat("        public {0} {1} {2}\n", ConvrtType(item.data_type, item.is_nullable), item.column_name, "{ get; set; }");

                sb.Append("\n");
            }
            sb.Append("    }\n");
            sb.Append("}");
            var path = string.Format("{0}/{1}/{1}.Entity/{2}_Entity.cs", BasePath, ns, name);
            WriteFile(path, sb.ToString());
            return sb.ToString();
        }


        private string ToConstant(string ns)
        {
            StringBuilder sb = GetCsprojectStart();
            sb.AppendFormat("namespace {0}.Entity\n", ns);
            sb.Append("{\n");
            sb.Append("    public class Constant\n");
            sb.Append("    {\n");
            sb.Append("        public const string LoginToken_Key = \"Authorization\";\n");
            sb.Append("        public const string JwtTokenPrefix = \"Bearer\";\n");
            sb.Append("         /// <summary>\n");
            sb.Append("         /// 验证码session名称\n");
            sb.Append("         /// </summary>\n");
            sb.Append("        public const string Session_CheckCode = \"Session_CheckCode\";\n");
            sb.Append("{\n");
            sb.Append("    }\n");
            sb.Append("}\n");
            var path = string.Format("{0}/{1}/{1}.Entity/Constant.cs", BasePath, ns);
            WriteFile(path, sb.ToString());
            return sb.ToString();
        }
        private string ToEntityCsproject(string ns)
        {
            StringBuilder sb = GetCsprojectStart();

            #region PackageReference
            sb.Append("    <ItemGroup>\n");
            sb.AppendFormat("        <PackageReference Include=\"Pan.Code\" Version=\"{0}\" />\n", PanCodeVersion);
            sb.Append("    </ItemGroup>\n");
            #endregion PackageReference

            sb = GetCsprojectEnd(sb);
            var path = string.Format("{0}/{1}/{1}.Entity/{1}.Entity.csproj", BasePath, ns);
            WriteFile(path, sb.ToString());
            return sb.ToString();
        }


        #endregion

        #region IRepository

        private string ToIRepository(string ns, string name, List<sys_table_column_model> list)
        {
            var firstColumn = list.FirstOrDefault();
            StringBuilder sb = new StringBuilder();
            sb.Append("using System;\n");
            sb.Append("using System.Collections.Generic;\n");
            sb.AppendFormat("using {0}.Entity;\n", ns);
            sb.Append("\n");
            sb.AppendFormat("namespace {0}.IRepository\n", ns);
            sb.Append("{\n");
            sb.AppendFormat("    public interface I{0}_Repository\n", name);
            sb.Append("    {\n");

            #region Insert
            sb.Append("        /// <summary>\n");
            sb.Append("        /// 新增\n");
            sb.Append("        /// </summary>\n");
            sb.AppendFormat("        bool Insert({0}_Entity model);\n", name);
            sb.Append("\n");
            #endregion Insert

            #region Update
            sb.Append("        /// <summary>\n");
            sb.Append("        /// 修改\n");
            sb.Append("        /// </summary>\n");
            sb.AppendFormat("        bool Update({0}_Entity model);\n", name);
            sb.Append("\n");
            #endregion Update

            #region Delete
            sb.Append("        /// <summary>\n");
            sb.Append("        /// 删除\n");
            sb.Append("        /// </summary>\n");
            sb.AppendFormat("        bool Delete({0} {1});\n", ConvrtType(firstColumn.data_type, firstColumn.is_nullable), firstColumn.column_name);
            sb.Append("\n");
            #endregion Delete

            #region Select
            sb.Append("        /// <summary>\n");
            sb.Append("        /// 获取单个\n");
            sb.Append("        /// </summary>\n");
            sb.AppendFormat("        {0}_Entity Get({1} {2});\n", name, ConvrtType(firstColumn.data_type, firstColumn.is_nullable), firstColumn.column_name);
            sb.Append("\n");
            #endregion Select

            #region SelectList
            sb.Append("        /// <summary>\n");
            sb.Append("        /// 获取列表\n");
            sb.Append("        /// </summary>\n");
            sb.AppendFormat("        (IEnumerable<{0}_Entity>,int) GetList({0}_Entity model,int pageindex,int pagesize);\n", name);
            sb.Append("\n");
            #endregion SelectList

            sb.Append("    }\n");
            sb.Append("}");
            var path = string.Format("{0}/{1}/{1}.IRepository/I{2}_Repository.cs", BasePath, ns, name);
            WriteFile(path, sb.ToString());
            return sb.ToString();
        }

        private string ToIRepositoryCsproject(string ns)
        {
            StringBuilder sb = GetCsprojectStart();

            sb.Append("    <ItemGroup>\n");
            sb.AppendFormat("        <PackageReference Include=\"Pan.Code\" Version=\"{0}\" />\n", PanCodeVersion);
            sb.Append("    </ItemGroup>\n");

            sb.Append("    <ItemGroup>\n");
            sb.AppendFormat("        <ProjectReference Include=\"..\\{0}.Entity\\{0}.Entity.csproj\" />\n", ns);
            sb.Append("    </ItemGroup>\n");

            sb = GetCsprojectEnd(sb);
            var path = string.Format("{0}/{1}/{1}.IRepository/{1}.IRepository.csproj", BasePath, ns);
            WriteFile(path, sb.ToString());
            return sb.ToString();
        }
        #endregion

        #region Repository
        private string ToRepository(string ns, string name, List<sys_table_column_model> list)
        {
            var firstColumn = list.FirstOrDefault();
            StringBuilder sb = new StringBuilder();
            StringBuilder insert_dicsb = new StringBuilder();
            insert_dicsb.Append("            Dictionary<string, object> dic = new Dictionary<string, object>();\n");
            foreach (var item in list)
            {
                if (udList.Contains(item.column_name))
                {
                    continue;
                }
                var type = ConvrtType(item.data_type, item.is_nullable);
                if (type == "int" || type == "decimal" || type == "tinyint" || type == "smallint" || type == "float" || type == "double")
                {
                    insert_dicsb.AppendFormat("            if(model.{0} != 0)\n", item.column_name);
                }
                else if (type.IndexOf("?") > 0)
                {
                    insert_dicsb.AppendFormat("            if(model.{0} != null && model.{0}.HasValue)\n", item.column_name);
                }
                else
                {
                    insert_dicsb.AppendFormat("            if(model.{0} != null)\n", item.column_name);
                }
                insert_dicsb.Append("            {\n");
                insert_dicsb.AppendFormat("                dic[\"{0}\"] = model.{0};\n", item.column_name);
                insert_dicsb.Append("            }\n");
            }
            StringBuilder update_dicsb = new StringBuilder();
            update_dicsb.Append("            Dictionary<string, object> dic = new Dictionary<string, object>();\n");
            foreach (var item in list)
            {
                if (crList.Contains(item.column_name))
                {
                    continue;
                }
                var type = ConvrtType(item.data_type, item.is_nullable);
                if (type == "int" || type == "decimal" || type == "tinyint" || type == "smallint" || type == "float" || type == "double")
                {
                    update_dicsb.AppendFormat("            if(model.{0} != 0)\n", item.column_name);
                }
                else if (type.IndexOf("?") > 0)
                {
                    update_dicsb.AppendFormat("            if(model.{0} != null && model.{0}.HasValue)\n", item.column_name);
                }
                else
                {
                    update_dicsb.AppendFormat("            if(model.{0} != null)\n", item.column_name);
                }
                update_dicsb.Append("            {\n");
                update_dicsb.AppendFormat("                dic[\"{0}\"] = model.{0};\n", item.column_name);
                update_dicsb.Append("            }\n");
            }
            StringBuilder list_dicsb = new StringBuilder();
            list_dicsb.Append("            Dictionary<string, object> dic = new Dictionary<string, object>();\n");
            foreach (var item in list)
            {
                if (crList.Contains(item.column_name) || udList.Contains(item.column_name))
                {
                    continue;
                }
                var type = ConvrtType(item.data_type, item.is_nullable);
                if (type == "int" || type == "decimal" || type == "tinyint" || type == "smallint" || type == "float" || type == "double")
                {
                    list_dicsb.AppendFormat("            if(model.{0} != 0)\n", item.column_name);
                }
                else if (type.IndexOf("?") > 0)
                {
                    list_dicsb.AppendFormat("            if(model.{0} != null && model.{0}.HasValue)\n", item.column_name);
                }
                else
                {
                    list_dicsb.AppendFormat("            if(model.{0} != null)\n", item.column_name);
                }
                list_dicsb.Append("            {\n");
                list_dicsb.AppendFormat("                dic[\"{0}\"] = model.{0};\n", item.column_name);
                list_dicsb.Append("            }\n");
            }

            sb.Append("using System;\n");
            sb.Append("using System.Collections.Generic;\n");
            sb.Append("using DBHelper.SQLHelper;\n");
            sb.AppendFormat("using {0}.Entity;\n", ns);
            sb.AppendFormat("using {0}.IRepository;\n", ns);
            sb.Append("\n");
            sb.AppendFormat("namespace {0}.Repository\n", ns);
            sb.Append("{\n");
            sb.AppendFormat("    public class {0}_Repository : I{0}_Repository\n", name);
            sb.Append("    {\n");

            #region Insert
            sb.Append("        /// <summary>\n");
            sb.Append("        /// 新增\n");
            sb.Append("        /// </summary>\n");
            sb.AppendFormat("        public bool Insert({0}_Entity model)\n", name);
            sb.Append("        {\n");
            sb.Append(insert_dicsb);
            sb.AppendFormat("            return SQLHelperFactory.Instance.ExecuteNonQuery(\"Insert_{0}\", dic) >0 ;\n", name);
            sb.Append("        }\n\n");
            #endregion Insert

            #region Update
            sb.Append("        /// <summary>\n");
            sb.Append("        /// 修改\n");
            sb.Append("        /// </summary>\n");
            sb.AppendFormat("        public bool Update({0}_Entity model)\n", name);
            sb.Append("        {\n");
            sb.Append(update_dicsb);
            sb.AppendFormat("            return SQLHelperFactory.Instance.ExecuteNonQuery(\"Update_{0}\", dic) >0 ;\n", name);
            sb.Append("        }\n\n");
            #endregion Update

            #region Delete
            sb.Append("        /// <summary>\n");
            sb.Append("        /// 删除\n");
            sb.Append("        /// </summary>\n");
            sb.AppendFormat("        public bool Delete({0} {1})\n", ConvrtType(firstColumn.data_type, firstColumn.is_nullable), firstColumn.column_name);
            sb.Append("        {\n");
            sb.Append("            Dictionary<string, object> dic = new Dictionary<string, object>();\n");
            sb.AppendFormat("            dic[\"{0}\"] = {0};\n", firstColumn.column_name);
            sb.AppendFormat("            return SQLHelperFactory.Instance.ExecuteNonQuery(\"Delete_{0}\", dic) >0 ;\n", name);
            sb.Append("        }\n\n");
            #endregion Delete

            #region Select
            sb.Append("        /// <summary>\n");
            sb.Append("        /// 获取单个\n");
            sb.Append("        /// </summary>\n");
            sb.AppendFormat("        public {0}_Entity Get({1} {2})\n", name, ConvrtType(firstColumn.data_type, firstColumn.is_nullable), firstColumn.column_name);
            sb.Append("        {\n");
            sb.Append("            Dictionary<string, object> dic = new Dictionary<string, object>();\n");
            sb.AppendFormat("            dic[\"{0}\"] = {0};\n", firstColumn.column_name);
            sb.AppendFormat("            return SQLHelperFactory.Instance.QueryForObjectByT<{0}_Entity>(\"Select_{0}\", dic);\n", name);
            sb.Append("        }\n\n");
            #endregion Select

            #region SelectList
            sb.Append("        /// <summary>\n");
            sb.Append("        /// 获取列表\n");
            sb.Append("        /// </summary>\n");
            sb.AppendFormat("        public (IEnumerable<{0}_Entity>,int) GetList({0}_Entity model,int pageindex,int pagesize)\n", name);
            sb.Append("        {\n");
            sb.Append(list_dicsb);
            sb.Append("            if (pageindex >= 0)\n");
            sb.Append("            {\n");
            sb.Append("                dic[\"StartIndex\"] = pageindex == 0 ? 0 : (pageindex - 1) * pagesize + 1;;\n");
            sb.Append("            }\n");
            sb.Append("            if (pagesize > 0)\n");
            sb.Append("            {\n");
            sb.Append("                dic[\"SelectCount\"] = pagesize;\n");
            sb.Append("            }\n");
            sb.AppendFormat("            var list = SQLHelperFactory.Instance.QueryMultipleByPage<{0}_Entity>(\"Select_{0}_List\", dic,out int total);\n", name);
            sb.Append("            return (list,total);\n");
            sb.Append("        }\n\n");
            #endregion SelectList

            sb.Append("    }\n");
            sb.Append("}");
            var path = string.Format("{0}/{1}/{1}.Repository/{2}_Repository.cs", BasePath, ns, name);
            WriteFile(path, sb.ToString());
            return sb.ToString();
        }

        private string ToRepositoryCsproject(string ns)
        {
            StringBuilder sb = GetCsprojectStart();

            sb.Append("    <ItemGroup>\n");
            sb.AppendFormat("        <PackageReference Include=\"Pan.Code\" Version=\"{0}\" />\n", PanCodeVersion);
            sb.AppendFormat("        <PackageReference Include=\"CoreDBHelper\" Version=\"{0}\" />\n", CoreDBHelperVersion);
            sb.Append("    </ItemGroup>\n");

            sb.Append("    <ItemGroup>\n");
            sb.AppendFormat("        <ProjectReference Include=\"..\\{0}.Entity\\{0}.Entity.csproj\" />\n", ns);
            sb.AppendFormat("        <ProjectReference Include=\"..\\{0}.IRepository\\{0}.IRepository.csproj\" />\n", ns);
            sb.Append("    </ItemGroup>\n");

            sb = GetCsprojectEnd(sb);
            var path = string.Format("{0}/{1}/{1}.Repository/{1}.Repository.csproj", BasePath, ns);
            WriteFile(path, sb.ToString());
            return sb.ToString();
        }

        #endregion

        #region Test
        #endregion


        /// <summary>
        /// 写文件
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <param name="Strings">文件内容</param>
        private void WriteFile(string path, string Strings)
        {
            if (!Directory.Exists(Path.GetDirectoryName(path)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(path));
            }
            if (File.Exists(path))
                File.Delete(path);
            System.IO.FileStream f = System.IO.File.Create(path);
            f.Close();
            f.Dispose();
            System.IO.StreamWriter f2 = new System.IO.StreamWriter(path, true, System.Text.Encoding.UTF8);
            f2.WriteLine(Strings);
            f2.Close();
            f2.Dispose();
        }

        private string ConvrtType(string db_type, string isNull)
        {
            var str = "";
            if (isNull == "YES")
            {
                str = "?";
            }
            switch (db_type)
            {
                case "char":
                case "varchar":
                case "text":
                    return "string";
                case "date":
                case "datetime":
                    return "DateTime" + str;
                case "decimal":
                    return "decimal" + str;
                case "int":
                case "tinyint":
                    return "int" + str;
                case "smallint":
                    return "short" + str;
                case "float":
                    return "float" + str;
                case "double":
                    return "double" + str;
                case "bit":
                    return "bool" + str;
                default:
                    return "string";
            }
        }

    }
}
