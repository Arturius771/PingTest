﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace PingTest {
    internal class PingIP {        
        Ping ping = new Ping();
        public PingIP(IPAddress ip, TextBox textBox, TextBox pingBox, int timeout, int count, List<String> failureCount, Label failLabel) {    
            try {
                int failCount = int.Parse(failLabel.Text);
                PingReply reply = ping.Send(ip, timeout);                
                if (reply.Status == IPStatus.Success) {
                    textBox.Text = count + ". Ping " + pingBox.Text + " " + reply.RoundtripTime.ToString() + "ms" + "\r\n" + textBox.Text;
                    textBox.BackColor = Color.Turquoise;
                }
                else {
                    failCount++;
                    failureCount.Add(count + " " + pingBox.Text + " FAILED " + DateTime.Now.ToShortTimeString());
                    textBox.Text = count + ". Ping " + pingBox.Text + " FAILED" + "\r\n" + textBox.Text;
                    failLabel.Text = failCount.ToString();
                    textBox.BackColor = Color.Salmon;                    
                }
            }
            catch(Exception exception) {
                textBox.Text = exception.ToString();
            }
        }
    }
}