using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskFormApp
{
    public partial class Form1 : Form
    {
        public int counter { get; set; } = 0;
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// File Read Button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void button1_Click(object sender, EventArgs e)
        {
            string data = string.Empty;

            //Task<string> read = ReadFileAsync();
            Task<string> read = ReadFileAsyncSecond();
            richTextBox2.Text = await new HttpClient().GetStringAsync("https://fenerbahce.org");

            data = await read;

            richTextBox1.Text = data;
        }

        /// <summary>
        /// Counter button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click_1(object sender, EventArgs e)
        {
            textBoxCounter.Text = counter++.ToString();
        }

        /// <summary>
        /// Sync File Read.
        /// </summary>
        /// <returns>data.</returns>
        private string ReadFile()
        {
            string data = string.Empty;
            using (StreamReader s = new StreamReader("dosya.txt"))
            {
                Thread.Sleep(5000);
                data = s.ReadToEnd();
            }
            return data;
        }

        /// <summary>
        /// Async File Read.
        /// </summary>
        /// <returns> data.</returns>
        private async Task<string> ReadFileAsync()
        {
            var data = string.Empty;

            using (StreamReader sr = new StreamReader("dosya.txt"))
            {
                Task<string> myTask = sr.ReadToEndAsync();
                /// async kullanım senaryosu
                /// Asny method çağrıldığında burada yapacağın ektra işler var ise, async await kullan ki aradaki işlemleri yap.
                /// Eğer ki StreamReader ı çalıştırırken yapacağın ekstra işler yoksa direkt geri dönebilirsin.

                await Task.Delay(5000);
                data = await myTask;
                return data;
            }
        }

        /// <summary>
        /// Direct return Task.
        /// When Task returns directly, async-await are unnecesary.
        /// </summary>
        /// <returns>Task.</returns>
        private Task<string> ReadFileAsyncSecond()
        {
            StreamReader sr = new StreamReader("dosya.txt");

            return sr.ReadToEndAsync();

        }
    }
}
