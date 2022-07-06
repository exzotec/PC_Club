using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using PC_Club.Models;
using PC_Club.Data;

namespace PC_Club.Controllers
{
    [ApiController]
    [Route ("api/token")]
    public class AccountController : Controller
    {
        private readonly DataContext db;

        public AccountController(DataContext context)
        {
            db = context;
        }

        [HttpPost]
        public IActionResult Token(User user)
        {
            var identity = GetIdentity(user.login, user.password);
            if (identity == null)
            {
                return BadRequest(new { errorText = "Некорректные логин и(или) пароль." });
            }

            var now = DateTime.UtcNow;
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: AuthOption.ISSUER,
                    audience: AuthOption.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOption.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOption.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                login = identity.Name //?
            };

            return Ok(response);
        }

        private ClaimsIdentity GetIdentity(Guid userId)
        {
            User user = db.users.FirstOrDefault(x => x.userId == userId);
            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.Equals, user.userId),
                };
                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }

            // если пользователя не найдено
            return null;
        }
    }
}
