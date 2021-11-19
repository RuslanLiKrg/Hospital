using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    /// <summary>
    /// Данный класс представляет контроллер
    /// </summary>
    public class HomeController : Controller
    {
        PhoneContext phoneContext = new PhoneContext();//база данных
        PatientContext patientContext = new PatientContext();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            ViewBag.Id = 0;

            IEnumerable<Phone> phones = phoneContext.Phones;//извлекаем данные из таблицы Phones, к-ми мы ранее заполнили таблицу
            ViewBag.Phones = phones;//динамический объект. в Динамическом объекте можно создаватть любые сввойства . С помощью динамического объекта можно предавать инфо.из метода в представление
            return View();//ищет представление соответст. текущему методу т.е. Index() в папке Views -> Home -> Index.cshtml
        }

        [HttpGet]
        public ActionResult InputInfoPatient(int? id)
        {
            ViewBag.Id = id;
            return View();
        }
        [HttpPost]
        public string InputInfoPatient(Patient newPatient)
        {
            return "Hello";
        }

        [HttpGet]
        public ActionResult Create(int? id)
        {
            ViewBag.Id = id;
            return View();
        }

        [HttpPost]
        public string Create(Phone newPhone)
        {
            phoneContext.Phones.Add(newPhone);
            phoneContext.SaveChanges();
            return $"Модель телефона {newPhone.Name} сохранена";
        }
        [HttpGet] //данный метод контролера будет срабатывать при Get запросе на контролер. Обращение через ссылку или адресую строку

        public ActionResult Buy(int id)//занести эту покупку в таблицу Purchases
        {
            ViewBag.Id = id;
            return View();//Вернет представление для  заполенния ФИО, адреса и т.д.
        }
        [HttpPost]//Будет сраабатывать при Пост запросе
        public string Buy(Purchase purchase)
        {
            purchase.DateTime_ = GetTodayDate();
            phoneContext.Purchases.Add(purchase);
            phoneContext.SaveChanges();//сохранение измений
            return $"Уважаемый {purchase.FIO}, с Вами скоро свяжутся";
        }

        [HttpGet]
        public ActionResult ShowList()
        {
            IEnumerable<Purchase> purchases = phoneContext.Purchases;//извлекаем данные из таблицы  Purchases
            ViewBag.Purchases = purchases;
            return View();
        }

        private DateTime GetTodayDate()
        {
            return DateTime.Now;
        }

        [HttpGet]
        public ActionResult SomeMethod()
        {
            ViewData["Date"] = DateTime.Now;
            return View("/Views/Home/MyView.cshtml");
        }

        [HttpGet]
        public ActionResult SomeView()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ListBooks()
        {
            return View(phoneContext.Phones);
        }




    }
}