using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.KimmelDS.Sprint5.Task1.V24.Lib
{
    public class DataService : ISprint5Task1V24
    {
        public string SaveToFileTextData(int startValue, int stopValue)
        {
            // Имя файла и путь для сохранения
            string fileName = "OutPutFileTask1.txt";
            string filePath = Path.Combine(Environment.CurrentDirectory, fileName);

            try
            {
                // Открываем файл для записи
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine("x\tF(x)");

                    // Табулирование функции на заданном диапазоне
                    for (int x = startValue; x <= stopValue; x++)
                    {
                        double result = CalculateFunction(x);

                        // Округляем результат до двух знаков после запятой
                        result = Math.Round(result, 2);

                        // Записываем в файл
                        writer.WriteLine($"{x}\t{result}");
                    }
                }

                // Возвращаем путь к файлу
                return filePath;
            }
            catch (Exception ex)
            {
                // Обработка исключений
                return $"Ошибка: {ex.Message}";
            }
        }

        private double CalculateFunction(int x)
        {
            // Проверка деления на ноль
            double denominator = (4 * x - 0.5);
            if (denominator == 0)
            {
                return 0; // Возвращаем 0 при делении на ноль
            }

            // Основная функция
            double result = (3 * Math.Cos(x) / denominator) + Math.Sin(x) - 5 * x - 2;

            return result;
        }
    }
}
