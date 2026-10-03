namespace CharArrayRows;

/// <summary>
/// Модуль бизнес-логики: поиск строк, состоящих только из строчных русских букв.
/// </summary>
public static class RowAnalyzer
{
    /// <summary>Является ли символ строчной русской буквой (а–я, ё).</summary>
    public static bool IsRussianLower(char c)
    {
        return (c >= 'а' && c <= 'я') || c == 'ё';
    }

    /// <summary>
    /// ПРОЦЕДУРА ИЗ ЗАДАНИЯ: проверка строки.
    /// Принимает ВСЕ элементы текущей строки и возвращает true,
    /// если каждый из них — строчная буква.
    /// </summary>
    public static bool IsRowAllLowercase(char[] row)
    {
        if (row == null || row.Length == 0)
            return false;

        foreach (char c in row)
        {
            if (!IsRussianLower(c))
                return false;   // нашли не строчную букву — строка не подходит
        }
        return true;
    }

    /// <summary>Копирует строку номер r (с нуля) двумерного массива в одномерный.</summary>
    public static char[] GetRow(char[,] matrix, int r)
    {
        int cols = matrix.GetLength(1);
        var row = new char[cols];
        for (int j = 0; j < cols; j++)
            row[j] = matrix[r, j];
        return row;
    }

    /// <summary>Возвращает номера (с единицы) строк, состоящих только из строчных букв.</summary>
    public static List<int> FindLowercaseRows(char[,] matrix)
    {
        var result = new List<int>();
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            if (IsRowAllLowercase(GetRow(matrix, i)))
                result.Add(i + 1);
        }
        return result;
    }
}