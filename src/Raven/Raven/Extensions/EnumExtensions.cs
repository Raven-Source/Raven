using Raven.Attributes;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Raven.Extensions
{
    public static class EnumExtensions
    {
        private static Dictionary<Type, Dictionary<int, string>> enumtDescriptionDict = new Dictionary<Type, Dictionary<int, string>>();
        private static object objLock = new object();
        private static Type enumType = typeof(Enum);

        /// <summary>
        /// 扩展方法，获得枚举的Description
        /// </summary>
        /// <param name="value">枚举值</param>
        /// <returns>枚举的Description</returns>
        public static string GetDesc(this Enum value)
        {
            string name = value.ToString();
            if (name == null)
            {
                return null;
            }
            Type type = value.GetType();
            if (!enumtDescriptionDict.ContainsKey(type))
            {
                lock (objLock)
                {
                    if (!enumtDescriptionDict.ContainsKey(type))
                    {
                        enumtDescriptionDict[type] = EnumToDictionary(type);
                    }
                }
            }

            int key = Convert.ToInt32(value);
            return enumtDescriptionDict[type][key];
        }

        /// <summary>
        /// 把枚举转换为键值对集合
        /// </summary>
        /// <param name="enumType">枚举类型</param>
        /// <returns>以枚举值为key，枚举文本为value的键值对集合</returns>
        private static Dictionary<int, string> EnumToDictionary(Type enumType)
        {
            if (!EnumExtensions.enumType.Equals(enumType))
            {
                throw new ArgumentException("传入的参数必须是枚举类型！", "enumType");
            }
            Dictionary<int, string> enumDic = new Dictionary<int, string>();
            Array enumValues = Enum.GetValues(enumType);
            foreach (Enum enumValue in enumValues)
            {
                int key = Convert.ToInt32(enumValue);
                string enumName = enumValue.ToString();
                FieldInfo field = enumType.GetField(enumName);

                DescriptionAttribute attribute = CustomAttributeExtensions.GetCustomAttribute<DescriptionAttribute>(field);
                //DescriptionAttribute attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (attribute != null)
                {
                    enumName = attribute.Description;
                }
                enumDic.Add(key, enumName);
            }
            return enumDic;
        }

    }
}
