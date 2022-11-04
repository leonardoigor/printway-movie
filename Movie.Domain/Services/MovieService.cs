using Movie.Domain.Arguments.Movie;
using Movie.Domain.Interfaces.Repositories;
using Movie.Domain.Interfaces.Services;
using prmToolkit.NotificationPattern;

namespace Movie.Domain.Services;

public class MovieService : Notifiable, IMovieService
{
    private readonly IMovieRepository _movieRepository;
    private readonly IRoomRepository _roomRepository;

    private readonly ISessionRepository _sessionRepository;

    public MovieService(ISessionRepository sessionRepository, IRoomRepository roomRepository,
        IMovieRepository movieRepository)
    {
        _sessionRepository = sessionRepository;
        _roomRepository = roomRepository;
        _movieRepository = movieRepository;
    }


    public bool AddMovie(MovieAddRequest movieRequest)
    {
        var movie = new Entities.Movie(movieRequest.Movie.Image, movieRequest.Movie.Title,
            movieRequest.Movie.Description, movieRequest.Movie.Duration);

        AddNotifications(movie);
        if (IsInvalid())
            return false;
        var result = _movieRepository.Add(movie);
        if (result == null)
            return false;
        return true;
    }

    public bool Edit(MovieEditRequest movieRequest)
    {
        var movie = new Entities.Movie(movieRequest.Movie.Image, movieRequest.Movie.Title,
            movieRequest.Movie.Description, movieRequest.Movie.Duration);
        _movieRepository.Add(movie);
        AddNotifications(movie);
        if (IsInvalid())
            return false;
        var result = _movieRepository.Edit(movie);
        if (result == null)
            return false;
        return true;
    }

    public bool Remove(DeleteMovieRequest movieRequest)
    {
        var movie = new Entities.Movie(movieRequest.Movie.Image, movieRequest.Movie.Title,
            movieRequest.Movie.Description, movieRequest.Movie.Duration);
        _movieRepository.Add(movie);
        AddNotifications(movie);
        if (IsInvalid())
            return false;
        var result = _movieRepository.Remove(movie);
        if (result == null)
            return false;
        return true;
    }
}
