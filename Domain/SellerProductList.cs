using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core
{
    public class UserProductsList
    {
        public Guid UserProductsListId { get; set; }
        public List<Product> Products { get; set; }
        public void AddProductToList(Product product)
        {
            Products.Add(product);
        }
    }
}
