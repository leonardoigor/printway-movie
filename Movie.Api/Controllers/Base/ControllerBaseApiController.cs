using Microsoft.AspNetCore.Mvc;
using Movie.Domain.Services.Base;
using Movie.Infra.Transactions.Base;

namespace Movie.Api.Controllers.Base;

public class ControllerBaseApiController : ControllerBase
{
    private readonly ILogger _logger;
    private readonly IUnitOfWork _unitOfWork;
    private IServiceBase _serviceBase;

    public ControllerBaseApiController(ILogger logger, IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public async Task<ActionResult<T>> ResponseAsync<T>(object result, IServiceBase serviceBase)
    {
        _serviceBase = serviceBase;

        if (!serviceBase.Notifications.Any())
            try
            {
                _unitOfWork.Commit();

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                // Aqui devo logar o erro
                return NotFound(
                    $"Houve um problema interno com o servidor. Entre em contato com o Administrador do sistema caso o problema persista. Erro interno: {ex.Message}");
            }

        return BadRequest(new { errors = serviceBase.Notifications });
    }

    protected BadRequestObjectResult ResponseExceptionAsync(Exception ex)
    {
        return BadRequest(new { errors = ex.Message, exception = ex.ToString() });
    }

    protected void Dispose(bool disposing)
    {
        //Realiza o dispose no serviço para que possa ser zerada as notificações
        if (_serviceBase != null) _serviceBase.Dispose();
    }
}
