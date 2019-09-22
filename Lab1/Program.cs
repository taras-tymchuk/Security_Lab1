using System;
using System.IO;

namespace Lab1
{
    class Program
    {
        private static string path = "results.txt";

        private static void SaveResults(string text)
        {
            File.AppendAllText(path, text + Environment.NewLine);
        }

        private static string CreateOutputString(int idx, int x)
        {
            return $"i = {idx}; X{idx} = {x}";
        }

        private static int GetNext(int a, int x, int c, int m)
        {
            return (a * x + c) % m;
        }

        static void Main(string[] args)
        {
            File.WriteAllText(path, string.Empty);

            Console.Write("Enter the amount of number you want to see: ");
            int n = Convert.ToInt32(Console.ReadLine()),
                m = (int)(Math.Pow(2, 18) - 1),
                a = (int)(Math.Pow(5, 3)),
                c = 34,
                X0 = 512,
                period = -1;
            string resultString = "";
            int[] arr = new int[n + 1];
            arr[0] = X0;

            for (int i = 1; i <= n; ++i)
            {
                X0 = GetNext(a, X0, c, m);
                arr[i] = X0;

                if (period == -1 && X0 == arr[0])
                {
                    period = i;
                }

                resultString = CreateOutputString(i, X0);
                Console.WriteLine(resultString);
                SaveResults(resultString);                
            }

            while (period == -1)
            {
                ++n;
                X0 = GetNext(a, X0, c, m);
                if (X0 == arr[0])
                {
                    period = n;
                }
            }

            Console.WriteLine($"Period = {period}");

            Console.ReadLine();
        }
    }
}
