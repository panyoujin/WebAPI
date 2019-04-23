using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace Pan.API.Filters
{
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
}
