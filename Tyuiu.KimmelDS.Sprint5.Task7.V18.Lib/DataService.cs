using System.Text.RegularExpressions;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.KimmelDS.Sprint5.Task7.V18.Lib
{
    public class DataService : ISprint5Task7V18
    {
        public string LoadDataAndSave(string path)
        {
            string pathSaveFile = Path.GetTempFileName();

            FileInfo fileInfo = new FileInfo(pathSaveFile);
            bool fileExists = fileInfo.Exists;

            if (fileExists)
            {
                File.Delete(pathSaveFile);
            }

            string strLine = "";
            using (StreamReader reader = new StreamReader(path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    strLine += line.Replace("н", "нн");

                    File.AppendAllText(pathSaveFile, strLine + Environment.NewLine);
                    strLine = "";
                }
            }

            return pathSaveFile; ;

            
        }
    }
}
