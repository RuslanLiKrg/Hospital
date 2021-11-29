using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class StudentController : Controller
    {
        public StudentController()
        {

        }
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddStudent()
        {
            return View();
        }
        public ActionResult EditStudent()
        {
            return View();
        }

        public ActionResult DeleteStudent()
        {
            return RedirectToAction("Index");
        }
    }
}