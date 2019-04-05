using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using EmployeeReview.Domain.Common;
using EmployeeReview.Domain.Security.DTO;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace EmployeeReview.Domain.Security.Helpers
{
    public class SecurityHelper : ISecurityHelper
    {
        private readonly AppSettings _appSettings;

        public SecurityHelper(IOptions<AppSettings> options)
        {
            _appSettings = options.Value;
        }
        public string CreateToken(Account account)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_appSettings.JwtSecret);

            List<Claim> claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, account.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, account.Email)
            };
            foreach (var role in account.Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.Name));
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);            
        }

        public (byte[] passwordHash, byte[] salt) HashPassword(string password)
        {
            byte[] salt;
            byte[] passwordHash;
            using (var hmac = new HMACSHA512())
            {
                salt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }

            return (passwordHash, salt);
        }

        public byte[] HashPassword(string password, byte[] salt)
        {
            byte[] passwordHash;
            using (var hmac = new HMACSHA512(salt))
            {
                salt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }

            return passwordHash;
        }

        public bool IsPasswordHashEqual(byte[] passwordHash1, byte[] passwordHash2)
        {
            if (passwordHash1.Length != passwordHash2.Length)
            {
                return false;
            }

            for(int i = 0; i < passwordHash1.Length; i++)
            if (passwordHash1[i] != passwordHash2[i])
                return false;

            return true;
        }
    }
}