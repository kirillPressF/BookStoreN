using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core.Models
{
    public class Book
    {
        public const int MAX_TITLE_LENGTH = 250;
        public Guid Id { get; }
        public string Title { get; } = string.Empty;
        public string Author { get; } = string.Empty;
        public string Description { get; } = string.Empty;
        public decimal Price { get; }

        private Book(Guid id, string title, string author, string description, decimal price)
        {
            Id = id;
            Title = title;
            Description = description;
            Author = author;
            Price = price;
        }

        public static (Book Book, string Error) Create(Guid id, string title, string author, string description, decimal price)
        {
            var error = string.Empty;

            if (string.IsNullOrEmpty(title) || title.Length > MAX_TITLE_LENGTH)
            {
                error = "title can not be empty or longer then 250 symbols";
            }

            var book = new Book(id, title, author, description, price);
            return (book, error);
        }
    }
}
