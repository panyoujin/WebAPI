using System;
using System.Collections.Generic;
using System.Text;

namespace Pan.Code
{
    /// <summary>
    /// API返回值基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ApiResult<T>
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool IsOk { get; set; }
        /// <summary>
        /// 返回信息
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 200 成功 600 未登录 
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// 返回的结果集
        /// </summary>
        public T Result { get; set; }
        /// <summary>
        /// 总数
        /// </summary>
        public int Total { get; set; }
    }
}
