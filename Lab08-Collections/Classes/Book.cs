using System;
using System.Collections.Generic;
using System.Text;
using Lab08_Collections;

namespace Lab08_Collections.Classes
{
    internal class Book
    {
        private string title;
        public string Title { get => title; set => title = value; }

        private Author author;
        public Author Author { get => author; set => author = value; }

        private int numberOfPages;
        public int NumberOfPages { get => numberOfPages; set => numberOfPages = value; }

        private Genre genre;
        public Genre Genre { get => genre; set => genre = value; }
    }
}
