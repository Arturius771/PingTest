using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace PingTest {
    internal class PingIP {        
        Ping ping = new Ping();

        public PingIP(IPAddress ip, TextBox textBox, TextBox pingBox, int timeout, int count, List<String> failureCount) {    
            try {
                PingReply reply = ping.Send(ip, timeout);
                if (reply.Status == IPStatus.Success) {
                    textBox.Text = count + "Ping to " + pingBox.Text + " " + reply.RoundtripTime.ToString() + "ms" + "\r\n" + textBox.Text;
                    textBox.BackColor = Color.Turquoise;
                }
                else {
                    failureCount.Add(count + pingBox.Text + " FAILED " + DateTime.Now.ToShortTimeString());
                    textBox.Text = count + "Ping to " + pingBox.Text + " FAILED" + "\r\n" + textBox.Text;
                    textBox.BackColor = Color.Salmon;                    
                }
            }
            catch(Exception exception) {
                textBox.Text = exception.ToString();
            }
        }
    }
}