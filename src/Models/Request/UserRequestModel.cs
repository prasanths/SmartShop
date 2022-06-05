using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartShop.Models.Request
{
    public class UserRequestModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        [JsonIgnore]
        public string Salt { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
