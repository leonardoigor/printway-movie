using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Movie.Api.Controllers.Base;
using Movie.Api.Security;
using Movie.Domain.Arguments;
using Movie.Infra.Transactions.Base;

namespace Movie.Api.Controllers;

[ApiController]
[Route("[controller]/{request}")]
public class AuthController : ControllerBaseApiController
{
    private readonly TokenManager _tokenManager;

    public AuthController(IUnitOfWork transaction, ILogger<MovieController> logger
    ) : base(logger, transaction)
    {
        _tokenManager = new TokenManager();
    }

    [HttpGet("/login")]
    [AllowAnonymous]
    // default email and password
    public async Task<IActionResult> PostAsync(string email = "gerente@admin", string password = "123456")
    {
        var request = new LoginRequest
        {
            email = email,
            password = password
        };
        if (request.email == "gerente@admin" && request.password == "123456")
        {
            var response = new LoginResponse
            {
                Token = await _tokenManager.GenerateTokenAsync(request.email, request.password),
                Expires = DateTime.UtcNow.AddMinutes(30),
                TokenType = JwtBearerDefaults.AuthenticationScheme,
                Email = request.email

            };
            var result = new BaseResponse<LoginResponse>(response);
            return Ok(result);
        }

        return Unauthorized();
    }
}
