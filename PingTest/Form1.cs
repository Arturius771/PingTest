using System;
using System.Windows.Forms;
using System.Net;
using System.Timers;

namespace PingTest {
    public partial class Form1 : Form {
        static System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
        static int alarmCounter = 1;
        static bool exitFlag = false;
        bool button1Pressed = false;
        bool button2Pressed = false;
        bool button3Pressed = false;
        bool button4Pressed = false;
        IPAddress ip1;
        IPAddress ip2;
        IPAddress ip3;
        IPAddress ip4;

        public Form1() {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e) {
            button1Pressed = true;
            ip1 = IPAddress.Parse(textBox1.Text);
            Console.WriteLine("Button1 Pressed");
            InitializeTimer();
        }
        private void button2_Click(object sender, EventArgs e) {
            button2Pressed = true;
            ip2 = IPAddress.Parse(textBox2.Text);
            Console.WriteLine("Button2 Pressed");
            InitializeTimer();
        }
        private void button3_Click(object sender, EventArgs e) {
            button3Pressed = true;
            ip3 = IPAddress.Parse(textBox3.Text);
            Console.WriteLine("Button3 Pressed");
            InitializeTimer();
        }
        private void button4_Click(object sender, EventArgs e) {
            button4Pressed = true;
            ip4 = IPAddress.Parse(textBox4.Text);
            Console.WriteLine("Button4 Pressed");
            InitializeTimer();
        }
        private void InitializeTimer() {
            // Call this procedure when the application starts.  
            // Set to 1 second.  
            myTimer.Interval = 1000;
            myTimer.Tick += new EventHandler(Timer1_Tick);

            // Enable timer.  
            myTimer.Enabled = true;
        }
        private void Timer1_Tick(object Sender, EventArgs e) {
            // Set the caption to the current time. 
            if (button1Pressed == true) {
                new PingIP(ip1, textBox5, textBox1);
            }
            if (button2Pressed == true) {
                new PingIP(ip1, textBox6, textBox2);
            }
            if (button3Pressed == true) {
                new PingIP(ip1, textBox7, textBox3);
            }
            if (button4Pressed == true) {
                new PingIP(ip1, textBox8, textBox4);
            }
        }
    }
}