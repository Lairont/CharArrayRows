using System.ComponentModel.DataAnnotations;

namespace CharArrayRows;

/// <summary>
/// Модуль данных: создание массива вручную или случайным образом.
/// </summary>
public static class MatrixInput
{
    private const string LowerAlphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
    private static readonly string UpperAlphabet = LowerAlphabet.ToUpper();
    private static readonly Random Rnd = new();

    /// <summary>Спрашивает у пользователя способ заполнения и создает массив.</summary>
    public static char[,] Create()
    {
        string? choice;
        do
        {
            Console.WriteLine("1 - ввести вручную, 2 - заполнить случайно");
            Console.Write("Ваш выбор: ");
            choice = Console.ReadLine()?.Trim();
        } while (choice != "1" && choice != "2");

        int rows = ReadSize("Количество строк (1-10): ");
        int cols = ReadSize("Количество столбцов (1-10): ");

        Logger.Info($"Создание массива {rows}x{cols}, способ: {choice}");
        return choice == "1" ? ReadManual(rows, cols) : GenerateRandom(rows, cols);
    }

    private static int ReadSize(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? text = Console.ReadLine();
            if (Validator.TryParseSize(text, out int value, out string error))
                return value;

            Console.WriteLine("Ошибка: " + error);
            Logger.Warn("Некорректный размер: " + text);
        }
    }

    private static char[,] ReadManual(int rows, int cols)
    {
        var matrix = new char[rows, cols];
        Console.WriteLine($"Вводите по одной строке из {cols} русских букв без пробелов.");

        for (int i = 0; i < rows; i++)
        {
            while (true)
            {
                Console.Write($"Строка {i + 1}: ");
                string? text = Console.ReadLine();
                if (Validator.ValidateRow(text, cols, out string error))
                {
                    for (int j = 0; j < cols; j++)
                        matrix[i, j] = text![j];
                    break;
                }
                Console.WriteLine("Ошибка: " + error);
                Logger.Warn("Некорректная строка: " + text);
            }
        }
        return matrix;
    }

    private static char[,] GenerateRandom(int rows, int cols)
    {
        var matrix = new char[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                // 90% строчных, чтобы подходящие строки встречались достаточно часто
                string alphabet = Rnd.NextDouble() < 0.9 ? LowerAlphabet : UpperAlphabet;
                matrix[i, j] = alphabet[Rnd.Next(alphabet.Length)];
            }
        }
        return matrix;
    }
}