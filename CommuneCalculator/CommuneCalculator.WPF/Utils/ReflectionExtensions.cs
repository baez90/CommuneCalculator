using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Net.NetworkInformation;
using System.Reflection;
using GalaSoft.MvvmLight;

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
        public static void RaiseBroadcastPropertyChanged<TModel, TMember>(this ViewModelBase viewModel, Expression<Func<TModel, TMember>> propertyExpression, TMember oldValue = default(TMember), TMember newValue = default(TMember)) where TModel : ViewModelBase
        {
            var lambda = propertyExpression as LambdaExpression;
            MemberExpression memberExpression;
            var expression = lambda.Body as UnaryExpression;
            if (expression != null)
            {
                var unaryExpression = expression;
                memberExpression = unaryExpression.Operand as MemberExpression;
            }
            else
            {
                memberExpression = lambda.Body as MemberExpression;
            }

            viewModel.RaisePropertyChanged<TMember>(memberExpression?.Member.Name, oldValue, newValue, true);
        }

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