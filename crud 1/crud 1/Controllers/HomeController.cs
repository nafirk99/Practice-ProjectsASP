using crud_1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace crud_1.Controllers
{
    public class HomeController : Controller
    {
        private SchoolContext _schoolContext;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, SchoolContext schoolContext)
        {
            _logger = logger;
            _schoolContext = schoolContext;
        }

        public IActionResult Index()
        {

            return View(_schoolContext.Teachers);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                _schoolContext.Teachers.Add(teacher);
                _schoolContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return View();
        }

        public IActionResult Update(int id)
        {
            return View(_schoolContext.Teachers.Where(a => a.Id == id).FirstOrDefault());
        }

        [HttpPost]
        public IActionResult Update(Teacher teacher)
        {
            _schoolContext.Teachers.Update(teacher);
            _schoolContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete (int id)
        {
            var teacher = _schoolContext.Teachers.Where(a => a.Id == id).FirstOrDefault();
            _schoolContext.Teachers.Remove(teacher);
            _schoolContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
