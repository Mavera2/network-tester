using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SpeedTest;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace pingtester
{
    public partial class Form1 : Form
    {
        string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Game_Server_Tracert.txt");
        private void fadeInTimer_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1)
                this.Opacity += 0.05;
            else
                fadeInTimer.Stop();
        }
        public Form1()
        {
            InitializeComponent();
            InitializeGrid();
        }

        private void InitializeGrid()
        {
            dataGridResults.Columns.Clear();
            dataGridResults.Columns.Add("Name", "Name");
            dataGridResults.Columns.Add("Location", "Location");
            dataGridResults.Columns.Add("IP", "IP");
            dataGridResults.Columns.Add("Result", "Result");
            dataGridResults.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dataGridResults.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridResults.RowTemplate.Height = 28;
            dataGridResults.AllowUserToAddRows = false;
        }

        private void ClearGrid()
        {
            dataGridResults.Columns.Clear();
        }

        private void AddPingResult(string category, string location, string ip, string result)
        {
            int rowIndex = dataGridResults.Rows.Add(category, location, ip, result);
            var cell = dataGridResults.Rows[rowIndex].Cells[3];

            if (result.Contains("Timeout") || result.Contains("Error"))
                cell.Style.ForeColor = Color.Red;
            else if (int.TryParse(result.Replace(" ms", ""), out int ping))
                cell.Style.ForeColor = ping < 50 ? Color.Green : Color.Orange;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            ClearGrid();



            await PingCategory("Apex Legends", new (string, string)[] { ("Amsterdam", "162.62.97.238") });
            await PingCategory("Battle.net Auth", new (string, string)[] { ("EU", "185.60.112.157"), ("US East", "137.221.106.104") });
            await PingCategory("Blizzard", new (string, string)[] { ("Europe 2", "185.60.112.157") });
            await PingCategory("CS2", new (string, string)[] { ("Stockholm", "146.66.152.1"), ("Valve Frankfurt", "146.66.155.1") });
            await PingCategory("Epic Games", new (string, string)[] { ("Europe 1", "52.28.63.252"), ("Europe 2", "185.60.112.157") });
            await PingCategory("ETS II", new (string, string)[] { ("TruckersMP", "145.239.131.35") });
            await PingCategory("Faceit", new (string, string)[] { ("England", "185.38.150.1"), ("Germany", "5.188.238.133"), ("Holland", "85.159.239.121") });
            await PingCategory("Fortnite", new (string, string)[] { ("Europe", "185.60.112.157") });
            await PingCategory("Geforce NOW", new (string, string)[] { ("Ankara", "85.29.14.132"), ("Istanbul", "85.29.18.132") });
            await PingCategory("League of Legends", new (string, string)[] { ("Istanbul", "104.160.143.212") });
            await PingCategory("Minecraft", new (string, string)[] { ("Hypixel", "116.202.118.107"), ("Mineplex", "104.238.130.180") });
            await PingCategory("Overwatch 2", new (string, string)[] { ("EU", "185.60.112.157") });
            await PingCategory("Palworld (Steam)", new (string, string)[] { ("Backup Relay", "146.66.152.12"), ("Steam Relay", "146.66.155.1") });
            await PingCategory("PUBG", new (string, string)[] { ("Frankfurt", "35.156.63.252"), ("Global", "13.124.63.251") });
            await PingCategory("PUBG Mobile", new (string, string)[] { ("Frankfurt", "162.62.97.238") });
            await PingCategory("Riot Games", new (string, string)[] {("Frankfurt", "104.160.143.124"),("Istanbul", "104.160.143.212"),
                ("Paris", "104.160.154.64"),("Stockholm", "104.160.143.99"),("Warsaw", "104.160.151.216")});
            await PingCategory("Rust (Facepunch)", new (string, string)[] { ("EU", "51.210.223.171") });
            await PingCategory("Steam", new (string, string)[] { ("Vienna", "146.66.155.1") });
            await PingCategory("Steam CDN", new (string, string)[] { ("CDN Amsterdam", "155.133.248.34"), ("Valve EU", "146.66.152.12") });
            await PingCategory("World of Tanks", new (string, string)[] { ("EU", "92.223.6.11") });
            await PingCategory("World of Warcraft", new (string, string)[] { ("EU", "185.60.112.157") });



        }

        private async Task PingCategory(string category, (string name, string ip)[] servers)
        {
            foreach (var (name, ip) in servers)
            {
                string result = await GetPing(ip);
                AddPingResult(category, name, ip, result);
            }
        }

        private void button2_MouseEnter(object sender, EventArgs e) => button2.BackColor = Color.Gainsboro;
        private void button2_MouseLeave(object sender, EventArgs e) => button2.BackColor = Color.White;



        private void buttonExit_Click(object sender, EventArgs e) => this.Close();
        private async Task<string> GetPing(string ip)
        {
            try
            {
                Ping ping = new Ping();
                PingReply reply = await ping.SendPingAsync(ip, 1000);

                if (reply.Status == IPStatus.Success)
                    return $"{reply.RoundtripTime} ms";
                else
                    return "Timeout";
            }
            catch
            {
                return "Error";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClearGrid();
            dataGridResults.Columns.Add("Name", "Name");
            dataGridResults.Columns.Add("Location", "Location");
            dataGridResults.Columns.Add("IP", "IP");
            dataGridResults.Columns.Add("Result", "Result");
            var dnsServers = new List<DnsServer>
         {
            new DnsServer("CloudFlare", "1.1.1.1"),
            new DnsServer("CloudFlare Secondary", "1.0.0.1"),
            new DnsServer("Google", "8.8.8.8"),
            new DnsServer("Google Secondary", "8.8.4.4"),
            new DnsServer("OpenDNS", "208.67.222.222"),
            new DnsServer("OpenDNS Secondary", "208.67.220.220"),
            new DnsServer("OpenDNS FamilyShield", "208.67.222.123"),
            new DnsServer("Quad9", "9.9.9.9"),
            new DnsServer("Quad9 Secondary", "149.112.112.112"),
            new DnsServer("Norton", "198.153.192.1"),
            new DnsServer("Level3", "209.244.0.3"),
            new DnsServer("Yandex", "77.88.8.8"),
            new DnsServer("Yandex Secondary", "77.88.8.1"),
            new DnsServer("Yandex Family", "77.88.8.7"),
            new DnsServer("Comodo Secure", "8.26.56.26"),
            new DnsServer("Comodo Secure Secondary", "8.20.247.20"),
            new DnsServer("CleanBrowsing", "185.228.168.9"),
            new DnsServer("CleanBrowsing Family", "185.228.168.168"),
            new DnsServer("CleanBrowsing Adult", "185.228.168.10"),
            new DnsServer("Neustar DNS", "156.154.70.1"),
            new DnsServer("Neustar Threat Protection", "156.154.70.2"),
            new DnsServer("Neustar Family Secure", "156.154.70.3"),
            new DnsServer("Alternate DNS", "76.76.19.19"),
            new DnsServer("Alternate DNS Secondary", "76.223.122.150"),
            new DnsServer("OpenNIC", "192.71.245.208"),
            new DnsServer("OpenNIC Secondary", "94.247.43.254"),
            new DnsServer("UncensoredDNS", "91.239.100.100"),
            new DnsServer("UncensoredDNS Secondary", "89.233.43.71"),
            new DnsServer("ControlD (Tracker Block)", "76.76.2.2"),
            new DnsServer("ControlD (Malware Block)", "76.76.2.1"),
            new DnsServer("AdGuard", "94.140.14.14"),
            new DnsServer("AdGuard Secondary", "94.140.15.15"),
            new DnsServer("Mullvad DNS", "193.138.218.74"),
            new DnsServer("Mullvad Secondary", "185.213.154.27"),
            new DnsServer("DNS.Watch", "84.200.69.80"),
            new DnsServer("DNS.Watch Secondary", "84.200.70.40"),
            new DnsServer("Verisign", "64.6.64.6"),
            new DnsServer("Verisign Secondary", "64.6.65.6"),
            new DnsServer("ArgoVPN DNS", "185.51.200.2"),
            new DnsServer("ArgoVPN Secondary", "185.51.200.3"),
            new DnsServer("TTNet (Türk Telekom)", "195.175.39.49")
        };


            foreach (var server in dnsServers)
            {
                var result = PingDnsServer(server.IpAddress);
                AddPingResult("DNS", server.Name, server.IpAddress, result);
            }
        }

        private string PingDnsServer(string ipAddress)
        {
            try
            {
                var ping = new Ping();
                var reply = ping.Send(ipAddress, 1000);
                return reply.Status == IPStatus.Success ? $"{reply.RoundtripTime} ms" : "Timeout";
            }
            catch
            {
                return "Error";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ClearGrid();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        public class DnsServer
        {
            public string Name { get; set; }
            public string IpAddress { get; set; }

            public DnsServer(string name, string ipAddress)
            {
                Name = name;
                IpAddress = ipAddress;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeGrid();

        }
        

        private async void tracerButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This test will take approximately 30 minutes.");

            SetupLogGrid();
            AddLog("Tracer test starting");
            tracerButton.Enabled = false;
            File.WriteAllText(filePath, $"Game Server Tracert - {DateTime.Now}\r\n\r\n");

            var servers = new (string Name, string IP)[]
            {
            ("Steam - Vienna", "146.66.155.1"),
            ("Epic Games - Europe 1", "52.28.63.252"),
            ("Epic Games - Europe 2", "52.47.193.251"),
            ("Amazon - Central", "52.28.63.252"),
            ("Amazon - London", "52.94.52.55"),
            ("GeforceNOW - Ankara", "85.29.14.132"),
            ("GeforceNOW - Istanbul", "85.29.18.132"),
            ("Riot Games - Istanbul", "104.160.143.212"),
            ("Riot Games - Frankfurt", "104.160.143.124"),
            ("Riot Games - Warsaw", "104.160.151.216"),
            ("Riot Games - Paris", "104.160.154.64"),
            ("Riot Games - Stockholm", "104.160.143.99"),
            ("Faceit - Turkiye", "213.128.77.221"),
            ("Faceit - Germany", "78.31.67.209"),
            ("Faceit - Holland", "85.159.239.121"),
            ("Faceit - France", "51.91.106.63"),
            ("Faceit - England", "185.38.150.1"),
            ("Blizzard - Europe 1", "185.60.114.159"),
            ("Blizzard - Europe 2", "185.60.112.157"),
            ("Apex Legends - Frankfurt", "52.58.81.34"),
            ("Apex Legends - Amsterdam", "162.62.97.238"),
            ("Minecraft - Hypixel", "116.202.118.107"),
            ("Minecraft - CubeCraft", "213.32.113.22"),
            ("PUBG - Frankfurt", "35.156.63.252"),
            ("PUBG Mobile - Frankfurt", "162.62.97.238"),
            ("ETS II - TruckersMP", "145.239.131.35")
            };

            foreach (var server in servers)
            {
                await RunTracert(server.Name, server.IP);
            }

            tracerButton.Enabled = true;
            MessageBox.Show("Test completed. Saved to desktop.");
        }

        private Task RunTracert(string name, string ip)
        {
            return Task.Run(() =>
            {
                AppendToFile($"===========================================\r\n{name} - please wait.\r\n");

                ProcessStartInfo psi = new ProcessStartInfo("tracert", $"-4 {ip}")
                {
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    StandardOutputEncoding = Encoding.UTF8
                };

                using (Process proc = Process.Start(psi))
                {
                    string output = proc.StandardOutput.ReadToEnd();
                    AppendToFile(output + "\r\n");
                }
            });
        }

        private void AppendToFile(string content)
        {
            File.AppendAllText(filePath, content);
        }
        private void SetupLogGrid()
        {
            dataGridResults.Columns.Clear();
            dataGridResults.Columns.Add("Time", "Time");
            dataGridResults.Columns.Add("Message", "Message");
            dataGridResults.Columns["Time"].Width = 100;
            dataGridResults.Columns["Message"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        private void AddLog(string message)
        {
            string time = DateTime.Now.ToString("HH:mm:ss");

            if (dataGridResults.InvokeRequired)
            {
                dataGridResults.Invoke(new Action(() =>
                {
                    dataGridResults.Rows.Add(time, message);
                    dataGridResults.FirstDisplayedScrollingRowIndex = dataGridResults.RowCount - 1;
                }));
            }
            else
            {
                dataGridResults.Rows.Add(time, message);
                dataGridResults.FirstDisplayedScrollingRowIndex = dataGridResults.RowCount - 1;
            }

        }

        private async void button4_Click(object sender, EventArgs e)
        {
            ClearGrid();
            dataGridResults.Columns.Add("Name", "Name");
            dataGridResults.Columns.Add("Location", "Location");
            dataGridResults.Columns.Add("IP", "IP");
            dataGridResults.Columns.Add("Result", "Result");
            await PingCategory("Instagram", new (string, string)[] { ("EU", "instagram.com") });
            await PingCategory("Facebook", new (string, string)[] { ("EU", "facebook.com") });
            await PingCategory("Kick", new (string, string)[] { ("TR", "kick.com") });
            await PingCategory("Twitch", new (string, string)[] { ("TR", "twitch.tv") });
            await PingCategory("Spotify", new (string, string)[] { ("TR", "spotify.com") });
            await PingCategory("Youtube", new (string, string)[] { ("TR", "youtube.com") });
            await PingCategory("Tiktok", new (string, string)[] { ("TR", "tiktok.com") });
            await PingCategory("Whatsapp", new (string, string)[] { ("TR", "whatsapp.com") });
            await PingCategory("Disney+", new (string, string)[] { ("TR", "disneyplus.com") });
            await PingCategory("Amazon", new (string, string)[] { ("Global", "amazon.com") });
            await PingCategory("Trendyol", new (string, string)[] { ("TR", "trendyol.com") });
            await PingCategory("Hepsiburada", new (string, string)[] { ("TR", "hepsiburada.com") });
            await PingCategory("n11", new (string, string)[] { ("TR", "n11.com") });
            await PingCategory("Sahibinden", new (string, string)[] { ("TR", "sahibinden.com") });
            await PingCategory("LinkedIn", new (string, string)[] { ("TR", "linkedin.com") });
            await PingCategory("Twitter", new (string, string)[] { ("TR", "twitter.com") });
            await PingCategory("Reddit", new (string, string)[] { ("TR", "reddit.com") });
            await PingCategory("OpenAI", new (string, string)[] { ("TR", "openai.com") });
            await PingCategory("GitHub", new (string, string)[] { ("TR", "github.com") });
            await PingCategory("Steam", new (string, string)[] { ("TR", "store.steampowered.com") });
            await PingCategory("Google", new (string, string)[] { ("TR", "google.com") });
            await PingCategory("Apple", new (string, string)[] { ("Global", "apple.com") });
            await PingCategory("Yandex", new (string, string)[] { ("RU", "yandex.ru") });
            await PingCategory("Zoom", new (string, string)[] { ("TR", "zoom.us") });
            await PingCategory("Google Drive", new (string, string)[] { ("Global", "drive.google.com") });
            await PingCategory("Google Maps", new (string, string)[] { ("Global", "maps.google.com") });
            await PingCategory("Gmail", new (string, string)[] { ("Global", "mail.google.com") });
            await PingCategory("Outlook", new (string, string)[] { ("Global", "outlook.live.com") });
            await PingCategory("Microsoft Teams", new (string, string)[] { ("Global", "teams.microsoft.com") });
            await PingCategory("Snapchat", new (string, string)[] { ("TR", "snapchat.com") });
            await PingCategory("Pinterest", new (string, string)[] { ("Global", "pinterest.com") });
            await PingCategory("Coursera", new (string, string)[] { ("Global", "coursera.org") });
            await PingCategory("Udemy", new (string, string)[] { ("TR", "udemy.com") });
            await PingCategory("Medium", new (string, string)[] { ("Global", "medium.com") });
            await PingCategory("Vimeo", new (string, string)[] { ("TR", "vimeo.com") });
            await PingCategory("Dailymotion", new (string, string)[] { ("EU", "dailymotion.com") });
            await PingCategory("SoundCloud", new (string, string)[] { ("Global", "soundcloud.com") });
            await PingCategory("Canva", new (string, string)[] { ("Global", "canva.com") });
            await PingCategory("Pixabay", new (string, string)[] { ("TR", "pixabay.com") });
            await PingCategory("Wetransfer", new (string, string)[] { ("Global", "wetransfer.com") });
            await PingCategory("Speedtest", new (string, string)[] { ("Global", "speedtest.net") });
            await PingCategory("Amazon", new (string, string)[] { ("Central", "52.28.63.252"), ("West", "52.94.52.55") });


        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string filePath = Path.Combine(desktopPath, "Test Results.txt");

                // Sütun genişliklerini hesapla
                int[] columnWidths = new int[dataGridResults.Columns.Count];
                for (int i = 0; i < dataGridResults.Columns.Count; i++)
                {
                    int maxWidth = dataGridResults.Columns[i].HeaderText.Length;

                    foreach (DataGridViewRow row in dataGridResults.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            string cellValue = row.Cells[i].Value?.ToString() ?? "";
                            if (cellValue.Length > maxWidth)
                                maxWidth = cellValue.Length;
                        }
                    }

                    columnWidths[i] = maxWidth + 2; // Fazladan boşluk
                }

                using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8))
                {
                    writer.WriteLine("Date: " + DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss"));
                    writer.WriteLine(); // Boş satır

                    // Başlıkları hizalı yaz
                    for (int i = 0; i < dataGridResults.Columns.Count; i++)
                    {
                        string header = dataGridResults.Columns[i].HeaderText;
                        writer.Write(header.PadRight(columnWidths[i]));
                    }
                    writer.WriteLine();

                    // Alt çizgi
                    for (int i = 0; i < dataGridResults.Columns.Count; i++)
                    {
                        writer.Write(new string('-', columnWidths[i]));
                    }
                    writer.WriteLine();

                    // Satırları yaz
                    foreach (DataGridViewRow row in dataGridResults.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            for (int i = 0; i < dataGridResults.Columns.Count; i++)
                            {
                                string cellValue = row.Cells[i].Value?.ToString() ?? "";
                                writer.Write(cellValue.PadRight(columnWidths[i]));
                            }
                            writer.WriteLine();
                        }
                    }
                }

                MessageBox.Show("Data successfully saved to desktop as 'Test Results.txt'.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private async void button6_Click(object sender, EventArgs e)
        {
            ClearGrid();
            dataGridResults.Columns.Add("Name", "Name");
            dataGridResults.Columns.Add("Location", "Location");
            dataGridResults.Columns.Add("IP", "IP");
            dataGridResults.Columns.Add("Result", "Result");
            await PingCategory("Apex Legends", new (string, string)[] { ("Amsterdam", "162.62.97.238") });
            await PingCategory("Battle.net Auth", new (string, string)[] { ("EU", "185.60.112.157"), ("US East", "137.221.106.104") });
            await PingCategory("Blizzard", new (string, string)[] { ("Europe 2", "185.60.112.157") });
            await PingCategory("CS2", new (string, string)[] { ("Stockholm", "146.66.152.1"), ("Valve Frankfurt", "146.66.155.1") });
            await PingCategory("Epic Games", new (string, string)[] { ("Europe 1", "52.28.63.252"), ("Europe 2", "185.60.112.157") });
            await PingCategory("ETS II", new (string, string)[] { ("TruckersMP", "145.239.131.35") });
            await PingCategory("Faceit", new (string, string)[] { ("England", "185.38.150.1"), ("Germany", "5.188.238.133"), ("Holland", "85.159.239.121") });
            await PingCategory("Fortnite", new (string, string)[] { ("Europe", "185.60.112.157") });
            await PingCategory("Geforce NOW", new (string, string)[] { ("Ankara", "85.29.14.132"), ("Istanbul", "85.29.18.132") });
            await PingCategory("League of Legends", new (string, string)[] { ("Istanbul", "104.160.143.212") });
            await PingCategory("Minecraft", new (string, string)[] { ("Hypixel", "116.202.118.107"), ("Mineplex", "104.238.130.180") });
            await PingCategory("Overwatch 2", new (string, string)[] { ("EU", "185.60.112.157") });
            await PingCategory("Palworld (Steam)", new (string, string)[] { ("Backup Relay", "146.66.152.12"), ("Steam Relay", "146.66.155.1") });
            await PingCategory("PUBG", new (string, string)[] { ("Frankfurt", "35.156.63.252"), ("Global", "13.124.63.251") });
            await PingCategory("PUBG Mobile", new (string, string)[] { ("Frankfurt", "162.62.97.238") });
            await PingCategory("Riot Games", new (string, string)[] {("Frankfurt", "104.160.143.124"),("Istanbul", "104.160.143.212"),
                ("Paris", "104.160.154.64"),("Stockholm", "104.160.143.99"),("Warsaw", "104.160.151.216")});
            await PingCategory("Rust (Facepunch)", new (string, string)[] { ("EU", "51.210.223.171") });
            await PingCategory("Steam", new (string, string)[] { ("Vienna", "146.66.155.1") });
            await PingCategory("Steam CDN", new (string, string)[] { ("CDN Amsterdam", "155.133.248.34"), ("Valve EU", "146.66.152.12") });
            await PingCategory("World of Tanks", new (string, string)[] { ("EU", "92.223.6.11") });
            await PingCategory("World of Warcraft", new (string, string)[] { ("EU", "185.60.112.157") });

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();
            frm3.Show();
        }


        private void dataGridResults_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Sadece başlık hücrelerine tıklanırsa işlem yap
            if (e.RowIndex == -1 && e.ColumnIndex >= 0)
            {
                var column = dataGridResults.Columns[e.ColumnIndex];
                bool isNumeric = true;

                // Sütun verilerinin sayısal olup olmadığını kontrol et (örneğin "12 ms")
                foreach (DataGridViewRow row in dataGridResults.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        string value = row.Cells[e.ColumnIndex].Value?.ToString()?.ToLower().Replace("ms", "").Trim();
                        if (!double.TryParse(value, out _))
                        {
                            isNumeric = false;
                            break;
                        }
                    }
                }

                // Satırları al
                List<DataGridViewRow> rows = dataGridResults.Rows
                    .Cast<DataGridViewRow>()
                    .Where(r => !r.IsNewRow)
                    .ToList();

                // Sıralama yönünü kontrol et
                bool ascending = column.Tag == null || !(bool)column.Tag;
                column.Tag = ascending;

                if (isNumeric)
                {
                    rows = ascending
                        ? rows.OrderBy(r => Convert.ToDouble(r.Cells[e.ColumnIndex].Value?.ToString()?.ToLower().Replace("ms", "").Trim())).ToList()
                        : rows.OrderByDescending(r => Convert.ToDouble(r.Cells[e.ColumnIndex].Value?.ToString()?.ToLower().Replace("ms", "").Trim())).ToList();
                }
                else
                {
                    rows = ascending
                        ? rows.OrderBy(r => r.Cells[e.ColumnIndex].Value?.ToString()).ToList()
                        : rows.OrderByDescending(r => r.Cells[e.ColumnIndex].Value?.ToString()).ToList();
                }

                // Grid temizle, sıralanmış satırları yeniden ekle
                dataGridResults.Rows.Clear();
                foreach (var row in rows)
                {
                    int index = dataGridResults.Rows.Add();
                    for (int i = 0; i < dataGridResults.Columns.Count; i++)
                    {
                        dataGridResults.Rows[index].Cells[i].Value = row.Cells[i].Value;
                    }
                }
            }
        }

        private async void button3_Click_2(object sender, EventArgs e)
        {
            // DataGridView setup
            dataGridResults.Columns.Clear();
            dataGridResults.Rows.Clear();

            dataGridResults.RowHeadersVisible = false;

            dataGridResults.Columns.Add("host", "Host");
            dataGridResults.Columns.Add("sent", "Sent");
            dataGridResults.Columns.Add("received", "Received");
            dataGridResults.Columns.Add("lost", "Lost");
            dataGridResults.Columns.Add("loss", "Packet Loss (%)");

            // Host sütununu gizle (veri orada ama görünmez)
            dataGridResults.Columns["host"].Visible = false;

            // Dark theme styling
            dataGridResults.RowsDefaultCellStyle.BackColor = Color.FromArgb(30, 30, 30);
            dataGridResults.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 45);
            dataGridResults.DefaultCellStyle.ForeColor = Color.White;
            dataGridResults.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(50, 50, 50);
            dataGridResults.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridResults.EnableHeadersVisualStyles = false;

            string host = "google.com";
            int timeout = 1000;
            int duration = 10000;

            int sentPackets = 0;
            int receivedPackets = 0;

            var pingSender = new Ping();
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            await Task.Run(() =>
            {
                while (stopwatch.ElapsedMilliseconds < duration)
                {
                    try
                    {
                        PingReply reply = pingSender.Send(host, timeout);
                        Interlocked.Increment(ref sentPackets);

                        if (reply.Status == IPStatus.Success)
                        {
                            Interlocked.Increment(ref receivedPackets);
                        }
                    }
                    catch
                    {
                        Interlocked.Increment(ref sentPackets);
                    }
                }
            });

            stopwatch.Stop();

            int lostPackets = sentPackets - receivedPackets;
            double lossPercentage = ((double)lostPackets / sentPackets) * 100;

            int rowIndex = dataGridResults.Rows.Add(host, sentPackets, receivedPackets, lostPackets, $"{lossPercentage:0.##}%");

            if (lossPercentage > 0)
            {
                dataGridResults.Rows[rowIndex].DefaultCellStyle.BackColor = Color.FromArgb(64, 0, 0); // dark red
                dataGridResults.Rows[rowIndex].DefaultCellStyle.ForeColor = Color.White;
            }
            else
            {
                dataGridResults.Rows[rowIndex].DefaultCellStyle.BackColor = Color.FromArgb(0, 64, 0); // dark green
                dataGridResults.Rows[rowIndex].DefaultCellStyle.ForeColor = Color.White;
            }
        }

        private async Task button7_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridResults.Rows.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "Test starting...", "Test starting...");

            await Task.Run(() =>
            {
                var psi = new ProcessStartInfo
                {
                    FileName = "speedtest.exe",
                    Arguments = "-f json", // JSON format
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                var process = Process.Start(psi);
                string output = process.StandardOutput.ReadToEnd();
                process.WaitForExit();

                JObject json = JObject.Parse(output);
                double download = json["download"]["bandwidth"].Value<double>() * 8 / 1_000_000;
                double upload = json["upload"]["bandwidth"].Value<double>() * 8 / 1_000_000;

                Invoke(new Action(() =>
                {
                    dataGridResults.Rows[rowIndex].Cells[1].Value = download.ToString("F2");
                    dataGridResults.Rows[rowIndex].Cells[2].Value = upload.ToString("F2");
                }));
            });
        }

        private async void button8_Click(object sender, EventArgs e)
        {
            dataGridResults.Columns.Clear();

            // 3 sütun: Time, Download, Upload
            dataGridResults.Columns.Add("Time", "🕒 Time");
            dataGridResults.Columns.Add("Download", "⬇️ Download (Mbps / MB/s)");
            dataGridResults.Columns.Add("Upload", "⬆️ Upload (Mbps / MB/s)");

            // Header stil
            dataGridResults.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridResults.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 30, 30);
            dataGridResults.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridResults.EnableHeadersVisualStyles = false;

            string exePath = Path.Combine(Application.StartupPath, "speedtest.exe");

            var psi = new ProcessStartInfo
            {
                FileName = exePath,
                Arguments = "-f json",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            // Satırı baştan ekle
            int rowIndex = dataGridResults.Rows.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "Running...", "Running...");

            await Task.Run(() =>
            {
                try
                {
                    using (var process = Process.Start(psi))
                    {
                        string output = process.StandardOutput.ReadToEnd();
                        process.WaitForExit();

                        dynamic result = JsonConvert.DeserializeObject(output);
                        double downloadBytesPerSec = result.download.bandwidth;
                        double uploadBytesPerSec = result.upload.bandwidth;

                        double downloadMbps = Math.Round((downloadBytesPerSec * 8) / 1_000_000, 2);
                        double uploadMbps = Math.Round((uploadBytesPerSec * 8) / 1_000_000, 2);
                        double downloadMBps = Math.Round(downloadBytesPerSec / 1_000_000, 2);
                        double uploadMBps = Math.Round(uploadBytesPerSec / 1_000_000, 2);

                        string downloadText = $"{downloadMbps} Mbps ({downloadMBps} MB/s)";
                        string uploadText = $"{uploadMbps} Mbps ({uploadMBps} MB/s)";

                        Invoke(new Action(() =>
                        {
                            dataGridResults.Rows[rowIndex].Cells[1].Value = downloadText;
                            dataGridResults.Rows[rowIndex].Cells[2].Value = uploadText;
                        }));
                    }
                }
                catch (Exception ex)
                {
                    Invoke(new Action(() =>
                    {
                        dataGridResults.Rows[rowIndex].Cells[1].Value = "Error";
                        dataGridResults.Rows[rowIndex].Cells[2].Value = "Error";
                        MessageBox.Show("Error: " + ex.Message, "Speed Test Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }));
                }
            });
        }

        private async void button9_Click(object sender, EventArgs e)
        {
            dataGridResults.Columns.Clear();
            dataGridResults.Columns.Add("Phase", "🧪 Test Phase");
            dataGridResults.Columns.Add("Result", "📊 Result / Value");
            button9.Enabled = false;
            AppendRow("Bufferbloat test started...", "");

            var unloadedLatencies = await MeasurePingAsync("8.8.8.8", 30);
            AppendStats("Unloaded Ping", unloadedLatencies);

            AppendRow("⬇️ Download test starting...", "");
            var downloadTask = SimulateDownloadAsync();
            var downloadLatencies = await MeasurePingAsync("8.8.8.8", 10);
            await downloadTask;
            AppendStats("Ping During Download", downloadLatencies);

            AppendRow("⬆️ Upload test starting...", "");
            var uploadTask = SimulateUploadAsync();
            var uploadLatencies = await MeasurePingAsync("8.8.8.8", 10);
            await uploadTask;
            AppendStats("Ping During Upload", uploadLatencies);

            AppendRow("✅ Bufferbloat test completed", "");
            button9.Enabled = true;
        }

        private async Task<List<long>> MeasurePingAsync(string host, int count)
        {
            List<long> latencies = new List<long>();
            using (Ping ping = new Ping())
            {
                for (int i = 0; i < count; i++)
                {
                    try
                    {
                        var reply = await ping.SendPingAsync(host, 1000);
                        if (reply.Status == IPStatus.Success)
                            latencies.Add(reply.RoundtripTime);
                    }
                    catch { }
                    await Task.Delay(200);
                }
            }
            return latencies;
        }

        private async Task SimulateDownloadAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var sw = Stopwatch.StartNew();
                    for (int i = 0; i < 5; i++)
                    {
                        await client.GetAsync("https://speed.hetzner.de/100MB.bin");
                    }
                    sw.Stop();
                    AppendRow("⬇️ Download duration", $"{sw.ElapsedMilliseconds} ms");
                }
                catch
                {
                }
            }
        }

        private async Task SimulateUploadAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var data = new ByteArrayContent(new byte[10 * 1024 * 1024]);
                    var sw = Stopwatch.StartNew();
                    for (int i = 0; i < 3; i++)
                    {
                        await client.PostAsync("https://httpbin.org/post", data);
                    }
                    sw.Stop();
                    AppendRow("⬆️ Upload duration", $"{sw.ElapsedMilliseconds} ms");
                }
                catch
                {
                }
            }
        }

        private void AppendStats(string phase, List<long> latencies)
        {
            if (latencies.Count == 0)
            {
                AppendRow($"{phase}", "❌ Ping failed");
                return;
            }

            latencies.Sort();
            long min = latencies.Min();
            long max = latencies.Max();
            double mean = latencies.Average();
            long median = latencies[latencies.Count / 2];
            double jitter = latencies.Zip(latencies.Skip(1), (a, b) => Math.Abs(a - b)).Average();

            AppendRow($"{phase} - Min Latency", $"{min} ms");
            AppendRow($"{phase} - Max Latency", $"{max} ms");
            AppendRow($"{phase} - Mean Latency", $"{mean:F2} ms");
            AppendRow($"{phase} - Median Latency", $"{median} ms");
            AppendRow($"{phase} - Jitter", $"{jitter:F2} ms");
        }

        private void AppendRow(string description, string result)
        {
            dataGridResults.Invoke((MethodInvoker)(() =>
            {
                dataGridResults.Rows.Add(description, result);
            }));
        }



        private void button10_Click_1(object sender, EventArgs e)
        {
            Form4 frm = new Form4();
            frm.Show();
        }

        private async void button11_Click(object sender, EventArgs e)
        {
            button11.Enabled = false;
            dataGridResults.Rows.Clear();
            dataGridResults.Columns.Clear();

            dataGridResults.Columns.Add("Index", "#");
            dataGridResults.Columns.Add("Ping", "Ping (ms)");
            dataGridResults.Columns.Add("Diff", "Δ (ms)");

            List<long> pingResults = new List<long>();
            List<long> jitterDiffs = new List<long>();

            string host = "8.8.8.8"; 

            using (Ping pingSender = new Ping())
            {
                for (int i = 0; i < 10; i++)
                {
                    try
                    {
                        PingReply reply = await pingSender.SendPingAsync(host, 1000);
                        long pingMs = reply.Status == IPStatus.Success ? reply.RoundtripTime : -1;

                        pingResults.Add(pingMs);

                        long diff = (i > 0 && pingResults[i - 1] >= 0 && pingMs >= 0)
                            ? Math.Abs(pingMs - pingResults[i - 1])
                            : 0;

                        jitterDiffs.Add(diff);

                        dataGridResults.Rows.Add(i + 1, pingMs >= 0 ? pingMs.ToString() : "Timeout", diff);
                    }
                    catch
                    {
                        pingResults.Add(-1);
                        jitterDiffs.Add(0);
                        dataGridResults.Rows.Add(i + 1, "Error", 0);
                    }

                    await Task.Delay(300); 
                }
            }

            double avgJitter = jitterDiffs.Skip(1).Average(); 

            int rowIndex = dataGridResults.Rows.Add();
            DataGridViewRow summaryRow = dataGridResults.Rows[rowIndex];
            summaryRow.Cells[0].Value = "Mean Jitter";
            summaryRow.Cells[1].Value = "";
            summaryRow.Cells[2].Value = avgJitter.ToString("0.00");

            summaryRow.DefaultCellStyle.BackColor = Color.FromArgb(30, 30, 30);
            summaryRow.DefaultCellStyle.ForeColor = Color.Orange;

            button11.Enabled = true;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "cmd.exe";
                psi.Arguments = "/c arp -a";
                psi.RedirectStandardOutput = true;
                psi.UseShellExecute = false;
                psi.CreateNoWindow = true;

                using (Process process = Process.Start(psi))
                {
                    string output = process.StandardOutput.ReadToEnd();
                    process.WaitForExit();

                    string[] lines = output.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                    // DataGridView temizle
                    dataGridResults.Columns.Clear();
                    dataGridResults.Rows.Clear();

                    // Sütunları oluştur
                    dataGridResults.Columns.Add("IP Address", "IP Address");
                    dataGridResults.Columns.Add("MAC Address", "MAC Address");
                    dataGridResults.Columns.Add("Type", "Type");

                    bool startReading = false;

                    foreach (string line in lines)
                    {
                        // Boş veya başlıksa geç
                        if (line.StartsWith("Interface:") || line.StartsWith("Internet Address") || string.IsNullOrWhiteSpace(line))
                        {
                            startReading = true;
                            continue;
                        }

                        if (startReading)
                        {
                            string[] parts = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                            if (parts.Length == 3)
                            {
                                dataGridResults.Rows.Add(parts[0], parts[1], parts[2]);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void labelLogo_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "cmd.exe";
                psi.Arguments = "/c netstat -b";
                psi.RedirectStandardOutput = true;
                psi.UseShellExecute = false;
                psi.CreateNoWindow = true;

                using (Process process = Process.Start(psi))
                {
                    string output = process.StandardOutput.ReadToEnd();
                    process.WaitForExit();

                    string[] lines = output.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

                    dataGridResults.Columns.Clear();
                    dataGridResults.Rows.Clear();
                    dataGridResults.Columns.Add("Protocol", "Protocol");
                    dataGridResults.Columns.Add("LocalAddress", "Local Address");
                    dataGridResults.Columns.Add("ForeignAddress", "Foreign Address");
                    dataGridResults.Columns.Add("State", "State");
                    dataGridResults.Columns.Add("Application", "Application");

                    string currentApp = "Unknown";

                    foreach (string line in lines)
                    {
                        string trimmed = line.Trim();

                        if (trimmed.StartsWith("[") && trimmed.EndsWith("]"))
                        {
                            currentApp = trimmed.Trim('[', ']');
                        }
                        else if (trimmed.StartsWith("TCP") || trimmed.StartsWith("UDP"))
                        {
                            string[] parts = trimmed.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                            if (parts.Length >= 3)
                            {
                                string protocol = parts[0];
                                string localAddress = parts[1];
                                string foreignAddress = parts[2];
                                string state = parts.Length >= 4 ? parts[3] : "N/A";

                                dataGridResults.Rows.Add(protocol, localAddress, foreignAddress, state, currentApp);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void button12_Click_2(object sender, EventArgs e)
        {
            dataGridResults.Columns.Clear();

            dataGridResults.Columns.Add("AdapterName", "Network Adapter");
            dataGridResults.Columns.Add("ConnectionType", "ConnectionType");
            dataGridResults.Columns.Add("Status", "Status");
            dataGridResults.Columns.Add("Speed", "Speed");
            dataGridResults.Columns.Add("Duration", "Duration");
            dataGridResults.Columns.Add("IPv4Address", "IPv4 Adress");
            dataGridResults.Columns.Add("IPv6Address", "IPv6 Adress");




            NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();

            foreach (NetworkInterface ni in networkInterfaces)
            {
                string adapterName = ni.Name;
                string connectionType = ni.NetworkInterfaceType.ToString();
                string status = ni.OperationalStatus == OperationalStatus.Up ? "Connected" :"Not Connected";

                string speed = (ni.Speed / 1000000) + " Mb/sn"; 

                string ipv4Address = string.Empty;
                string ipv6Address = string.Empty;

                IPInterfaceProperties ipProperties = ni.GetIPProperties();

                foreach (UnicastIPAddressInformation ipInfo in ipProperties.UnicastAddresses)
                {
                    if (ipInfo.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork) // IPv4
                    {
                        ipv4Address = ipInfo.Address.ToString();
                    }
                    else if (ipInfo.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6) // IPv6
                    {
                        ipv6Address = ipInfo.Address.ToString();
                    }
                }

                string duration = "Information not available"; 

                // Verileri DataGridView'e ekle
                dataGridResults.Rows.Add(adapterName, connectionType, status, speed, duration, ipv4Address, ipv6Address);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            dataGridResults.Columns.Clear();
                dataGridResults.Columns.Add("IP", "IP Adress");
                dataGridResults.Columns.Add("MAC", "MAC Adress");


            NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();

            foreach (NetworkInterface ni in networkInterfaces)
            {
                if (ni.OperationalStatus == OperationalStatus.Up)
                {
                    string macAddress = ni.GetPhysicalAddress().ToString();

                    if (macAddress.Length == 12) 
                    {
                        macAddress = string.Join(":", Enumerable.Range(0, macAddress.Length / 2)
                            .Select(i => macAddress.Substring(i * 2, 2))); 
                    }
                    else
                    {
                        macAddress = "Invalid MAC address"; 
                    }

                    // IP adresini al (IPv4)
                    IPInterfaceProperties ipProperties = ni.GetIPProperties();
                    foreach (UnicastIPAddressInformation ipInfo in ipProperties.UnicastAddresses)
                    {
                        if (ipInfo.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork) // IPv4
                        {
                            string ipAddress = ipInfo.Address.ToString();

                            dataGridResults.Rows.Add(ipAddress, macAddress);
                            return;
                        }
                    }
                }
            }

            MessageBox.Show("IP and MAC address not found.");
        }
    }
}


