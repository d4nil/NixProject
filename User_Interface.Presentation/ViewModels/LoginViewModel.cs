using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace User_Interface.Presentation.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Введите имейл")]
        [EmailAddress(ErrorMessage = "Имейл должен быть в формате email@gmail.com")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Введите пароль")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Display(Name = "Запомнить?")]
        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}
