using Movie.Domain.Arguments.RoomRequest;
using Movie.Domain.Entities;
using Movie.Domain.Interfaces.Repositories;
using prmToolkit.NotificationPattern;

namespace Movie.Domain.Services;

public class RoomService : Notifiable
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
}
