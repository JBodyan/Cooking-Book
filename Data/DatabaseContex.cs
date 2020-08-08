using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Data.Configuration;
using Data.Configuration.Shoplist;
using Data.Entities;
using Data.Entities.Shoplist;

namespace Data
{
    public class DatabaseContex : DbContext
    {
        public DatabaseContex(DbContextOptions<DatabaseContex> options) : base(options)
        {
        }


        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<ResetPassword> ResetPassword { get; set; }
        public DbSet<RefreshToken> RefreshToken { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }
        public DbSet<ProductDetails> ProductDetails { get; set; }
        public DbSet<NutritionDeclaration> NutritionDeclaration { get; set; }

        public DbSet<Shoplist> Shoplist { get; set; }
        public DbSet<ShoplistUser> ShoplistUser { get; set; }
        public DbSet<ShoplistRole> ShoplistRole { get; set; }
        public DbSet<ShoplistCategory> ShoplistCategory { get; set; }
        public DbSet<ShoplistProduct> ShoplistProduct { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new RoleConfig());
            modelBuilder.ApplyConfiguration(new ResetPasswordConfig());
            modelBuilder.ApplyConfiguration(new ProductConfig());
            modelBuilder.ApplyConfiguration(new ProductCategoryConfig());
            modelBuilder.ApplyConfiguration(new ProductDetailsConfig());
            modelBuilder.ApplyConfiguration(new NutritionDeclarationConfig());

            modelBuilder.ApplyConfiguration(new ShoplistConfig());
            modelBuilder.ApplyConfiguration(new ShoplistRoleConfig());
            modelBuilder.ApplyConfiguration(new ShoplistUserConfig());
            modelBuilder.ApplyConfiguration(new ShoplistCategoryConfig());
            modelBuilder.ApplyConfiguration(new ShoplistProductConfig());

            DatabaseInitializer.Seed(modelBuilder);
        }
    }
}
