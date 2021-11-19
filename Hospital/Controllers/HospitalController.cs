using Hospital.Models;
using Hospital.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
        public IActionResult MainPage(string massege)
        {
            return View(massege);
        }
        public IActionResult ShowAllPatient(string iin, string surname,int page = 1, SortState sortState = SortState.NAME_ASC )
        {
            int pageSize = 3;
            IQueryable<Patient> patients = repository.GetAllPatients;

            if (iin != null)
            {
                patients = patients.Where(p => p.IIN == iin);
            }
            if (!String.IsNullOrEmpty(surname))
            {
                patients = patients.Where(p => p.Surname.ToLower().Contains(surname.ToLower()));
            }
            //сортировка
            switch (sortState)
            {
                case SortState.NAME_DESC:
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

            //пагинация

            var count = patients.Count();
            var items = patients.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            //формируем модель представления
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = new PageViewModel(count, page, pageSize),
                SortViewModel = new SortViewModel(sortState),
                FilterViewModel = new FilterViewModel(iin, surname),
                Patients = items
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
        public IActionResult EditPatient(int? id)
        {
            ViewBag.AllAddressName = repository.GetAllStreet;
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

        [HttpPost]
        public IActionResult EditPatient(Patient patient)
        {
            repository.SavePatient(patient);
            return RedirectToAction("MainPage");
        }
        public IActionResult AddPatient()
        {
            ViewBag.AllAddressName = repository.GetAllStreet;
            return View();
        }
        [HttpPost]
        public IActionResult AddPatient(Patient patient)
        {
            if (ModelState.IsValid)
            {
                repository.AddPatient(patient);
                return RedirectToAction("MainPage", "Hospital", new { message = "Пациент добавлен" });

            }
            else
            {
                ViewBag.AllAddressName = repository.GetAllStreet;
                return View();
            }
        }
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
        [HttpPost]
        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                Patient patient = repository.GetPatientByID(id);
                if (patient != null)
                {
                    repository.DeletePatient(id);
                    return RedirectToAction("MainPage");
                }
            }
            return NotFound();
        }
    }
}
