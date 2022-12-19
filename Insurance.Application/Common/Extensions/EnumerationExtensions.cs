using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace Insurance.Application.Common.Extensions
{
    public static class EnumerationExtensions
    {
        public static string GetDisplayName(this Enum enumeration)
        {
            return enumeration.GetType()?
                    .GetMember(enumeration.ToString())?
                    .First()?
                    .GetCustomAttribute<DisplayAttribute>()?
                    .Name ?? enumeration.ToString();
        }

        public static string GetName(this Enum enumeration)
        {
            return Enum.GetName(enumeration.GetType(), enumeration);
        }
    }
}
