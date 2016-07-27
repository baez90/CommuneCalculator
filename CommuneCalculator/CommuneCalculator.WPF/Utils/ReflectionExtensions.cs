using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace CommuneCalculator.Utils
{
    public static class ReflectionExtensions
    {
        public static bool HasValidationAttributes(this PropertyInfo propertyInfo)
        {
            return propertyInfo.GetCustomAttributes<ValidationAttribute>(true).Any();
        }

        public static ValidationAttribute[] GetValidationAttributes(this PropertyInfo propertyInfo)
        {
            return propertyInfo.GetCustomAttributes<ValidationAttribute>(true).ToArray();
        }
    }

    public static class PropertyInfoExtensions
    {
        public static Func<T, object> GetValueGetter<T>(this PropertyInfo propertyInfo)
        {
            var actualType = Expression.Parameter(typeof(T), "t");
            var instanceConvert = Expression.TypeAs(actualType, propertyInfo.DeclaringType);

            var property = Expression.Property(instanceConvert, propertyInfo);
            var convert = Expression.TypeAs(property, typeof(object));
            return (Func<T, object>) Expression.Lambda(convert, actualType).Compile();
        }


        public static Action<T, object> GetValueSetter<T>(this PropertyInfo propertyInfo)
        {
            if (typeof(T) != propertyInfo.DeclaringType)
            {
                throw new ArgumentException();
            }


            var instance = Expression.Parameter(propertyInfo.DeclaringType, "i");
            var argument = Expression.Parameter(typeof(object), "a");
            var setterCall = Expression.Call(
                instance,
                propertyInfo.GetSetMethod(),
                Expression.Convert(argument, propertyInfo.PropertyType));

            return (Action<T, object>) Expression.Lambda(setterCall, instance, argument).Compile();
        }
    }
}