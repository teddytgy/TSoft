using System.Collections.Generic;

namespace TSoft.Validation
{
    public interface IValidator
    {
        List<ValidationResult> Validate(object model);
    }
}