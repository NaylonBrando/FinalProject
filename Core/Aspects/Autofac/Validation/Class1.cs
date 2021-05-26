using Castle.DynamicProxy;
using Core.CrossCuttingConcers.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspects.Autofac.Validation
{
    //Validate metodlarda validate için kullanacagız
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)//attributeye tipleri typle atiyoruz
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType)) //gönderilen validatır IValidor degilse
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değil!");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);//Reflection
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];//_validatorType'nin generic calistigi tirpi bul. Product vs 
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);//örn productun parametrelerini bul
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity); //bulunan parametreleri tek tek doğrula
            }
        }
    }
}
