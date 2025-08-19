using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UniversityMIS.database;
using UniversityMIS.Models;

namespace UniversityMIS.Controllers
{
    public class MarkController : Controller
    {
        private readonly AppDbContext _context;

        public MarkController(AppDbContext dbContext)
        {
            _context = dbContext;
        }
        public ActionResult Index()
        {
            var marks = _context.Marks
            .Include(s => s.Student)
            .Include(s => s.Subject)
            .Include(s => s.Semester)
            .ToList();
            return View(marks);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Semesters = new SelectList(_context.Semesters.ToList(), "Id", "SemesterName");
            ViewBag.Subjects = new SelectList(_context.Subjects.ToList(), "Id", "SubjectName");
            ViewBag.Students = new SelectList(_context.Students.ToList(), "Id", "FirstName");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Marks Marks)
        {
            if (ModelState.IsValid)
            {
                _context.Marks.Add(Marks);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Marks);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var Marks = _context.Marks.Find(id);
            ViewBag.Semesters = new SelectList(_context.Semesters.ToList(), "Id", "SemesterName");
            ViewBag.Subjects = new SelectList(_context.Subjects.ToList(), "Id", "SubjectName");
            ViewBag.Students = new SelectList(_context.Students.ToList(), "Id", "FirstName");
            return View(Marks);
        }
        [HttpPost]
        public IActionResult Edit(Marks Marks)
        {
            if (ModelState.IsValid)
            {
                _context.Marks.Update(Marks);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return BadRequest();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var Mark = _context.Marks.Find(id);
            if (Mark == null)
            {
                return NotFound();
            }

            _context.Marks.Remove(Mark);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

    }
}
