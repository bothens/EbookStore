using FluentValidation;
using EFilmStore.DTOs;

namespace EFilmStore.Validators
{
    public class FilmDtoValidator : AbstractValidator<FilmDto>
    {
        public FilmDtoValidator()
        {
            RuleFor(x => x.Title).NotEmpty().Length(2, 100);
            RuleFor(x => x.Price).GreaterThan(0);
        }
    }
}
