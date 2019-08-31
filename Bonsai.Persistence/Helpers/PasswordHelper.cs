using System;
using System.Text;

namespace Bonsai.Persistence.Helpers
{
    public class PasswordHelper
    {
        public PasswordHelper()
        {
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

    }
}
