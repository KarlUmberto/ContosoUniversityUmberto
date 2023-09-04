using ContosoUniversityUmberto.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversityUmberto.Controllers
{
    public class StudentsControllers : Controller
    {
        private readonly SchoolContext _context;
        public StudentsControllers(SchoolContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Students.ToListAsync());
        }
    }
}
