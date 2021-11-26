using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Models.ViewModels
{
    public class LoginModel
    {
        [Required]
        [Display(Name = "Логин")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Пароль")]
        [UIHint("password")]
        public string Password { get; set; }
        public string ReturnURL { get; set; } = "/";
    }
}
