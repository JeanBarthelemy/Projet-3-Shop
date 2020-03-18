using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;


namespace WpfTest_Shop
{
    public class ShopContext : DbContext
    {
        public virtual DbSet<Shop> Shops { get; set; }
        public virtual DbSet<Magazine> Magazines { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<County> County { get; set; }
        public virtual DbSet<District> District { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Editor> Editor { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Server=LOCALHOST\SQLEXPRESS;Database=Projet3_Shop;Integrated Security=True;MultipleActiveResultSets=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ShopMagazine>()
                .HasKey(sm => new { sm.ShopId, sm.MagazineId });
            modelBuilder.Entity<ShopMagazine>()
                .HasOne(sm => sm.Shop)
                .WithMany(s => s.ManyShopMagazines)
                .HasForeignKey(sm =>sm.ShopId);
            modelBuilder.Entity<ShopMagazine>()
                .HasOne(sm => sm.Magazine)
                .WithMany(m => m.ManyShopMagazines)
                .HasForeignKey(sm => sm.MagazineId);

            modelBuilder.Entity<MagazineOrder>()
                .HasKey(mo => new { mo.MagazineId, mo.OrderId });
            modelBuilder.Entity<MagazineOrder>()
                .HasOne(mo => mo.Magazine)
                .WithMany(m => m.ManyMagazineOrders)
                .HasForeignKey(mo => mo.MagazineId);
            modelBuilder.Entity<MagazineOrder>()
                .HasOne(mo => mo.Order)
                .WithMany(o => o.ManyMagazineOrders)
                .HasForeignKey(mo => mo.OrderId);

            modelBuilder.Entity<PersonShop>()
                .HasKey(ps => new { ps.PersonId, ps.ShopId });
            modelBuilder.Entity<PersonShop>()
                .HasOne(ps => ps.Person)
                .WithMany(p => p.ManyPersonShops)
                .HasForeignKey(ps => ps.PersonId);
            modelBuilder.Entity<PersonShop>()
                .HasOne(ps => ps.Shop)
                .WithMany(s => s.ManyPersonShops)
                .HasForeignKey(ps => ps.ShopId);

            modelBuilder.Entity<OrderShop>()
                .HasKey(os => new { os.OrderId, os.ShopId });
            modelBuilder.Entity<OrderShop>()
                .HasOne(os => os.Order)
                .WithMany(o => o.ManyOrderShops)
                .HasForeignKey(os => os.OrderId);
            modelBuilder.Entity<OrderShop>()
                .HasOne(os => os.Shop)
                .WithMany(s => s.ManyOrderShops)
                .HasForeignKey(os => os.ShopId);


        }

    }
}