using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Models.ViewModels
{
    public class VisitRecordfForEditViewModel
    {
        public VisitHistory VisitRecord { get; set; }
        public IEnumerable<DiagnozList> DiagnozLists { get; set; }
        public IEnumerable<Doctor> Doctors { get; set; }
        public int IdPatient { get; set; }
        public VisitRecordfForEditViewModel()
        {

        }
        public VisitRecordfForEditViewModel(VisitHistory _visitRecord, IEnumerable<DiagnozList> _diagnozLists, IEnumerable<Doctor> _doctors, int _idPatient)
        {
            VisitRecord = _visitRecord;
            DiagnozLists = _diagnozLists;
            Doctors = _doctors;
            IdPatient = _idPatient;
        }
    }
}
