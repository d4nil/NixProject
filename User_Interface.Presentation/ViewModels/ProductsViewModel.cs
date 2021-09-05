using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Core;

namespace User_Interface.Presentation.Models
{
    public class ProductsViewModel
    {
       public Guid UserId { get; set; }
       public IEnumerable<Product> Products { get; set; }
       public IEnumerable<User> Users { get; set; }
       public PageViewModel PageViewModel { get; set; }
       public Guid BuyerId { get; set; }
    }
}
