using Movie.Domain.Entities;

namespace Movie.Domain.Arguments.RoomRequest;

public class RoomRemoverRequest

{
    public RoomRemoverRequest(Room room)
    {
        Room = room;
    }

    public RoomRemoverRequest()
    {
    }

    public Room Room { get; set; }
}
