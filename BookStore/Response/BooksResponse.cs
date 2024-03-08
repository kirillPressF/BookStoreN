namespace BookStore.API.Response
{
    public record BooksResponse(
        Guid Id,
        string Title,
        string Author,
        string Description,
        decimal Price);
}
