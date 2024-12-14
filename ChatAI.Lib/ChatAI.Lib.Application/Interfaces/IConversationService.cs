namespace ChatAI.Lib.Application.Interfaces;

/// <summary>
/// Интерфейс взаимодействия с AI через чат.
/// </summary>
public interface IConversationService
{
    /// <summary>
    /// Послать команду.
    /// </summary>
    /// <param name="conversationGuid">Guid разговора.</param>
    /// <param name="userPrompt">Текст команды (промт).</param>
    Task SendCommand(Guid conversationGuid, string userPrompt);

    /// <summary>
    /// Получить ответ.
    /// </summary>
    /// <param name="conversationGuid">Guid разговора.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    Task<string> GetResponseAsync(Guid conversationGuid, CancellationToken cancellationToken);

    
    //Task<bool> LoadSourceCodeForContextAsync()
}
