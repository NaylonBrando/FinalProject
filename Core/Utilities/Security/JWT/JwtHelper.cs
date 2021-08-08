using Core.Entities.Concrate;
using Core.Extensions;
using Core.Utilities.IoC;
using Core.Utilities.Security.Encryption;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Utilities.Security.JWT
{
    //Token üretimi gerçekleştirecek sınıf
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; } //Bu bizim apideki appsetting.json u okumaya yarar.
        private TokenOptions _tokenOptions;//Configurationla okunan nesneleri aktarıcak nesne   
        private DateTime _accessTokenExpiration;
        public JwtHelper(IConfiguration configuration)//appstetingsi IConfiguration ile enjekte edecegiz
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();//Get -->TokenOptions(sınıf)=TokenOptions(json dosyasındaki kod blogu)
            //getsections:: appsteing dosyasında TokenOptions adli kod blogunu bul
            //TokenOptions(sınıf)'nı, TokenOptions(jsondaki kod blogu)'ndaki seylere esitle
            
        }
        //securitykey, şifreli tokeni oluştururken gerekli olan anahtar.
        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
        {
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);//Olustururken securitykeye ihtiyac var, helperden yardım alarak olusturuyoruz
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredantials(securityKey);//byte security key için hangi algoirtmayı vs kullanacak ve anahtar nedir
            //JWT token üretecek kod
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, operationClaims);
            //Tokenin yazdırılması
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);//Token nesnemizi stringe çeviren kod

            return new AccessToken//Tokenin döndğrğlmesi
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };

        }

        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user,
            SigningCredentials signingCredentials, List<OperationClaim> operationClaims)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,//Eğer token exp bilgisi şuandan önceyse gecerli degil
                claims: SetClaims(user, operationClaims),//alttaki kod blogunda claimleri set ediyoruz
                signingCredentials: signingCredentials //signingCredentials using System.IdentityModel.Tokens.Jwt'den gelir
            );
            return jwt;
        }
        //Token olusturacagiz ama bize claim bilgisi lazım onu buradan hallediyoruz
        //ıenub, listin basesidir
        //yetkiden daha fazlasidir
        private IEnumerable<Claim> SetClaims(User user, List<OperationClaim> operationClaims) //claimleri olustururken kullandıgımız yardımcı metod
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddEmail(user.Email);
            claims.AddName($"{user.FirstName} {user.LastName}");//Bu kullanım iki stringi yanyana göstermek icindir
            claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());

            return claims;
        }
    }
}
