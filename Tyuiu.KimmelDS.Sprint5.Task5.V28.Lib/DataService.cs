using System.Globalization;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.KimmelDS.Sprint5.Task5.V28.Lib
{
    public class DataService : ISprint5Task5V28
    {
        public double LoadFromDataFile(string path)
        {
            var numbers = new List<double>();

            using (var rd = new StreamReader(path))
            {
                string line;
                while ((line = rd.ReadLine()) != null)
                {
                    var tokens = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    foreach (var token in tokens)
                    {
                        if (double.TryParse(token, NumberStyles.Any, CultureInfo.InvariantCulture, out var number))
                        {
                            numbers.Add(Math.Round(number, 3));
                        }
                    }
                }
            }

            var minPositiveDivisibleBy5 = numbers
                .Where(n => n > 0 && n % 5 == 0)
                .DefaultIfEmpty(0)
                .Min();

            if (minPositiveDivisibleBy5 == 0)
            {
                Console.WriteLine("Нет положительных чисел, которые делятся на 5.");
                return 0;
            }

            var n = (int)minPositiveDivisibleBy5;

            long factorial = 1;
            for (int i = 1; i <= n; i++)
            {
                factorial *= i;
            }

            Console.WriteLine($"Факториал числа {n} = {factorial}");

            return factorial;
        }
    }
}