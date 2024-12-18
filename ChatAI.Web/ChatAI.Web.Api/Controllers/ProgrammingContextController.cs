using ChatAI.Lib.Application.Implementation;
using ChatAI.Lib.Application.Interfaces;
using ChatAI.Lib.Contract.ConversationService.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.SemanticKernel.ChatCompletion;

namespace ChatAI.Web.Api.Controllers;

/// <summary>
/// Контроллер для загрузки контекста в модель.
/// </summary>
[ApiController]
[Route("[controller]/[action]")]
public class ProgrammingContextController : ControllerBase
{
    private readonly ILogger<ProgrammingContextController> _logger;
    private readonly IProgrammingContextService _programmingContextService;

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="logger">Логгер.</param>
    /// <param name="programmingContextService">Сервис для подготовки модели к контексту.</param>
    public ProgrammingContextController(
        ILogger<ProgrammingContextController> logger,
        IProgrammingContextService programmingContextService)
    {
        _logger = logger;
        _programmingContextService = programmingContextService;
    }

    /// <summary>
    /// Загрузить исходный код в контекст.
    /// </summary>
    /// <param name="request">Модель запроса.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> LoadAsync(CancellationToken cancellationToken)
    {
        var guid = Guid.NewGuid();
        using (_logger.BeginScope("Processed {id}", guid))
        {
            try
            {
                await _programmingContextService.LoadSourseCodeByPathAsync(@"C:\Projects\Pets\Solution42", cancellationToken);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка обработки");
                return BadRequest(ex);
            }
        }
    }
}
