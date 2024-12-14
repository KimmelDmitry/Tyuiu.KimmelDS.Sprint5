using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.KimmelDS.Sprint5.Task7.V18.Lib
{
    public class DataService : ISprint5Task7V18
    {
        public string LoadDataAndSave(string path)
        {
            string inputData;
            using (var reader = new StreamReader(path))
            {
                inputData = reader.ReadToEnd();
            }

            string outputData = inputData.Replace("н", "нн");

            
            using (var fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                using (var writer = new StreamWriter(fs))
                {
                    writer.Write(outputData);
                }
            }

            return path;
        }
    }
}
