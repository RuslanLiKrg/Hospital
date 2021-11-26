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

        public IQueryable<Doctor> GetAllDoctors => hospitalDB.DoctorLists.Include(s => s.Speciality);
        public IQueryable<VisitHistory> GetAllVisitHistoriesByIdPatient(int?idPatient) => hospitalDB.VisitHistories.Include("DoctorList").Include("DiagnozList").Include("Patient").Where(i => i.PatientId == idPatient).AsQueryable<VisitHistory>();

        public IQueryable<Street> GetAllStreet => hospitalDB.Streets;

        public IQueryable<string> GetAllIIN => hospitalDB.Patients.Select(p => p.IIN);

        public IQueryable<DiagnozList> GetAllDiagnoses => hospitalDB.DiagnozLists;

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

        public void DeletePatient(Patient patient)
        {
            hospitalDB.Patients.Remove(patient);
            hospitalDB.SaveChanges();

        }

        public void AddNewRecordInVisitHistory(VisitHistory newRecordInVisitHistory)
        {
            hospitalDB.Add(newRecordInVisitHistory);
            hospitalDB.SaveChanges();
        }

        public IQueryable<Patient> SortPatients(SortState sortState, IQueryable<Patient> patients)
        {
            switch (sortState)
            {
                case SortState.NAME_PATIENT_DESC:
                    patients = patients.OrderByDescending(p => p.Surname);
                    break;
                case SortState.IIN_ASC:
                    patients = patients.OrderBy(p => p.IIN);
                    break;
                case SortState.IIN_DESC:
                    patients = patients.OrderByDescending(p => p.IIN);
                    break;
                case SortState.STREET_NAME_ASC:
                    break;
                case SortState.STREET_NAME_DESC:
                    break;
                default:
                    patients = patients.OrderBy(p => p.Surname);
                    break;
            }
            return patients;
        }

        public IQueryable<VisitHistory> SortVisitRecords(SortState sortState, IQueryable<VisitHistory> visitHistories)
        {
            switch (sortState)
            {
                case SortState.DOCTOR_NAME_ASC:
                    return visitHistories.OrderBy(d => d.DoctorList.Surname);
                case SortState.DOCTOR_NAME_DESC:
                    return visitHistories.OrderByDescending(d => d.DoctorList.Surname);
                case SortState.DATE_DESC:
                    return visitHistories.OrderByDescending(d => d.Date);
                default:
                    return visitHistories.OrderBy(d => d.Date);

            }
        }
        /// <summary>
        /// Получить запись посещения по id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public VisitHistory GetVisitRecordById(int? id)
        {
            VisitHistory visitRecord = hospitalDB.VisitHistories.Include(v => v.Patient).Include(v => v.DoctorList).Include(v =>v.DiagnozList).FirstOrDefault(v => v.Id == id);
            return visitRecord;
        }

        public void DeleteVisitRecord(int? id)
        {
            hospitalDB.VisitHistories.Remove(hospitalDB.VisitHistories.Where(c => c.Id == id).FirstOrDefault());
            hospitalDB.SaveChanges();
        }

        public void SaveVisitRecord(VisitHistory visitRecord)
        {
            hospitalDB.VisitHistories.Update(visitRecord);
            hospitalDB.SaveChanges();
        }
    }
}
