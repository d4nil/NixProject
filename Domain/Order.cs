using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Domain.Core
{
    public class Order
    {
        public Guid UserId { get; set; }
        public Guid OrderId { get; set; }

        [Required(ErrorMessage = "Имя пустое")]
        public string Name { get; set; }
        public string Comment { get; set; }
        [Required(ErrorMessage = "Выберите город")]
        public City City { get; set; }
        public Guid CityId { get; set; }

        [Required(ErrorMessage = "Адрес пуст")]
        public string Address { get; set; }
        public DateTime Date { get; set; }
        public decimal SumCost { get; set; }
        public  List<Cartline> lines { get; set; }
        public Order() { }
    }
}
