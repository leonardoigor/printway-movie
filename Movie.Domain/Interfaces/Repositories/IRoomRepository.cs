using Movie.Domain.Entities;
using Movie.Domain.Interfaces.Repositories.Base;
using prmToolkit.NotificationPattern;

namespace Movie.Domain.Interfaces.Repositories;

public interface IRoomRepository : INotifiable, IRepositoryBase<Room, Guid>
{
    public bool AddRoom(Room room);
}
