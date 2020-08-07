using System;
using System.Collections.Generic;
using System.Text;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data
{
    static class DatabaseInitializer
    {
        public static void Seed(ModelBuilder builder)
        {
            Seed(builder.Entity<User>());
            Seed(builder.Entity<Role>());
        }

        private static void Seed(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Bogdan",
                    MiddleName = "Igorevich",
                    LastName = "Kandela",
                    Email = "bogdan.kand97@gmail.com",
                    Password = "bk_password",
                    RoleId = 1
                }
            );
        }
        private static void Seed(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(
                new Role
                {
                    Id = 1,
                    Name = "Admin"
                },
                new Role
                {
                    Id = 2,
                    Name = "User"
                }
            );
        }
    }
}
