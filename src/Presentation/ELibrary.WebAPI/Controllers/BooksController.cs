using ELibrary.Application.Abstractions.Services.EntityFramework;
using ELibrary.Application.Extensions;
using ELibrary.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ELibrary.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        readonly IEfService _efService;

        public BooksController(IEfService efService)
        {
            _efService = efService;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var books = await _efService.Lister.GetListAsync<Book>();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var book = await _efService.Getter.GetAsync<Book>(x => x.Id == id);
            if (book == null)
                return NotFound();
            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Book book)
        {
            var createdBook = await _efService.Creator.CreateAsync(book);
            await _efService.Saver.SaveAsync();
            return Created("", createdBook);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Book book)
        {
            var updateBook = await _efService.Getter.GetAsync<Book>(x => x.Id == book.Id, options => options.DisableTracking());
            if (updateBook == null)
                return NotFound();
            updateBook.Name = book.Name;
            _efService.Updater.Update(updateBook);
            await _efService.Saver.SaveAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleteBook = await _efService.Getter.GetAsync<Book>(x => x.Id == id, options => options.DisableTracking());
            if (deleteBook == null)
                return NotFound();
            _efService.Deleter.Delete(deleteBook);
            await _efService.Saver.SaveAsync();
            return NoContent();
        }
    }
}
