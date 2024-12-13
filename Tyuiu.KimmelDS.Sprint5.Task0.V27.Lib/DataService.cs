using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.KimmelDS.Sprint5.Task0.V27.Lib
{
    public class DataService : ISprint5Task0V27
    {
        public string SaveToFileTextData(int x)
        {
            var path = Path.Combine(Path.GetTempPath(), "OutPutFileTask0.txt");
            var res = Math.Round(Math.Pow(x - 1, 3 * x + 1), 3);
            File.WriteAllText(path, res.ToString());

            return path;
        }
    }
}
