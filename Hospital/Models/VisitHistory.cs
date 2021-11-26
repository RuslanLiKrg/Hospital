
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public class VisitHistory
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Укажите дату приема")]
        [Display(Name = "Дата")]
        public DateTime Date { get; set; }

        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        [Required(ErrorMessage = "Выберете врача")]
        [Display(Name = "ФИО врача")]
        public int DoctorId { get; set; }
        public Doctor DoctorList { get; set; }

        [Required(ErrorMessage = "Выберете поставленный диагноз")]
        [Display(Name = "Диагноз")]
        public int DiagnozListId { get; set; }
        public DiagnozList DiagnozList { get; set; }
        [Required(ErrorMessage = "Укажите жалобы пациента")]
        [Display(Name = "Жалобы")]
        public string Complaints { get; set; }
    }
}
