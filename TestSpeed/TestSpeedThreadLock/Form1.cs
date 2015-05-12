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

namespace TestSpeedThreadLock
{
    public partial class Form1 : Form
    {
        List<TimeSpan> InterLocker = new List<TimeSpan>();
        int count;

        public Form1()
        {
            InitializeComponent();
           
        }

        void Interlocker()
        {
           
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 100000; i++)
            {
                Interlocked.Increment(ref count);
            }
            sw.Stop();
            InterLocker.Add(sw.Elapsed);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread [] threads = new Thread[10];
          
            for (int i = 0; i < 10; ++i)
            {
                threads[i] = new Thread(Interlocker);
                threads[i].Join();
            }
            label1.Text = InterLocker.Average(c => c.Milliseconds).ToString();
        }


    }
}
