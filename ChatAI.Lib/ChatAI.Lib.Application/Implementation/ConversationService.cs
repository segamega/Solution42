using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using ChatAI.Lib.Application.Interfaces;

namespace ChatAI.Lib.Application.Implementation;

/// <summary>
/// Реализация интерфейса <see cref="IConversationService"/>
/// </summary>
public class ConversationService : IConversationService
{
    private readonly Kernel _kernel;
    private readonly IChatCompletionService _chatCompletionService;
    private readonly ChatHistory _chatHistory;

    public ConversationService()
    {
        // Warning due to the experimental state of some Semantic Kernel SDK features.
        #pragma warning disable SKEXP0070
        _kernel = Kernel.CreateBuilder()
                    .AddOllamaChatCompletion(
                        modelId: "phi3:medium", // "phi3:mini"
                        endpoint: new Uri("http://localhost:11434"))
                    .Build();

        _chatCompletionService = _kernel.GetRequiredService<IChatCompletionService>();
        _chatHistory = [];
    }

    public async Task<string> GetResponseAsync(Guid conversationGuid, CancellationToken cancellationToken)
    {
        var response = "";
        await foreach (var item in
            _chatCompletionService.GetStreamingChatMessageContentsAsync(_chatHistory))
        {
            response += item.Content;
        }
        _chatHistory.Add(new ChatMessageContent(AuthorRole.Assistant, response));
        return response;
    }

    public Task SendCommand(Guid conversationGuid, string userPrompt)
    {
        _chatHistory.Add(new ChatMessageContent(AuthorRole.User, userPrompt));
        return Task.CompletedTask;
    }
}
