using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace pingtester
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            LoadDnsOptions();
        }

        private void LoadDnsOptions()
        {
            // Yaygın DNS listesi
            var dnsList = new Dictionary<string, string>
        {
           { "Google DNS", "8.8.8.8 8.8.4.4" },
           { "Cloudflare", "1.1.1.1 1.0.0.1" },
           { "OpenDNS", "208.67.222.222 208.67.220.220" },
           { "Quad9", "9.9.9.9 149.112.112.112" },
           { "Yandex", "77.88.8.8 77.88.8.1" },
           { "AdGuard", "94.140.14.14 94.140.15.15" },
           { "Comodo", "8.26.56.26 8.20.247.20" },
           { "CleanBrowsing Family Filter", "185.228.168.168 185.228.169.168" },
           { "CleanBrowsing Adult Filter", "185.228.168.10 185.228.169.11" },
           { "CleanBrowsing Security Filter", "185.228.168.9 185.228.169.9" },
           { "DNS.Watch", "84.200.69.80 84.200.70.40" },
           { "Verisign", "64.6.64.6 64.6.65.6" },
           { "Neustar DNS Family Secure", "156.154.70.3 156.154.71.3" },
           { "Neustar DNS Threat Protection", "156.154.70.2 156.154.71.2" },
           { "Alternate DNS", "76.76.19.19 76.223.122.150" },
           { "OpenNIC", "192.71.245.208 94.247.43.254" },
           { "UncensoredDNS", "91.239.100.100 89.233.43.71" },
           { "CyberGhost DNS", "38.132.106.139 194.187.251.67" },
           { "Mullvad DNS", "193.138.218.74 185.213.154.27" },
           { "ControlD (Tracker Block)", "76.76.2.2 76.76.10.2" },
           { "ControlD (Malware Block)", "76.76.2.1 76.76.10.1" },
           { "ArgoVPN DNS", "185.51.200.2 185.51.200.3" }
         };

            comboBox1.Items.Clear();
            foreach (var kvp in dnsList)
            {
                comboBox1.Items.Add($"{kvp.Key} ({kvp.Value})");
            }

            comboBox1.Tag = dnsList;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Please select a DNS.");
                return;
            }

            var selectedText = comboBox1.SelectedItem.ToString();
            var dnsList = (Dictionary<string, string>)comboBox1.Tag;

            foreach (var kvp in dnsList)
            {
                if (selectedText.StartsWith(kvp.Key))
                {
                    string dns1 = kvp.Value.Split(' ')[0];
                    string dns2 = kvp.Value.Split(' ')[1];

                    string interfaceName = GetActiveInterfaceName();
                    if (interfaceName == null)
                    {
                        MessageBox.Show("No active network connection found.");
                        return;
                    }

                    bool result = SetDNS(interfaceName, dns1, dns2);

                    if (result)
                        MessageBox.Show($"DNS successfully changed to: {dns1}, {dns2}");
                    else
                        MessageBox.Show("Failed to set DNS. Please make sure the application is running as administrator.");
                    return;
                }
            }
        }

        private string GetActiveInterfaceName()
        {
            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (ni.OperationalStatus == OperationalStatus.Up &&
                    ni.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                {
                    return ni.Name;
                }
            }
            return null;
        }

        private bool SetDNS(string interfaceName, string dns1, string dns2)
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo("netsh", $"interface ip set dns name=\"{interfaceName}\" static {dns1}")
                {
                    Verb = "runas",
                    CreateNoWindow = true,
                    UseShellExecute = true
                };
                Process.Start(psi)?.WaitForExit();

                ProcessStartInfo psi2 = new ProcessStartInfo("netsh", $"interface ip add dns name=\"{interfaceName}\" {dns2} index=2")
                {
                    Verb = "runas",
                    CreateNoWindow = true,
                    UseShellExecute = true
                };
                Process.Start(psi2)?.WaitForExit();

                return true;
            }
            catch
            {
                return false;
            }
        }
        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string interfaceName = GetActiveInterfaceName();
            if (interfaceName == null)
            {
                MessageBox.Show("No active network connection found.");
                return;
            }

            bool result = ResetDNS(interfaceName);

            if (result)
                MessageBox.Show("DNS settings reset to automatic.");
            else
                MessageBox.Show("Failed to reset DNS. Please make sure the application is running as administrator.");
        }

        private bool ResetDNS(string interfaceName)
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo("netsh", $"interface ip set dns name=\"{interfaceName}\" source=dhcp")
                {
                    Verb = "runas",
                    CreateNoWindow = true,
                    UseShellExecute = true
                };
                Process.Start(psi)?.WaitForExit();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
