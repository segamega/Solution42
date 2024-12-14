using ChatAI.Lib.Application.Interfaces;
using ChatAI.Lib.Contract.ConversationService.Request;
using Microsoft.AspNetCore.Mvc;

namespace ChatAI.Web.Api.Controllers;

/// <summary>
/// Контроллер для взаимодействия с моделью.
/// </summary>
[ApiController]
[Route("[controller]/[action]")]
public class ConversationController : ControllerBase
{
    private readonly ILogger<ConversationController> _logger;
    private readonly IConversationService _conversationService;

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="logger">Логгер.</param>
    /// <param name="conversationService">Сервис для запросов к модели.</param>
    public ConversationController(
        ILogger<ConversationController> logger,
        IConversationService conversationService)
    {
        _logger = logger;
        _conversationService = conversationService;
    }

    /// <summary>
    /// Получить ответ от сервиса с сохранением истории переписки.
    /// </summary>
    /// <param name="request">Модель запроса.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ConversationRequestAsync(
        ConversationRequest request, CancellationToken cancellationToken)
    {
        var guid = Guid.NewGuid();
        using (_logger.BeginScope("Processed {id}", guid))
        {
            try
            {
                await _conversationService.SendCommand(guid, request.UserPrompt);
                var response = await _conversationService.GetResponseAsync(guid, cancellationToken);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка обработки");
                return BadRequest(ex);
            }
        }
    }
}
