namespace ChatAI.Lib.Application.Interfaces;

public interface IConversation
{
    /// <summary>
    /// Подготавливает контекст разговора.
    /// </summary>
    /// <param name="conversationGuid">Guid для загрузки контекста. Если не был передан, то будет создан новый контекст.</param>
    /// <returns>Guid разговора.</returns>
    public Task<Guid> PrepareConversation(Guid? conversationGuid);
}
