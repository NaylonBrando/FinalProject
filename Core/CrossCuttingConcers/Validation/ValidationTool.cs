using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcers.Validation
{
    public static class ValidationTool //bu tip toollar genelde static olur.
    {
        public static void Validate(IValidator validator, object entity) //IValidator interfacesi fluentvalidatorda hazır gelmiş
        {
            //IValidator kendi kodladıgımız validatoruun referansını tutar
            //Ee ? biz ProductValidator'a IValidator inherit etmedik ??
            //ProductValidator'a inherit edilen AbstractValidator IValidator'a implement edilmiş
            //oradan kalitim alinmis
            var context = new ValidationContext<object>(entity);
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
