using Microsoft.AspNetCore.Mvc;
using Movie.Api.Controllers.Base;
using Movie.Domain.Arguments;
using Movie.Domain.Arguments.SessionRequest;
using Movie.Domain.Arguments.SessionResponse;
using Movie.Domain.Interfaces.Services;
using Movie.Infra.Transactions.Base;

namespace Movie.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class SessionController : ControllerBaseApiController
{
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IMovieService _movieService;
    private readonly IRoomService _roomService;
    private readonly ISessionService _sessionService;

    public SessionController(IUnitOfWork transaction, ILogger<WeatherForecastController> logger,
        IMovieService movieService,
        ISessionService sessionService,
        IRoomService roomService) : base(transaction)
    {
        _logger = logger;
        _movieService = movieService;
        _sessionService = sessionService;
        _roomService = roomService;
    }

    [HttpPost(Name = "create-session")]
    public async Task<ActionResult> CreateSession(SessionAddRequest request)
    {
        var result = new BaseResponse<CreateSessionResponse>(new CreateSessionResponse());
        try
        {
            _roomService.Exist(request.RoomId);
            _movieService.Exist(request.MovieId);
            _roomService.AddNotifications(_movieService.Notifications);
            if (_roomService.IsInvalid())
            {
                result.AddNotifications(_roomService.Notifications);
                result.StatusCode = 400;
                return result.ToActionResult;
            }

            var response = _sessionService.Add(request);
            result.StatusCode = response ? 200 : 400;
            await ResponseAsync<BaseResponse<CreateSessionResponse>>(result, _sessionService);
            return result.ToActionResult;
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            return BadRequest(e);
        }
    }
}
