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
            //Normalde console app kullan�rken altyp�y� kullanmak i�in ilgili manageri ve daldan nesne olusturmam�z gerekir
            // Bu da bunu sa�l�yor
            //Bana arka planda bir referans olu�tur.
            //Birisi senden constructorda IProductService isterse ona arka planda new ProductManager olu�tur ve ver.
            //Bu metodu cagiracak olan her servise ayni referans adresini verir. T�m bellekte bir adet productmanager olustutur. b�t�n clientlere ayn� instanceyi verir.
            //i�erisinde data tutmuyorsan�z kullan�n, tek al��veri� sepetinin herkesin kullanmas� gibi.
            //services.AddSingleton<IProductService, ProductManager>(); //Iproduct service i�in �retilen ProductManager instancesi
            //services.AddSingleton<IProductDal, EfProductDal>(); //IProductDal i�in �retilen EfProductDal instancesi
            //AOP
            //Autofac, ninject, castlewindsor, structure map, lightinject, dryinject ---> IoC container
            // .net'in containerini b�rak�p, Autofac containere ge�tik


            //Bu sistemde aut. olarak jwt kullan�cagini belirttigimiz kodlar
            var tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
            //Bir nevi sisteme giris icin anahtar
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        //Bunlar kullan�c�ya veridigimiz tokenin issuer olarak erhan@er.. veriyoruz
                        //Sonra onlar� kontrol ediyoruz
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
            //Middleware, asp net yasam d�ng�s�nde hangi yap�lar�n s�ras�yla devreye girecegini s�yl�yoruz
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