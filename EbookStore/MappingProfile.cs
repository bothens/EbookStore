using AutoMapper;
using EFilmStore.Models;
using EFilmStore.DTOs;

namespace EFilmStore.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // DTO -> Entity (fanns redan)
            CreateMap<FilmDto, Film>();
            CreateMap<DirectorDto, Director>();

            // Entity -> DTO (behövs för ProjectTo och GET)
            CreateMap<Film, FilmDto>();
            CreateMap<Director, DirectorDto>();
        }
    }
}


