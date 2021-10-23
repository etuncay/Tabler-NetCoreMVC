using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tabler_NetCoreMVC.Core.Interfaces;
using Tabler_NetCoreMVC.Models.Dto;
using Tabler_NetCoreMVC.Models.ViewModels.Request;

namespace Tabler_NetCoreMVC.Controllers
{
    public class AuthController : Controller
    {
        private readonly IConfiguration _config;
        private readonly ITokenService _tokenService;
        private string generatedToken = null;

        public AuthController(IConfiguration config, ITokenService tokenService)
        {
            _config = config;
            _tokenService = tokenService;
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(UserRequestViewModel userModel)
        {
            if (string.IsNullOrEmpty(userModel.UserName) || string.IsNullOrEmpty(userModel.Password))
            {
                return (RedirectToAction("Error"));
            }


            var validUser = new UserDTO()
            {
                UserName ="etuncay",
                Password ="qweqwe123",
                Role = "Admin"
            };

            if (validUser != null)
            {
                generatedToken = _tokenService.BuildToken(_config["Jwt:Key"].ToString(), _config["Jwt:Issuer"].ToString(),validUser);

                if (generatedToken != null)
                {
                    HttpContext.Session.SetString("Token", generatedToken);
                    return RedirectToAction("Index","User");
                }
            }

            return (RedirectToAction("Error"));
        }


        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }


        [AllowAnonymous]
        [HttpPost]
        public IActionResult Register(UserRegisterRequestViewModel model)
        {



            return (RedirectToAction("Error"));
        }
       


        public IActionResult LogAuth()
        {
            return View();
        }
    }
}
