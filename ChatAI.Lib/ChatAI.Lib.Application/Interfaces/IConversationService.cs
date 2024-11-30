namespace ChatAI.Lib.Application.Interfaces;

/// <summary>
/// Интерфейс взаимодействия с AI через чат.
/// </summary>
public interface IConversationService
{
    /// <summary>
    /// Подготавливает контекст разговора.
    /// </summary>
    /// <param name="conversationGuid">Guid для загрузки контекста. Если не был передан, то будет создан новый контекст.</param>
    /// <returns>Guid разговора.</returns>
    public Task<Guid> PrepareConversation(Guid? conversationGuid);

    /// <summary>
    /// Послать команду.
    /// </summary>
    /// <param name="conversationGuid">Guid разговора.</param>
    /// <param name="userPrompt">Текст команды (промт).</param>
    public Task SendCommand(Guid conversationGuid, string userPrompt);

    /// <summary>
    /// Получить ответ.
    /// </summary>
    /// <param name="conversationGuid">Guid разговора.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    public Task<string> GetResponseAsync(Guid conversationGuid, CancellationToken cancellationToken);
}
