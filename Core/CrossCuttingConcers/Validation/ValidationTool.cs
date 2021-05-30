using FluentValidation;

namespace Core.CrossCuttingConcers.Validation
{
    public static class ValidationTool //bu tip toollar genelde static olur.
    {
        public static void Validate(IValidator validator, object entity) //IValidator interfacesi fluentvalidatorda hazır gelmiş
        {
            //object seçmemizin sebebi belki entity olur belki dto olur

            //IValidator kendi kodladıgımız validatoruun referansını tutar
            //Ee ? biz ProductValidator'a IValidator inherit etmedik ??
            //ProductValidator'a inherit edilen AbstractValidator IValidator'a implement edilmiş
            //oradan kalitim alinmis
            //AbstractValidator, fluentvalidator hazır kütüphanesinden gelen bir sinif
            var context = new ValidationContext<object>(entity); //hazır sınıf ValidationContext
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}