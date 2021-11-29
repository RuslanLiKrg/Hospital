using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public class Patient
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Пожалуйста введите Ваш ИИН.")]
        [RegularExpression("[0-9]{12,12}", ErrorMessage = "Недопустимый ИИН")]
        [Display(Name = "ИИН")]

        public string IIN { get; set; }
        [Required(ErrorMessage = "Пожалуйста введите ваше имя.")]
        [Display(Name = "Имя")]

        public string  Name { get; set; }
        [Required(ErrorMessage ="Пожалуйста введите вашу фамилию.")]
        [Display(Name = "Фамилия")]

        public string Surname { get; set; }
        [Required(ErrorMessage ="Пожалуйста введите ваше отчество")]
        [Display(Name = "Отчество")]

        public string Patronymic { get; set; }
        [Required(ErrorMessage = "Пожалуйста выберете название улицы")]
        [Display(Name = "Название улицы")]
        public int StreetId { get; set; }
        public Street Street { get; set; }

        [Required(ErrorMessage = "Пожалуйста введите номер дома")]
        [Display(Name = "Номер дома")]
        public int HouseNumber { get; set; }
        [Display(Name = "Номер квартиры")]
        public int? AppartmentNumber { get; set; }

        [Required(ErrorMessage ="Пожалуйста введите контактный номер телефона")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Номер телефона")]
        public string PhoneNumber { get; set; }

        public List<Doctor> Doctors { get; set; }
        public List<DiagnozList> DiagnozLists { get; set; }
    }
}
