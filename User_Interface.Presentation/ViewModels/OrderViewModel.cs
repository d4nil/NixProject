using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Core;
using System.ComponentModel.DataAnnotations;

namespace User_Interface.Presentation.Models
{
    public class OrderViewModel
    {
       [Required(ErrorMessage = "Имя пустое")]
       public string Name { get; set; }
       public string Comment { get; set; }
       [Required(ErrorMessage = "Выберите город")]
       public City City { get; set; }

       [Required(ErrorMessage = "Адрес пуст")]
       public string Address { get; set; }
       public DateTime Date { get; set; }

       public decimal SumCost { get; set; }
       public IEnumerable<Cartline> lines { get; set; }
       public IEnumerable<Order> orders { get; set; }
       public IEnumerable<City> Cities { get; set; }
       public User User { get; set; }
       public ShoppingCart cart { get; set; }
       
    }
}
