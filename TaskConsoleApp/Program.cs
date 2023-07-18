using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace TaskConsoleApp
{
    /// <summary>
    /// Website model class.
    /// </summary>
    public class Content
    {
        public string Site { get; set; }
        public int Leng { get; set; }
    }
    class Program
    {
        /// <summary>
        /// Maşn method for thr process Task
        /// First Version
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        private static async Task Main(string[] args)
        {

            ///ContinueWith()
            //Console.WriteLine("Hello World!");

            //var myTask = new HttpClient().GetStringAsync("https://fenerbahce.org").ContinueWith(
            //    (data) =>
            //    {
            //        Console.WriteLine("Data Lenght : " + data.Result.Length);
            //    });

            //Console.WriteLine("Other process in break");
            //await myTask;
            #region WhenAll

            //Console.WriteLine("Main Thread: " + Thread.CurrentThread.ManagedThreadId);

            //List<string> urlsList = new List<string>()
            //{
            //       "https://www.google.com",
            //       "https://fenerbahce.org",
            //       "https://n11.com",
            //       "https://www.amazon.com",
            //       "https://haberturk.com"
            //};

            //List<Task<Content>> taskList = new List<Task<Content>>();

            //urlsList.ToList().ForEach(x =>
            //{
            //    taskList.Add(GetContentAsync(x));
            //});

            //var contents = Task.WhenAll(taskList.ToArray());

            //Console.WriteLine("WhenAll metodundan sonra yapılabilecek işler: " + Thread.CurrentThread.ManagedThreadId);

            //var data = await contents;

            //data.ToList().ForEach(x =>

            //{
            //    Console.WriteLine($"{x.Site} Boyut: {x.Leng}");

            //});


            #endregion


            #region WhenAny
            ///Parametre içerisinde task array alır ve biten ilk task i döndürür.
            //Console.WriteLine("Main Thread: " + Thread.CurrentThread.ManagedThreadId);

            //List<string> urlsList = new List<string>()
            //{
            //       "https://www.google.com",
            //       "https://fenerbahce.org",
            //       "https://n11.com",
            //       "https://www.amazon.com",
            //       "https://haberturk.com"
            //};

            //List<Task<Content>> taskList = new List<Task<Content>>();

            //urlsList.ToList().ForEach(x =>
            //{
            //    taskList.Add(GetContentAsync(x));
            //});

            //var firstData = await Task.WhenAny(taskList);

            //Console.WriteLine($"{firstData.Result.Site} - {firstData.Result.Leng}");

            #endregion

            #region WaitAll
            //WhenAll dan farkı ana thread i bloklar.

            //Console.WriteLine("Main Thread: " + Thread.CurrentThread.ManagedThreadId);

            //List<string> urlsList = new List<string>()
            //{
            //       "https://www.google.com",
            //       "https://fenerbahce.org",
            //       "https://n11.com",
            //       "https://www.amazon.com",
            //       "https://haberturk.com"
            //};

            //List<Task<Content>> taskList = new List<Task<Content>>();

            //urlsList.ToList().ForEach(x =>
            //{
            //    taskList.Add(GetContentAsync(x));
            //});

            //Console.WriteLine("WaitAll metodundan önce");

            ////Task.WaitAll(taskList.ToArray());

            //var isCompleted = Task.WaitAll(taskList.ToArray(),300);
            //Console.WriteLine($"Tasks are completed: {isCompleted}");

            //Console.WriteLine("WaitAll metodundan sonra");

            //Console.WriteLine($"{taskList.First().Result.Site} - {taskList.First().Result.Leng}");

            #endregion

            #region WaitAny
            //Çağrılmış olduğu thread i bloklar. 
            Console.WriteLine("Main Thread: " + Thread.CurrentThread.ManagedThreadId);

            List<string> urlsList = new List<string>()
            {
                   "https://www.google.com",
                   "https://fenerbahce.org",
                   "https://n11.com",
            };

            List<Task<Content>> taskList = new List<Task<Content>>();

            urlsList.ToList().ForEach(x =>
            {
                taskList.Add(GetContentAsync(x));
            });

            Console.WriteLine("WaitAny metodundan önce");

            //var isCompleted = Task.WaitAll(taskList.ToArray(), 300);

            var firstTaskIndex = Task.WaitAny(taskList.ToArray());

            Console.WriteLine($"{taskList[firstTaskIndex].Result.Site} - {taskList[firstTaskIndex].Result.Leng}");
            #endregion

        }


        /// <summary>
        /// For the Task methods.
        /// </summary>
        /// <param name="url"></param>
        /// <returns>Content class.</returns>
        public static async Task<Content> GetContentAsync(string url)
        {
            Content content = new Content();
            var data = await new HttpClient().GetStringAsync(url);

            content.Site = url;
            content.Leng = url.Length;

            Console.WriteLine("GetContentAsync thread : " + Thread.CurrentThread.ManagedThreadId);

            return content;

        }

        ///// <summary>
        ///// Without ContinueWith 
        ///// </summary>
        ///// <param name="args"></param>
        ///// <returns></returns>
        //private static async Task Main(string[] args)
        //{
        //    Console.WriteLine("Hello World!");

        //    var myTask = new HttpClient().GetStringAsync("https://fenerbahce.org");

        //    Console.WriteLine("Other process in break");

        //    var data = await myTask;
        //    Console.WriteLine("Data Lenght : " + data.Length);
        //}

        ///// <summary>
        ///// Other usage ContinueWith
        ///// If after the await, we have long codes, this is good version of the ContinueWith usage.
        ///// </summary>
        ///// <param name="args"></param>
        ///// <returns></returns>
        //private static async Task Main(string[] args)
        //{
        //    Console.WriteLine("Hello World!");

        //    var myTask = new HttpClient().GetStringAsync("https://fenerbahce.org").ContinueWith(Work);

        //    Console.WriteLine("Other process in break");

        //     await myTask;

        //}

        ///// <summary>
        ///// Method that Long process for the continuewith.
        ///// </summary>
        ///// <param name="data"></param>
        //private static void Work(Task<string> data)
        //{
        //    Console.WriteLine("Data Lenght : " + data.Result.Length);
        //}

        private static async Task WhenAll(string[] args)
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


    }
}
