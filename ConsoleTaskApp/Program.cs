using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleTaskApp
{
    class Program
    {
        public class Status
        {
            public int ThreadId { get; set; }
            public DateTime dateTime { get; set; }
        }
        private async static Task Main(string[] args)
        {
            var myTask = Task.Factory.StartNew((Obj) => {

                Console.WriteLine("myTask çalıştı!");

                var status = Obj as Status;

                status.ThreadId = Thread.CurrentThread.ManagedThreadId;
            },     new Status() { dateTime =DateTime.Now} );

            await myTask;

            var s = myTask.AsyncState as Status;

            Console.WriteLine(s.dateTime);
            Console.WriteLine(s.ThreadId);


        }
    }
}
