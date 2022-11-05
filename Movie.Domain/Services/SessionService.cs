using Movie.Domain.Arguments.SessionRequest;
using Movie.Domain.Entities;
using Movie.Domain.Interfaces.Repositories;
using Movie.Domain.Interfaces.Services;
using Movie.Domain.Services.Base;
using prmToolkit.NotificationPattern;

namespace Movie.Domain.Services;

public class SessionService : Notifiable, ISessionService, IServiceBase
{
    private readonly ISessionRepository _sessionRepository;

    public SessionService(ISessionRepository sessionRepository)
    {
        _sessionRepository = sessionRepository;
    }

    public bool Add(SessionAddRequest req)
    {
        var session = new Session
        {
            Date = req.Date,
            MovieId = req.MovieId,
            Price = req.Price,
            RoomId = req.RoomId,
            EndDate = req.EndDate,
            IsDubbed = req.IsDubbed,
            StartDate = req.StartDate,
            TypeAnimation = req.TypeAnimation
        };
        AddNotifications(session);
        if (IsInvalid())
            return false;

        var result = _sessionRepository.Add(session);
        if (result == null)
            return false;

        return true;
    }

    public bool Edit(SessionEditRequest req)
    {
        var session = new Session
        {
            Date = req.Date,
            Movie = req.Movie,
            Price = req.Price,
            Room = req.Room,
            EndDate = req.EndDate,
            IsDubbed = req.IsDubbed,
            StartDate = req.StartDate,
            TypeAnimation = req.TypeAnimation
        };
        AddNotifications(session);
        if (IsInvalid())
            return false;

        var result = _sessionRepository.Edit(session);
        if (result == null)
            return false;

        return true;
    }

    public bool Remove(SessionRemoveRequest req)
    {
        var session = new Session
        {
            Date = req.Date,
            Movie = req.Movie,
            Price = req.Price,
            Room = req.Room,
            EndDate = req.EndDate,
            IsDubbed = req.IsDubbed,
            StartDate = req.StartDate,
            TypeAnimation = req.TypeAnimation
        };
        AddNotifications(session);
        if (IsInvalid())
            return false;

        return _sessionRepository.Remove(session);
    }
}
