using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using SmartShop.Db;
using SmartShop.Db.Entities;
using SmartShop.Models;
using SmartShop.Models.Request;
using SmartShop.Models.Response;
using SmartShop.Services.Interfaces;
using SmartShop.Utils;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace SmartShop.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<AuthController> _logger;
        private readonly IAuthService<LoginRequestModel, LoginResponseModel> _authService;
        private readonly IUserService<UserRequestModel, UserResponseModel> _userService;
        public AuthController(IAuthService<LoginRequestModel, LoginResponseModel> authService,
            IUserService<UserRequestModel, UserResponseModel> userService,
            IConfiguration configuration, ILogger<AuthController> logger)
        {
            _configuration = configuration;
            _logger = logger;
            _authService = authService;
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public ActionResult<LoginResponseModel> Login(LoginRequestModel loginRequestLogin)
        {
            var loginResponseModel = _authService.Login(loginRequestLogin);
            return loginResponseModel;
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        public ActionResult<UserResponseModel> Register(UserRequestModel userRequestModel)
        {
            var responseRegister = new UserResponseModel();
            if (_userService.GetUserByEmail(userRequestModel.Email).Result != null)
            {
                var email = userRequestModel.Email;
                var salt = CryptoUtil.GenerateSalt();
                var password = userRequestModel.Password;
                var hashedPassword = CryptoUtil.HashMultiple(password, salt);
                userRequestModel.Role = userRequestModel.Role.ToUpper();
                // Pass word encryption
                userRequestModel.Salt = salt;
                userRequestModel.Password = hashedPassword;

                _userService.Add(userRequestModel);
                responseRegister.Success = true;
            }
            else
            {
                return BadRequest("Email is already in use");
            }
            return responseRegister;
        }
    }
}
