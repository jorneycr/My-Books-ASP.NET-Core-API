﻿using System;
using System.Collections.Generic;

namespace My_Books.Data.ViewModels
{
    public class BookVM
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Boolean IsRead { get; set; }
        public DateTime? DateRead { get; set; }
        public int? Rate { get; set; }
        public string Genre { get; set; }
        public string CoverUrl { get; set; }

        public int PublisherId { get; set; }
        public List<int> AuthorsId { get; set; }
    }

    public class BookWithAuthorsVM
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Boolean IsRead { get; set; }
        public DateTime? DateRead { get; set; }
        public int? Rate { get; set; }
        public string Genre { get; set; }
        public string CoverUrl { get; set; }

        public string PublisherNames { get; set; }
        public List<string> AuthorNames { get; set; }
    }
}
