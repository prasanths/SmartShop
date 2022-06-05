using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace SmartShop.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = "Bearer", Roles = "ADMIN")]
    public class UserController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<AuthController> _logger;
        public UserController(IConfiguration configuration, ILogger<AuthController> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }
    }
}
