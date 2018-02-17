using TSoft.Entities.Models;
using TSoft.Validation;
using TSoft.Validation.Validators;

namespace TSoft.Entities.Validation
{
    internal class PersonValidator : Validator<Person>
    {
        public PersonValidator()
        {
            this.ValidateId(m => m.PersonId);            

            this.ValidateRequired(m => m.FirstName);

            this.ValidateRequired(m => m.LastName);

            this.ValidateRequired(m => m.Email);
            this.ValidateEmail(m => m.Email);

            this.ValidateRequired(m => m.Phone);
            this.ValidatePhone(m => m.Phone);

            this.AddValidation()
                .SetProperty(m => m.FirstName)
                .SetValidater(model => !string.IsNullOrEmpty(model.FirstName))
                .SetErrorMessage("Person First Name is required!");

            this.AddValidation()
                .SetProperty(m => m.LastName)
                .SetValidater(model => !string.IsNullOrEmpty(model.LastName))
                .SetErrorMessage("Person Last Name is required!");

            this.AddValidation()
                .SetProperty(m => m.Phone)
                .SetValidater(model => !string.IsNullOrEmpty(model.Phone))
                .SetErrorMessage("Person Phone is required!");

            this.AddValidation()
                .SetProperty(m => m.Email)
                .SetValidater(model => !string.IsNullOrEmpty(model.Email))
                .SetErrorMessage("Person Email is required!");
        }
    }
}
