using System;
using Domain.Core;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class Context : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<UserData> UserDataList { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<UserProductsList> UserProductsLists { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
            Database.EnsureCreated();
        }


    }
}

