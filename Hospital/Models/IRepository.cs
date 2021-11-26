using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public interface IRepository
    {
        public IQueryable<Patient> GetAllPatients { get; }
        public IQueryable<Doctor> GetAllDoctors { get; }
        public IQueryable<DiagnozList> GetAllDiagnoses { get; }
        public IQueryable<VisitHistory> GetAllVisitHistoriesByIdPatient(int? idPatient);
        public VisitHistory GetVisitRecordById(int?id);
        public void DeleteVisitRecord(int?id);
        public IQueryable<string> GetAllIIN { get; }
        public void AddPatient(Patient patient);
        public void AddNewRecordInVisitHistory(VisitHistory newRecordInVisitHistory);
        public IQueryable<Street> GetAllStreet { get; }
        public Patient GetPatientByIIN(string iin);
        public Patient GetPatientByID(int? id);
        public Patient GetPatientByFIO(string name);
        public void SavePatient(Patient patient);
        public void SaveVisitRecord(VisitHistory visitRecord);
        public void DeletePatient(Patient patient);
        public IQueryable<Patient> SortPatients(SortState sortState, IQueryable<Patient> patients);
        public IQueryable<VisitHistory> SortVisitRecords(SortState sortState, IQueryable<VisitHistory> visitHistories);



    }
}
