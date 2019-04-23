using System.ComponentModel;

namespace Pan.Code
{
    public class EnumType
    {
        /// <summary>
        /// 接口返回码
        /// </summary>
        public enum ApiCodeEnum
        {
            /// <summary>
            /// 成功
            /// </summary>
            [Description("成功")]
            Success = 200,
            /// <summary>
            /// 未知错误
            /// </summary>
            [Description("未知错误")]
            Unknown = 500,
            /// <summary>
            /// 请求数据错误
            /// </summary>
            [Description("请求数据错误")]
            DataError = 501,
            /// <summary>
            /// 未登录
            /// </summary>
            [Description("未登录")]
            NotLogin = 600,
            /// <summary>
            /// 未授权
            /// </summary>
            [Description("未授权")]
            Unauthorized = 610,
            /// <summary>
            /// 签名错误
            /// </summary>
            [Description("签名错误")]
            SignError = 700,
        }
        /// <summary>
        /// 是或者否
        /// </summary>
        public enum YesOrNo
        {
            /// <summary>
            /// 否
            /// </summary>
            [Description("否")]
            No = 0,
            /// <summary>
            /// 是
            /// </summary>
            [Description("是")]
            Yes = 1,

        }
    }
}
