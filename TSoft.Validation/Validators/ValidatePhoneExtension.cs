#region

using System;
using System.Linq.Expressions;

#endregion

namespace TSoft.Validation.Validators
{
    public static class ValidatePhoneExtension
    {
        public static Validation<TModel> ValidatePhone<TModel>(this Validator<TModel> validator, Expression<Func<TModel, object>> property)
        {
            return validator.ValidateRegex(property)
                            .SetPattern(@"'1?\s*\W?\s*([2-9][0-8][0-9])\s*\W?\s*([2-9][0-9]{2})\s*\W?\s*([0-9]{4})(\se?x?t?(\d*))?';")
                            .SetErrorMessage(property.GetPropertyName() + " is not a valid Phone Number!");
        }
    }
}