using System;
using System.Reflection;

namespace Pan.Code.Extentions
{
    public static class EnumExtentions
    {
        /// <summary>
        /// 获得枚举字段的Attribute
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumValue"></param>
        /// <returns></returns>
        public static T GetAttribute<T>(this Enum enumValue) where T : Attribute
        {

            FieldInfo field = enumValue.GetType().GetField(enumValue.ToString());

            return field == null ? null : Attribute.GetCustomAttribute(field, typeof(T)) as T;
        }
        /// <summary>
        /// 获取枚举字段的描述，如果没有则返回枚举本身
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string Description(this Enum t)
        {
            var des = t.GetAttribute<System.ComponentModel.DescriptionAttribute>();
            return des == null ? t.ToString() : des.Description;
        }

        /// <summary>
        /// 枚举转 int
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static int ToInt(this Enum t)
        {
            return Convert.ToInt32(t);
        }

        /// <summary>
        /// int 转枚举
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static T ToEnum<T>(this int value) where T : Enum
        {
            return (T)Enum.ToObject(typeof(T), value);
        }

        /// <summary>
        /// string 转枚举
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static T ToEnum<T>(this string value) where T : Enum
        {
            return (T)Enum.ToObject(typeof(T), value);
        }
    }
}
