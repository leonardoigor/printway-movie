using Movie.Domain.Arguments.SessionRequest;
using Movie.Domain.Entities;
using Movie.Domain.Interfaces.Repositories;
using Movie.Domain.Interfaces.Services;
using Movie.Domain.Services.Base;
using prmToolkit.NotificationPattern;

namespace Movie.Domain.Services;

public class SessionService : Notifiable, ISessionService, IServiceBase
{
    private readonly IMovieRepository _movieRepository;
    private readonly ISessionRepository _sessionRepository;

    public SessionService(ISessionRepository sessionRepository, IMovieRepository movieRepository)
    {
        _sessionRepository = sessionRepository;
        _movieRepository = movieRepository;
    }

    public bool Add(SessionAddRequest req)
    {
        var movie = _movieRepository.GetById(req.MovieId);
        if (movie == null)
        {
            AddNotification("Movie", "Filme não encontrado");
            return false;
        }

        req.Movie = movie;

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
        var movie = _movieRepository.GetById(req.MovieId);
        if (movie == null)
        {
            AddNotification("Movie", "Filme não encontrado");
            return false;
        }

        req.Movie = movie;

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

    public List<Session> GetAll()
    {
        return _sessionRepository.List().ToList();
    }

    public bool Update(SessionEditRequest request)
    {
        var movie = _movieRepository.GetById(request.MovieId);
        if (movie == null)
        {
            AddNotification("Movie", "Filme não encontrado");
            return false;
        }

        request.Movie = movie;
        var session = _sessionRepository.GetById(request.Id);
        if (session == null)
            AddNotification("Session", "Sessão não encontrada");
        session.Date = request.Date;
        session.MovieId = request.MovieId;
        session.Price = request.Price;
        session.RoomId = request.RoomId;
        session.EndDate = request.EndDate;
        session.IsDubbed = request.IsDubbed;
        session.StartDate = request.StartDate;
        session.TypeAnimation = request.TypeAnimation;

        _sessionRepository.Edit(session);
        return true;
    }

    public bool Delete(Guid id)
    {
        var session = _sessionRepository.GetById(id);
        if (session == null)
            AddNotification("Session", "Sessão não encontrada");

        return _sessionRepository.Remove(session);
    }
}
