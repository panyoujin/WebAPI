namespace Pan.Code.Extentions
{
    /// <summary>
    /// 公共的返回
    /// </summary>
    public static class ResponseExtension
    {
        /// <summary>
        /// 成功
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ApiResult<T> ResponseSuccess<T>(this T obj, string message = "", int total = 0)
        {
            ApiResult<T> result = new ApiResult<T>();
            result.Code = EnumType.ApiCodeEnum.Success.ToInt();
            result.Message = !string.IsNullOrWhiteSpace(message) ? message : EnumType.ApiCodeEnum.Success.Description();
            result.IsOk = true;
            result.Result = obj;
            result.Total = total;
            return result;
        }
        /// <summary>
        /// 未知错误
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ApiResult<string> ResponseUnknown(this object obj, string message = "")
        {
            ApiResult<string> result = new ApiResult<string>();
            result.Code = EnumType.ApiCodeEnum.Unknown.ToInt();
            result.Message = !string.IsNullOrWhiteSpace(message) ? message : EnumType.ApiCodeEnum.Unknown.Description();
            result.IsOk = false;
            result.Result = result.Message;

            return result;
        }
        /// <summary>
        /// 请求数据错误
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ApiResult<string> ResponseDataError(this object obj, string message = "")
        {
            ApiResult<string> result = new ApiResult<string>();
            result.Code = EnumType.ApiCodeEnum.DataError.ToInt();
            result.Message = !string.IsNullOrWhiteSpace(message) ? message : EnumType.ApiCodeEnum.DataError.Description();
            result.IsOk = false;
            result.Result = result.Message;

            return result;
        }
        /// <summary>
        /// 未登录
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ApiResult<string> ResponseNotLogin(this object obj, string message = "")
        {
            ApiResult<string> result = new ApiResult<string>();
            result.Code = EnumType.ApiCodeEnum.NotLogin.ToInt();
            result.Message = !string.IsNullOrWhiteSpace(message) ? message : EnumType.ApiCodeEnum.NotLogin.Description();
            result.IsOk = false;
            result.Result = result.Message;

            return result;
        }
        /// <summary>
        /// 未授权
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ApiResult<string> ResponseUnauthorized(this object obj, string message = "")
        {
            ApiResult<string> result = new ApiResult<string>();
            result.Code = EnumType.ApiCodeEnum.Unauthorized.ToInt();
            result.Message = !string.IsNullOrWhiteSpace(message) ? message : EnumType.ApiCodeEnum.Unauthorized.Description();
            result.IsOk = false;
            result.Result = result.Message;

            return result;
        }
        /// <summary>
        /// 签名错误
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ApiResult<string> ResponseSignError(this object obj, string message = "")
        {
            ApiResult<string> result = new ApiResult<string>();
            result.Code = EnumType.ApiCodeEnum.SignError.ToInt();
            result.Message = !string.IsNullOrWhiteSpace(message) ? message : EnumType.ApiCodeEnum.SignError.Description();
            result.IsOk = false;
            result.Result = result.Message;

            return result;
        }
    }
}
