using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SmartShop.Db.Entities;
using SmartShop.Models.Request;
using SmartShop.Models.Response;
using SmartShop.Repositories.Interfaces;
using SmartShop.Services.Interfaces;
using SmartShop.Utils;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SmartShop.Services
{
    public class AuthService : IAuthService<LoginRequestModel, LoginResponseModel>
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository<User> _userRepository;
        private readonly IMapper _mapper;

        public AuthService(IUserRepository<User> userRepository, IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public LoginResponseModel Login(LoginRequestModel loginRequestLogin)
        {
            var loginResponseModel = new LoginResponseModel();
            var existingUser = _userRepository.GetUserByEmail(loginRequestLogin.Email);
            if (existingUser != null)
            {
                var isPasswordVerified = CryptoUtil.VerifyPassword(loginRequestLogin.Password, existingUser.Salt, existingUser.Password);
                if (isPasswordVerified)
                {
                    var claimList = new List<Claim>();
                    claimList.Add(new Claim(ClaimTypes.Email, existingUser.Email));
                    claimList.Add(new Claim(ClaimTypes.Name, existingUser.FirstName));
                    claimList.Add(new Claim(ClaimTypes.Role, existingUser.Role));
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Keys:SecretKey"]));
                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var expireDate = DateTime.UtcNow.AddDays(1);
                    var timeStamp = DateUtil.ConvertToTimeStamp(expireDate);
                    var token = new JwtSecurityToken(
                        claims: claimList,
                        notBefore: DateTime.UtcNow,
                        expires: expireDate,
                        signingCredentials: creds);
                    loginResponseModel.Success = true;
                    loginResponseModel.Token = new JwtSecurityTokenHandler().WriteToken(token);
                    loginResponseModel.ExpireDate = timeStamp;
                }
                else
                {
                    throw new Exception("Password is wrong");
                }
            }
            else
            {
                throw new Exception("Email is wrong");
            }
            //}
            return loginResponseModel;
        }
    }
}
