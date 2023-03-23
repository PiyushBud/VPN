using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net.Sockets;

namespace VPN
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Connect_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Singapore") 
            {
                if (radioButton1.Checked) //UDP
                {
                    //Init new process
                    Process process = new Process();
                    ProcessStartInfo startInfo = new ProcessStartInfo();

                    //Declare process start information
                    startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    startInfo.FileName = @"S:\Program Files\OpenVPN\bin\openvpn.exe";
                    startInfo.Arguments = "--config sgudp.ovpn";
                    startInfo.Verb = "runas";
                    process.StartInfo = startInfo;

                    //Start process
                    process.Start();
                    MessageBox.Show("You've connected to server with udp.");
                }
                else if (radioButton2.Checked) //TCP
                {
                    //Init new process
                    Process process = new Process();
                    ProcessStartInfo startInfo = new ProcessStartInfo();

                    //Declare process start information
                    startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    startInfo.FileName = @"S:\Program Files\OpenVPN\bin\openvpn.exe";
                    startInfo.Arguments = "--config sgudp.ovpn";
                    startInfo.Verb = "runas";
                    process.StartInfo = startInfo;

                    //Start process
                    process.Start();
                    MessageBox.Show("You've connected to server with tcp.");
                }
            }
        }

        private void Disconnect_Click(object sender, EventArgs e)
        {
            disconnect();
            MessageBox.Show("You've disconnected from the server.");
        }

        private void disconnect()
        {
            //Kill the opened process
            Process.Start(new ProcessStartInfo
            {
                FileName = "taskkill",
                Arguments = $"/f /im openvpn.exe",
                CreateNoWindow = true,
                UseShellExecute = false
            }).WaitForExit();
        }
    }
}
