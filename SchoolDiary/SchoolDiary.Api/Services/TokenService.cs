﻿namespace SchoolDiary.Api.Services
{
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using Microsoft.Extensions.Options;
    using Microsoft.IdentityModel.Tokens;
    using SchoolDiary.Api.Models.Config;
    using SchoolDiary.Common.Models;
    using SchoolDiary.Common.Services;

    public interface ITokenService
    {
        string GenerateNewToken(User user);
    }

    public class TokenService : ITokenService
    {
        private readonly JwtConfig _jwtConfig;
        private readonly ITimeService _timeService;

        public TokenService(IOptions<JwtConfig> jwtConfig, ITimeService timeService)
        {
            _jwtConfig = jwtConfig.Value;
            _timeService = timeService;
        }

        public string GenerateNewToken(User user)
        {
            if (user is null) throw new ArgumentNullException();

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtConfig.JwtKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]{
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = _timeService.UtcNow().AddMinutes(_jwtConfig.JwtExpireMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
