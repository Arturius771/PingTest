﻿using System;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;

namespace PingTest {
    public partial class Form1 : Form {
        static Timer myTimer = new Timer();
        bool button1Pressed = false;
        bool button2Pressed = false;
        bool button3Pressed = false;
        bool button4Pressed = false;
        static List<string> failureCount1 = new List<string>();
        static List<string> failureCount2 = new List<string>();
        static List<string> failureCount3 = new List<string>();
        static List<string> failureCount4 = new List<string>();
        LastFailTime lft1 = new LastFailTime();
        LastFailTime lft2 = new LastFailTime();
        LastFailTime lft3 = new LastFailTime();
        LastFailTime lft4 = new LastFailTime();
        IPAddress ip1;
        IPAddress ip2;
        IPAddress ip3;
        IPAddress ip4;
        int timeout;
        int pingCount = 0;        
        string startTime;
        string reportTime;
        string failureOnlyLog;
        Color originalColor = Form1.DefaultBackColor;
       


        public Form1() {
            Console.WriteLine("Hello");
            InitializeComponent();
            InitializeTimer();
            timeout = int.Parse(textBox9.Text);
            startTime = DateTime.Now.ToString("dd-MM-yyyy HH-mm");
        }
        private void button1_Click(object sender, EventArgs e) {
            try {
                Console.WriteLine("Button1 Pressed");
                button1Pressed = !button1Pressed;
                timeout = int.Parse(textBox9.Text);
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
                timeout = int.Parse(textBox9.Text);
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
                timeout = int.Parse(textBox9.Text);
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
                timeout = int.Parse(textBox9.Text);
                ip4 = IPAddress.Parse(textBox4.Text);
                myTimer.Interval = int.Parse(textBox10.Text);
            }
            catch {
                Console.WriteLine("error button4");
            }
        }
        private void button5_Click(object sender, EventArgs e) {            
            SaveFileDialog saveFile = new SaveFileDialog {
                Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*",
                FilterIndex = 1
            };

            reportTime = DateTime.Now.ToString("dd-MM-yyyy HH-mm");
            saveFile.FileName = "Ping Test " + reportTime;
            if (saveFile.ShowDialog() == DialogResult.OK) {
                failureOnlyLog = string.Join("\r\n", failureCount1.ToArray()) + "\r\n" + string.Join("\r\n", failureCount2.ToArray()) + "\r\n" + string.Join("\r\n", failureCount3.ToArray()) + "\r\n" + string.Join("\r\n", failureCount4.ToArray());
                File.WriteAllText(saveFile.FileName, "Start: " + startTime + " " + "End: " + reportTime + "\r\nTimeout: " + textBox9.Text + " Frequency: " + textBox10.Text + "\r\n" + failureOnlyLog + "\r\n" + textBox1.Text + ":\r\n" + textBox5.Text + "\r\n" + textBox2.Text + ":\r\n" + textBox6.Text + "\r\n" + textBox3.Text + ":\r\n" + textBox7.Text + "\r\n" + textBox4.Text + ":\r\n" + textBox8.Text);
            }
        }
        private void button6_Click(object sender, EventArgs e) {

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
            pingCount++;
            if (button1Pressed == true) {
                new PingIP(ip1, textBox5, textBox1, timeout, pingCount, failureCount1, label8, lft1);
                button1.Text = "Stop";
            }
            else {
                button1.Text = "Ping";
                textBox5.BackColor = originalColor;
            }
            if(button2Pressed == true) {
                new PingIP(ip2, textBox6, textBox2, timeout, pingCount, failureCount2, label9, lft2);
                button2.Text = "Stop";
            }
            else {
                button2.Text = "Ping";
                textBox6.BackColor = originalColor;
            }
            if (button3Pressed == true) {
                new PingIP(ip3, textBox7, textBox3, timeout, pingCount, failureCount3, label11, lft3);
                button3.Text = "Stop";
            }
            else {
                button3.Text = "Ping";
                textBox7.BackColor = originalColor;
            }
            if (button4Pressed == true) {
                new PingIP(ip4, textBox8, textBox4, timeout, pingCount, failureCount4, label13, lft4);
                button4.Text = "Stop";
            }
            else {
                button4.Text = "Ping";
                textBox8.BackColor = originalColor;
            }
        }
        private void Form1_Resize(object sender, EventArgs e) {
            if (this.WindowState == FormWindowState.Minimized) {
                Hide();
                notifyIcon1.Visible = true;
            }
        }//minimize and hide in notification area
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e) {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }        
    }
}