using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Timers;
using System.Windows.Forms;

namespace PingTest {
    internal class PingIP {        
        Ping ping = new Ping();

        public PingIP(IPAddress ip, TextBox textBox, TextBox pingBox) {            
            PingReply reply = ping.Send(ip, 1000);

            if (reply.Status == IPStatus.Success) {
                textBox.Text = textBox.Text + "Ping to " + pingBox.Text + " SUCCESSFUL - " + reply.RoundtripTime.ToString() + "ms" + "\r\n";
            }
            else {
                textBox.Text = textBox.Text + "Ping to " + pingBox.Text + "FAILED - " + "Response delay = " + reply.RoundtripTime.ToString() + "ms" + "\r\n";
            }
        }
    }
}