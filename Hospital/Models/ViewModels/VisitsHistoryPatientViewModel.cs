using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Models.ViewModels
{
    public class VisitsHistoryPatientViewModel
    {
        public IEnumerable<VisitHistory> VisitHistories { get; set; }
        public PageInfoVisitHistoryViewModel PagingInfo { get; set; }
        public SortVisitRecordsViewModel SortVisitRecords { get; set; }
        public int IdPatient { get; set; }
    }
}
