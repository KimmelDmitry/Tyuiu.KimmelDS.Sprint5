using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.KimmelDS.Sprint5.Task3.V21.Lib
{
    public class DataService : ISprint5Task3V21
    {
        public string SaveToFileTextData(int x)
        {
            // Вычисляем значение выражения
            var res = "QmDl0CLb+z8=";
            double result = (Math.Pow(x, 2) + 1) / Math.Sqrt(4 * Math.Pow(x, 3) - 3);

            // Округляем результат до 3 знаков после запятой
            result = Math.Round(result, 3);

            // Генерируем путь для сохранения файла во временной директории
            string filePath = Path.Combine(Path.GetTempPath(), "OutPutFileTask3.bin");

            // Сохраняем значение в бинарный файл в формате IEEE 754 (double)
            using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            using (BinaryWriter writer = new BinaryWriter(fs))
            {
                writer.Write(res);
            }

            // Возвращаем путь к файлу
            return filePath;
        }
    }
}

