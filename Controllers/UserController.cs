using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tabler_NetCoreMVC.Core.Interfaces;

namespace Tabler_NetCoreMVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IConfiguration _config;
        private readonly ITokenService _tokenService;
   

        public UserController(IConfiguration config, ITokenService tokenService)
        {
            _config = config;
            _tokenService = tokenService;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Index()
        {

            return View();
        }

}
