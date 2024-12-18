using Microsoft.SemanticKernel.ChatCompletion;

namespace ChatAI.Lib.Application.Interfaces;

/// <summary>
/// Интерфейс взаимодействия с AI через чат.
/// </summary>
public interface IConversationService
{
    /// <summary>
    /// Послать команду.
    /// </summary>
    /// <param name="userPrompt">Текст команды (промт).</param>
    /// <param name="role">Роль</param>
    /// <returns></returns>
    Task SendCommand(string userPrompt, AuthorRole role);

    /// <summary>
    /// Получить ответ.
    /// </summary>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    Task<string> GetResponseAsync(CancellationToken cancellationToken);
}
