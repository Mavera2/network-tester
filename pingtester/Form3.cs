using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace pingtester
{
    public partial class Form3 : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect, int nTopRect, int nRightRect, int nBottomRect,
            int nWidthEllipse, int nHeightEllipse);

        public Form3()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ip = textBox1.Text.Trim();

            if (string.IsNullOrWhiteSpace(ip))
            {
                MessageBox.Show("Please enter an IP address.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Ping pingSender = new Ping();
                PingReply reply = pingSender.Send(ip, 1000);

                dataGridView1.Columns.Clear();
                dataGridView1.Rows.Clear();

                dataGridView1.Columns.Add("Status", "Status");
                dataGridView1.Columns.Add("Address", "Address");
                dataGridView1.Columns.Add("Latency", "Latency (ms)");

                if (reply.Status == IPStatus.Success)
                {
                    dataGridView1.Rows.Add("Success", reply.Address.ToString(), reply.RoundtripTime);
                }
                else
                {
                    dataGridView1.Rows.Add("Failed", "-", "-");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while performing the ping: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panelLeft_Paint(object sender, PaintEventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string ip = textBox1.Text.Trim();

            if (string.IsNullOrWhiteSpace(ip))
            {
                MessageBox.Show("Please enter an IP address.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dataGridView1.Invoke((MethodInvoker)(() =>
            {
                dataGridView1.Columns.Clear();
                dataGridView1.Rows.Clear();

                dataGridView1.Columns.Add("Hop", "Hop");
                dataGridView1.Columns.Add("Response", "Response");
            }));

            Task.Run(() =>
            {
                try
                {
                    ProcessStartInfo psi = new ProcessStartInfo("tracert", $"-h 30 -4 {ip}")
                    {
                        RedirectStandardOutput = true,
                        UseShellExecute = false,
                        CreateNoWindow = true,
                        StandardOutputEncoding = Encoding.UTF8
                    };

                    using (Process proc = Process.Start(psi))
                    {
                        int hopNumber = 1;
                        while (!proc.StandardOutput.EndOfStream)
                        {
                            string line = proc.StandardOutput.ReadLine()?.Trim();

                            if (string.IsNullOrWhiteSpace(line) ||
                                line.StartsWith("Tracing") ||
                                line.StartsWith("over a maximum") ||
                                line.StartsWith("Trace complete"))
                                continue;

                            string hopText = hopNumber.ToString();
                            string responseText = line;

                            if (dataGridView1.IsHandleCreated && !dataGridView1.IsDisposed)
                            {
                                dataGridView1.Invoke((MethodInvoker)(() =>
                                {
                                    if (!dataGridView1.IsDisposed)
                                    {
                                        dataGridView1.Rows.Add(hopText, responseText);
                                        dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount - 1;
                                    }
                                }));
                            }

                            hopNumber++;
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (this.IsHandleCreated && !this.IsDisposed)
                    {
                        this.Invoke((MethodInvoker)(() =>
                        {
                            MessageBox.Show("An error occurred while performing the traceroute: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }));
                    }
                }
            });

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string filePath = Path.Combine(desktopPath, "Test Results.txt");

                // Sütun genişliklerini hesapla
                int[] columnWidths = new int[dataGridView1.Columns.Count];
                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    int maxWidth = dataGridView1.Columns[i].HeaderText.Length;

                    foreach (DataGridViewRow row in dataGridView1.Rows)
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
                    // Tarih + saat
                    writer.WriteLine("Date: " + DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss"));
                    writer.WriteLine(); // Boş satır

                    // Başlıkları hizalı yaz
                    for (int i = 0; i < dataGridView1.Columns.Count; i++)
                    {
                        string header = dataGridView1.Columns[i].HeaderText;
                        writer.Write(header.PadRight(columnWidths[i]));
                    }
                    writer.WriteLine();

                    // Alt çizgi
                    for (int i = 0; i < dataGridView1.Columns.Count; i++)
                    {
                        writer.Write(new string('-', columnWidths[i]));
                    }
                    writer.WriteLine();

                    // Satırları yaz
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            for (int i = 0; i < dataGridView1.Columns.Count; i++)
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex >= 0)
            {
                var column = dataGridView1.Columns[e.ColumnIndex];
                bool isNumeric = true;

                // Sayısal kontrol
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        var rawValue = row.Cells[e.ColumnIndex].Value?.ToString();
                        if (string.IsNullOrWhiteSpace(rawValue)) continue;

                        string cleanedValue = rawValue.ToLower().Replace("ms", "").Trim();
                        if (!double.TryParse(cleanedValue, out _))
                        {
                            isNumeric = false;
                            break;
                        }
                    }
                }

                bool ascending = column.Tag == null || !(bool)column.Tag;
                column.Tag = ascending;

                var rows = dataGridView1.Rows
                    .Cast<DataGridViewRow>()
                    .Where(r => !r.IsNewRow)
                    .ToList();

                if (isNumeric)
                {
                    rows = ascending
                        ? rows.OrderBy(r =>
                        {
                            var val = r.Cells[e.ColumnIndex].Value?.ToString()?.ToLower().Replace("ms", "").Trim();
                            return double.TryParse(val, out var num) ? num : double.MaxValue;
                        }).ToList()
                        : rows.OrderByDescending(r =>
                        {
                            var val = r.Cells[e.ColumnIndex].Value?.ToString()?.ToLower().Replace("ms", "").Trim();
                            return double.TryParse(val, out var num) ? num : double.MinValue;
                        }).ToList();
                }
                else
                {
                    rows = ascending
                        ? rows.OrderBy(r => r.Cells[e.ColumnIndex].Value?.ToString()).ToList()
                        : rows.OrderByDescending(r => r.Cells[e.ColumnIndex].Value?.ToString()).ToList();
                }

                var rowData = rows.Select(r =>
                    r.Cells.Cast<DataGridViewCell>().Select(c => c.Value).ToArray()
                ).ToList();

                dataGridView1.Rows.Clear();
                foreach (var values in rowData)
                {
                    dataGridView1.Rows.Add(values);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            string ipAddress = textBox1.Text;
            string result = await Task.Run(() => GetWhoisData(ipAddress));
            FillDataGrid(result);
        }

        private string GetWhoisData(string ip)
        {
            try
            {
                using (var tcpClient = new TcpClient("whois.ripe.net", 43))
                using (var networkStream = tcpClient.GetStream())
                using (var writer = new StreamWriter(networkStream))
                using (var reader = new StreamReader(networkStream))
                {
                    writer.WriteLine(ip);
                    writer.Flush();

                    string response = reader.ReadToEnd();
                    return response;
                }
            }
            catch (Exception ex)
            {
                return $"Hata: {ex.Message}";
            }
        }

        private void FillDataGrid(string whoisData)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add("Field", "Field");
            dataGridView1.Columns.Add("Value", "Value");

            using (StringReader reader = new StringReader(whoisData))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Contains(":"))
                    {
                        var parts = line.Split(new[] { ':' }, 2);
                        string key = parts[0].Trim();
                        string value = parts[1].Trim();

                        if (!string.IsNullOrWhiteSpace(key) && !string.IsNullOrWhiteSpace(value))
                        {
                            dataGridView1.Rows.Add(key, value);
                        }
                    }
                }
            }

            // Otomatik sütun genişliği
            dataGridView1.AutoResizeColumns();
        }

        private async void button6_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            string ipAddress = textBox1.Text;  
            string portText1 = textBox2.Text;  
            string portText2 = textBox3.Text;  

            if (int.TryParse(portText1, out int startPort))
            {
                List<int> ports = new List<int>();

                ports.Add(startPort);

               
                if (!string.IsNullOrEmpty(portText2) && int.TryParse(portText2, out int endPort))
                {
                    if (startPort > endPort)
                    {
                        MessageBox.Show("The starting port must be less than or equal to the ending port.");
                        return;
                    }

                    // Add the ports in the range
                    for (int port = startPort + 1; port <= endPort; port++)
                    {
                        ports.Add(port);
                    }
                }

                if (dataGridView1.Columns.Count == 0)
                {
                    dataGridView1.Columns.Add("IP", "IP Address");
                    dataGridView1.Columns.Add("Port", "Port Number");
                    dataGridView1.Columns.Add("Status", "Status");
                }

                foreach (int port in ports)
                {
                    bool isPortOpen = await CheckPortAsync(ipAddress, port);

                    dataGridView1.Rows.Add(ipAddress, port, isPortOpen ? "OPEN" : "CLOSED");
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid start port number.");
            }
        }

        private async Task<bool> CheckPortAsync(string ipAddress, int port)
        {
            try
            {
                using (TcpClient client = new TcpClient())
                {
                    var connectTask = client.ConnectAsync(ipAddress, port);
                    var timeoutTask = Task.Delay(3000);

                    var completedTask = await Task.WhenAny(connectTask, timeoutTask);

                    if (completedTask == connectTask)
                    {
                        return true;
                    }
                    else
                    {
                        return false; 
                    }
                }
            }
            catch
            {
                return false; 
            }
        }
    }
    }
