using Castle.DynamicProxy;
using System;

namespace Core.Utilities.Interceptors
{
    //Temel bir try catch
    //Bütün metodların çatısı olacak
    //metodlarımız aşağıdaki kurallardan geçecek
    public abstract class MethodInterception : MethodInterceptionBaseAttribute
    {
        //Burada metod ne oldugunda hangisi olacagini seciyoruz. Metodlar zaten virtual, ona göre kendimize düzenliyoruz
        //invocation: business method
        protected virtual void OnBefore(IInvocation invocation) { }

        protected virtual void OnAfter(IInvocation invocation)
        {
        }

        protected virtual void OnException(IInvocation invocation, System.Exception e)
        {
        }

        protected virtual void OnSuccess(IInvocation invocation)
        {
        }

        public override void Intercept(IInvocation invocation) //calistirmak istedigimiz metod
        {
            var isSuccess = true;
            OnBefore(invocation); //o metod başta mı çalışsın
            try
            {
                invocation.Proceed();
            }
            catch (Exception e)
            {
                isSuccess = false;
                OnException(invocation, e); //hata aldıgında mi calissin
                throw;
            }
            finally
            {
                if (isSuccess)
                {
                    OnSuccess(invocation); //finalde mi calissin
                }
            }
            OnAfter(invocation);
        }
    }
}