using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UniversityMIS.database;
using UniversityMIS.Models;

namespace UniversityMIS.Controllers
{
    public class SubjectController : Controller
    {
        private readonly AppDbContext _context;

        public SubjectController(AppDbContext dbContext)
        {
            _context = dbContext;
        }
        public ActionResult Index()
        {
             var subjects = _context.Subjects
                .Include(s => s.Semester) // Eager load Semester
                .ToList();
            return View(subjects);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Semester = new SelectList(_context.Semesters.ToList(), "Id", "SemesterName");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Subject Subject)
        {
            if (ModelState.IsValid)
            {
                _context.Subjects.Add(Subject);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return BadRequest();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var Subject = _context.Subjects.Find(id);
            ViewBag.Semester = new SelectList(_context.Semesters.ToList(), "Id", "SemesterName");
            return View(Subject);
        }
        [HttpPost]
        public IActionResult Edit(Subject Subject)
        {
            if (ModelState.IsValid)
            {
                _context.Subjects.Update(Subject);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return BadRequest();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var Subject = _context.Subjects.Find(id);
            if (Subject == null)
            {
                return NotFound();
            }

            _context.Subjects.Remove(Subject);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

    }
}
