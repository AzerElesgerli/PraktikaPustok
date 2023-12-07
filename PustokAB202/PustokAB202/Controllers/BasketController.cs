
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PustokAB202.DAL;
using PustokAB202.Models;
using PustokAB202.ViewModels;

namespace PustokAB202.Controllers
{
    public class BasketController : Controller
    {
      

        private readonly AppDbContext _context;
        
        public BasketController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<BasketVM> basketVM = new();
            if (Request.Cookies["Basket"] is not null)
            {
                List<BasketItemsVM> basket = JsonConvert.DeserializeObject<List<BasketItemsVM>>(Request.Cookies["Basket"]);

                foreach (BasketItemsVM basketCookieItem in basket)
                {
                    Book book = await _context.Books.Include(p => p.BookImages.Where(pi => pi.IsPrimary == true)).FirstOrDefaultAsync(p => p.Id == basketCookieItem.Id);

                    if (book is not null)
                    {
                        BasketVM basketItemVM = new()
                        {
                            Id = book.Id,
                            Name = book.Name, 
                            Price = book.SalePrice,
                            Count = basketCookieItem.Count,
                            SubTotal = book.CostPrice * basketCookieItem.Count,
                        };
                        basketVM.Add(basketItemVM);

                    }
                }
            }
            return View(basketVM);
        }

        public async Task<IActionResult> AddBasket(int id, string controllerName)
        {
            if (id <= 0) return BadRequest();
            Book book = await _context.Books.FirstOrDefaultAsync(p => p.Id == id);
            if (book is null) return NotFound();
            List<BasketItemsVM> basket;
            if (Request.Cookies["Basket"] is not null)
            {
                basket = JsonConvert.DeserializeObject<List<BasketItemsVM>>(Request.Cookies["Basket"]);
                var item = basket.FirstOrDefault(b => b.Id == id);
                if (item is null)
                {
                    BasketItemsVM itemVm = new BasketItemsVM
                    {
                        Id = id,
                        Count = 1
                    };
                    basket.Add(itemVm);
                }
                else
                {
                    item.Count++;
                }
            }
            else
            {
                basket = new();
                BasketItemsVM itemVm = new BasketItemsVM
                {
                    Id = id,
                    Count = 1
                };
                basket.Add(itemVm);
            }

            string json = JsonConvert.SerializeObject(basket);
            Response.Cookies.Append("Basket", json);

            return RedirectToAction(nameof(Index), controllerName);
        }

        public async Task<IActionResult> RemoveBasket(int id)
        {
            if (id <= 0) return BadRequest();
            Book book = await _context.Books.FirstOrDefaultAsync(p => p.Id == id);
            if (book is null) return NotFound();
            List<BasketItemsVM> basket;
            if (Request.Cookies["Basket"] is not null)
            {
                basket = JsonConvert.DeserializeObject<List<BasketItemsVM>>(Request.Cookies["Basket"]);
                var item = basket.FirstOrDefault(b => b.Id == id);
                if (item is not null)
                {
                    basket.Remove(item);

                    string json = JsonConvert.SerializeObject(basket);
                    Response.Cookies.Append("Basket", json);
                }
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Decrement(int id)
        {
            if (id <= 0) return BadRequest();
            Book book = await _context.Books.FirstOrDefaultAsync(p => p.Id == id);
            if (book is null) return NotFound();
            List<BasketItemsVM> basket;
            if (Request.Cookies["Basket"] is not null)
            {
                basket = JsonConvert.DeserializeObject<List<BasketItemsVM>>(Request.Cookies["Basket"]);
                var item = basket.FirstOrDefault(b => b.Id == id);
                if (item is not null)
                {
                    item.Count--;
                    if (item.Count == 0)
                    {
                        basket.Remove(item);
                    }
                    string json = JsonConvert.SerializeObject(basket);
                    Response.Cookies.Append("Basket", json);
                }
            }
            return RedirectToAction(nameof(Index));
        }
    }
}