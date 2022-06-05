using Microsoft.EntityFrameworkCore;
using SmartShop.Db.Entities;

namespace SmartShop.Db
{
    public class SmartShopDbContext : DbContext
    {
        //public SmartShopDbContext()
        //{

        //}

        public SmartShopDbContext(DbContextOptions<SmartShopDbContext> dbContextOptions): base(dbContextOptions)
        {

        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserAddress> UserAddresses { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<OrderShippingDetail> OrderShippingDetails { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.HasIndex(e => e.Email)
                    .HasDatabaseName("IX_EMAIL");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasColumnType("varchar(50)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasColumnType("varchar(128)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasColumnName("role")
                    .HasColumnType("varchar(20)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasColumnType("varchar(50)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.LastName)
                   .IsRequired()
                   .HasColumnName("last_name")
                   .HasColumnType("varchar(50)")
                   .HasDefaultValueSql("'0'");

                entity.Property(e => e.Salt)
                    .IsRequired()
                    .HasColumnName("salt")
                    .HasColumnType("varchar(36)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.CreatedAt)
                    .IsRequired()
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.UpdatedAt)
                    .IsRequired()
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("address");

                entity.HasKey(o => o.Id);

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Address1)
                    .IsRequired()
                    .HasColumnName("address1")
                    .HasColumnType("varchar(128)");

                entity.Property(e => e.Address2)
                    .HasColumnName("address2")
                    .HasColumnType("varchar(128)");

                entity.Property(e => e.AddressType)
                    .IsRequired()
                    .HasColumnName("address_type")
                    .HasColumnType("tinyint");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasColumnName("country")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Postcode)
                    .IsRequired()
                    .HasColumnName("post_code")
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.CreatedAt)
                    .IsRequired()
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.UpdatedAt)
                    .IsRequired()
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<UserAddress>(entity =>
            {
                entity.ToTable("user_address");
                entity.HasKey(o => o.Id);

                entity.Property(e => e.AddressId)
                    .HasColumnName("address_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt)
                    .IsRequired()
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.UpdatedAt)
                    .IsRequired()
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(s => s.User)
                    .WithMany(ad => ad.UserAddresses)
                    .HasForeignKey(ad => ad.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(s => s.Address)
                    .WithMany(d=>d.UserAddresses)
                    .HasForeignKey(ad => ad.AddressId)
                    .OnDelete(DeleteBehavior.Cascade);
            });



            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable("order_detail");
                entity.HasKey(o => o.Id);

                //entity.HasOne(od => od.Product)
                //.WithOne(o => o.OrderDetails)
                //.HasForeignKey<Product>(ad => ad.ProductId);

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.OrderId)
                    .IsRequired()
                    .HasColumnName("order_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ProductId)
                    .IsRequired()
                    .HasColumnName("product_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Quantity)
                    .IsRequired()
                    .HasColumnName("quantity")
                    .HasColumnType("float");

                entity.Property(e => e.CreatedAt)
                    .IsRequired()
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.UpdatedAt)
                    .IsRequired()
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

            });

            modelBuilder.Entity<OrderShippingDetail>(entity =>
            {
                entity.ToTable("order_shipping_detail");
                entity.HasKey(o => o.Id);

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.OrderId)
                    .IsRequired()
                    .HasColumnName("order_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BillingAddressId)
                    .IsRequired()
                    .HasColumnName("billing_address_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ShippingAddressId)
                    .IsRequired()
                    .HasColumnName("shipping_address_id");

                entity.Property(e => e.CreatedAt)
                    .IsRequired()
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.UpdatedAt)
                    .IsRequired()
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("order");
                entity.HasKey(o => o.Id);


                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Total)
                    .IsRequired()
                    .HasColumnName("total")
                    .HasColumnType("float");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Date)
                    .IsRequired()
                    .HasColumnName("date")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.CreatedAt)
                    .IsRequired()
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.UpdatedAt)
                    .IsRequired()
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");


                entity.HasOne(s => s.OrderShippingDetail)
                    .WithOne(ad => ad.Order)
                    .HasForeignKey<OrderShippingDetail>(ad => ad.OrderId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(s => s.OrderDetails)
                    .WithOne(o => o.Order)
                    .OnDelete(DeleteBehavior.Cascade);

            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.ToTable("product_category");
                entity.HasKey(o => o.Id);

                entity.Property(e => e.Id)
                   .HasColumnName("id")
                   .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(36)");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasColumnType("varchar(250)");

                entity.Property(e => e.CreatedAt)
                    .IsRequired()
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.UpdatedAt)
                    .IsRequired()
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");


                entity.HasMany(s => s.Products)
                    .WithOne(ad => ad.ProductCategory)
                    .HasForeignKey(ad => ad.CategoryId)
                    .OnDelete(DeleteBehavior.Cascade);



            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("product");
                entity.HasKey(o => o.Id);

                entity.Property(e => e.Id)
                   .HasColumnName("id")
                   .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(36)");

                entity.Property(e => e.Price)
                    .IsRequired()
                    .HasColumnName("price")
                    .HasColumnType("float");

                entity.Property(e => e.CategoryId)
                    .IsRequired()
                    .HasColumnName("category_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasColumnType("varchar(250)");

                entity.Property(e => e.imageUrl)
                    .IsRequired()
                    .HasColumnName("image_url")
                    .HasColumnType("varchar(250)");

                entity.Property(e => e.CreatedAt)
                    .IsRequired()
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.UpdatedAt)
                    .IsRequired()
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");


                entity.HasOne(s => s.ProductCategory);
                ;



            });


            modelBuilder.Entity<Cart>(entity =>
            {
                entity.ToTable("cart");
                entity.HasKey(o => o.Id);

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Total)
                    .IsRequired()
                    .HasColumnName("total")
                    .HasColumnType("float");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt)
                    .IsRequired()
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.UpdatedAt)
                    .IsRequired()
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");


                entity.HasMany(s => s.CartDetails)
                    .WithOne(ad => ad.Cart)
                    .HasForeignKey(ad => ad.CartId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(s => s.User);
            });

            modelBuilder.Entity<CartDetail>(entity =>
            {
                entity.ToTable("cart_detail");
                entity.HasKey(o => o.Id);

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CartId)
                    .IsRequired()
                    .HasColumnName("cart_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ProductId)
                    .IsRequired()
                    .HasColumnName("product_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Quantity)
                    .IsRequired()
                    .HasColumnName("quantity")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedAt)
                    .IsRequired()
                    .HasColumnName("created_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.UpdatedAt)
                    .IsRequired()
                    .HasColumnName("updated_at")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(b => b.Cart);

                entity.HasOne(b => b.Product);
            });

        }
    }
}
