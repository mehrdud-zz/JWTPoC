using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace TestJWT.JWT
{
    public class JWTController
    {
        public const string JWT_ISSUER = "security.wpap.worldpay.local";
        public const string JWT_AUDIENCE = "wpap.worldpay.local";


     

        public JwtSecurityToken GenerateJwtSecurityToken(
          string SecurityKey, string CallerId, string CorrelationId)
        {
            return this.GenerateJwtSecurityToken(SecurityKey, CallerId, CorrelationId, new List<Claim>());
        }
        public JwtSecurityToken GenerateJwtSecurityToken(
           string SecurityKey, string CallerId, string CorrelationId, List<Claim> CustomClaimsList)
        {
            var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToLongTimeString()),
                    new Claim("req", CorrelationId), // CorrelationId
                    new Claim(JwtRegisteredClaimNames.Sub, CallerId) // CalllerId 
                };

            if (!(CustomClaimsList is null))
                foreach (var claim in CustomClaimsList)
                {
                    claims.Append(claim);
                }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecurityKey));
            
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: JWT_ISSUER,
                audience: JWT_AUDIENCE,
                claims: claims,
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: creds);

            return jwtSecurityToken;
        } 
    }

    public class JWTResponse
    {

    }
}
