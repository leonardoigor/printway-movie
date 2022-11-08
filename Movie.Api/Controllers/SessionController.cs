using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Movie.Api.Controllers.Base;
using Movie.Domain.Arguments;
using Movie.Domain.Arguments.SessionRequest;
using Movie.Domain.Arguments.SessionResponse;
using Movie.Domain.Entities;
using Movie.Domain.Interfaces.Services;
using Movie.Infra.Transactions.Base;

namespace Movie.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class SessionController : ControllerBaseApiController
{
    private readonly ILogger _logger;
    private readonly IMovieService _movieService;
    private readonly IRoomService _roomService;
    private readonly ISessionService _sessionService;

    public SessionController(IUnitOfWork transaction, ILogger<SessionController> logger,
        IMovieService movieService,
        ISessionService sessionService,
        IRoomService roomService) : base(logger, transaction)
    {
        _logger = logger;
        _movieService = movieService;
        _sessionService = sessionService;
        _roomService = roomService;
    }


    [HttpGet(Name = "GetAllSessions")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public IActionResult GetAllSessions()
    {
        var response = _sessionService.GetAll();
        var result = new BaseResponse<List<Session>>(response);
        return Ok(result);
    }

    [HttpGet("{id}", Name = "GetSessionById")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public IActionResult GetSessionById(Guid id)
    {
        var response = _sessionService.GetById(id);
        var result = new BaseResponse<Session>(response);
        return Ok(result);
    }

    [HttpDelete("{id}", Name = "DeleteSession")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<IActionResult> DeleteSession(Guid id)
    {
        try
        {
            var response = _sessionService.Delete(id);
            var result = new BaseResponse<bool>(response);
            await ResponseAsync<BaseResponse<bool>>(result, _sessionService);

            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }

    [HttpPut(Name = "Update-session")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<IActionResult> UpdateSession([FromBody] SessionEditRequest request)
    {
        try
        {
            var response = _sessionService.Update(request);
            var result = new BaseResponse<bool>(response);
            await ResponseAsync<BaseResponse<bool>>(result, _sessionService);
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }

    [HttpPost(Name = "create-session")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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

            request.Movie = _movieService.GetMovieById(request.MovieId);


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
