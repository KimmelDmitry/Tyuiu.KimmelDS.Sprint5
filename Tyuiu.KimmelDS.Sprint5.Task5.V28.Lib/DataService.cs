using System.Globalization;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.KimmelDS.Sprint5.Task5.V28.Lib
{
    public class DataService : ISprint5Task5V28
    {
        public double LoadFromDataFile(string path)
        {
            // Проверка существования файла
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("Файл не найден.", path);
            }

            // Чтение всех строк из файла
            string[] fileContent = File.ReadAllLines(path);

            // Логирование содержимого файла для отладки
            Console.WriteLine("Содержимое файла:");
            foreach (var line in fileContent)
            {
                Console.WriteLine($"Обрабатываемая строка: '{line}'");
            }

            // Создание списка чисел, преобразуя строки
            var numbers = fileContent
                .Select(line => line.Trim())
                .Where(line => !string.IsNullOrEmpty(line))
                .Select(line =>
                {
                    double result;
                    // Попытка преобразования строки в число
                    if (double.TryParse(line, NumberStyles.Any, CultureInfo.InvariantCulture, out result))
                    {
                        return result;
                    }
                    return (double?)null;
                })
                .Where(n => n.HasValue)
                .Select(n => n.Value)
                .ToList();

            // Логирование найденных чисел для отладки
            Console.WriteLine("Найденные числа:");
            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }

            // Если чисел нет, выбрасываем исключение
            if (!numbers.Any())
            {
                throw new InvalidOperationException("В файле нет чисел.");
            }

            // Поиск наименьшего положительного числа, делящегося на 5
            var minPositiveDivisibleBy5 = numbers
                .Where(n => n > 0 && n % 5 == 0)
                .Min();

            // Если такого числа нет, выбрасываем исключение
            if (minPositiveDivisibleBy5 == null)
            {
                throw new InvalidOperationException("В файле нет положительного числа, которое делится на 5.");
            }

            // Рассчитываем факториал этого числа
            int n = (int)minPositiveDivisibleBy5;
            long factorial = 1;
            for (int i = 1; i <= n; i++)
            {
                factorial *= i;
            }

            // Выводим результат
            Console.WriteLine($"Факториал числа {n} = {factorial}");

            return factorial;
        }
    }
}