using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        List<int> interval = new List<int>();

        [DllImport("user32.dll")]
        private static extern void mouse_event(int dwflags,int dx,int dy,int dwData,int dwExtraInfo);
        private const int MOUSEEVENTF_LEFTDOWN = 0x0002;
        private const int MOUSEEVENTF_LEFTUP = 0x0004;


        public Form1()
        {



            InitializeComponent();

            
        }
        Keys bind = Keys.None;

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label1.Text = $"CPS:{trackBar1.Value}";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            interval.Add(400); //2cps
            interval.Add(200); //4cps
            interval.Add(150); //6cps
            interval.Add(100); //8cps
            interval.Add(90); //10cps
            interval.Add(80); //12cps
            interval.Add(72); //14cps
            interval.Add(60); //16cps
            interval.Add(50); //18cps
            interval.Add(10); //20cps

            if (trackBar1.Value == 0)
            {
                button1.Enabled = false;
            }

            else if (trackBar1.Value > 0)
            {
                button1.Enabled = true;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(button1.Text == "START")
            {
                button1.Text = "STOP";
                trackBar1.Enabled = false;
                System.Threading.Thread.Sleep(5000);
                timer1.Interval = interval[trackBar1.Value-10];
                timer1.Enabled = true;
            }

            else
            {
                button1.Text = "START";
                timer1.Enabled = false;
                trackBar1.Enabled = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN, Control.MousePosition.X, Control.MousePosition.Y, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, Control.MousePosition.X, Control.MousePosition.Y, 0, 0);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Text = "...";
        }

        private void button2_KeyDown(object sender, KeyEventArgs e)
        {
            bind = e.KeyCode;
            button2.Text = "Bind:" + bind;
        }
    }
}
