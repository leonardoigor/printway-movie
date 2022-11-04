using Movie.Domain.Entities;
using Movie.Domain.Interfaces.Repositories.Base;
using prmToolkit.NotificationPattern;

namespace Movie.Domain.Interfaces.Repositories;

public interface ISessionRepository : INotifiable, IRepositoryBase<Session, Guid>, IDisposable
{
}
