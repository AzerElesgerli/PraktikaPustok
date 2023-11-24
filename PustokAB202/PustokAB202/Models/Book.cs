namespace PustokAB202.Models
{
    public class Book
    {


        public int Id { get; set; }
        public string Name { get; set; }

        public int AuthorId { get; set; }

        public Author Author { get; set; }

        public int GenreId { get; set; }

        public Genre Genre { get; set; }

        public string Page { get; set; }

        public bool IsAvialable { get; set; }

        public decimal CostPrice { get; set; }

        public decimal SalePrice { get; set; }

        public int Discount { get; set; }

        public string Desc { get; set; }  



    }
}
