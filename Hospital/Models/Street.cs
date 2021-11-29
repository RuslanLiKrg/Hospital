using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public class Street
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Patient> Patients { get; set; }
    }
}
