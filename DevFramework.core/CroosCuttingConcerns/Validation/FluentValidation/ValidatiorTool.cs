using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.core.CroosCuttingConcerns.Validation.FluentValidation
{
    public class ValidatiorTool
    {

        public static void FluentValidate<T>(IValidator<T> validator, T entity)
        {
            var result = validator.Validate(new ValidationContext<T>(entity));
            if (result.Errors.Count > 0)
            {
                throw new ValidationException(result.Errors);
            }
        }

    }
}
