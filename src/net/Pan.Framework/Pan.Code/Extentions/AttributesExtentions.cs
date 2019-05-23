using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Pan.Code.Attributes;

namespace Pan.Code.Extentions
{
    public static class AttributesExtentions
    {
        /// <summary>
        /// 获得枚举字段的Attribute
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumValue"></param>
        /// <returns></returns>
        public static T GetAttribute<T>(this object enumValue) where T : Attribute
        {

            FieldInfo field = enumValue.GetType().GetField(enumValue.ToString());

            return field == null ? null : Attribute.GetCustomAttribute(field, typeof(T)) as T;
        }

        /// <summary>
        /// 判断是否为主键
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsPrimaryKey(this object t)
        {
            var des = t.GetAttribute<PrimaryKeyAttribute>();
            return des != null;
        }
    }
}
