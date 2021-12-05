using Hospital.Models;
using Hospital.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.Controllers
{
    public class VisitHistoryController : Controller
    {
        private readonly IRepository repository;
        public int countItemOnOnePage = 4;
        public VisitHistoryController(IRepository _repository)
        {
            repository = _repository;
        }
        [Authorize]
        public ViewResult ShowAllVisitHistoryByIdPatient(int idPatient, int numberPage = 1, SortState sortState = SortState.DATE_ASC)
        {
            //сортировка
            IQueryable<VisitHistory> visitHistories = repository.SortVisitRecords(sortState, repository.GetAllVisitHistoriesByIdPatient(idPatient));

            //пагинация
            var items = visitHistories.Skip((numberPage - 1) * countItemOnOnePage).Take(countItemOnOnePage);

            //формируем модель представления
            VisitsHistoryPatientViewModel viewModel = new VisitsHistoryPatientViewModel
            {
                VisitHistories = items,
                PagingInfo = new PageInfoVisitHistoryViewModel { CurrentPage = numberPage, ItemsPerPage = countItemOnOnePage, TotalItems = repository.GetAllVisitHistoriesByIdPatient(idPatient).Count() },
                IdPatient = idPatient,
                SortVisitRecords = new SortVisitRecordsViewModel(sortState)
            };
            return View(viewModel);

        }
        [Authorize]
        public IActionResult AddVisitHistoryById(int idPatient)
        {
            ViewBag.idPatient = idPatient;
            ViewBag.Doctors = repository.GetAllDoctors;
            ViewBag.Diagnoses = repository.GetAllDiagnoses;
            VisitRecordfForEditViewModel viewModel = new VisitRecordfForEditViewModel() { VisitRecord = new VisitHistory(),  DiagnozLists = repository.GetAllDiagnoses, Doctors = repository.GetAllDoctors, IdPatient = idPatient };
            return View(viewModel);
        }
        [Authorize]
        [HttpPost]
        public IActionResult AddVisitHistoryById(VisitRecordfForEditViewModel newRecordInVisitHistory)
        {
            if (ModelState.IsValid)
            {
                repository.AddNewRecordInVisitHistory(newRecordInVisitHistory.VisitRecord);
                TempData["message"] = $"Новая запись о пациенте  добавлена";
                return RedirectToAction("MainPage", "Hospital");
            }
            else
            {
                //newRecordInVisitHistory = new VisitRecordfForEditViewModel() { VisitRecord = new VisitHistory(), DiagnozLists = repository.GetAllDiagnoses, Doctors = repository.GetAllDoctors, IdPatient = idPatient };
                return View(newRecordInVisitHistory);
            }
        }
        [Authorize]
        [HttpGet]
        [ActionName("Delete")]
        public IActionResult ConfirnDelete(int? id)
        {
            if (id != null)
            {
                VisitHistory visirRecord = repository.GetVisitRecordById(id);
                if (visirRecord != null)
                {
                    return View(visirRecord);
                }
            }
            return NotFound();
        }
        [Authorize]
        [HttpPost]
        public IActionResult Delete(int?id)
        {
            repository.DeleteVisitRecord(id);
            TempData["message"] = $"Запись посещения была удалена";
            return RedirectToAction("MainPage", "Hospital");
        }
        [Authorize]
        public IActionResult EditVisitRecord(int? id)
        {
            if (id != null)
            {
                VisitHistory visitRecord = repository.GetVisitRecordById(id);
                if (visitRecord != null)
                {
                    VisitRecordfForEditViewModel viewModel = new VisitRecordfForEditViewModel(visitRecord, repository.GetAllDiagnoses, repository.GetAllDoctors, 0);                   
                    return View(viewModel);
                }
            }
            return NotFound();
        }
        [Authorize]
        [HttpPost]
        public IActionResult EditVisitRecord(VisitHistory visitRecord)
        {
            if (ModelState.IsValid)
            {
                repository.SaveVisitRecord(visitRecord);
                TempData["message"] = $"Запись под ID: {visitRecord.Id} дата: {visitRecord.Date} была изменена";
                return RedirectToAction("MainPage", "Hospital");
            }
            else
            {
                VisitRecordfForEditViewModel viewModel = new VisitRecordfForEditViewModel(visitRecord, repository.GetAllDiagnoses, repository.GetAllDoctors, 0);
                return View(viewModel);

            }
        }
    }
}
