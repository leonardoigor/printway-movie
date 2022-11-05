using Movie.Domain.Arguments.SessionRequest;
using Movie.Domain.Services.Base;
using prmToolkit.NotificationPattern;

namespace Movie.Domain.Interfaces.Services;

public interface ISessionService : INotifiable, IServiceBase
{
    public bool Add(SessionAddRequest movie);
    public bool Edit(SessionEditRequest movieRequest);
    public bool Remove(SessionRemoveRequest movieRequest);
}
