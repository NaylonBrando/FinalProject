using Core.Utilities.IoC;
using Core.Utilities.Security.Encryption;
using Core.Utilities.Security.JWT;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            //IoC Container:
            //Normalde console app kullanýrken altypýyý kullanmak için ilgili manageri ve daldan nesne olusturmamýz gerekir
            // Bu da bunu saðlýyor
            //Bana arka planda bir referans oluþtur.
            //Birisi senden constructorda IProductService isterse ona arka planda new ProductManager oluþtur ve ver.
            //Bu metodu cagiracak olan her servise ayni referans adresini verir. Tüm bellekte bir adet productmanager olustutur. bütün clientlere ayný instanceyi verir.
            //içerisinde data tutmuyorsanýz kullanýn, tek alýþveriþ sepetinin herkesin kullanmasý gibi.
            //services.AddSingleton<IProductService, ProductManager>(); //Iproduct service için üretilen ProductManager instancesi
            //services.AddSingleton<IProductDal, EfProductDal>(); //IProductDal için üretilen EfProductDal instancesi
            //AOP
            //Autofac, ninject, castlewindsor, structure map, lightinject, dryinject ---> IoC container
            // .net'in containerini býrakýp, Autofac containere geçtik


            //Bu sistemde aut. olarak jwt kullanýcagini belirttigimiz kodlar
            var tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
            //Bir nevi sisteme giris icin anahtar
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        //Bunlar kullanýcýya veridigimiz tokenin issuer olarak erhan@er.. veriyoruz
                        //Sonra onlarý kontrol ediyoruz
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = tokenOptions.Issuer,
                        ValidAudience = tokenOptions.Audience,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
                    };
                });
            ServiceTool.Create(services);


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Middleware, asp net yasam döngüsünde hangi yapýlarýn sýrasýyla devreye girecegini söylüyoruz
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}