using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace TaskConsoleApp
{
    class Program
    {
        /// <summary>
        /// ContinueWith method in Task
        /// First Version
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        private static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var myTask = new HttpClient().GetStringAsync("https://fenerbahce.org").ContinueWith(
                (data) =>
                {
                    Console.WriteLine("Data Lenght : " + data.Result.Length);
                });

            Console.WriteLine("Other process in break");
            await myTask;
        }

        /// <summary>
        /// Without ContinueWith 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        private static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var myTask = new HttpClient().GetStringAsync("https://fenerbahce.org");

            Console.WriteLine("Other process in break");

            var data = await myTask;
            Console.WriteLine("Data Lenght : " + data.Length);
        }

        /// <summary>
        /// Other usage ContinueWith
        /// If after the await, we have long codes, this is good version of the ContinueWith usage.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        private static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var myTask = new HttpClient().GetStringAsync("https://fenerbahce.org").ContinueWith(Work);

            Console.WriteLine("Other process in break");

             await myTask;
            
        }

        /// <summary>
        /// Method that Long process for the continuewith.
        /// </summary>
        /// <param name="data"></param>
        private static void Work(Task<string> data)
        {
            Console.WriteLine("Data Lenght : " + data.Result.Length);
        }


    }
}
