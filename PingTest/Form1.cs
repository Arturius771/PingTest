using System;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace PingTest {
    public partial class Form1 : Form {
        static System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
        bool button1Pressed = false;
        bool button2Pressed = false;
        bool button3Pressed = false;
        bool button4Pressed = false;
        IPAddress ip1;
        IPAddress ip2;
        IPAddress ip3;
        IPAddress ip4;
        int milliseconds;
        int count = 0;
        string startTime;
        string reportTime;

        public Form1() {
            Console.WriteLine("Hello");
            InitializeComponent();
            InitializeTimer();
            milliseconds = int.Parse(textBox9.Text);
            startTime = DateTime.Now.ToShortTimeString();
        }
        private void button1_Click(object sender, EventArgs e) {
            try {
                Console.WriteLine("Button1 Pressed");
                button1Pressed = !button1Pressed;
                milliseconds = int.Parse(textBox9.Text);
                ip1 = IPAddress.Parse(textBox1.Text);
                myTimer.Interval = int.Parse(textBox10.Text);
            }
            catch {
                Console.WriteLine("error button1");
            }
        }
        private void button2_Click(object sender, EventArgs e) {            
            try {
                Console.WriteLine("Button2 Pressed");
                button2Pressed = !button2Pressed;
                milliseconds = int.Parse(textBox9.Text);
                ip2 = IPAddress.Parse(textBox2.Text);
                myTimer.Interval = int.Parse(textBox10.Text);
            }
            catch {
                Console.WriteLine("error button2");
            }
        }
        private void button3_Click(object sender, EventArgs e) {            
            try {
                Console.WriteLine("Button3 Pressed");
                button3Pressed = !button3Pressed;
                milliseconds = int.Parse(textBox9.Text);
                ip3 = IPAddress.Parse(textBox3.Text);
                myTimer.Interval = int.Parse(textBox10.Text);
            }
            catch {
                Console.WriteLine("error button3");
            }
        }
        private void button4_Click(object sender, EventArgs e) {            
            try {
                Console.WriteLine("Button4 Pressed");
                button4Pressed = !button4Pressed;
                milliseconds = int.Parse(textBox9.Text);
                ip4 = IPAddress.Parse(textBox4.Text);
                myTimer.Interval = int.Parse(textBox10.Text);
            }
            catch {
                Console.WriteLine("error button4");
            }
        }
        private void button5_Click(object sender, EventArgs e) {
            reportTime = DateTime.Now.ToShortTimeString();
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFile.FilterIndex = 1;
            if (saveFile.ShowDialog() == DialogResult.OK) {
                File.WriteAllText(saveFile.FileName, "Start: " + startTime + " " + "End: " + reportTime + "\r\nTimeout: " + textBox9.Text + " Frequency: " + textBox10.Text + "\r\n" + textBox1.Text + ":\r\n" + textBox5.Text + "\r\n" + textBox2.Text + ":\r\n" + textBox6.Text + "\r\n" + textBox3.Text + ":\r\n" + textBox7.Text + "\r\n" + textBox4.Text + ":\r\n" + textBox8.Text);
            }
        }
        private void InitializeTimer() {
            // Call this procedure when the application starts.  
            // Set to 1 second.  
            myTimer.Interval = int.Parse(textBox10.Text);
            myTimer.Tick += new EventHandler(Timer1_Tick);

            // Enable timer.  
            myTimer.Enabled = true;
        }
        private void Timer1_Tick(object Sender, EventArgs e) {
            Console.WriteLine("Tick");
            count++;
            if (button1Pressed == true) {
                new PingIP(ip1, textBox5, textBox1, milliseconds, count);
            }
            if(button2Pressed == true) {
                new PingIP(ip2, textBox6, textBox2, milliseconds, count);
            }
            if(button3Pressed == true) {
                new PingIP(ip3, textBox7, textBox3, milliseconds, count);
            }
            if(button4Pressed == true) {
                new PingIP(ip4, textBox8, textBox4, milliseconds, count);
            }
        }

        private void label3_Click(object sender, EventArgs e) {

        }
    }
}