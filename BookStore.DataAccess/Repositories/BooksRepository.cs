using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using BookStore.Core.Abstractions;
using BookStore.Core.Models;
using BookStore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.DataAccess.Repositories
{
    public class BooksRepository : IBooksRepository
    {
        private readonly BookStoreDbContext _context;
        public BooksRepository(BookStoreDbContext context)
        {
            _context = context;
        }

        public async Task<List<Book>> Get()
        {
            var bookEntities =  await _context.Books
                .AsNoTracking()
                .ToListAsync();
            var books = bookEntities
                .Select(b => Book.Create(b.Id, b.Title, b.Author, b.Description, b.Price).Book)
                .ToList();
            return books;
        }

        public async Task<Guid> Create(Book book)
        {
            var bookEntity = new BookEntity
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Description = book.Description,
                Price = book.Price,
            };
            await _context.AddAsync(bookEntity);
            await _context.SaveChangesAsync();
            return book.Id;
        }

        public async Task<Guid> Update(Guid id, string title, string author, string description, decimal price)
        {
            await _context.Books
                .Where(x => x.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(x => x.Title, x => title)
                    .SetProperty(x => x.Author, x => author)
                    .SetProperty(x => x.Description, x => description)
                    .SetProperty(x => x.Price, x => price)
                );
            return id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.Books.Where(x => x.Id == id)
                .ExecuteDeleteAsync();
            return id;
        }
    }
}
