using System.Text;
using tyuiu.cources.programming.interfaces.Sprint5;

namespace Tyuiu.KimmelDS.Sprint5.Task2.V28.Lib
{
    public class DataService : ISprint5Task2V28
    {
        public string SaveToFileTextData(int[,] matrix)
        {
            string path = "OutPutFileTask2.csv";
            var sb = new StringBuilder();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] > 0)
                        matrix[i, j] = 1;
                    else
                        matrix[i, j] = 0;

                    sb.Append(matrix[i, j]);

                    if (j < matrix.GetLength(1) - 1)
                        sb.Append(";");
                }

                sb.AppendLine();
            }

            File.WriteAllText(path, sb.ToString());

            Console.WriteLine(sb.ToString());

            return path;
        }
    }
}