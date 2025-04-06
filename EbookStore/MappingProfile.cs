using AutoMapper;
using EBookStore.Models;
using EBookStore.DTOs;

namespace EBookStore.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<Book, BookDto>();
     CreateMap<BookDto, Book>()
 
                .ForMember(dest => dest.AuthorId, opt => opt.MapFrom(src => src.AuthorId))
                .ForMember(dest => dest.BookId, opt => opt.Ignore());
            CreateMap<Author, AuthorDto>(); // <-- Denna saknades
            
        }
    }
}