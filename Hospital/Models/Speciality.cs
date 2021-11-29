using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public class Speciality
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Doctor> DoctorLists { get; set; }
        public Speciality()
        {
            DoctorLists = new List<Doctor>();
        }
    }
}
