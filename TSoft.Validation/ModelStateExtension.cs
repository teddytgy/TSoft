using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace TSoft.Validation
{
    public static class ModelStateExtension
    {
        /// <summary>
        /// Selects all model errors and converts them into a Dictionary where the key is the property name and the value is a collection of error messages.
        /// </summary>
        public static Dictionary<string, IEnumerable<string>> GetValidationErrors(this ModelStateDictionary modelStateDictionary)
        {
            var result = new Dictionary<string, IEnumerable<string>>();

            foreach (var key in modelStateDictionary.Keys)
            {
                var errorMessages = modelStateDictionary
                    .Where(x => x.Key == key)
                    .SelectMany(x => x.Value.Errors.Select(e => e.ErrorMessage))
                    .ToList();

                if (errorMessages.Any())
                    result[key] = errorMessages;
            }

            return result;
        }
    }
}
