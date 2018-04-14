using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Area51.ApiRepository;
using Area51.ApiRepositoryContracts;
using Area51.WebApi.Infrastructure.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Area51.WebApi.Controllers
{

    public class TokenRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IPersonRepository _testService;
        public ValuesController(IConfiguration conf, IPersonRepository rep)
        {
            _testService = rep;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/values/RequestToken")]
        public IActionResult RequestToken([FromBody] TokenRequest request)
        {
            if (request.Username == "Jon" && request.Password == "Again, not for production use, DEMO ONLY!")
            {
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, request.Username),
                    new Claim("CompletedBasicTraining", ""),
                    //new Claim(CustomClaimTypes.EmploymentCommenced,
                    //            new DateTime(2017,12,1).ToString(),
                    //            ClaimValueTypes.DateTime)
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("secretkey_secretkey123!"));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "yourdomain.com",
                    audience: "yourdomain.com",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }

            return BadRequest("Could not verify username and password");
        }


        // GET api/values
        [HttpGet]

        [AllowAnonymous]
        public string[] Get()
        {
            AuthenticationHelper.Login(new LoginModel() { });
           return _testService.GetAll().Select(a => a.First_Name + " - " + a.Last_Name).ToArray();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string[] Get(int id)
        {
            return _testService.GetAll().Select(a => a.First_Name + " - " + a.Last_Name).ToArray();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
