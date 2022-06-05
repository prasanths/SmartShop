using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartShop.Models
{
    public class BaseResponseModel
    {
        public bool Success { get; set; }
        public List<string> MessageList { get; set; }
        public BaseResponseModel()
        {
            MessageList = new List<string>();
        }
    }
}
