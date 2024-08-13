using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPortal.web.Data;
using StudentPortal.web.Models;
using StudentPortal.web.Models.Entities;

namespace StudentPortal.web.Controllers
{
    public class StudentsController : Controller
    {
        public readonly ApplicationDbContext DbContext;
        public StudentsController(ApplicationDbContext dbContext)
        {
            this.DbContext = dbContext;
        }

        

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult>  Add(AddStudentViewModel viewModel)
        {
            var student = new Student
            {
                Name = viewModel.Name,
                Email = viewModel.Email,
                Phone = viewModel.Phone,
                Subscribed = viewModel.Subscribed,
            };

            await DbContext.students.AddAsync(student);
            await DbContext.SaveChangesAsync();
            //return View();
            return RedirectToAction("List");

        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var student = await DbContext.students.ToListAsync();
            return View(student);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var student = await DbContext.students.FindAsync(id);
            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Student viewmodel)
        {
            var student = await DbContext.students.FindAsync(viewmodel.Id);
            if (student is not null)
            {
                student.Name = viewmodel.Name;
                student.Email = viewmodel.Email;
                student.Phone = viewmodel.Phone;
                student.Subscribed = viewmodel.Subscribed;

                await DbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Students");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Student viewModel)
        {
            var student = await DbContext.students.Where(a => a.Id == viewModel.Id).FirstOrDefaultAsync();
            if (student is not null)
            {
                 DbContext.students.Remove(student);
                await DbContext.SaveChangesAsync();
            }

            return RedirectToAction("List", "Students");
        }
    }
}
