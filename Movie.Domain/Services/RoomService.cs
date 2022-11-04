using Movie.Domain.Interfaces.Repositories;
using prmToolkit.NotificationPattern;

namespace Movie.Domain.Services;

public class RoomService : Notifiable
{
    private readonly IRoomRepository _roonRepository;

    public RoomService(ISessionRepository _roonRepository)
    {
        _roonRepository = _roonRepository;
    }
}
