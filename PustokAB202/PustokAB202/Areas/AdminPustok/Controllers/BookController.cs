using Microsoft.AspNetCore.Mvc;

namespace PustokAB202.Areas.AdminPustok.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
