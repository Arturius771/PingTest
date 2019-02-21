using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace PingTest {
    internal class PingIP {        
        Ping ping = new Ping();

        public PingIP(IPAddress ip, TextBox textBox, TextBox pingBox, int milliseconds, int count) {    
            try {
                PingReply reply = ping.Send(ip, milliseconds);
                if (reply.Status == IPStatus.Success) {
                    textBox.Text = count + ". Ping to " + pingBox.Text + " @ " + reply.RoundtripTime.ToString() + "ms" + "\r\n" + textBox.Text;
                }
                else {
                    textBox.Text = count + ". Ping to " + pingBox.Text + " FAILED" + "\r\n" + textBox.Text;
                }
            }
            catch(Exception exception) {
                textBox.Text = exception.ToString();
            }
        }
    }
}