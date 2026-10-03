namespace CharArrayRows;

/// <summary>Вспомогательный модуль: проверка пользовательского ввода.</summary>
public static class Validator
{
    public const int MaxSize = 10;

    public static bool TryParseSize(string? text, out int value, out string error)
    {
        value = 0;
        error = "";

        if (!int.TryParse(text, out value))
        {
            error = "нужно ввести целое число.";
            return false;
        }
        if (value < 1 || value > MaxSize)
        {
            error = $"число должно быть от 1 до {MaxSize}.";
            return false;
        }
        return true;
    }

    public static bool IsRussianLetter(char c)
    {
        return (c >= 'а' && c <= 'я') || (c >= 'А' && c <= 'Я') || c == 'ё' || c == 'Ё';
    }

    public static bool ValidateRow(string? text, int cols, out string error)
    {
        error = "";

        if (string.IsNullOrEmpty(text) || text.Length != cols)
        {
            error = $"в строке должно быть ровно {cols} символов.";
            return false;
        }
        foreach (char c in text)
        {
            if (!IsRussianLetter(c))
            {
                error = $"символ '{c}' не является буквой русского алфавита.";
                return false;
            }
        }
        return true;
    }
}