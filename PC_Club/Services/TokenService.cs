using PC_Club.Certificates;
using PC_Club.Shared;
using PC_Club.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using PC_Club.Repositories;

namespace PC_Club.Services
{
    public class TokenService
    {
        private readonly UserRepository userRepository;
        private readonly SigningAudienceCertificate signingAudienceCertificate;

        public TokenService(UserRepository userRepository)
        {
            this.userRepository = userRepository;
            signingAudienceCertificate = new SigningAudienceCertificate();
        }

        public string GetToken(string login)
        {
            User user = userRepository.Get(login);
            SecurityTokenDescriptor tokenDescriptor = GetTokenDescriptor(user);

            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken = tokenHandler.CreateToken(tokenDescriptor);
            string token = tokenHandler.WriteToken(securityToken);

            return token;
        }

        private SecurityTokenDescriptor GetTokenDescriptor(User user)
        {
            const int expiringDays = 7;

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(user.Claims()),
                Expires = DateTime.UtcNow.AddDays(expiringDays),
                SigningCredentials = signingAudienceCertificate.GetAudienceSigningKey()
            };

            return tokenDescriptor;
        }
    }
}
