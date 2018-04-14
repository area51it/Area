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
using Microsoft.Extensions.Configuration;
using Area51.ApiAgent;

namespace Area51.UI.Controllers
{
    public class BaseController : Controller
    {
        private IConfiguration _configuration;
        private string _securityKey { get; set; }
        private string _accessToken { get; set; }

        public BaseController()
        {
        }

        private ApiAgent.ApiAgent _agent;
        public ApiAgent.ApiAgent Agent
        {
            get
            {
                return _agent ?? BuildAgent();
            }
        }

        private ApiAgent.ApiAgent BuildAgent()
        {
           

            return new ApiAgent.ApiAgent("", "",false);
        }

    }
}
