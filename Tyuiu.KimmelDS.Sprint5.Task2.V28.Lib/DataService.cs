using System.Text;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.KimmelDS.Sprint5.Task2.V28.Lib
{
    public class DataService : ISprint5Task2V28
    {
        public string SaveToFileTextData(int[,] matrix)
        {
            // Генерация пути к временной директории
            string fileName = "OutPutFileTask2.csv";
            string filePath = Path.Combine(Path.GetTempPath(), fileName);

            // Создаем StringBuilder для формирования содержимого файла
            StringBuilder resultBuilder = new StringBuilder();

            // Обработка матрицы
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    // Замена значений: положительное -> 1, отрицательное -> 0
                    if (matrix[i, j] > 0)
                        resultBuilder.Append(1);
                    else
                        resultBuilder.Append(0);

                    // Добавляем разделитель ";" между элементами строки
                    if (j < matrix.GetLength(1) - 1)
                        resultBuilder.Append(";");
                }

                // Переход на новую строку
                resultBuilder.AppendLine();
            }

            // Записываем данные в файл в временную директорию
            File.WriteAllText(filePath, resultBuilder.ToString());

            // Возвращаем путь к файлу
            return filePath;
        }
    }
}