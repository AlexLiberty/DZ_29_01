using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_29_01
{
    internal class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int PageCount { get; set; }
        public override string ToString()
        {
            return $"Id - {Title}, Name - {Title}, Author - {Author}, PageCount - {PageCount}";
        }
        public static Book[] Data() => new Book[]
        {
            new Book{Title="Book1", Author="Author1", PageCount=100},
            new Book{Title="Book2", Author="Author2", PageCount=200},
            new Book{Title="Book3", Author="Author3", PageCount=300},
            new Book{Title="Book4", Author="Author4", PageCount=400},
            new Book{Title="Book5", Author="Author5", PageCount=500},
        };
    }
}
