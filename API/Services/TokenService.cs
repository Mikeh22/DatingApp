using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using API.Entities;
using API.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace API.Services
{
    public class TokenService : ITokenService
    {
        private readonly SymmetricSecurityKey _key;
        public TokenService(IConfiguration config)
        {
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));
        }

        public string CreateToken(AppUser user)
        {
            var claims = new List<Claim>  // adding our claim to token 
            {
                new Claim(JwtRegisteredClaimNames.NameId, user.UserName)
            };

            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature); // Here we are creating credentials

            var tokenDescriptor = new SecurityTokenDescriptor  //describe how our token is going to look
            {
               Subject = new ClaimsIdentity(claims),
               Expires = DateTime.Now.AddDays(7),
               SigningCredentials = creds

            };

            var tokenHandler = new JwtSecurityTokenHandler();  // this is required to create a JWT

            var token = tokenHandler.CreateToken(tokenDescriptor);  // we create token here

            return tokenHandler.WriteToken(token);  // we return the token to whoever created it here
        }
    }
}