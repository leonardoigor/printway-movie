using Movie.Domain.Interfaces.Repositories;
using prmToolkit.NotificationPattern;

namespace Movie.Domain.Services;

public class SessionService : Notifiable
{
    private readonly ISessionRepository _sessionRepository;

    public SessionService(ISessionRepository sessionRepository)
    {
        _sessionRepository = sessionRepository;
    }
}
