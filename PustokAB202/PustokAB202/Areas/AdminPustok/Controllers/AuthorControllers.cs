using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PustokAB202.DAL;
using PustokAB202.Models;
using System.ComponentModel;

namespace PustokAB202.Areas.AdminPustok.Controllers
{
    public class AuthorControllers : Controller
    {
        private AppDbContext _context;

        public AuthorControllers(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            Book existed = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);


            if (existed is null) {

                return NotFound();
            }
            _context.Books.Remove(existed);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));


        }
    }
}