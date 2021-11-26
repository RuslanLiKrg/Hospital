using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Models.ViewModels
{
    public class SortVisitRecordsViewModel
    {
        public SortState NameSort { get; private set; }
        public SortState DoctorNameSort{ get; private set; }
        public SortState DateNameSort{ get; private set; }
        public SortState Current { get; set; }
        public SortVisitRecordsViewModel(SortState sortState)
        {
            DoctorNameSort = sortState == SortState.DOCTOR_NAME_ASC ? SortState.DOCTOR_NAME_DESC : SortState.DOCTOR_NAME_ASC;
            DateNameSort = sortState == SortState.DATE_ASC ? SortState.DATE_DESC : SortState.DATE_ASC;
            Current = sortState;
        }
    }
}
