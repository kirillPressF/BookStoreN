using System.Diagnostics;
using BookStore.API.Response;
using BookStore.API.Request;
using BookStore.Application.Services;
using BookStore.Core.Abstractions;
using BookStore.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService _booksServices;

        public BooksController(IBooksService booksServices)
        {
            _booksServices = booksServices;
        }

        [HttpGet]
        public async Task<ActionResult<List<BooksResponse>>> GetBook()
        {
            var books = await _booksServices.GetAllBooks();
            var response = books.Select(b => new BooksResponse(b.Id, b.Title, b.Author, b.Description, b.Price));
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateBook([FromBody] BooksRequest request)
        {
            var (book, error) = Book.Create(
                Guid.NewGuid(),
                request.Title,
                request.Author,
                request.Description,
                request.Price);
            if (!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }

            await _booksServices.CreateBook(book);
            return Ok(book.Id);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateBook(Guid id, [FromBody] BooksRequest request)
        {
            var bookId = await _booksServices.UpdateBook(id, request.Title, request.Author, request.Description,
                request.Price);
            return Ok(bookId);
        }
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteBook(Guid id)
        {
            var bookId = await _booksServices.DeleteBook(id);
            return Ok(bookId);
        }
    }
}
