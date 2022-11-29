using ELibrary.Application.Abstractions.EntityServices;
using ELibrary.Application.Extensions;
using ELibrary.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ELibrary.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        readonly IEntityService _entityService;

        public BooksController(IEntityService entityService)
        {
            _entityService = entityService;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var books = await _entityService.Lister.GetListAsync<Book>();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var book = await _entityService.Getter.GetAsync<Book>(x => x.Id == id);
            if (book == null)
                return NotFound();
            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Book book)
        {
            var createdBook = await _entityService.Creator.CreateAsync(book);
            await _entityService.Saver.SaveAsync();
            return Created("", createdBook);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Book book)
        {
            var updateBook = await _entityService.Getter.GetAsync<Book>(x => x.Id == book.Id, options => options.DisableTracking());
            if (updateBook == null)
                return NotFound();
            updateBook.Name = book.Name;
            _entityService.Updater.Update(updateBook);
            await _entityService.Saver.SaveAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleteBook = await _entityService.Getter.GetAsync<Book>(x => x.Id == id, options => options.DisableTracking());
            if (deleteBook == null)
                return NotFound();
            _entityService.Deleter.Delete(deleteBook);
            await _entityService.Saver.SaveAsync();
            return NoContent();
        }
    }
}
