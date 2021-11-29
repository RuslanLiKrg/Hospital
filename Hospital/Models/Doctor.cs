using System.Collections.Generic;

namespace Hospital.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int SpecialityId { get; set; }
        public Speciality Speciality { get; set; }
        public List<Patient> Patients { get; set; }
        public List<DiagnozList> DiagnozLists { get; set; }
    }
}