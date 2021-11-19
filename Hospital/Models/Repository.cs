using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public class Repository : IRepository
    {
        private readonly HospitalDBContext hospitalDB;
        public Repository(HospitalDBContext _hospitalDB)
        {
            hospitalDB = _hospitalDB;
        }
        public IQueryable<Patient> GetAllPatients =>  hospitalDB.Patients.Include(a => a.Street); 


        public IQueryable<VisitHistory> VisitHistories => hospitalDB.VisitHistories.Include("Patient").Include("DoctorList").Include("DiagnozList");

        public IQueryable<Street> GetAllStreet => hospitalDB.Streets;

        public IQueryable<string> GetAllIIN => hospitalDB.Patients.Select(p => p.IIN);

        public Patient GetPatientByIIN(string iin)
        {
            return hospitalDB.Patients.Include(a => a.Street).FirstOrDefault(i => i.IIN  == iin);             
        }
        public void AddPatient(Patient patient)
        {
            hospitalDB.Patients.Add(patient);
            hospitalDB.SaveChanges();
        }


        public Patient GetPatientByFIO(string name)
        {
            return hospitalDB.Patients.Include(a => a.Street).FirstOrDefault(f => (f.Name + " " + f.Surname + " " + f.Patronymic) == name);
        }

        public Patient GetPatientByID(int? id)
        {
            return hospitalDB.Patients.Include(a => a.Street).FirstOrDefault(p => p.Id == id);
        }
        public void SavePatient(Patient patient)
        {
            hospitalDB.Patients.Update(patient);
            hospitalDB.SaveChanges();

        }

        public void DeletePatient(int? id)
        {
            hospitalDB.Patients.Remove(hospitalDB.Patients.FirstOrDefault(p =>p.Id == id));
            hospitalDB.SaveChanges();

        }

    }
}
