using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
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

        private async void button1_Click(object sender, EventArgs e)
        {
            string data = string.Empty;
                
            Task<string> read = ReadFileAsync();
            richTextBox2.Text = await new HttpClient().GetStringAsync("https://fenerbahce.org");

            data = await read;

            richTextBox1.Text = data;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            textBoxCounter.Text = counter++.ToString();
        }
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
        
        private async Task<string> ReadFileAsync()
        {
            var data = string.Empty;

            using (StreamReader sr = new StreamReader("dosya.txt"))
            {
                Task<string> myTask = sr.ReadToEndAsync();

                await Task.Delay(5000);
                data = await myTask;
                return data;
            }
        }
    }
}
