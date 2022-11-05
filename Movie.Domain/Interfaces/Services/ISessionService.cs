using Movie.Domain.Arguments.SessionRequest;
using prmToolkit.NotificationPattern;

namespace Movie.Domain.Interfaces.Services;

public interface ISessionService : INotifiable
{
    public bool Add(SessionAddRequest movie);
    public bool Edit(SessionEditRequest movieRequest);
    public bool Remove(SessionRemoveRequest movieRequest);
}
