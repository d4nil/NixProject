using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core
{
    public class User
    {
        public string IdentityId { get; set; }
        public Guid UserId { get; set; }
        public UserData UserData { get; set; }
        public UserProductsList UserProductsList { get; set; }
        public ShoppingCart Cart { get; set; }

        public void AddProduct(Product product)
        {

            UserProductsList.AddProductToList(product);
        }
        public void DeleteProduct(Product prod)
        {
            UserProductsList.Products.Remove(prod);
        }
    }
}
