using FatDairy.Domain.Models;
using FatDairy.Domain.Repos;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApi.Auth;
using WebApi.DTOs;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        protected readonly IFattyRepository _fattyRepo;
        protected readonly IAppUser _appUser;
        public AuthController(IFattyRepository fattyRepo, IAppUser appUser)
        {
            _fattyRepo = fattyRepo ?? throw new ArgumentNullException(nameof(fattyRepo));
            _appUser = appUser;
        }


        [HttpPost("token")]
        public async Task<IActionResult> GetToken([FromBody] AuthUserDTO dto)
        {
            var identity = await GetIdentityAsync(dto.email, dto.password);
            if (identity == null)
            {
                return Unauthorized();
            }
            var now = DateTime.UtcNow;
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                username = identity.Name
            };
            return Ok(JsonConvert.SerializeObject(response, new JsonSerializerSettings { Formatting = Formatting.Indented }));
        }

        private async Task<ClaimsIdentity> GetIdentityAsync(string email, string password)
        {
            Fatty person = await _fattyRepo.GetByEmail(email);
            if (person != null && person.UserInfo.Password == password)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, person.UserInfo.Email),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, "Fatty"),
                    new Claim("UserId", person.Id.ToString())
                };
                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }
            return null;
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetCurrentUser()
        {
            try
            {
                if (_appUser == null)
                    return Unauthorized();
                return Ok(_appUser);
            }
            catch (Exception err)
            {

            }
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
