using Microsoft.AspNetCore.Mvc;
using EBookStore.Models;
using EBookStore.DTOs;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using EBookStore.Data;

namespace EBookStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public AuthorsController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<Author>> CreateAuthor(AuthorDto authorDto)
        {
            var author = _mapper.Map<Author>(authorDto);
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();
            return Ok(author);
        }

        [HttpGet]
        public async Task<ActionResult<List<Author>>> GetAllAuthors()
        {
            var authors = await _context.Authors.ToListAsync();
            return authors;
        }
    }
}