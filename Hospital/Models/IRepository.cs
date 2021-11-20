using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public interface IRepository
    {
        public IQueryable<Patient> GetAllPatients { get; }
        public IQueryable<VisitHistory> VisitHistories { get; }
        public IQueryable<string> GetAllIIN { get; }
        public void AddPatient(Patient patient);
        public IQueryable<Street> GetAllStreet { get; }
        public Patient GetPatientByIIN(string iin);
        public Patient GetPatientByID(int? id);
        public Patient GetPatientByFIO(string name);
        public void SavePatient(Patient patient);
        public void DeletePatient(Patient patient);



    }
}
