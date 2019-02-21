using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Timers;
using System.Windows.Forms;

namespace PingTest {
    internal class PingIP {        
        Ping ping = new Ping();

        public PingIP(IPAddress ip, TextBox textBox, TextBox pingBox) {    
            try {
                PingReply reply = ping.Send(ip, 1000);
                if (reply.Status == IPStatus.Success) {
                    textBox.Text = textBox.Text + "Ping to " + pingBox.Text + " @ " + reply.RoundtripTime.ToString() + "ms" + "\r\n";
                }
                else {
                    textBox.Text = textBox.Text + "Ping to " + pingBox.Text + " FAILED" + "\r\n";
                }
            }
            catch(Exception exception) {
                textBox.Text = exception.ToString();
            }
        }
    }
}