using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Models.ViewModels
{
    public class PatientWithStreets
    {
        public Patient Patient { get; set; }
        public IQueryable<Street> Streets { get; set; }
        [Required(ErrorMessage = "eroror")]
        public int iiin { get; set; }
    }
}
