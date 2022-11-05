using Movie.Domain.Arguments.Movie;
using Movie.Domain.Arguments.RoomRequest;
using Movie.Domain.Entities;
using Movie.Domain.Interfaces.Repositories;
using Movie.Domain.Interfaces.Services;
using Movie.Domain.Services.Base;
using prmToolkit.NotificationPattern;

namespace Movie.Domain.Services;

public class RoomService : Notifiable, IRoomService, IServiceBase
{
    private readonly IRoomRepository _roonRepository;

    public RoomService(IRoomRepository roonRepository)
    {
        _roonRepository = roonRepository;
    }

    public bool Add(RoomAddRequest req)
    {
        var room = new Room(req.Room.Name, req.Room.Quantity);


        AddNotifications(room);
        if (IsInvalid())
            return false;

        var result = _roonRepository.Add(room);
        if (result == null)
            return false;
        return true;
    }

    public bool Edit(MovieEditRequest movieRequest)
    {
        throw new NotImplementedException();
    }

    public bool Remove(DeleteMovieRequest movieRequest)
    {
        throw new NotImplementedException();
    }

    public bool Edit(EditRoomRequest req)
    {
        var room = new Room(req.Room.Name, req.Room.Quantity);
        AddNotifications(room);
        if (IsInvalid())
            return false;
        var result = _roonRepository.Edit(room);
        if (result == null)
            return false;
        return true;
    }

    public bool Remove(RoomRemoverRequest req)
    {
        var room = new Room(req.Room.Name, req.Room.Quantity);
        AddNotifications(room);
        if (IsInvalid())
            return false;
        return _roonRepository.Remove(room);
    }
}
