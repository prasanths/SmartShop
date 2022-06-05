using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartShop.Db.Entities
{
    public class User : BaseEntity
    {
        public string Email { get; set; }
        public string Salt { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<UserAddress> UserAddresses { get; set; }
    }
}
