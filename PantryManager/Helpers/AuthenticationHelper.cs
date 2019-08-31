using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using Bonsai.Domain;

namespace Bonsai.Helpers
{
    public class AuthenticationHelper
    {
        private string Secret { get; set; }

        public AuthenticationHelper(string secret)
        {
            Secret = secret;
        }

        public void CreatePasswordHashAndSalt(string password, out byte[] hash, out byte[] salt)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new Exception("Password cannot be empty!");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                salt = hmac.Key;
                hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public bool VerifyPassword(string password, byte[] hash, byte[] salt)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new Exception("Password cannot be empty!");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(salt))
            {
                var passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                for (int i = 0; i < passwordHash.Length; i++)
                {
                    if (passwordHash[i] != hash[i])
                        return false;
                }
            }

            return true;
        }

        public string GenerateToken(UserAccount user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

    }
}
