using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcStudentApp.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;

namespace MvcStudentApp.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly UniversityContext db;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, UniversityContext context)
        {
            _logger = logger;
            db = context;
        }

        public IActionResult Index()
        {
            var allStudents = db.Students.Include(s => s.Lesson).ToList();
            ViewBag.Students = allStudents;
            return View();
        }

        private void GiveStudents()
        {
            var allStudents = db.Students.Include(s => s.Lesson).ToList();
            ViewBag.Students = allStudents;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Authorize]
        [HttpGet]
        public ActionResult CreateStudent()
        {
            GiveStudents();
            var allStudent = db.Students.ToList<Student>();
            ViewBag.Students = allStudent;
            return View();
        }

        [HttpPost]
        public string CreateStudent(Student newStudent)
        {
            db.Students.Add(newStudent);
            db.SaveChanges();
            return "Студент" + newStudent.FirstName + " " + newStudent.LastName + "добавлен в ведомость.";
        }
    }
}
