using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core
{

    public class Product 
    {
        public Guid UserId { get;set;}
        public Guid ProductId { get; set; }

        [Required(ErrorMessage = "Необходимо ввести название")]
        public string PName { get; set; }
        public string ProductDescription { get; set; }

        [Required(ErrorMessage = "Необходимо ввести цену")]
        public decimal Cost { get; set; }

        [Required(ErrorMessage = "Необходимо выбрать состояние")]
        public string Condition { get; set; }

        [Required(ErrorMessage = "Необходимо выбрать категорию")]
        public Category Category { get; set; }
        public Category Subcategory { get; set; }
        public Producer Producer { get; set; }

        public Product(string name, string descr, string condition, decimal cost, Category category, Producer producer)
        {
            Category = category;
            PName = name;
            ProductDescription = descr;
            Condition = condition;
            Cost = cost;
            Producer = producer;

        }

        public Product () { }
        public void ChangeCondition()
        {
            if (Condition == "Новое")
                Condition = "Б/У";
            else
                Condition = "Новое";

        }

        public void ChangeCost( decimal cost)
        {
            Cost = cost;
        }
        public void ChangeCategory(Category category)
        {
            Category = category;
        }
        public void ChangeDescription(string descr)
        {
            ProductDescription = descr;
        }
        public void ChangeName(string name)
        {
            PName = name;
        }
    }
}
