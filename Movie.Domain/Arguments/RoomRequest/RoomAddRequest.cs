using Movie.Domain.Entities;

namespace Movie.Domain.Arguments.RoomRequest;

public class RoomAddRequest
{
    public RoomAddRequest(Room room)
    {
        Room = room;
    }

    public RoomAddRequest()
    {
    }

    public Room Room { get; set; }
}
