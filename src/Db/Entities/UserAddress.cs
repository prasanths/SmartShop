using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartShop.Db.Entities
{
    public class Address : BaseEntity
    {
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Postcode { get; set; }
        public int AddressType { get; set; }

        public ICollection<UserAddress> UserAddresses { get; set; }
    }
        public class UserAddress : BaseEntity
    {
        public int UserId { get; set; }
        public int AddressId { get; set; }

        public User User { get; set; }

        public Address Address { get; set; }
    }
}
