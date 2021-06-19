using Core.Utilities.Interceptors;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using Core.Utilities.IoC;
using Core.Extensions;
using Business.Constants;

namespace Business.BusinessAspects.Autofac
{
    //Bunu 14.derste kullanmaya basladik
    //JWTnin yetki kontrolü için olan attribute
    public class SecuredOperation : MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor;//her istek için http contexti oluşturur

        public SecuredOperation(string roles)
        {
            _roles = roles.Split(',');//attributeye parametre olarak verilecek rolleri arraya atmaya yarar
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();//her jwtlik istek icin. Bu aslında apide yaptıgımız autofac destegini masaüstü platformada aktarıyor

        }

        protected override void OnBefore(IInvocation invocation)//Metodun önünde calistir
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles(); //O anki kullanıcının rollerini getir
            //Rolleri gezerken ilgili rol varsa return et
            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))
                {
                    return;
                }
            }
            //İlgili rol yoksa uyarı mesajını ver
            throw new Exception(Messages.AuthorizationDenied);
        }
    }
}
