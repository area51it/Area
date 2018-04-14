using Microsoft.AspNetCore.Http;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace Area51.WebApi.Infrastructure.Helpers
{
    public class LoginModel
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }
    }

    public class UserModel
    {
        public string Name { get; set; }

        public string Email { get; set; }
    }

    public sealed class AuthenticationHelper
    {
        private static IConfiguration _cfg;

        private AuthenticationHelper(IConfiguration configuration)
        {
            _cfg = configuration;
        }
        public static string Login(LoginModel login)
        {
            var user = Authenticate(login);

            if (user != null)
            {
                var tokenString = BuildToken(user);
            }

            return string.Empty;
        }

        private static string BuildToken(UserModel user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_cfg["TokenAuthentication:SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_cfg["TokenAuthentication:Issuer"],
              _cfg["TokenAuthentication:Issuer"],
              expires: DateTime.Now.AddMinutes(30),
              signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        private static UserModel Authenticate(LoginModel login)
        {
            UserModel user = null;

            if (login.Username == "mario" && login.Password == "secret")
            {
                user = new UserModel { Name = "Mario Rossi", Email = "mario.rossi@domain.com" };
            }
            return user;
        }

    }


}
