using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class UnitOfWork : IDisposable
    {
        private Context db;
        public ProductRepository productRepository;
        public OrderRepository orderRepository;
        public CategoryRepository categoryRepository;
        public ProducerRepository producerRepository;
        public UserDataRepository userDataRepository;
        public UserRepository userRepository;
        public EmailRepository emailRepository;
        public PhoneRepository phoneRepository;
        public CityRepository cityRepository;
        public UserProductsListRepository userProductsListRepository;
        public ShoppingCartRepository shoppingCartRepository;

        public UnitOfWork (Context context)
        {
            db = context;
        }
        
        public ShoppingCartRepository ShoppingCarts
        {
            get
            {
                if (shoppingCartRepository == null)
                    shoppingCartRepository = new ShoppingCartRepository(db);
                return shoppingCartRepository;
            }
        }
        public UserProductsListRepository UserProductsLists
        {
            get
            {
                if (userProductsListRepository == null)
                    userProductsListRepository = new UserProductsListRepository(db);
                return userProductsListRepository;
            }
        }
        public CityRepository Cities
        {
            get
            {
                if (cityRepository == null)
                    cityRepository = new CityRepository(db);
                return cityRepository;
            }
        }
        public PhoneRepository Phones
        {
            get
            {
                if (phoneRepository == null)
                    phoneRepository = new PhoneRepository(db);
                return phoneRepository;
            }
        }
        public EmailRepository Emails
        {
            get
            {
                if (emailRepository == null)
                    emailRepository = new EmailRepository(db);
                return emailRepository;
            }
        }
        public UserRepository Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(db);
                return userRepository;
            }
        }
        public UserDataRepository UserDataList
        {
            get
            {
                if (userDataRepository == null)
                    userDataRepository = new UserDataRepository(db);
                return userDataRepository;
            }
        }
        public ProducerRepository Producers
        {
            get
            {
                if (producerRepository == null)
                    producerRepository = new ProducerRepository(db);
                return producerRepository;
            }
        }
        public CategoryRepository Categories
        {
            get
            {
                if (categoryRepository == null)
                    categoryRepository = new CategoryRepository(db);
                return categoryRepository;
            }
        }
        public ProductRepository Products
        {
            get
            {
                if (productRepository == null)
                    productRepository = new ProductRepository(db);
                return productRepository;
            }
        }

        public OrderRepository Orders
        {
            get
            {
                if (orderRepository == null)
                    orderRepository = new OrderRepository(db);
                return orderRepository;
            }
        }
        
        public async Task Save()
        {
            await db.SaveChangesAsync();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

}
