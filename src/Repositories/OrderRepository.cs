using SmartShop.Db;
using SmartShop.Db.Entities;
using SmartShop.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartShop.Repositories
{
    public class OrderRepository : BaseRepository<Order, SmartShopDbContext>, IOrderRepository<Order>
    {
        public OrderRepository(SmartShopDbContext context) : base(context)
        {

        }
    }
}
