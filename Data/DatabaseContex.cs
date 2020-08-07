using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Data.Configuration;
using Data.Entities;

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
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductDetails> ProductDetailses { get; set; }
        public DbSet<NutritionDeclaration> NutritionDeclarations { get; set; }

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

            DatabaseInitializer.Seed(modelBuilder);
        }
    }
}
