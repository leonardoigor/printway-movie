using Movie.Domain.Entities;
using Movie.Domain.Interfaces.Repositories;
using Movie.Infra.Persistence.Contexts;
using Movie.Infra.Persistence.Repositories.Base;

namespace Movie.Infra.Persistence.Repositories;

public class SessionRepository : RepositoryBase<Session, Guid>, ISessionRepository
{
    protected readonly PopCornContext _context;

    public SessionRepository(PopCornContext context) : base(context)
    {
        _context = context;
    }
}
