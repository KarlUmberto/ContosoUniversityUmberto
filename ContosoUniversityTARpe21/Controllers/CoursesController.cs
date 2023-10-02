using ContosoUniversityTARpe21.Data;
using ContosoUniversityTARpe21.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversityTARpe21.Controllers
{
    public class CoursesController : Controller
    {
        private readonly SchoolContext _context;
        public CoursesController(SchoolContext context)
        {
            _context = context;
        }

        //get index
        public async Task<IActionResult> Index()
        {
            var schoolContext = _context.Courses.Include(d => d.Department);
            return View(await schoolContext.ToListAsync());
        }
        //get details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var course = await _context.Courses
                .Include(d => d.Department)
                .FirstOrDefaultAsync(m => m.CourseID == id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        //get create
        public IActionResult Create()
        {
            ViewData["DepartmentID"] = new SelectList(_context.Departments, "DepartmentID", "Name");
            return View();
        }

        //post create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CourseID,Title,Credits,DepartmentID,")] Course course)
        {
            ModelState.Remove("CourseAssignments");
            ModelState.Remove("Department");
            ModelState.Remove("Enrollments");
            if (ModelState.IsValid)
            {
                _context.Add(course);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["DepartmentID"] = new SelectList(_context.Departments, "DepartmentID", "Name", course.DepartmentID);
            return View(course);
        }

        //get edit
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            ViewData["DepartmentID"] = new SelectList(_context.Departments, "DepartmentID", "Name", course.DepartmentID);
            return View(course);
        }

        //post edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CourseID,Title,Credits,DepartmentID")]Course course)
        {
            ModelState.Remove("CourseAssignments");
            ModelState.Remove("Department");
            ModelState.Remove("Enrollments");
            if (id != course.CourseID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(course);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {

                    if (!CourseExists(course.CourseID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentID"] = new SelectList(_context.Departments, "DepartmentID", "Name", course.DepartmentID);
            return View(course);
        }

        //get delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                .Include(d => d.Department)
                .FirstOrDefaultAsync(m => m.CourseID == id);

            if (course == null)
            {
                
                return NotFound();
            }
            return View(course);
        }

        //post delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course != null)
            {
                _context.Courses.Remove(course);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool CourseExists(int id)
        {
            return (_context.Courses?.Any(e => e.CourseID == id)).GetValueOrDefault();
        }
    }
}
