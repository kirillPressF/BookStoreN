using BookStore.Core.Models;

namespace BookStore.Core.Abstractions;

public interface IBooksRepository
{
    public Task<List<Book>> Get();
    public Task<Guid> Create(Book book);
    public Task<Guid> Update(Guid id, string title, string author, string description, decimal price);
    public Task<Guid> Delete(Guid id);
}