using Movie.Domain.Arguments.Movie;
using Movie.Domain.Entities;
using Movie.Domain.Interfaces.Repositories;
using Movie.Domain.Interfaces.Services;
using prmToolkit.NotificationPattern;

namespace Movie.Domain.Services;

public class MovieService : Notifiable, IMovieService
{
    private readonly ISessionRepository _sessionRepository;

    public MovieService(ISessionRepository sessionRepository)
    {
        _sessionRepository = sessionRepository;
    }

    public bool AddMovie(MovieAddRequest movieRequest)
    {
        var movie = new Entities.Movie(movieRequest.Movie.Image, movieRequest.Movie.Title,
            movieRequest.Movie.Description, movieRequest.Movie.Duration);
        var room = new Room(movieRequest.Room.Name, movieRequest.Room.Quantity);

        var session = new Session(movieRequest.date, movieRequest.startDate, movieRequest.endDate, movieRequest.price,
            movieRequest.typeAnimation, true, movie, room);
        AddNotifications(session.Notifications);
        AddNotifications(movie.Notifications);
        AddNotifications(room.Notifications);
        if (IsInvalid())
            return false;
        var result = _sessionRepository.Add(session);
        if (result == null)
            return false;
        return true;
    }
}
