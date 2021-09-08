using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Core;
using Data;
using System.ComponentModel.DataAnnotations;

namespace User_Interface.Presentation.Models
{
    public class ProductViewModel
    {

        [Required(ErrorMessage = "Необходимо ввести название")]
        public string PName { get; set; }
        public string ProductDescription { get; set; }

        [Required(ErrorMessage = "Необходимо ввести цену")]
        public decimal Cost { get; set; }

        [Required(ErrorMessage = "Необходимо выбрать состояние")]
        public string Condition { get; set; }

        [Required(ErrorMessage = "Необходимо выбрать категорию")]
        public Category Category { get; set; }
        public Category SubCategory { get; set; }

        public Producer Producer { get; set; }
        public UserData userdata { get; set; }
        public IEnumerable<Category> categories { get; set; }
        public IEnumerable<Producer> producers { get; set; }
        public Guid BuyerId { get; set; }

    }
}
