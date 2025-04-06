using EBookStore.DTOs;
using EBookStore.Services;
using Microsoft.AspNetCore.Mvc;

namespace EBookStore.Controllers
{
    [ApiController]
    [Route("api/external-books")]
    public class ExternalBooksController : ControllerBase
    {
        private readonly ExternalBookService _externalBookService;

        public ExternalBooksController(ExternalBookService externalBookService)
        {
            _externalBookService = externalBookService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ExternalBookDto>>> Search([FromQuery] string query)
        {
            return await _externalBookService.SearchBooks(query);
        }
    }
}