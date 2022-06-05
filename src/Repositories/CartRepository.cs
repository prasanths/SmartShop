using SmartShop.Db;
using SmartShop.Db.Entities;
using SmartShop.Repositories.Interfaces;

namespace SmartShop.Repositories
{
    public class CartRepository : BaseRepository<Cart, SmartShopDbContext>, ICartRepository<Cart>
    {
        public CartRepository(SmartShopDbContext context) : base(context)
        {

        }
    }
}
