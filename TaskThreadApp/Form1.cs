using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskThreadApp
{
    public partial class Form1 : Form
    {
        public static int Counter { get; set; } = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
           var aTask =  Go(progressBar1);
           var bTask = Go(progressBar3);

            await Task.WhenAll(aTask, bTask);
        }

        //public void Go(ProgressBar progressBar)
        //{
        //    Enumerable.Range(1, 100).ToList().ForEach(x =>
        //    {
        //        Thread.Sleep(100);
        //        progressBar.Value = x;

        //    });
        //}

        /// <summary>
        /// For the Task.Run methods
        /// The difference of Run and StartNew,  StartNew() can takes object parameters.
        /// </summary>
        /// <param name="progressBar"></param>
        /// <returns></returns>
        public async Task Go(ProgressBar progressBar)
        {
            await Task.Run(() =>
            {

                Enumerable.Range(1, 100).ToList().ForEach(x =>
                {
                    Thread.Sleep(100);
                    progressBar.Invoke((MethodInvoker)delegate { progressBar.Value = x;  });

                });

            });

        }

        private void btnCounter_Click(object sender, EventArgs e)
        {
            btnCounter.Text = Counter++.ToString();
        }
    }
}
