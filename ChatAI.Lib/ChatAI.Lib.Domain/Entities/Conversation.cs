namespace ChatAI.Lib.Domain.Entities;

/// <summary>
/// Разговор
/// </summary>
public class Conversation
{
    /// <summary>
    /// Идентификатор записи
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Guid разговора
    /// </summary>
    public Guid ConversationId { get; set; }

    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    public int UserId { get; set; }

    /// <summary>
    /// Дата создания
    /// </summary>
    public DateTime Created { get; set; }
}
