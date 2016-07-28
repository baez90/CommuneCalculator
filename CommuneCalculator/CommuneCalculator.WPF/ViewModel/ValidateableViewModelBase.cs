﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using CommuneCalculator.Utils;
using GalaSoft.MvvmLight;

namespace CommuneCalculator.ViewModel
{
    public abstract class ValidateableViewModelBase : ViewModelBase, IDataErrorInfo
    {
        private readonly Dictionary<string, Func<ValidateableViewModelBase, object>> _propertyGetters;
        private readonly Dictionary<string, ValidationAttribute[]> _validators;

        private int _validationExceptionCount;

        protected ValidateableViewModelBase()
        {
            _validators = GetType()
                .GetProperties()
                .Where(p => p.HasValidationAttributes())
                .ToDictionary(p => p.Name, p => p.GetValidationAttributes());

            _propertyGetters = GetType()
                .GetProperties()
                .Where(p => p.HasValidationAttributes())
                .ToDictionary(p => p.Name, p => p.GetValueGetter<ValidateableViewModelBase>());
        }


        /// <summary>
        ///     Gets the number of properties which have a validation attribute and are currently valid
        /// </summary>
        public int ValidPropertiesCount
        {
            get
            {
                var query = from validator in _validators
                    where validator.Value.All(attribute => attribute.IsValid(_propertyGetters[validator.Key](this)))
                    select validator;
                return query.Count() - _validationExceptionCount;
            }
        }


        /// <summary>
        ///     Gets the number of properties which have a validation attribute
        /// </summary>
        public int TotalPropertiesWithValidationCount => _validators.Count;

        /// <summary>
        ///     Gets the error message for the property with the given name.
        /// </summary>
        /// <param name="propertyName">Name of the property</param>
        public string this[string propertyName]
        {
            get
            {
                if (!_propertyGetters.ContainsKey(propertyName)) return string.Empty;
                var propertyValue = _propertyGetters[propertyName](this);

                var errorMessages = _validators[propertyName]
                    .Where(v => !v.IsValid(propertyValue))
                    .Select(v => v.ErrorMessage).ToArray();

                return string.Join(Environment.NewLine, errorMessages);
            }
        }


        /// <summary>
        ///     Gets an error message indicating what is wrong with this object.
        /// </summary>
        public string Error
        {
            get
            {
                var errors = from validator in _validators
                    from attribute in validator.Value
                    where !attribute.IsValid(_propertyGetters[validator.Key](this))
                    select attribute.ErrorMessage;

                return string.Join(Environment.NewLine, errors.ToArray());
            }
        }

        public bool IsValid(string propertyName)
        {
            if (!_propertyGetters.ContainsKey(propertyName)) return false;
            var propertyValue = _propertyGetters[propertyName](this);

            return _validators[propertyName].Select(attribute => attribute.IsValid(propertyValue)).Count(b => b) ==
                   _validators[propertyName].Length;
        }


        /// <exception cref="ArgumentException">Value must be a lamda expression</exception>
        public bool IsValid<T>(Expression<Func<T>> memberExpression)
        {
            if (memberExpression.NodeType != ExpressionType.Lambda)
            {
                throw new ArgumentException("Value must be a lamda expression", "memberExpression");
            }

            var body = memberExpression.Body as MemberExpression;
            if (body == null)
            {
                throw new ArgumentException("'x' should be a member expression");
            }

            var propertyName = body.Member.Name;
            if (!_propertyGetters.ContainsKey(propertyName)) return false;
            var propertyValue = _propertyGetters[propertyName](this);

            return _validators[propertyName].Select(attribute => attribute.IsValid(propertyValue)).Count(b => b) ==
                   _validators[propertyName].Length;
        }
    }
}