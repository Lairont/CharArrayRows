using System.Text;

namespace CharArrayRows;

internal static class Program
{
    private static void Main()
    {
        // Чтобы русские буквы корректно вводились и выводились в консоли
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        Logger.Info("Программа запущена");
        Console.WriteLine("=== Практическая работа 8-9, вариант 4 ===");
        Console.WriteLine("Поиск строк, состоящих только из строчных русских букв.");

        var matrices = new List<char[,]>();
        for (int k = 1; k <= 2; k++)
        {
            Console.WriteLine($"\n--- Создание массива №{k} ---");
            matrices.Add(MatrixInput.Create());
        }

        bool foundAny = false;

        for (int k = 0; k < matrices.Count; k++)
        {
            Console.WriteLine($"\nМассив №{k + 1}:");
            PrintMatrix(matrices[k]);

            List<int> rows = RowAnalyzer.FindLowercaseRows(matrices[k]);

            if (rows.Count > 0)
            {
                foundAny = true;
                Console.WriteLine("Строки только из строчных букв: " + string.Join(", ", rows));
            }
            else
            {
                Console.WriteLine("В этом массиве таких строк нет.");
            }
            Logger.Info($"Массив {k + 1}: найдено строк {rows.Count}");
        }

        if (!foundAny)
            Console.WriteLine("\nСтрок, состоящих только из строчных букв, нет ни в одном из массивов.");

        Logger.Info("Программа завершена");
        Console.WriteLine("\nНажмите Enter для выхода...");
        Console.ReadLine();
    }

    private static void PrintMatrix(char[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            Console.Write($"{i + 1,2}: ");
            for (int j = 0; j < matrix.GetLength(1); j++)
                Console.Write(matrix[i, j] + " ");
            Console.WriteLine();
        }
    }
}