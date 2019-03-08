﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace PingTest {
    internal class PingIP {        
        Ping ping = new Ping();

        public PingIP(IPAddress ip, TextBox textBox, TextBox pingBox, int timeout, int count, List<String> failureCount, Label failureLabel, LastFailTime lft) {    
            try {                
                int failCount = int.Parse(failureLabel.Text);
                PingReply reply = ping.Send(ip, timeout);
                
                if (reply.Status == IPStatus.Success) {
                    textBox.Text = count + " Ping to " + pingBox.Text + " " + reply.RoundtripTime.ToString() + "ms" + "\r\n";//changed in performance test
                    textBox.BackColor = Color.Turquoise;
                }
                else {
                    string now = DateTime.Now.ToString("HH:mm");

                    failCount++;
                    failureLabel.Text = failCount.ToString();
                    textBox.Text = count + ". Ping to " + pingBox.Text + " FAILED" + "\r\n";      //changed in performance test              
                    textBox.BackColor = Color.Salmon;
                    if(now != lft.lastFailTimeGetSet) {
                        failureCount.Add(pingBox.Text + " FAILED " + DateTime.Now.ToString("HH:mm"));
                        lft.lastFailTimeGetSet = DateTime.Now.ToString("HH:mm");
                    }
                    Console.WriteLine(lft.lastFailTimeGetSet + "check");
                }
            }
            catch(Exception exception) {
                textBox.Text = exception.ToString();
            }
            
        }
    }
}