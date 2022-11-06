using Microsoft.AspNetCore.Mvc;
using Movie.Api.Controllers.Base;
using Movie.Domain.Arguments;
using Movie.Domain.Arguments.Movie;
using Movie.Domain.Arguments.SessionResponse;
using Movie.Domain.Interfaces.Services;
using Movie.Infra.Transactions.Base;

namespace Movie.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class MovieController : ControllerBaseApiController
{
    private readonly ILogger _logger;
    private readonly IMovieService _movieService;
    private readonly IRoomService _roomService;
    private readonly ISessionService _sessionService;

    public MovieController(IUnitOfWork transaction, ILogger logger,
        IMovieService movieService,
        ISessionService sessionService,
        IRoomService roomService) : base(logger, transaction)
    {
        _logger = logger;
        _movieService = movieService;
        _sessionService = sessionService;
        _roomService = roomService;
    }


    [HttpPost(Name = "create-movie")]
    public async Task<ActionResult> CreateMovie(MovieAddRequest request)
    {
        var result = new BaseResponse<CreateSessionResponse>(new CreateSessionResponse());
        try
        {
            var alreadyhasMovie = _movieService.Exist(request.Movie.Title);
            if (alreadyhasMovie)
            {
                result.Messages = new List<string> { "Movie already exists" };
                result.StatusCode = 400;
                return result.ToActionResult;
            }

            _movieService.ClearNotifications();
            var response = _movieService.AddMovie(request);
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
