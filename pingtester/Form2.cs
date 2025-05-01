using System;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pingtester
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.Load += new EventHandler(Form2_Load);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // Varsayılan ayarlar
            comboBoxPreset.Items.AddRange(new string[] { "Default", "High Performance", "Low Power" });
            comboBoxPreset.SelectedIndex = 0;

            comboBoxServer.Items.AddRange(new string[] { "New Jersey", "Frankfurt", "Tokyo" });
            comboBoxServer.SelectedIndex = 0;

            trackBarFrequency.Minimum = 1;
            trackBarFrequency.Maximum = 100;
            trackBarFrequency.Value = 15;
            trackBarFrequency.SmallChange = 10;
            trackBarFrequency.LargeChange = 10;
            trackBarFrequency.TickFrequency = 10;

            trackBarDuration.Minimum = 1;
            trackBarDuration.Maximum = 60;
            trackBarDuration.Value = 10;
            trackBarDuration.SmallChange = 10;
            trackBarDuration.LargeChange = 10;
            trackBarDuration.TickFrequency = 10;

            trackBarDelay.Minimum = 10;
            trackBarDelay.Maximum = 1000;
            trackBarDelay.Value = 200;
            trackBarDelay.SmallChange = 10;
            trackBarDelay.LargeChange = 10;
            trackBarDelay.TickFrequency = 10;

            numericUpDownPacketMin.Minimum = 32;
            numericUpDownPacketMin.Maximum = 65500;
            numericUpDownPacketMin.Value = 32;

            numericUpDownPacketMax.Minimum = 32;
            numericUpDownPacketMax.Maximum = 65500;
            numericUpDownPacketMax.Value = 128;

            labelFrequency.Text = $"Frequency: {trackBarFrequency.Value} pings/sec";
            labelDuration.Text = $"Duration: {trackBarDuration.Value} sec";
            labelDelay.Text = $"Acceptable Delay: {trackBarDelay.Value} ms";
        }

        private async void buttonStartTest_Click_1(object sender, EventArgs e)
        {
            buttonStartTest.Enabled = false;
            buttonStartTest.Text = "Testing...";
            dataGridResults.Rows.Clear();
            labelFooter.Text = "Test started...";

            if (checkBoxWaitBeforeRecording.Checked)
            {
                await Task.Delay(2000);
            }

            string target = "google.com";

            int packetSizeMin = (int)numericUpDownPacketMin.Value;
            int packetSizeMax = (int)numericUpDownPacketMax.Value;
            int frequency = trackBarFrequency.Value;
            int duration = trackBarDuration.Value;
            int acceptableDelay = trackBarDelay.Value;

            int totalPings = frequency * duration;
            int successfulPings = 0;
            int failedPings = 0;
            long totalPingTime = 0;

            Ping pingSender = new Ping();
            Random rand = new Random();

            for (int i = 0; i < totalPings; i++)
            {
                int packetSize = rand.Next(packetSizeMin, packetSizeMax + 1);
                byte[] buffer = new byte[packetSize];
                rand.NextBytes(buffer);
                PingOptions options = new PingOptions();

                string status = "";
                long pingTime = 0;

                try
                {
                    PingReply reply = await pingSender.SendPingAsync(target, 1000, buffer, options);

                    if (reply.Status == IPStatus.Success)
                    {
                        pingTime = reply.RoundtripTime;
                        totalPingTime += pingTime;
                        successfulPings++;
                        status = "Success";
                    }
                    else
                    {
                        failedPings++;
                        status = "Failed";
                    }
                }
                catch
                {
                    failedPings++;
                    status = "Error";
                }

                int rowIndex = dataGridResults.Rows.Add(i + 1, status, pingTime, buffer.Length);
                DataGridViewRow currentRow = dataGridResults.Rows[rowIndex];

                if (status == "Success")
                    currentRow.DefaultCellStyle.ForeColor = Color.LightGreen;
                else
                    currentRow.DefaultCellStyle.ForeColor = Color.IndianRed;

                await Task.Delay(1000 / frequency);
            }

            long avgPing = successfulPings > 0 ? totalPingTime / successfulPings : 0;
            double packetLossRate = (double)failedPings / totalPings * 100;

            string result =
                $"Total Pings: {totalPings}\n" +
                $"Success: {successfulPings}\n" +
                $"Failed: {failedPings}\n" +
                $"Avg. Ping: {avgPing} ms\n" +
                $"Packet Loss: {packetLossRate:F2}%\n" +
                $"Acceptable Delay: {acceptableDelay} ms\n" +
                $"Connection Quality: " +
                $"{(packetLossRate < 5 && avgPing <= acceptableDelay ? "Excellent" : packetLossRate < 20 ? "Moderate" : "Poor")}";

            labelFooter.Text = result;
            buttonStartTest.Enabled = true;
            buttonStartTest.Text = "Start Test";
        }

        private void trackBarFrequency_Scroll_1(object sender, EventArgs e)
        {
            labelFrequency.Text = $"Frequency: {trackBarFrequency.Value} pings/sec";
        }

        private void trackBarDuration_Scroll_1(object sender, EventArgs e)
        {
            labelDuration.Text = $"Duration: {trackBarDuration.Value} sec";
        }

        private void trackBarDelay_Scroll_1(object sender, EventArgs e)
        {
            labelDelay.Text = $"Acceptable Delay: {trackBarDelay.Value} ms";
        }

        private void comboBoxPreset_SelectedIndexChanged(object sender, EventArgs e) { }
        private void comboBoxServer_SelectedIndexChanged(object sender, EventArgs e) { }
        private void checkBoxWaitBeforeRecording_CheckedChanged(object sender, EventArgs e) { }
        private void numericUpDownPacketMin_ValueChanged(object sender, EventArgs e) { }
        private void numericUpDownPacketMax_ValueChanged(object sender, EventArgs e) { }
        private void dataGridResults_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}
