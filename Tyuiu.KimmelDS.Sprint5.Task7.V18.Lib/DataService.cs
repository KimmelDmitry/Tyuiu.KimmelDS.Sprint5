using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.KimmelDS.Sprint5.Task7.V18.Lib
{
    public class DataService : ISprint5Task7V18
    {
        public string LoadDataAndSave(string path)
        {
            string str = File.ReadAllText(path);

            string outputData = str.Replace("н", "нн");

            string outpath = $@"{Directory.GetCurrentDirectory()}\OutPutDataFileTask7V18.txt";

            var fileinfo = new FileInfo(outpath);
            {
                if (fileinfo.Exists)
                    File.Delete(outpath);
                File.AppendAllText(outpath, str);
            }

            return outpath;
        }
    }
}
