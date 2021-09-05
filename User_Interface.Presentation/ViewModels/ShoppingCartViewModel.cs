using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Core;
namespace User_Interface.Presentation.Models
{
    public class ShoppingCartViewModel
    {
        public IEnumerable<Cartline> lines { get; set; }
        public decimal TotalCostAllProducts { get; set; }
        public string ReturnUrl { get; set; }
    }
}
