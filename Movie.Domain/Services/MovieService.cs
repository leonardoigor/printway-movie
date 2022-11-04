using Movie.Domain.Arguments.Movie;
using Movie.Domain.Entities;
using Movie.Domain.Interfaces.Services;
using prmToolkit.NotificationPattern;

namespace Movie.Domain.Services;

public class MovieService : Notifiable, IMovieService
{
    public bool AddMovie(MovieAddRequest movieRequest)
    {
        var movie = new Entities.Movie(movieRequest.Movie.Image, movieRequest.Movie.Title,
            movieRequest.Movie.Description, movieRequest.Movie.Duration);
        var room = new Room(movieRequest.Room.Name, movieRequest.Room.Quantity);
        AddNotifications(movie.Notifications);
        AddNotifications(room.Notifications);
        if (IsInvalid())
            return false;
        return true;
    }
}
