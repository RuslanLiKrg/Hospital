using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public enum SortState
    {
       NAME_PATIENT_ASC,
       NAME_PATIENT_DESC,
       IIN_ASC,
       IIN_DESC,
       STREET_NAME_ASC,
       STREET_NAME_DESC,
       DOCTOR_NAME_ASC,
       DOCTOR_NAME_DESC,
       DATE_ASC,
       DATE_DESC
    }
}
