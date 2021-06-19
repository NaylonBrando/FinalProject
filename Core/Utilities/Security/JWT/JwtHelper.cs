using Core.Entities.Concrate;
using Core.Extensions;
using Core.Utilities.Security.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

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
        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
        {
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);//Olustururken securitykeye ihtiyac var, helperden yardım alarak olusturuyoruz
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredantials(securityKey);//byte security key için hangi algoirtmayı vs kullanacak ve anahtar nedir
            
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, operationClaims);//İlgili kullanıcı için yetkileri içeren metod
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken
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
                notBefore: DateTime.Now,
                claims: SetClaims(user, operationClaims),
                signingCredentials: signingCredentials //signingCredentials using System.IdentityModel.Tokens.Jwt'den gelir
            );
            return jwt;
        }
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
