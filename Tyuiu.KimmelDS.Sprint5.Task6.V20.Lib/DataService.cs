using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.KimmelDS.Sprint5.Task6.V20.Lib
{
    public class DataService : ISprint5Task6V20
    {
        public int LoadFromDataFile(string path)
        {
            int sixLetterWordCount = 0;

            // Чтение данных из файла
            using (var reader = new StreamReader(path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    // Разделяем строку на слова по пробелам и другим разделителям
                    var words = line.Split(new char[] { ' ', ',', '.', ';', ':', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

                    // Считаем слова длиной ровно 6 символов
                    sixLetterWordCount += words.Count(word => word.Length == 6);
                }
            }

            // Возвращаем результат
            return sixLetterWordCount;
        }
    }
}
