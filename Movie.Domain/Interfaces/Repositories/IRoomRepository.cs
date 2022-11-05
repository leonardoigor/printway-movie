using Movie.Domain.Entities;
using Movie.Domain.Interfaces.Repositories.Base;

namespace Movie.Domain.Interfaces.Repositories;

public interface IRoomRepository : IRepositoryBase<Room, Guid>
{
    public bool AddRoom(Room room);
}
