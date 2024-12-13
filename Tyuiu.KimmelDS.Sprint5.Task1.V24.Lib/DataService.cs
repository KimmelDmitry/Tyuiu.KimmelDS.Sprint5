using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.KimmelDS.Sprint5.Task1.V24.Lib
{
    public class DataService : ISprint5Task1V24
    {
        public string SaveToFileTextData(int startValue, int stopValue)
        {
            string filePath = "OutPutFileTask1.txt";

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                Console.WriteLine("x\tF(x)");
                writer.WriteLine("x\tF(x)");

                for (double x = startValue; x <= stopValue; x += 1)
                {
                    double result = CalculateFunction(x);

                    result = Math.Round(result, 2);

                    Console.WriteLine($"{x}\t{result}");
                    writer.WriteLine($"{x}\t{result}");
                }
            }
            return filePath;
        }

        static double CalculateFunction(double x)
        {
            try
            {
                double denominator = (4 * x - 0.5);
                if (denominator == 0)
                {
                    return 0; 
                }

                // Основная функция
                double result = (3 * Math.Cos(x) / denominator) + Math.Sin(x) - 5 * x - 2;

                return result;
            }
            catch (DivideByZeroException)
            {
                return 0; 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
                return 0;
            }
        }
    }
}
