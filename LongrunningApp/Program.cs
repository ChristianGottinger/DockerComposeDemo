using StackExchange.Redis;
using System;
using System.Threading.Tasks;

namespace LongrunningApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionMulitiplexer = ConnectionMultiplexer.Connect(args[0]);
            var database = connectionMulitiplexer.GetDatabase();

            MainAsync(database).GetAwaiter().GetResult();

            Console.ReadKey();
        }

        public static async Task MainAsync(IDatabase database)
        {
            Console.Write($"{Environment.MachineName} incrementing counter");
            while (true)
            {
                await database.StringIncrementAsync("counter", 1);
                Console.Write(".");
                await Task.Delay(5000);
            }
        }
    }
}
