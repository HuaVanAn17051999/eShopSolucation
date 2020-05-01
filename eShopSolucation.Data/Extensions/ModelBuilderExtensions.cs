using eShopSolucation.Data.Entities;
using eShopSolucation.Data.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolucation.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppConfig>().HasData(
                new AppConfig() { Key = "HomeTitle", Value = "This is home page of eShopSolution" },
                new AppConfig() { Key = "HomeKeyword", Value = "This is keyword of eShopSolution" },
                new AppConfig() { Key = "HomeDescription", Value = "This is description  of eShopSolution" }
                );

            modelBuilder.Entity<Language>().HasData(
                new Language() { Id = "vi-VN", Name = "Tiếng Việt", IsDefault = true },
                new Language() { Id = "en-US", Name = "English", IsDefault = true }

                );

            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    Id = 1,
                    IsShowOnHome = true,
                    ParentId = null,
                    SortOrder = 1,
                    Status = Status.Active,
                }
                );

            modelBuilder.Entity<Category>().HasData(
              new Category()
              {
                  Id = 2,
                  IsShowOnHome = true,
                  ParentId = null,
                  SortOrder = 2,
                  Status = Status.Active, 
              }
              );

            modelBuilder.Entity<CategoryTranslation>().HasData(
              new CategoryTranslation() { Id = 1, CategoryId = 1, Name = "Áo nam", LanguageId = "vi-VN", SeoAlias = "ao-nam", SeoDescription = "Sản phẩm áo thời trang", SeoTitle = "Sản phẩm áo thời trang" },
              new CategoryTranslation() { Id = 2, CategoryId = 1, Name = "Men Shirt", LanguageId = "en-US", SeoAlias = "men-shirt", SeoDescription = "Fashionable shirt products", SeoTitle = "Fashionable shirt products" },
              new CategoryTranslation() { Id = 3, CategoryId = 2, Name = "Áo nữ", LanguageId = "vi-VN", SeoAlias = "ao-nu", SeoDescription = "Sản phẩm áo thời trang", SeoTitle = "Sản phẩm áo thời trang" },
              new CategoryTranslation() { Id = 4, CategoryId = 2, Name = "Women Shirt", LanguageId = "en-US", SeoAlias = "women-shirt", SeoDescription = "Fashionable shirt products", SeoTitle = "Fashionable shirt products" }
              );

            modelBuilder.Entity<Product>().HasData(
               new Product()
               {
                   Id = 1,
                   DateCreated = DateTime.Now,
                   OriginalPrice = 100,
                   Price = 200,
                   Stock = 0,
                   ViewCount = 0,    
               });

            modelBuilder.Entity<ProductTranslation>().HasData(
                 new ProductTranslation() { Id = 1 ,ProductId = 1, Name = "Áo sơ mi nam trắng", LanguageId = "vi-VN", SeoAlias = "ao-so-mi-nam-trang", SeoDescription = "Áo sơ mi nam trắng", SeoTitle = "Sản phẩm áo thời trang", Details = "Áo sơ mi nam trắng", Description = "" },
                 new ProductTranslation() { Id = 2, ProductId = 1, Name = "Men's white shirts", LanguageId = "en-US", SeoAlias = "men-is-white-shirts", SeoDescription = "Men's white shirts", SeoTitle = "Men's white shirts", Details = "Details of Product", Description = "" }
                );

            modelBuilder.Entity<ProductInCategory>().HasData(
                new ProductInCategory() { ProductId = 1, CategoryId = 1 }
                );

            // any guid
            var roleId = new Guid("65653D6D-A1A6-44C6-AA99-ECCD2A90BBBD");
            var adminId = new Guid("E8FB9B73-3A09-4EB8-A8C2-79FE14B70CD7");
            modelBuilder.Entity<AppRole>().HasData(new AppRole
            {
                Id = roleId,
                Name = "admin",
                NormalizedName = "admin",
                Description = "Administrator role"
            });

            var hasher = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = adminId,
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "anhuavan9x@gmail.com",
                NormalizedEmail = "anhuavan9x@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Abc1234$"),
                SecurityStamp = string.Empty,
                FirstName = "Hua",
                LastName = "An",
                Dob = new DateTime(2020,01,04)
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = roleId,
                UserId = adminId
            });
        }

    }
}
