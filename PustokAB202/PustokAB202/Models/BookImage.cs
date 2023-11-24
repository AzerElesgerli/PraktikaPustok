﻿namespace PustokAB202.Models
{
    public class BookImage
    {

        public int Id { get; set; }

        public string Image { get; set; }

        public bool? IsPrimary { get; set; }

        public int BookId { get; set; }

        public Book Book { get; set; }

        public List<BookImage> BookImages { get; set; }
    }
}