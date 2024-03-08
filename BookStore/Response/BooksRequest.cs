namespace BookStore.API.Request;

public record BooksRequest(
    string Title,
    string Author,
    string Description,
    decimal Price);