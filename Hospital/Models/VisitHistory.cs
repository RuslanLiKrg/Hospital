
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public class VisitHistory
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }

        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        public int DoctorId { get; set; }
        public Doctor DoctorList { get; set; }


        public int DiagnozListId { get; set; }
        public DiagnozList DiagnozList { get; set; }

        public string Complaints { get; set; }
    }
}
