using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartShop.Models.Response
{
    public class LoginResponseModel : BaseResponseModel
    {
        public string Token { get; set; }
        public int ExpireDate { get; set; }
    }
}
