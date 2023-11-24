using PustokAB202.Models;

namespace PustokAB202.Areas.AdminPustok.ViewModels.Book
{
    public class BookCreateVM
    {

      
        public string Name { get; set; }
        public string Author { get; set; }  
        public string Genre { get; set; }
        public string Page { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SalePrice { get; set; }
        public int Discount { get; set; }
        public string Desc { get; set; }


    }
}
