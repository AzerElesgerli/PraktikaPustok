﻿using PustokAB202.Models;

namespace PustokAB202.Areas.AdminPustok.ViewModels.Book
{
    public class BookCreateVM
    {


        public string Name { get; set; }

        public string Desc { get; set; }

        public int Page { get; set; }


        public decimal CostPrice { get; set; }

        public decimal SalePrice { get; set; }

        public decimal Discount { get; set; }


        public int AuthorId { get; set; }


        public int GenreId { get; set; }

        public List<Author>? Authors { get; set; }
        public List<Genre>? Genres { get; set; }

    }
}
