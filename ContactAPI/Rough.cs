﻿namespace BookService.Models 
{ 
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
    }
}

namespace BootService.Models
{
    public class BookDetailsDto
    {
    public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get;set; }
        public decimal Price { get; set; }
        public string AuthorName { get; set; }
        public string Genre { get; set; }
    }
}
