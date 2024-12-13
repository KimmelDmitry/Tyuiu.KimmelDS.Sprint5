using System.Globalization;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.KimmelDS.Sprint5.Task4.V6.Lib
{
    public class DataService : ISprint5Task4V6
    {
        public double LoadFromDataFile(string path)
        {
            // Проверяем, существует ли файл по указанному пути
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("Файл не найден.", path);
            }

            // Читаем значение из файла
            string fileContent = File.ReadAllText(path).Trim();

            // Выводим содержимое файла для отладки
            Console.WriteLine($"Содержимое файла: {fileContent}");

            // Преобразуем значение в вещественное число с учётом локали
            if (double.TryParse(fileContent, NumberStyles.Any, CultureInfo.InvariantCulture, out double x))
            {
                // Вычисляем значение по формуле: y = 1 / cos(x) + 2.2 * x^2
                double y = 1 / Math.Cos(x) + 2.2 * Math.Pow(x, 2);

                // Округляем результат до трёх знаков после запятой
                return Math.Round(y, 3);
            }
            else
            {
                // Если не удалось преобразовать, выводим информацию об ошибке
                throw new FormatException($"Ошибка формата данных в файле. Не удалось преобразовать '{fileContent}' в вещественное число.");
            }
        }
    }
}