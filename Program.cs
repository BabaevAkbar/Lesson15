using System;
using System.Threading.Tasks;

namespace Lesson15
{
    class Program
    {
        static string ReadNotAsync(string nameFile)
        {
            string result = File.ReadAllText(nameFile);
            return result;
        }
        static async Task<string?> ReadWithAsync(string nameFile)
        {
            using (StreamReader rd = new StreamReader(nameFile))
            {
                string? a = await rd.ReadLineAsync();
                await Task.Delay(2000);
                return a;
            }
        }

        static int SumArrayNotAsync()
        {
            Random r = new Random();
            int[] arr = new int[15];
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = r.Next(1, 100);
            }
            foreach (var item in arr)
            {
                sum += item;
            }
            return sum;
        }

        static async Task<int> SumArrayWithAsync()
        {
            Random r = new Random();
            int[] arr = new int[15];
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = r.Next(1, 100);
            }
            await Task.Run(() =>
            {
                foreach (var item in arr)
                {
                    sum += item;
                }
            });
            return sum;
        }

        static async Task Main(string[] str)
        {
            // //Задача 1
            // using (StreamWriter wr = new StreamWriter("test.txt"))
            // {
            //     wr?.WriteAsync("Hello World ");
            // }
            // string data1 = ReadNotAsync("test.txt");
            // Console.WriteLine(data1);
            // string? data = await ReadWithAsync("test.txt");
            // Console.WriteLine(data);

            // Задача 2
            int a = SumArrayNotAsync();
            Console.WriteLine($"1: {a}");
            int b = await SumArrayWithAsync();
            Console.WriteLine($"2: {b}");
        }
    }
}