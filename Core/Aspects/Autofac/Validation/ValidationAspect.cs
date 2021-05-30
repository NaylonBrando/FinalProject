using Castle.DynamicProxy;
using Core.CrossCuttingConcers.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Linq;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception //Aspect, metodun neresinde calismasini istiyorsan
    {
        private Type _validatorType;

        //Kontrol aşaması
        public ValidationAspect(Type validatorType)//attributeye tipleri typle atiyoruz
        {
            //Defensive coding
            if (!typeof(IValidator).IsAssignableFrom(validatorType)) //gönderilen validatır IValidor degilse. IsAssignableFrom, atanabiliyor mu
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değil!");
            }

            _validatorType = validatorType;
        }

        //Onbeforeyi MethodInterception'dan alip, override edip çalıştırılacak kod
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);//Reflection. productvalidatorun instancesini olustur
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];//productvalidatorun basesini(abstract validator) bul, onun  generic calistigi türü bul bul. Product vs
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);//sonra productun parametrelerini bul
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity); //ValidationTool'u merkezi yerde kullan. Bulunan parametreleri tek tek doğrula
            }
        }
    }
}