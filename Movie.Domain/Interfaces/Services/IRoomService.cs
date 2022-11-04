using Movie.Domain.Arguments.Movie;
using Movie.Domain.Arguments.RoomRequest;
using prmToolkit.NotificationPattern;

namespace Movie.Domain.Interfaces.Services;

public interface IRoomService : INotifiable
{
    public bool Add(RoomAddRequest movie);
    public bool Edit(MovieEditRequest movieRequest);
    public bool Remove(DeleteMovieRequest movieRequest);
}
