using Chargoon.Sample.Domain.Service;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Chargoon.Sample.Service
{
    public class TokenService : ITokenService
    {
        private double _millisecond = 604800000; //7 days
        private string Secret
        {
            get
            {
                return "db3OIsj+BXE9NZDy0t8W3TcNekrF+2d/1sFnWG4HnV8TZY30iTOdtVWJG8abWvB1GlOgJuQZdcF2Luqm/hccMw==";
            }
        }

        public double ExpireMilliSeconds
        {
            get
            {
                return _millisecond‬; 
            }
        }

        public string TokenType
        {
            get
            {
                return "Bearer";
            }
        }

        public string GenerateToken(string id)
        {
            var symmetricKey = Convert.FromBase64String(Secret);
            var tokenHandler = new JwtSecurityTokenHandler();

            var now = DateTime.UtcNow;
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, id)
                }),

                Expires = now.AddMilliseconds(ExpireMilliSeconds),

                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(symmetricKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var stoken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(stoken);

            return token;
        }

        private ClaimsPrincipal GetPrincipal(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;
                if (jwtToken == null) return null;

                var symmetricKey = Convert.FromBase64String(Secret);
                var validationParameters = new TokenValidationParameters()
                {
                    RequireExpirationTime = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(symmetricKey)
                };

                SecurityToken securityToken;
                var principal = tokenHandler.ValidateToken(token, validationParameters, out securityToken);

                return principal;
            }
            catch (Exception)
            {
                //should write log
                return null;
            }
        }

        public bool ValidateToken(string token, out string id)
        {
            id = null;
            var simplePrinciple = GetPrincipal(token);
            var identity = simplePrinciple.Identity as ClaimsIdentity;
            if (identity == null) return false;
            if (!identity.IsAuthenticated) return false;
            var usernameClaim = identity.FindFirst(ClaimTypes.NameIdentifier);
            id = usernameClaim?.Value;
            if (string.IsNullOrEmpty(id)) return false;
            return true;
        }

        //protected Task<IPrincipal> AuthenticateJwtToken(string token)
        //{
        //    string username;

        //    if (ValidateToken(token, out username))
        //    {
        //        // based on username to get more information from database 
        //        // in order to build local identity
        //        var claims = new List<Claim>
        //{
        //    new Claim(ClaimTypes.Name, username)
        //    // Add more claims if needed: Roles, ...
        //};

        //        var identity = new ClaimsIdentity(claims, "Jwt");
        //        IPrincipal user = new ClaimsPrincipal(identity);

        //        return Task.FromResult(user);
        //    }

        //    return Task.FromResult<IPrincipal>(null);
        //}
    }
}
