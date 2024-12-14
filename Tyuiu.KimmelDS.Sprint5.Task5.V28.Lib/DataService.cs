using System.Globalization;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.KimmelDS.Sprint5.Task5.V28.Lib
{
    public class DataService : ISprint5Task5V28
    {
        public double LoadFromDataFile(string path)
        {
            var numbers = new List<double>();
            //reading
            using (var rd = new StreamReader(path))
            {
                string line;
                while ((line = rd.ReadLine()) != null)
                {
                    numbers.Add(double.Parse(line, CultureInfo.InvariantCulture));
                }
            }

            var minPositiveDivisibleBy5 = numbers
                .Where(n => n > 0 && n % 5 == 0)
                .Min();

            var n = (int)minPositiveDivisibleBy5;

            long factorial = 1;
            for (int i = 1; i <= n; i++)
                factorial *= i;

            Console.WriteLine($"Факториал числа {n} = {factorial}");

            return factorial;
        }
    }
}