using Microsoft.AspNetCore.Mvc;

namespace ContosoUniversityUmberto.Controllers
{
    public class InstructorsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
