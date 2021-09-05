﻿using Domain.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(Guid? id);
        void Create(T item);
        void Update(T item);
        void Delete(Guid? id);
    }

    public class ProductRepository : IRepository<Product>
    {
        private Context db;

        public ProductRepository(Context context)
        {
            this.db = context;
        }

        public IEnumerable<Product> GetAll()
        {
            return db.Products;
        }

        public Product Get(Guid? id)
        {
            return db.Products.Find(id);
        }
        public Product GetByUser(Guid? id)
        {
            User user = db.Users.Find(id);
            Product prod = db.Products.Where(x => x.UserId == user.UserId).FirstOrDefault();
            return db.Products.Find(prod.ProductId);
        }

        public void Create(Product product)
        {
            db.Products.Add(product);
        }

        public void Update(Product product)
        {
            db.Entry(product).State = EntityState.Modified;
        }

        public void Delete(Guid? id)
        {
            Product product = db.Products.Find(id);
            if (product != null)
                db.Products.Remove(product);
        }
    }

    public class CategoryRepository : IRepository<Category>
    {
        private Context db;

        public CategoryRepository(Context context)
        {
            this.db = context;
        }

        public IEnumerable<Category> GetAll()
        {
            return db.Categories;
        }

        public Category Get(Guid? id)
        {
            return db.Categories.Find(id);
        }

        public void Create(Category category)
        {
            db.Categories.Add(category);
        }

        public void Update(Category category)
        {
            db.Entry(category).State = EntityState.Modified;
        }

        public void Delete(Guid? id)
        {
            Category category = db.Categories.Find(id);
            if (category != null)
                db.Categories.Remove(category);
        }
    }
    public class ProducerRepository : IRepository<Producer>
    {
        private Context db;

        public ProducerRepository(Context context)
        {
            this.db = context;
        }

        public IEnumerable<Producer> GetAll()
        {
            if(db.Producers == null) { return null; }
            else
            return db.Producers;
        }

        public Producer Get(Guid? id)
        {
            return db.Producers.Find(id);
        }

        public void Create(Producer producer)
        {
            db.Producers.Add(producer);
        }

        public void Update(Producer producer)
        {
            db.Entry(producer).State = EntityState.Modified;
        }

        public void Delete(Guid? id)
        {
            Producer producer = db.Producers.Find(id);
            if (producer != null)
                db.Producers.Remove(producer);
        }
    }
    public class UserDataRepository : IRepository<UserData>
    {
        private Context db;

        public UserDataRepository(Context context)
        {
            this.db = context;
        }

        public IEnumerable<UserData> GetAll()
        {
            return db.UserDataList;
        }

        public UserData Get(Guid? id)
        {
            return db.UserDataList.Find(id);
        }
        public UserData GetByUser(Guid? id)
        {
            User user =  db.Users.Find(id);
            if (user == null) { return null; }
            else { 
            UserData userData = db.UserDataList.Where(x => x.UserDataId == user.UserId).FirstOrDefault();
            return db.UserDataList.Find(userData.UserDataId);
            }
        }

        public void Create(UserData userdata)
        {
            db.UserDataList.Add(userdata);
        }

        public void Update(UserData userdata)
        {
            db.Entry(userdata).State = EntityState.Modified;
        }

        public void Delete(Guid? id)
        {
            UserData userdata = db.UserDataList.Find(id);
            if (userdata != null)
                db.UserDataList.Remove(userdata);
        }
    }
    public class UserRepository : IRepository<User>
    {
        private Context db;

        public UserRepository(Context context)
        {
            this.db = context;
        }

        public IEnumerable<User> GetAll()
        {
            return db.Users;
        }

        public User Get(Guid? id)
        {
            return db.Users.Find(id);
        }
        public User Get(string id)
        {

            User user =  db.Users.Where(x => x.IdentityId == id).FirstOrDefault();
            if (user == null) return null;
            else { 
            return db.Users.Find(user.UserId);
            }
        }

        public void Create(User user)
        {
            db.Users.Add(user);
        }

        public void Update(User user)
        {
            db.Entry(user).State = EntityState.Modified;
        }

        public void Delete(Guid? id)
        {
            User user = db.Users.Find(id);
            if (user != null)
                db.Users.Remove(user);
        }
    }
    public class OrderRepository : IRepository<Order>
    {
        private Context db;

        public OrderRepository(Context context)
        {
            this.db = context;
        }

        public IEnumerable<Order> GetAll()
        {
            return db.Orders;
        }

        public Order Get(Guid? id)
        {
            return db.Orders.Find(id);
        }

        public void Create(Order order)
        {
            db.Orders.Add(order);
        }

        public void Update(Order order)
        {
            db.Entry(order).State = EntityState.Modified;
        }

        public void Delete(Guid? id)
        {
            Order order = db.Orders.Find(id);
            if (order != null)
                db.Orders.Remove(order);
        }
    }
    public class EmailRepository : IRepository<Email>
    {
        private Context db;

        public EmailRepository(Context context)
        {
            this.db = context;
        }

        public IEnumerable<Email> GetAll()
        {
            return db.Emails;
        }

        public Email Get(Guid? id)
        {
            return db.Emails.Find(id);
        }

        public void Create(Email email)
        {
            db.Emails.Add(email);
        }

        public void Update(Email email)
        {
            db.Entry(email).State = EntityState.Modified;
        }

        public void Delete(Guid? id)
        {
            Email email = db.Emails.Find(id);
            if (email != null)
                db.Emails.Remove(email);
        }
    }
    public class PhoneRepository : IRepository<Phone>
    {
        private Context db;

        public PhoneRepository(Context context)
        {
            this.db = context;
        }

        public IEnumerable<Phone> GetAll()
        {
            return db.Phones;
        }

        public Phone Get(Guid? id)
        {
            return db.Phones.Find(id);
        }

        public void Create(Phone phone)
        {
            db.Phones.Add(phone);
        }

        public void Update(Phone phone)
        {
            db.Entry(phone).State = EntityState.Modified;
        }

        public void Delete(Guid? id)
        {
            Phone phone = db.Phones.Find(id);
            if (phone != null)
                db.Phones.Remove(phone);
        }
    }
    public class CityRepository : IRepository<City>
    {
        private Context db;

        public CityRepository(Context context)
        {
            this.db = context;
        }

        public IEnumerable<City> GetAll()
        {
            return db.Cities;
        }

        public City Get(Guid? id)
        {
            return db.Cities.Find(id);
        }

        public void Create(City city)
        {
            db.Cities.Add(city);
        }

        public void Update(City city)
        {
            db.Entry(city).State = EntityState.Modified;
        }

        public void Delete(Guid? id)
        {
            City city = db.Cities.Find(id);
            if (city != null)
                db.Cities.Remove(city);
        }
    }
    public class UserProductsListRepository : IRepository<UserProductsList>
    {
        private Context db;

        public UserProductsListRepository(Context context)
        {
            this.db = context;
        }

        public IEnumerable<UserProductsList> GetAll()
        {
            return db.UserProductsLists;
        }

        public UserProductsList Get(Guid? id)
        {
            return db.UserProductsLists.Find(id);
        }

        public void Create(UserProductsList userProductsList)
        {
            db.UserProductsLists.Add(userProductsList);
        }

        public void Update(UserProductsList userProductsList)
        {
            db.Entry(userProductsList).State = EntityState.Modified;
        }

        public void Delete(Guid? id)
        {
            UserProductsList userProductsList = db.UserProductsLists.Find(id);
            if (userProductsList != null)
                db.UserProductsLists.Remove(userProductsList);
        }
    }
    public class ShoppingCartRepository : IRepository<ShoppingCart>
    {
        private Context db;

        public ShoppingCartRepository(Context context)
        {
            this.db = context;
        }

        public IEnumerable<ShoppingCart> GetAll()
        {
            return db.ShoppingCarts;
        }

        public ShoppingCart Get(Guid? id)
        {
            return db.ShoppingCarts.Find(id);
        }
        public ShoppingCart GetByUser(Guid? id)
        {
            User user = db.Users.Find(id);
            ShoppingCart shop = db.ShoppingCarts.Where(x => x.BuyerId == user.UserId).FirstOrDefault();
            return db.ShoppingCarts.Find(shop.ShoppingCartId);
        }

        public void Create(ShoppingCart shoppingCart)
        {
            db.ShoppingCarts.Add(shoppingCart);
        }

        public void Update(ShoppingCart shoppingCart)
        {
            db.Entry(shoppingCart).State = EntityState.Modified;
        }

        public void Delete(Guid? id)
        {
            ShoppingCart shoppingCart = db.ShoppingCarts.Find(id);
            if (shoppingCart != null)
                db.ShoppingCarts.Remove(shoppingCart);
        }
    }
}