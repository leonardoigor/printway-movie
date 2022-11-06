using Movie.Domain.Arguments.Movie;
using prmToolkit.NotificationPattern;

namespace Movie.Domain.Interfaces.Services;

public interface IMovieService : INotifiable
{
    public bool AddMovie(MovieAddRequest movie);
    public bool Edit(MovieEditRequest movieRequest);
    public bool Remove(DeleteMovieRequest movieRequest);
    bool Exist(Guid movieId);
    bool Exist(string movieTitle);
    List<Entities.Movie> GetMovies();
    bool UpdateMovie(MovieEditRequest request);
    bool DeleteMovie(Guid id);
}
