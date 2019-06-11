using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            TimeSpan lastTime = timer.Elapsed;
            Synchronous().Wait();
            Console.WriteLine("Synchronous await:" + (timer.Elapsed - lastTime));
            timer.Restart();
            lastTime = timer.Elapsed;
            Parallel().Wait();
            Console.WriteLine("Parallel await:" + (timer.Elapsed - lastTime));
            Console.ReadLine();
        }

        public static async Task Synchronous()
        {
            await Task.Run(() => {
                for (int i = 0; i <= 1000000; i++) { continue; }
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            });
            await Task.Run(() => {
                for (int i = 0; i <= 1000000; i++) { continue; }
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            });
            await Task.Run(() => {
                for (int i = 0; i <= 1000000; i++) { continue; }
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            });
        }

        public static async Task Parallel()
        {
            Task task1 = Task.Run(() => {
                for (int i = 0; i <= 1000000; i++) { continue; }
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            });
            Task task2 = Task.Run(() => {
                for (int i = 0; i <= 1000000; i++) { continue; }
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            });
            Task task3 = Task.Run(() => {
                for (int i = 0; i <= 1000000; i++) { continue; }
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            });
            await Task.WhenAll(task1, task2, task3);
        }
    }
}
