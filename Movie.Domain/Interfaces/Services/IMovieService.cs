using Movie.Domain.Arguments.Movie;
using prmToolkit.NotificationPattern;

namespace Movie.Domain.Interfaces.Services;

public interface IMovieService : INotifiable
{
    public bool AddMovie(MovieAddRequest movie);
    public bool Edit(MovieEditRequest movieRequest);
    public bool Remove(DeleteMovieRequest movieRequest);
}
