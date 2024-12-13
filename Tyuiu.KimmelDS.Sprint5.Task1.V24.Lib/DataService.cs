using System.Text;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.KimmelDS.Sprint5.Task1.V24.Lib
{
    
    public class DataService : ISprint5Task1V24
    {
        public string SaveToFileTextData(int startValue, int stopValue)
        {
            // Создаем StringBuilder для накопления результатов
            StringBuilder resultBuilder = new StringBuilder();

            for (int x = startValue; x <= stopValue; x++)
            {
                double result = CalculateFunction(x);

                // Округляем до двух знаков и убираем лишние нули
                string formattedResult = Math.Round(result, 2).ToString("G", System.Globalization.CultureInfo.InvariantCulture);

                // Заменяем точку на запятую для соответствия требуемому формату
                resultBuilder.AppendLine(formattedResult.Replace('.', ','));
            }

            // Возвращаем результат как строку
            return resultBuilder.ToString().TrimEnd();
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
