using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task.Data;
using Task.Models;

namespace Task.Controllers
{
    public class StudentController : Controller
    {
        private readonly DataContext _db;

        public StudentController(DataContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            var students = await _db.Student.Include(c => c.Class).ToListAsync();
            return View(students);
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.Class = await _db.Class.ToListAsync();

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Student student)
        {
            if(ModelState.IsValid)
            {
                student.Id = new Guid();
                student.CreatedDate = DateTime.Now;
                student.ModificationDate = null;
                _db.Student.Add(student);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var student = await _db.Student.Include(c => c.Class)
                                           .FirstOrDefaultAsync(s => s.Id == id);

            return View(student);
        }
        
        public async Task<IActionResult> Edit(Guid id)
        {
            ViewBag.Class = await _db.Class.ToListAsync();
            var student = await _db.Student.Include(c => c.Class)
                                           .FirstOrDefaultAsync(s => s.Id == id);

            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                student.ModificationDate = DateTime.Now;
                var entity = _db.Student.Update(student);
                entity.Property(p => p.CreatedDate).IsModified = false;
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var student = await _db.Student.Include(c => c.Class)
                                           .FirstOrDefaultAsync(s => s.Id == id);

            return View(student);
        }

        public async Task<IActionResult> Remove(Guid id)
        {
            var student = await _db.Student.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            _db.Student.Remove(student);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
