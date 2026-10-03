namespace CharArrayRows;

/// <summary>Простое логирование в файл log.txt рядом с программой.</summary>
public static class Logger
{
    private static readonly string FilePath = "log.txt";

    public static void Info(string message) => Write("INFO", message);
    public static void Warn(string message) => Write("WARN", message);

    private static void Write(string level, string message)
    {
        try
        {
            string line = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [{level}] {message}{Environment.NewLine}";
            File.AppendAllText(FilePath, line);
        }
        catch
        {
            // ошибка записи лога не должна ломать программу
        }
    }
}