using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Pan.Code.Extentions;
using Pan.Entity;
using Pan.Entity.ApiModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pan.API.Filters
{
    public class LoginFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            //检查是否已登录
            ApiResult<int> apiResult = new ApiResult<int>();
            apiResult.IsOk = false;
            apiResult.Message = EnumType.ApiCodeEnum.NotLogin.Description();
            apiResult.Code = EnumType.ApiCodeEnum.NotLogin.ToInt();
            apiResult.Result= EnumType.ApiCodeEnum.NotLogin.ToInt();
            context.HttpContext.Response.WriteAsync(apiResult.ToJson());
        }
    }
}
