namespace ChatAI.Lib.Contract.ConversationService.Request;

/// <summary>
/// Запрос с сохранением в историю сообщений.
/// </summary>
public class ConversationRequest
{
    /// <summary>
    /// Содержание запроса.
    /// </summary>
    required public string UserPrompt { get; set; }
}