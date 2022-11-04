using Movie.Domain.Arguments.Movie;

namespace Movie.Domain.Interfaces.Services;

public interface IMovieService
{
    public bool AddMovie(MovieAddRequest movie);
    public bool Edit(MovieEditRequest movieRequest);
}
