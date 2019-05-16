using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pan.Code.Extentions
{
    public static class JsonExtend
    {
        public static string ToJson(this object obj)
        {
            var timeConverter = new Newtonsoft.Json.Converters.IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" };
            return JsonConvert.SerializeObject(obj, Formatting.Indented, timeConverter);
        }

        public static T ToModel<T>(this string str)
        {
            return JsonConvert.DeserializeObject<T>(str);
        }

        /// <summary>
        /// 轉換類型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T ConvertToT<T>(this object obj)
        {
            return obj.ToJson().ToModel<T>();
        }
    }
}
