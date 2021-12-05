using Hospital.Models;
using Hospital.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Omu.AwesomeMvc;
using Omu.SampleData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Controllers.HospitalController
{
    public class HospitalController : Controller
    {
        private IRepository repository;
        public HospitalController(IRepository _repository)
        {
            repository = _repository;
        }

        [Authorize]
        public IActionResult MainPage(string massege)
        {
            return View(massege);
        }

        [Authorize]
        public IActionResult ShowAllPatient(string iin, string surname, int page = 1, SortState sortState = SortState.NAME_PATIENT_ASC )
        {
            int pageSize = 3;
            IQueryable<Patient> patients = repository.GetAllPatients;

            //Фильтрация
            if (iin != null)
            {
                patients = patients.Where(p => p.IIN == iin);
            }
            if (!String.IsNullOrEmpty(surname))
            {
                patients = patients.Where(p => p.Surname.ToLower().Contains(surname.ToLower()));
            }
            //сортировка
            patients = repository.SortPatients(sortState, patients);

            //пагинация

            var count = patients.Count();
            var items = patients.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            //формируем модель представления
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = new PageViewModel(count, page, pageSize),
                SortViewModel = new SortViewModel(sortState),
                FilterViewModel = new FilterViewModel(iin, surname),
                Patients = items,
                Streets = repository.GetAllStreet
            };
            return View(viewModel);
        }
        public IActionResult Details(int? id)
        {
            if (id != null)
            {
                Patient patient = repository.GetAllPatients.FirstOrDefault(p => p.Id == id);
                if (patient != null)
                {
                    return View(patient);
                }
            }
            return NotFound();
        }
        [HttpGet]
        public IActionResult ChoosePatient()
        {
            ViewBag.iin = 0;
            ViewBag.name = string.Empty;

            return View();
        }

        [HttpPost]
        public IActionResult ChoosePatient(int iin, string name)
        {
            Patient _patient;
            if (iin != 0)
            {
                _patient = repository.GetPatientByIIN(iin.ToString());
                return RedirectToAction("CartPatient", "Hospital", _patient);

            }
            if (name != null)
            {
                _patient = repository.GetPatientByFIO(name);
                return RedirectToAction("CartPatient", "Hospital", _patient);
            }
            return View();
        }
        [Authorize]
        public IActionResult EditPatient(int? id)
        {
            if (id != null)
            {
                Patient patient = repository.GetPatientByID(id);
                if (patient != null)
                {
                    return PartialView("EditPatient", new PatientWithStreets { Patient = patient, Streets = repository.GetAllStreet});
                }
            }
            return NotFound();
        }
        [Authorize]
        [HttpPost]
        public IActionResult EditPatient(Patient patient)
        {
            if (ModelState.IsValid)
            {
                repository.SavePatient(patient);
                TempData["message"] = $"Пациент: {patient.Surname} {patient.Name} был изменен";
                return RedirectToAction("ShowAllPatient");
            }
            else
            {
                return View(patient);
            }
        }
        [Authorize]
        [HttpGet]
        public IActionResult AddPatient()
        {
            return PartialView("AddPatient", new PatientWithStreets() { Streets = repository.GetAllStreet});/*для него по умолчанию не определяется мастер-страница.*/
        }
        [Authorize]
        [HttpPost]
        public IActionResult AddPatient(Patient patient)
        {
            if (ModelState.IsValid)
            {
                repository.AddPatient(patient);
                TempData["message"] = $"Пациент: {patient.Surname} {patient.Name} был добавлен";
                return RedirectToAction("MainPage", "Hospital");
            }
            else
            {
                return PartialView("AddPatient");
            }
        }
        [Authorize]
        [HttpGet]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Patient patient = repository.GetPatientByID(id);
                if (patient != null)
                {
                    return View(patient);
                }
            }
            return NotFound();
        }
        [Authorize]
        [HttpPost]
        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                Patient patient = repository.GetPatientByID(id);
                if (patient != null)
                {
                    repository.DeletePatient(patient);
                    TempData["message"] = $"Пациент: {patient.Surname} {patient.Name} был удален";
                    return RedirectToAction("MainPage");
                }
            }
            return NotFound();
        }
    }
}
