using EBookStore.DTOs;
using EBookStore.Services;
using Microsoft.AspNetCore.Mvc;

namespace EBookStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public async Task<ActionResult<List<AuthorDto>>> GetAll()
        {
            return await _authorService.GetAllAuthors();
        }

        [HttpPost]
        public async Task<ActionResult<AuthorDto>> Create(AuthorDto authorDto)
        {
            var createdAuthor = await _authorService.CreateAuthor(authorDto);
            return CreatedAtAction(nameof(GetAll), createdAuthor);
        }
    }
}