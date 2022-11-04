using Movie.Domain.Entities;
using Movie.Domain.Interfaces.Repositories.Base;

namespace Movie.Domain.Interfaces.Repositories;

public interface IRoomRepository : IRepositoryBase<Session, Guid>
{
}
