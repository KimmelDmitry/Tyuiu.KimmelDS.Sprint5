using System.Globalization;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.KimmelDS.Sprint5.Task5.V28.Lib
{
    public class DataService : ISprint5Task5V28
    {
        public double LoadFromDataFile(string path)
        {
            // Проверяем, существует ли файл по указанному пути
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("Файл не найден.", path);
            }

            // Читаем все строки из файла
            string[] fileContent = File.ReadAllLines(path);

            // Для отладки выводим все строки
            Console.WriteLine("Содержимое файла:");
            foreach (var line in fileContent)
            {
                Console.WriteLine(line);
            }

            // Создаём список чисел, преобразуя строки в числа
            var numbers = fileContent
                .Select(line => line.Trim())
                .Where(line => !string.IsNullOrEmpty(line))
                .Select(line =>
                {
                    double result;
                    // Пробуем преобразовать строку в вещественное число
                    if (double.TryParse(line, NumberStyles.Any, CultureInfo.InvariantCulture, out result))
                    {
                        return result;
                    }
                    return (double?)null;
                })
                .Where(n => n.HasValue)
                .Select(n => n.Value)
                .ToList();

            // Для отладки выводим все найденные числа
            Console.WriteLine("Найденные числа:");
            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }

            // Проверка, что список не пустой
            if (!numbers.Any())
            {
                throw new InvalidOperationException("В файле нет чисел.");
            }

            // Находим наименьшее положительное целое число, которое делится на 5
            var minPositiveDivisibleBy5 = numbers
                .Where(n => n > 0 && n % 5 == 0)
                .Min();

            // Если не нашли такого числа
            if (minPositiveDivisibleBy5 == null)
            {
                throw new InvalidOperationException("В файле нет положительного числа, которое делится на 5.");
            }

            // Рассчитываем факториал для этого числа
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