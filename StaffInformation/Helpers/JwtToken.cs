using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffInformation.Helpers
{
    public static class JwtToken
    {
        private const string SECRET_KEY = "ASPNETCORESECRETKEYFORAUTHENTICATIONANDAUTHORIZATION";
        public static readonly SymmetricSecurityKey SIGNING_KEY = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SECRET_KEY));

        public static string GenerateJwtToken() 
        {
            var credentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(SIGNING_KEY, SecurityAlgorithms.HmacSha256);

            var header = new JwtHeader(credentials);

            DateTime Expiry = DateTime.UtcNow.AddMonths(12);
            int ts = (int)(Expiry - new DateTime(1970, 1, 1)).TotalSeconds;

            var payload = new JwtPayload
            {
                {"Sub","testSubject" },
                {"Name","Dubem" },
                {"Email","Donnytest@tesst.com" },
                {"exp", ts },
                {"iss","https://localhost:44394/" },// The Issuer - The party generating the JWT
                {"aud","https://localhost:44394/" }// The Audience - The address of the resource

            };

            var secToken = new JwtSecurityToken(header , payload);
            var handler = new JwtSecurityTokenHandler();
            var tokenString = handler.WriteToken(secToken); // SecurityToken

            Console.WriteLine(tokenString);
            Console.WriteLine("Consume Token");

            return tokenString;
        }
    }
}
