using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Area51.UI.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;



namespace Area51.UI.Controllers
{
    public class HomeController : BaseController
    {

        public async Task<IActionResult> Index()
        {
            AuthenticationProperties options = new AuthenticationProperties();

            options.AllowRefresh = true;
            options.IsPersistent = true;
            options.ExpiresUtc = DateTime.UtcNow.AddSeconds(int.Parse("3"));

            var claims = new List<Claim>
            {
                    new Claim(ClaimTypes.Name, ""),
                    new Claim("AcessToken", string.Format("Bearer {0}", "")),
                };

            var identity = new ClaimsIdentity(claims, "ApplicationCookie");
            // create claims
            //List<Claim> claims = new List<Claim>
            //{
            //    new Claim(ClaimTypes.Name, "Sean Connery"),
            //    new Claim(ClaimTypes.Email, inputModel.Username),
            //     new Claim(ClaimTypes.tok, inputModel.Username)
            //};

            //// create identity
            //ClaimsIdentity identity = new ClaimsIdentity(claims, "cookie");
            // create principal
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);

            // sign-in
            await HttpContext.SignInAsync(principal);

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
