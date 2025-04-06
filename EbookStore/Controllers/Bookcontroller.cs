using Microsoft.EntityFrameworkCore;
using EBookStore.Data;
using EBookStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using EBookStore.Controllers;

namespace EBookStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public BooksController(AppDbContext context, IMapper mapper)  // Uppdatera konstruktorn
        {
            _context = context;
            _mapper = mapper;  // Tilldela mapper
        }

        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetAll()
        {
            // Enkel lösning med await och ToListAsync()
            var books = await _context.Books.ToListAsync();
            return books;
        }

        [HttpPost]
        public async Task<ActionResult<Book>> Create(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return Ok(book);
        }

    }
}
