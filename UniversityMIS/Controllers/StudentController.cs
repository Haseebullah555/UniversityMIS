using Microsoft.AspNetCore.Mvc;
using UniversityMIS.database;
using UniversityMIS.Models;

namespace UniversityMIS.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDbContext _context;

        public StudentController(AppDbContext dbContext)
        {
            _context = dbContext;
        }
        public ActionResult Index()
        {
            var students = _context.Students.ToList();
            return View(students);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student Student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Add(Student);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return BadRequest();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var Student = _context.Students.Find(id);
            return View(Student);
        }
        [HttpPost]
        public IActionResult Edit(Student Student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Update(Student);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return BadRequest();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var Student = _context.Students.Find(id);
            if (Student == null)
            {
                return NotFound();
            }

            _context.Students.Remove(Student);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

    }
}
