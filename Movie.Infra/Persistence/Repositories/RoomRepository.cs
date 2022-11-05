using Movie.Domain.Entities;
using Movie.Domain.Interfaces.Repositories;
using Movie.Infra.Persistence.Contexts;
using Movie.Infra.Persistence.Repositories.Base;

namespace Movie.Infra.Persistence.Repositories;

public class RoomRepository : RepositoryBase<Room, Guid>, IRoomRepository
{
    protected readonly PopCornContext _context;

    public RoomRepository(PopCornContext context) : base(context)
    {
        _context = context;
    }

    public bool AddRoom(Room room)
    {
        throw new NotImplementedException();
    }
}
