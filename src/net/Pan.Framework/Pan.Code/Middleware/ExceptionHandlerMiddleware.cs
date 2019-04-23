using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Pan.Code.Middleware
{
    /// <summary>
    /// 用户自定义全局异常处理中间件
    /// </summary>
    public class UserExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<UserExceptionHandlerMiddleware> _logger;

        public UserExceptionHandlerMiddleware(RequestDelegate rd, ILogger<UserExceptionHandlerMiddleware> logger)
        {
            _next = rd;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError("UserExceptionHandlerMiddleware", ex);
                await HandleExceptionAsync(context, ex);
            }
        }
        private static async Task HandleExceptionAsync(HttpContext context, Exception e)
        {
            if (e == null) return;


            await WriteExceptionAsync(context, e).ConfigureAwait(false);
        }

        private static async Task WriteExceptionAsync(HttpContext context, Exception e)
        {
            if (e is UnauthorizedAccessException)
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            else if (e is Exception)
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            context.Response.ContentType = "application/json";

            await context.Response.WriteAsync(
                JsonConvert.SerializeObject(e)).ConfigureAwait(false);
        }

    }
}
