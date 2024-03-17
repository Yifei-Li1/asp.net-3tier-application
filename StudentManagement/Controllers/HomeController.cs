using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentManagement.BLL;
using StudentManagement.DAL;



namespace StudentManagement.Controllers
{
    public class HomeController : Controller
    {
        private StudentService _studentService = new StudentService();

        [HttpGet]
        public ActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddStudent(Student student)
        {
            if (ModelState.IsValid)
            {
                _studentService.AddStudent(student);
                return RedirectToAction("Index"); // Assuming Index displays the list of students
            }

            return View(student);
        }
        public ActionResult Index()
        {
            var students = _studentService.GetAllStudents();
            return View(students);
        }

    }
    
    
}   