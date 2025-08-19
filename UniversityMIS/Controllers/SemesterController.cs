using Microsoft.AspNetCore.Mvc;
using UniversityMIS.database;
using UniversityMIS.Models;

namespace UniversityMIS.Controllers
{
    public class SemesterController : Controller
    {
        private readonly AppDbContext _context;

        public SemesterController(AppDbContext dbContext)
        {
            _context = dbContext;
        }
        public IActionResult Index()
        {
            var semesters = _context.Semesters.ToList();
            return View(semesters);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Semester semester)
        {
            if (ModelState.IsValid)
            {
                _context.Semesters.Add(semester);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return BadRequest();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var semester = _context.Semesters.Find(id);
            return View(semester);
        }
        [HttpPost]
        public IActionResult Edit(Semester semester)
        {
            if (ModelState.IsValid)
            {
                _context.Semesters.Update(semester);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return BadRequest();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var semester = _context.Semesters.Find(id);
            if (semester == null)
            {
                return NotFound();
            }

            _context.Semesters.Remove(semester);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

    }
}
