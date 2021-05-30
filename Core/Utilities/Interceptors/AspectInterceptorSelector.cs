using Castle.DynamicProxy;
using System;
using System.Linq;
using System.Reflection;

namespace Core.Utilities.Interceptors
{
    //class, metod attributlerini okuyan, onları bir listeye koyan
    //listeyi öncelik degerine sıralayan
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>
                (true).ToList(); //git classin attributelerini oku
            var methodAttributes = type.GetMethod(method.Name)
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);//git ilgili metodun attributelerini oku
            classAttributes.AddRange(methodAttributes);

            return classAttributes.OrderBy(x => x.Priority).ToArray(); //onları listeye koy, önceliklere göre sırala
        }
    }
}