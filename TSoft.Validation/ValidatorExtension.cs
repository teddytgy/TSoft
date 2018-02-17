#region

#endregion



namespace TSoft.Validation
{
    public static class ValidatorExtension
    {
        public static Validation<TModel> AddValidation<TModel>(this Validator<TModel> validator)
        {
            var validation = new Validation<TModel>();
            validator.AddValidation(validation);
            return validation;
        }
    }
}