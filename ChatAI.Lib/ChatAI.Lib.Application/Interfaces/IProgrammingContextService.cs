using System.Threading;

namespace ChatAI.Lib.Application.Interfaces;

/// <summary>
/// Сервис для подготовки контекста беседы для 
/// помощи с исходным кодом.
/// </summary>
public interface IProgrammingContextService
{
    /// <summary>
    /// Загрузить исходный код в контекст.
    /// </summary>
    /// <param name="sourseCode">Строка содержащая исходный код.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    Task LoadSourseCodeAsync(string sourseCode, CancellationToken cancellationToken);

    /// <summary>
    /// Загрузить исходный код по указанному пути
    /// учитывая вложенные папки в контекст.
    /// </summary>
    /// <param name="sourseCodePath">Путь к папке с исходным кодом.</param>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns></returns>
    Task LoadSourseCodeByPathAsync(string sourseCodePath, CancellationToken cancellationToken);
}
