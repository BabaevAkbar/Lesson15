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

        static async Task Main(string[] str)
        {
            //Задача 1
            using (StreamWriter wr = new StreamWriter("test.txt"))
            {
                wr?.WriteAsync("Hello World ");
            }
            string data1 = ReadNotAsync("test.txt");
            Console.WriteLine(data1);
            string? data = await ReadWithAsync("test.txt");
            Console.WriteLine(data);
        }
    }
}