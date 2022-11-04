using Movie.Domain.Entities;

namespace Movie.Domain.Arguments.RoomRequest;

public class EditRoomRequest

{
    public EditRoomRequest(Room room)
    {
        Room = room;
    }

    public EditRoomRequest()
    {
    }

    public Room Room { get; set; }
}
