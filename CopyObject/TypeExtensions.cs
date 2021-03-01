using System;
using System.Linq;

namespace CopyObjectLibrary
{
    public static class TypeExtensions
    {
        public static bool IsSimpleType(this Type type) => type.Equals(typeof(string)) || type.IsValueType;

        public static bool IsNullableGeneric(this Type type) => type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);

        public static bool IsTypeCloseEnough(this Type type, Type compareWith)
        {
            if (type.Equals(compareWith)) return true;
            if (type.IsNullableGeneric() && type.GetGenericArguments().First().Equals(compareWith)) return true;
            if (compareWith.IsNullableGeneric() && compareWith.GetGenericArguments().First().Equals(type)) return true;
            return false;
        }
    }
}
