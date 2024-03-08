using BookStore.Core.Models;

namespace BookStore.Core.Abstractions;

public interface IBooksService
{
    public Task<List<Book>> GetAllBooks();
    public Task<Guid> CreateBook(Book book);
    public Task<Guid> UpdateBook(Guid id, string title, string author, string description, decimal price);
    public Task<Guid> DeleteBook(Guid id);
}