using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Share.Common
{
    public static class EntityHelper
    {
        public static bool Validate(this object instance, bool throwIfNotValid = true)
        {
            List<ValidationResult> validationResults;
            var r = instance.GetValidateResults(out validationResults);
            if (throwIfNotValid && !r)
            {
                throw new Exception(validationResults[0].ErrorMessage);
            }
            return r;
        }

        public static bool GetValidateResults(this object instance, out List<ValidationResult> validationResults)
        {
            ValidationContext context = new ValidationContext(instance);
            validationResults = new List<ValidationResult>();
            var r = Validator.TryValidateObject(instance, context, validationResults, true);
            return r;
        }
    }
}
