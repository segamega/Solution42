namespace ChatAI.Lib.Domain.Entities;

/// <summary>
/// Сообщение из разговора
/// </summary>
public class Message
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
    /// Идентификатор отправителя сообщения
    /// </summary>
    public int UserIdFrom { get; set; }

    /// <summary>
    /// Идентификатор получателя сообщения
    /// </summary>
    public int UserIdTo {  get; set; }

    /// <summary>
    /// Контент сообщения
    /// </summary>
    public string Content { get; set; } = null!;

    /// <summary>
    /// Дата создания
    /// </summary>
    public DateTime Created { get; set; }
}
