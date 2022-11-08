using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Movie.Api.Controllers.Base;
using Movie.Domain.Interfaces.Services;
using Movie.Infra.Transactions.Base;

namespace Movie.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class RoomController : ControllerBaseApiController
{
    private readonly ILogger _logger;
    private readonly IMovieService _movieService;
    private readonly IRoomService _roomService;
    private readonly ISessionService _sessionService;

    public RoomController(IUnitOfWork transaction, ILogger<MovieController> logger,
        IMovieService movieService,
        ISessionService sessionService,
        IRoomService roomService) : base(logger, transaction)
    {
        _logger = logger;
        _movieService = movieService;
        _sessionService = sessionService;
        _roomService = roomService;
    }

    [HttpGet(Name = "getall-rooms")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public ActionResult getAll()
    {
        return Ok(_roomService.getAll());
    }
}
