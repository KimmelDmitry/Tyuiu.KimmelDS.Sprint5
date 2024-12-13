using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.KimmelDS.Sprint5.Task3.V21.Lib
{
    public class DataService : ISprint5Task3V21
    {
        public string SaveToFileTextData(int x)
        {
            // Вычисляем значение выражения
            double result = (Math.Pow(x, 2) + 1) / Math.Sqrt(4 * Math.Pow(x, 3) - 3);

            // Округляем результат до трёх знаков после запятой
            result = Math.Round(result, 3);

            // Генерируем путь для сохранения файла в Temp
            string filePath = Path.Combine(Path.GetTempPath(), "OutPutFileTask3.bin");

            // Сохраняем результат в бинарный файл
            using (BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.Create)))
            {
                writer.Write(result);
            }

            // Выводим результат на консоль
            Console.WriteLine($"Вычисленное значение: {result}");
            Console.WriteLine($"Файл сохранен по пути: {filePath}");

            // Возвращаем путь к файлу
            return filePath;
        }
    }
}

