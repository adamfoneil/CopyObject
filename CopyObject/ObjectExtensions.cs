using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CopyObjectLibrary
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// copies identically named/typed properties from one object to another.
        /// This is for converting between DTO and model classes,
        /// copied from AerieWork.Blazor
        /// </summary>
        public static T CopyAs<T>(this object @object) where T : class, new()
        {
            var result = new T();
            return CopyAs(@object, result);
        }

        public static T CopyAs<T>(this object @object, T instance)
        {
            var srcProps = @object.GetType().GetProperties();
            var destProps = typeof(T).GetProperties().Where(pi => pi.CanWrite);

            var setProps = srcProps.Join(destProps, pi => pi, pi => pi, (src, dest) => new
            {
                Property = dest,
                Value = src.GetValue(@object)
            }, new PropertyInfoComparer());

            foreach (var p in setProps)
            {
                p.Property.SetValue(instance, p.Value);
            }

            return instance;
        }

        public static void CopyTo<T>(this object @object, T instance) => CopyAs(@object, instance);

        private class PropertyInfoComparer : IEqualityComparer<PropertyInfo>
        {
            public bool Equals(PropertyInfo x, PropertyInfo y) =>
                (x.Name.Equals(y.Name) && x.PropertyType.IsTypeCloseEnough(y.PropertyType));

            public int GetHashCode(PropertyInfo obj) => (!obj.PropertyType.IsNullableGeneric()) ?
                obj.PropertyType.GetHashCode() :
                obj.PropertyType.GetGenericArguments().First().GetHashCode();
        }     
    }
}
