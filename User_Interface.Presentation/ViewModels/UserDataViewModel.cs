using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Core;
using System.ComponentModel.DataAnnotations;

namespace User_Interface.Presentation.Models
{
    public class UserDataViewModel
    {   
        [Required(ErrorMessage ="Необходимо ввести имя")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Необходимо ввести  телефон"), Phone]
        public string Phone { get; set; }
        public List<Phone> Phones { get; set; }
        [Required(ErrorMessage = "Необходимо ввести  имейл"), EmailAddress]
        public string Email { get; set; }
        public List<Email> Emails { get; set; }
        [Required(ErrorMessage = "Выберите город")]
        public City City { get; set; }

    }
}
