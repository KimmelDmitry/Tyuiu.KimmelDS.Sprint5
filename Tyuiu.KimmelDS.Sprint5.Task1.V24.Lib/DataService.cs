using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.KimmelDS.Sprint5.Task1.V24.Lib
{
    public class DataService : ISprint5Task1V24
    {
        public string SaveToFileTextData(int startValue, int stopValue)
        {
            string fileName = "OutPutFileTask1.txt";
            string filePath = Path.Combine(Environment.CurrentDirectory, fileName);

            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine("x\tF(x)");

                    for (int x = startValue; x <= stopValue; x++)
                    {
                        double result = CalculateFunction(x);

                        result = Math.Round(result, 2);

                        writer.WriteLine($"{x}\t{result}");
                    }
                }

                return filePath;
            }
            catch (Exception ex)
            {
                return $"Ошибка: {ex.Message}";
            }
        }

        private double CalculateFunction(int x)
        {
            double denominator = (4 * x - 0.5);

            if (denominator == 0) return 0; 

            double result = (3 * Math.Cos(x) / denominator) + Math.Sin(x) - 5 * x - 2;

            return result;
        }
    }
}
