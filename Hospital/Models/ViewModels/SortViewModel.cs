using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Models.ViewModels
{
    public class SortViewModel
    {
        public SortState FIOSort { get; private set; }
        public SortState IINSort{ get; private set; }
        public SortState Current { get; set; }
        public SortViewModel(SortState sortState)
        {
            FIOSort = sortState == SortState.NAME_PATIENT_ASC ? SortState.NAME_PATIENT_DESC : SortState.NAME_PATIENT_ASC;
            IINSort = sortState == SortState.IIN_ASC ? SortState.IIN_DESC : SortState.IIN_ASC;
            Current = sortState;
        }
    }
}
