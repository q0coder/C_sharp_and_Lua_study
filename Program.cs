using System;
using System.Diagnostics;
namespace C__stduy_5_18
{
    internal class Program
    {
        static void OrderDelivery()
        {
            Console.WriteLine("ordering delivery");
        }
        static async Task WaitDelivery()
        {
            Console.WriteLine("waiting delivery...");
            await Task.Delay(5000);
            Console.WriteLine("delivery arrived");

        }
        static async Task EatDelivery()
        {
            Console.WriteLine("eat delivery...");
            await Task.Delay(5000);

            Console.WriteLine("finish eating");

        }
        static async Task LearnCsharp()
        {
            Console.WriteLine("learning C-sharp...");
            await Task.Delay(10000);
            Console.WriteLine("finish learning");

        }

        static async Task Main(string[] args)
        {
           var p= Stopwatch.StartNew();
           OrderDelivery();
            var waitingdelivery = WaitDelivery();
            var learingCsharp = LearnCsharp();
            await waitingdelivery;
            await EatDelivery();
            await learingCsharp;
            //WaitDelivery();
            //LearnCsharp();
            //await WaitDelivery();
            //await EatDelivery();
            //await LearnCsharp();

            p.Stop();
            Console.WriteLine(p.Elapsed.TotalSeconds);
        }
    }
}
