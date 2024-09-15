using System;
using System.IO;

namespace lab1._2
{
    internal class Program
    {
        public static string Rand()
        {
            int N, M;
            string FileName;
            Console.Write("Enter N: ");
            N = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter M: ");
            M = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter file name: ");
            FileName = Console.ReadLine();


            string FullPath = Path.Combine(FileName + ".txt");

            using (var new_out = new StreamWriter(FullPath))
            {
                new_out.WriteLine(N);
                new_out.WriteLine(M);

                Random r = new Random(DateTime.Now.Millisecond);
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < M; j++)
                    {
                        int x = r.Next(-1000, 1001);
                        new_out.Write(x + " ");
                    }
                    new_out.WriteLine();
                }
            }

            Console.WriteLine("File " + FullPath + " was created!");
            return FullPath;
        }

        static void Main(string[] args)
        {
            string inputFilePath = Rand();
            using (var new_in = new StreamReader(inputFilePath))
            using (var new_out = new StreamWriter(@"output.txt"))
            {
                int N = Convert.ToInt32(new_in.ReadLine());
                int M = Convert.ToInt32(new_in.ReadLine());
                new_out.WriteLine("Исходная матрица");
                int[,] matrix = new int[N, M];
                for (int i = 0; i < N; i++)
                {
                    string str_all = new_in.ReadLine();
                    string[] str_elem = str_all.Split(' ');
                    for (int j = 0; j < M; j++)
                    {
                        matrix[i, j] = Convert.ToInt32(str_elem[j]);
                        new_out.Write(matrix[i, j] + " ");
                    }
                    new_out.WriteLine();
                }

                // 2
                new_out.WriteLine("Максимум для каждого столбца ");
                for (int i = 0; i < M; i++)
                {
                    int max = matrix[0, i];
                    for (int j = 0; j < N; j++)
                    {
                        if (matrix[j, i] > max)
                        {
                            max = matrix[j, i];
                        }
                    }
                    new_out.Write(max + " ");
                }
                new_out.WriteLine();

                // 3
                new_out.WriteLine("Модифицированная матрица");
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < M; j++)
                    {
                        if (matrix[i, j] % 2 == 0)
                        {
                            matrix[i, j] = 1;
                        }
                        else
                        {
                            matrix[i, j] = 0;
                        }
                        new_out.Write(matrix[i, j] + " ");
                    }
                    new_out.WriteLine();
                }
                
            }
        }
    }
}
