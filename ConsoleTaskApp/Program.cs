using System;
using System.IO;
using System.Threading.Tasks;

namespace ConsoleTaskApp
{
    class Program
    {        
        public static string  CacheData { get; set; }
        private async static Task Main(string[] args)
        {
            ///FromResult() cachelenmiş datayı dönmek için kullanılır genellikle.

            CacheData = await GetDataAsync();
            Console.WriteLine(CacheData);

        }

        public static Task<string> GetDataAsync()
        {
            if (String.IsNullOrEmpty(CacheData))
                return File.ReadAllTextAsync("dosya.txt");
            else
                return Task.FromResult<string>(CacheData);


        }

    }
}
