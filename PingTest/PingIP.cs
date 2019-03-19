using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace PingTest {
    internal class PingIP {        
        Ping ping = new Ping();

        public PingIP(IPAddress ip, TextBox outputTextbox, TextBox pingBox, int timeout, int count, List<String> failureCount, List<String> allPings, Label failureLabel, LastFailTime lft) {    
            try {                
                int failCount = int.Parse(failureLabel.Text);
                PingReply reply = ping.Send(ip, timeout);
                
                if (reply.Status == IPStatus.Success) {
                    allPings.Add(count + ". Ping to " + pingBox.Text + " " + reply.RoundtripTime.ToString() + "ms");
                    outputTextbox.Text = count + ". Ping to " + pingBox.Text + " " + reply.RoundtripTime.ToString() + "ms";
                    outputTextbox.BackColor = Color.Turquoise;
                }
                else {
                    string now = DateTime.Now.ToString("HH:mm");
                    failCount++;
                    failureLabel.Text = failCount.ToString();
                    outputTextbox.Text = count + ". Ping to " + pingBox.Text + " FAILED";                    
                    allPings.Add(count + ". Ping to " + pingBox.Text + " FAILED");
                    if (now != lft.lastFailTimeGetSet) {
                        failureCount.Add("FAILED " + DateTime.Now.ToString("HH:mm") + " " + pingBox.Text);
                        lft.lastFailTimeGetSet = DateTime.Now.ToString("HH:mm");
                    }
                    outputTextbox.BackColor = Color.Salmon;
                    Console.WriteLine(lft.lastFailTimeGetSet + "check");
                }
            }
            catch(Exception exception) {
                outputTextbox.Text = exception.ToString();
            }            
        }
    }
}