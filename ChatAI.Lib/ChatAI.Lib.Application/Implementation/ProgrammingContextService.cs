using ChatAI.Lib.Application.Interfaces;
using Microsoft.SemanticKernel.ChatCompletion;
using System.Text;

namespace ChatAI.Lib.Application.Implementation;


/// <summary>
/// Реализация интерфейса <see cref="IProgrammingContextService"/>
/// </summary>
public class ProgrammingContextService : IProgrammingContextService
{
    /// <summary>
    /// Сервис взоимодействия с моделью.
    /// </summary>
    private readonly IConversationService _conversationService;

    private const string PREFIX = "Здравствуйте, я нуждаюсь в помощи с кодом на языке программирования C#. Я работаю над веб-приложением на ASP.NET Core и столкнулся с проблемой, которую не могу решить самостоятельно. Я хотел бы получить вашу помощь в качестве опытного разработчика на C# с глубоким пониманием языка и его экосистемы. Сначала я предоставляю часть моего исходного кода для контекста, а в самом конце задам свой вопрос. Вот мой код: ";
    private const string POSTFIX = "Пожалуйста, помогите мне найти решение или объясните, как я могу решить эту проблему. Пожалуйста, ответьте в формальном тоне, как если бы вы объясняли коллеге-программисту. Пожалуйста, предоставьте ответ в виде шагов, которые я могу выполнить, чтобы решить проблему. Важно отметить, что я ценю честность и точность в ответах. Если вы не уверены в ответе или не знаете решения проблемы, пожалуйста, не предлагайте гипотетических или неверных решений. Лучше честно сказать, что вы не знаете или не можете дать точный ответ, чем предоставить неверную информацию.";
    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="conversationService">Ссылка на сервис взоимодействия с моделью.</param>
    public ProgrammingContextService(IConversationService conversationService)
    {  
        _conversationService = conversationService; 
    }

    public async Task LoadSourseCodeAsync(string sourseCode, CancellationToken cancellationToken)
    {
        await _conversationService.SendCommand(PREFIX + Environment.NewLine + sourseCode + Environment.NewLine + POSTFIX, AuthorRole.User);
    }

    public async Task LoadSourseCodeByPathAsync(string sourseCodePath, CancellationToken cancellationToken)
    {
        var sourceCode = new StringBuilder();

        await ScanDirectory(sourseCodePath, sourceCode);

        await LoadSourseCodeAsync(sourceCode.ToString(), cancellationToken);
    }

    private async Task ScanDirectory(string directoryPath, StringBuilder sourceCode)
    {
        var files = Directory.GetFiles(directoryPath);
        var directories = Directory.GetDirectories(directoryPath);

        foreach (var file in files)
        {
            if (file.EndsWith(".cs", StringComparison.OrdinalIgnoreCase) ||
                file.EndsWith(".config", StringComparison.OrdinalIgnoreCase) ||
                file.EndsWith(".xml", StringComparison.OrdinalIgnoreCase))
            {
                var fileContent = await File.ReadAllTextAsync(file);
                sourceCode.Append($"<!-- Начало файла {file} -->\n");
                sourceCode.Append(fileContent);
                sourceCode.Append($"<!-- Конец файла {file} -->\n\n");
            }
        }

        foreach (var directory in directories)
        {
            await ScanDirectory(directory, sourceCode);
        }
    }
}
