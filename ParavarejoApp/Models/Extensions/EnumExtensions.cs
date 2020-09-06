using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace ParavarejoApp.Models.Extensions
{
    namespace ParavarejoApp.Extensions
    {
        public static class EnumExtesions
        {
            public static string GetDescription(this Enum obj)
            {
                Enum myEnum = (Enum)obj;
                string description = GetEnumDescription(myEnum);
                return description;
            }

            private static string GetEnumDescription(Enum enumObj)
            {
                FieldInfo fieldInfo = enumObj.GetType().GetField(enumObj.ToString());
                object[] attribArray = fieldInfo.GetCustomAttributes(false);

                if (attribArray.Length == 0)
                    return enumObj.ToString();
                else
                {
                    DescriptionAttribute attrib = null;

                    foreach (var att in attribArray)
                    {
                        if (att is DescriptionAttribute)
                            attrib = att as DescriptionAttribute;
                    }

                    if (attrib != null)
                        return attrib.Description;

                    return enumObj.ToString();
                }
            }

        }
    }
}
