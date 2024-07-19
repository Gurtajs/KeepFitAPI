using System;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using api.Models;

namespace api
{
    public class JWTToken
    {
        private readonly IConfiguration _configuration;
        public JWTToken(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GenerateToken(Users users)
        {
            var claims = new[]
            {
            new Claim(ClaimTypes.Email, users.Email)
            // Add other claims as needed
        };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["JwtSettings:Issuer"],
                audience: _configuration["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

}

