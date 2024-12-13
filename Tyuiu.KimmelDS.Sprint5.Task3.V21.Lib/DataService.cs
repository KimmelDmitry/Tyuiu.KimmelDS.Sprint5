using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.KimmelDS.Sprint5.Task3.V21.Lib
{
    public class DataService : ISprint5Task3V21
    {
        public string SaveToFileTextData(int x)
        {
            double result = (Math.Pow(x, 2) + 1) / Math.Sqrt(4 * Math.Pow(x, 3) - 3);

            result = Math.Round(result, 3);

            string filePath = Path.Combine(Path.GetTempPath(), "OutPutFileTask3.bin");

            using (BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.Create)))
            {
                writer.Write(result);
            }

            Console.WriteLine($"Вычисленное значение: {result}");
            Console.WriteLine($"Файл сохранен по пути: {filePath}");

            return filePath;
        }
    }
}
}
