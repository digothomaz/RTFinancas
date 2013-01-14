using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using RThomaz.Data.Enums;

namespace RThomaz.Data.Common
{
    public class EnumHelper
    {
        public static Dictionary<TBase, string> GetDictionaryFromEnum<TEnum, TBase>()
        {
            var items = new Dictionary<TBase, string>();

            foreach (var value in Enum.GetValues(typeof(TEnum)))
            {
                items.Add((TBase)value, EnumHelper.GetEnumDescription(value as Enum));
            }

            var sortedDict = (from entry in items orderby entry.Value ascending select entry).ToDictionary(pair => pair.Key, pair => pair.Value);

            return sortedDict;
        }

        public static string GetEnumDescription(Enum value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString());
            var attribute = field.GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault();
            if (attribute != null)
                return (attribute as DescriptionAttribute).Description;
            else
                return value.ToString();
        }

        public static string GetEnumDescription<TEnum>(object key)
        {
            var item = (Enum)Enum.Parse(typeof(TEnum), key.ToString());
            var description = GetEnumDescription(item);
            return description;
        }        
    }
}
