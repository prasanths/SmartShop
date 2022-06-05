using SmartShop.Db;
using SmartShop.Db.Entities;
using SmartShop.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartShop.Repositories
{
    public class UserRepository : BaseRepository<User, SmartShopDbContext>, IUserRepository<User>
    {
        private readonly SmartShopDbContext _context;
        public UserRepository(SmartShopDbContext context) : base(context)
        {
            _context = context;
        }

        public User GetUserByEmail(string email)
        {
            return _context.Users.SingleOrDefault(x => x.Email == email);
        }
    }
}
