using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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

    public MovieController(IUnitOfWork transaction, ILogger<MovieController> logger,
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
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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

    [HttpGet(Name = "get-movies")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<ActionResult> GetMovies()
    {
        Console.WriteLine("create-movie");
        var result = new BaseResponse<List<Domain.Entities.Movie>>(new List<Domain.Entities.Movie>());
        try
        {
            var response = _movieService.GetMovies();
            result.StatusCode = response.Any() ? 200 : 400;
            result.Data = response;
            return result.ToActionResult;
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            return BadRequest(e);
        }
    }

    [HttpPut(Name = "update-movie")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<ActionResult> UpdateMovie(MovieEditRequest request)
    {
        var result = new BaseResponse<CreateSessionResponse>(new CreateSessionResponse());
        try
        {
            var alreadyhasMovie = _movieService.Exist(request.Id);
            if (!alreadyhasMovie)
            {
                result.Messages = new List<string> { "Filme nao exist" };
                result.StatusCode = 400;
                return result.ToActionResult;
            }

            _movieService.ClearNotifications();
            var response = _movieService.UpdateMovie(request);
            result.StatusCode = response ? 200 : 400;
            result.AddNotifications(_movieService.Notifications);
            await ResponseAsync<BaseResponse<CreateSessionResponse>>(result, _sessionService);
            return result.ToActionResult;
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }

    [HttpDelete(Name = "delete-movie")]
    public async Task<ActionResult> DeleteMovie(Guid Id)
    {
        var result = new BaseResponse<CreateSessionResponse>(new CreateSessionResponse());
        try
        {
            var response = _movieService.DeleteMovie(Id);
            result.StatusCode = response ? 200 : 400;
            result.AddNotifications(_movieService.Notifications);
            await ResponseAsync<BaseResponse<CreateSessionResponse>>(result, _sessionService);
            return result.ToActionResult;
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }

    // get by id
    [HttpGet("{id}", Name = "get-movie-by-id")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<ActionResult> GetMovieById(Guid id)
    {
        var result = new BaseResponse<Domain.Entities.Movie>(new Domain.Entities.Movie());
        try
        {
            var response = _movieService.GetMovieById(id);
            result.StatusCode = response != null ? 200 : 400;
            result.Data = response;
            return result.ToActionResult;
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }
}
