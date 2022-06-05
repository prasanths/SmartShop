﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartShop.Db;

namespace SmartShop.Migrations
{
    [DbContext(typeof(SmartShopDbContext))]
    partial class SmartShopDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("SmartShop.Db.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    b.Property<string>("Address1")
                        .IsRequired()
                        .HasColumnType("varchar(128)")
                        .HasColumnName("address1");

                    b.Property<string>("Address2")
                        .HasColumnType("varchar(128)")
                        .HasColumnName("address2");

                    b.Property<sbyte>("AddressType")
                        .HasColumnType("tinyint")
                        .HasColumnName("address_type");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("city");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("country");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Postcode")
                        .IsRequired()
                        .HasColumnType("varchar(30)")
                        .HasColumnName("post_code");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("updated_at")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("Id");

                    b.ToTable("address");
                });

            modelBuilder.Entity("SmartShop.Db.Entities.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<float>("Total")
                        .HasColumnType("float")
                        .HasColumnName("total");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("updated_at")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int>("UserId")
                        .HasColumnType("int(11)")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("cart");
                });

            modelBuilder.Entity("SmartShop.Db.Entities.CartDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    b.Property<int>("CartId")
                        .HasColumnType("int(11)")
                        .HasColumnName("cart_id");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int>("ProductId")
                        .HasColumnType("int(11)")
                        .HasColumnName("product_id");

                    b.Property<int>("Quantity")
                        .HasColumnType("int(11)")
                        .HasColumnName("quantity");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("updated_at")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("ProductId");

                    b.ToTable("cart_detail");
                });

            modelBuilder.Entity("SmartShop.Db.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<float>("Total")
                        .HasColumnType("float")
                        .HasColumnName("total");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("updated_at")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int>("UserId")
                        .HasColumnType("int(11)")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.ToTable("order");
                });

            modelBuilder.Entity("SmartShop.Db.Entities.OrderDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int>("OrderId")
                        .HasColumnType("int(11)")
                        .HasColumnName("order_id");

                    b.Property<int?>("OrderShippingDetailId")
                        .HasColumnType("int(11)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int(11)")
                        .HasColumnName("product_id");

                    b.Property<float>("Quantity")
                        .HasColumnType("float")
                        .HasColumnName("quantity");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("updated_at")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("OrderShippingDetailId");

                    b.HasIndex("ProductId");

                    b.ToTable("order_detail");
                });

            modelBuilder.Entity("SmartShop.Db.Entities.OrderShippingDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    b.Property<int>("BillingAddressId")
                        .HasColumnType("int(11)")
                        .HasColumnName("billing_address_id");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int>("OrderId")
                        .HasColumnType("int(11)")
                        .HasColumnName("order_id");

                    b.Property<int>("ShippingAddressId")
                        .HasColumnType("int(11)")
                        .HasColumnName("shipping_address_id");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("updated_at")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("Id");

                    b.HasIndex("OrderId")
                        .IsUnique();

                    b.ToTable("order_shipping_detail");
                });

            modelBuilder.Entity("SmartShop.Db.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int(11)")
                        .HasColumnName("category_id");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Description")
                        .IsRequired()
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("varchar(250)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(36)")
                        .HasColumnName("name");

                    b.Property<float>("Price")
                        .HasColumnType("float")
                        .HasColumnName("price");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("updated_at")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("imageUrl")
                        .IsRequired()
                        .ValueGeneratedOnUpdateSometimes()
                        .HasColumnType("varchar(250)")
                        .HasColumnName("description");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("product");
                });

            modelBuilder.Entity("SmartShop.Db.Entities.ProductCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(250)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(36)")
                        .HasColumnName("name");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("updated_at")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("Id");

                    b.ToTable("product_category");
                });

            modelBuilder.Entity("SmartShop.Db.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Email")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("email")
                        .HasDefaultValueSql("'0'");

                    b.Property<string>("Password")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(128)")
                        .HasColumnName("password")
                        .HasDefaultValueSql("'0'");

                    b.Property<string>("Role")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(20)")
                        .HasColumnName("role")
                        .HasDefaultValueSql("'0'");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(36)")
                        .HasColumnName("salt")
                        .HasDefaultValueSql("'0'");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("updated_at")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .HasDatabaseName("IX_EMAIL");

                    b.ToTable("user");
                });

            modelBuilder.Entity("SmartShop.Db.Entities.UserAddress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AddressId")
                        .HasColumnType("int(11)")
                        .HasColumnName("address_id");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasColumnName("updated_at")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int>("UserId")
                        .HasColumnType("int(11)")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("UserId");

                    b.ToTable("user_address");
                });

            modelBuilder.Entity("SmartShop.Db.Entities.Cart", b =>
                {
                    b.HasOne("SmartShop.Db.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SmartShop.Db.Entities.CartDetail", b =>
                {
                    b.HasOne("SmartShop.Db.Entities.Cart", "Cart")
                        .WithMany("CartDetails")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmartShop.Db.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("SmartShop.Db.Entities.OrderDetail", b =>
                {
                    b.HasOne("SmartShop.Db.Entities.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmartShop.Db.Entities.OrderShippingDetail", null)
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderShippingDetailId");

                    b.HasOne("SmartShop.Db.Entities.Product", "Product")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("SmartShop.Db.Entities.OrderShippingDetail", b =>
                {
                    b.HasOne("SmartShop.Db.Entities.Order", "Order")
                        .WithOne("OrderShippingDetail")
                        .HasForeignKey("SmartShop.Db.Entities.OrderShippingDetail", "OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("SmartShop.Db.Entities.Product", b =>
                {
                    b.HasOne("SmartShop.Db.Entities.ProductCategory", "ProductCategory")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProductCategory");
                });

            modelBuilder.Entity("SmartShop.Db.Entities.UserAddress", b =>
                {
                    b.HasOne("SmartShop.Db.Entities.Address", "Address")
                        .WithMany("UserAddresses")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmartShop.Db.Entities.User", "User")
                        .WithMany("UserAddresses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SmartShop.Db.Entities.Address", b =>
                {
                    b.Navigation("UserAddresses");
                });

            modelBuilder.Entity("SmartShop.Db.Entities.Cart", b =>
                {
                    b.Navigation("CartDetails");
                });

            modelBuilder.Entity("SmartShop.Db.Entities.Order", b =>
                {
                    b.Navigation("OrderDetails");

                    b.Navigation("OrderShippingDetail");
                });

            modelBuilder.Entity("SmartShop.Db.Entities.OrderShippingDetail", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("SmartShop.Db.Entities.Product", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("SmartShop.Db.Entities.ProductCategory", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("SmartShop.Db.Entities.User", b =>
                {
                    b.Navigation("UserAddresses");
                });
#pragma warning restore 612, 618
        }
    }
}