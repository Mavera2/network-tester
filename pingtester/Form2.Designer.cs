using System.Drawing;
using System.Windows.Forms;

namespace pingtester
{
    partial class Form2
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private System.Windows.Forms.DataGridView dataGridResults;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelPacketSize;
        private System.Windows.Forms.NumericUpDown numericUpDownPacketMin;
        private System.Windows.Forms.NumericUpDown numericUpDownPacketMax;
        private System.Windows.Forms.Label labelFrequency;
        private System.Windows.Forms.TrackBar trackBarFrequency;
        private System.Windows.Forms.Label labelDuration;
        private System.Windows.Forms.TrackBar trackBarDuration;
        private System.Windows.Forms.Label labelDelay;
        private System.Windows.Forms.TrackBar trackBarDelay;
        private System.Windows.Forms.ComboBox comboBoxPreset;
        private System.Windows.Forms.CheckBox checkBoxWaitBeforeRecording;
        private System.Windows.Forms.ComboBox comboBoxServer;
        private System.Windows.Forms.Button buttonStartTest;
        private System.Windows.Forms.Label labelFooter;

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelPacketSize = new System.Windows.Forms.Label();
            this.numericUpDownPacketMin = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownPacketMax = new System.Windows.Forms.NumericUpDown();
            this.labelFrequency = new System.Windows.Forms.Label();
            this.trackBarFrequency = new System.Windows.Forms.TrackBar();
            this.labelDuration = new System.Windows.Forms.Label();
            this.trackBarDuration = new System.Windows.Forms.TrackBar();
            this.labelDelay = new System.Windows.Forms.Label();
            this.trackBarDelay = new System.Windows.Forms.TrackBar();
            this.comboBoxPreset = new System.Windows.Forms.ComboBox();
            this.checkBoxWaitBeforeRecording = new System.Windows.Forms.CheckBox();
            this.comboBoxServer = new System.Windows.Forms.ComboBox();
            this.buttonStartTest = new System.Windows.Forms.Button();
            this.labelFooter = new System.Windows.Forms.Label();
            this.dataGridResults = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPacketMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPacketMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarFrequency)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarDuration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridResults)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.labelTitle.ForeColor = System.Drawing.Color.Turquoise;
            this.labelTitle.Location = new System.Drawing.Point(20, 20);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(123, 25);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Test Settings";
            // 
            // labelPacketSize
            // 
            this.labelPacketSize.ForeColor = System.Drawing.Color.White;
            this.labelPacketSize.Location = new System.Drawing.Point(20, 60);
            this.labelPacketSize.Name = "labelPacketSize";
            this.labelPacketSize.Size = new System.Drawing.Size(74, 23);
            this.labelPacketSize.TabIndex = 1;
            this.labelPacketSize.Text = "Packet Size:";
            // 
            // numericUpDownPacketMin
            // 
            this.numericUpDownPacketMin.Location = new System.Drawing.Point(100, 58);
            this.numericUpDownPacketMin.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.numericUpDownPacketMin.Minimum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.numericUpDownPacketMin.Name = "numericUpDownPacketMin";
            this.numericUpDownPacketMin.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownPacketMin.TabIndex = 2;
            this.numericUpDownPacketMin.Value = new decimal(new int[] {
            212,
            0,
            0,
            0});
            // 
            // numericUpDownPacketMax
            // 
            this.numericUpDownPacketMax.Location = new System.Drawing.Point(226, 58);
            this.numericUpDownPacketMax.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.numericUpDownPacketMax.Minimum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.numericUpDownPacketMax.Name = "numericUpDownPacketMax";
            this.numericUpDownPacketMax.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownPacketMax.TabIndex = 3;
            this.numericUpDownPacketMax.Value = new decimal(new int[] {
            228,
            0,
            0,
            0});
            // 
            // labelFrequency
            // 
            this.labelFrequency.ForeColor = System.Drawing.Color.White;
            this.labelFrequency.Location = new System.Drawing.Point(20, 100);
            this.labelFrequency.Name = "labelFrequency";
            this.labelFrequency.Size = new System.Drawing.Size(150, 23);
            this.labelFrequency.TabIndex = 4;
            this.labelFrequency.Text = "Frequency (Pings/sec):";
            // 
            // trackBarFrequency
            // 
            this.trackBarFrequency.Location = new System.Drawing.Point(180, 100);
            this.trackBarFrequency.Maximum = 100;
            this.trackBarFrequency.Name = "trackBarFrequency";
            this.trackBarFrequency.Size = new System.Drawing.Size(104, 45);
            this.trackBarFrequency.TabIndex = 5;
            this.trackBarFrequency.Value = 15;
            this.trackBarFrequency.Scroll += new System.EventHandler(this.trackBarFrequency_Scroll_1);
            // 
            // labelDuration
            // 
            this.labelDuration.ForeColor = System.Drawing.Color.White;
            this.labelDuration.Location = new System.Drawing.Point(20, 150);
            this.labelDuration.Name = "labelDuration";
            this.labelDuration.Size = new System.Drawing.Size(150, 23);
            this.labelDuration.TabIndex = 6;
            this.labelDuration.Text = "Duration (sec):";
            // 
            // trackBarDuration
            // 
            this.trackBarDuration.Location = new System.Drawing.Point(180, 150);
            this.trackBarDuration.Maximum = 120;
            this.trackBarDuration.Name = "trackBarDuration";
            this.trackBarDuration.Size = new System.Drawing.Size(104, 45);
            this.trackBarDuration.TabIndex = 7;
            this.trackBarDuration.Value = 10;
            this.trackBarDuration.Scroll += new System.EventHandler(this.trackBarDuration_Scroll_1);
            // 
            // labelDelay
            // 
            this.labelDelay.ForeColor = System.Drawing.Color.White;
            this.labelDelay.Location = new System.Drawing.Point(20, 200);
            this.labelDelay.Name = "labelDelay";
            this.labelDelay.Size = new System.Drawing.Size(180, 23);
            this.labelDelay.TabIndex = 8;
            this.labelDelay.Text = "Acceptable Delay (ms):";
            // 
            // trackBarDelay
            // 
            this.trackBarDelay.Location = new System.Drawing.Point(180, 200);
            this.trackBarDelay.Maximum = 1000;
            this.trackBarDelay.Name = "trackBarDelay";
            this.trackBarDelay.Size = new System.Drawing.Size(104, 45);
            this.trackBarDelay.TabIndex = 9;
            this.trackBarDelay.Value = 200;
            this.trackBarDelay.Scroll += new System.EventHandler(this.trackBarDelay_Scroll_1);
            // 
            // comboBoxPreset
            // 
            this.comboBoxPreset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPreset.Items.AddRange(new object[] {
            "Default",
            "Gaming",
            "Streaming"});
            this.comboBoxPreset.Location = new System.Drawing.Point(100, 250);
            this.comboBoxPreset.Name = "comboBoxPreset";
            this.comboBoxPreset.Size = new System.Drawing.Size(121, 21);
            this.comboBoxPreset.TabIndex = 10;
            // 
            // checkBoxWaitBeforeRecording
            // 
            this.checkBoxWaitBeforeRecording.ForeColor = System.Drawing.Color.White;
            this.checkBoxWaitBeforeRecording.Location = new System.Drawing.Point(20, 280);
            this.checkBoxWaitBeforeRecording.Name = "checkBoxWaitBeforeRecording";
            this.checkBoxWaitBeforeRecording.Size = new System.Drawing.Size(300, 24);
            this.checkBoxWaitBeforeRecording.TabIndex = 11;
            this.checkBoxWaitBeforeRecording.Text = "Wait 2 seconds before recording?";
            // 
            // comboBoxServer
            // 
            this.comboBoxServer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxServer.Items.AddRange(new object[] {
            "New Jersey",
            "London",
            "Tokyo"});
            this.comboBoxServer.Location = new System.Drawing.Point(100, 310);
            this.comboBoxServer.Name = "comboBoxServer";
            this.comboBoxServer.Size = new System.Drawing.Size(121, 21);
            this.comboBoxServer.TabIndex = 12;
            // 
            // buttonStartTest
            // 
            this.buttonStartTest.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.buttonStartTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStartTest.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.buttonStartTest.Location = new System.Drawing.Point(20, 350);
            this.buttonStartTest.Name = "buttonStartTest";
            this.buttonStartTest.Size = new System.Drawing.Size(120, 35);
            this.buttonStartTest.TabIndex = 13;
            this.buttonStartTest.Text = "Start Test";
            this.buttonStartTest.UseVisualStyleBackColor = false;
            this.buttonStartTest.Click += new System.EventHandler(this.buttonStartTest_Click_1);
            // 
            // labelFooter
            // 
            this.labelFooter.AutoSize = true;
            this.labelFooter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelFooter.ForeColor = System.Drawing.Color.Transparent;
            this.labelFooter.Location = new System.Drawing.Point(146, 350);
            this.labelFooter.Name = "labelFooter";
            this.labelFooter.Size = new System.Drawing.Size(259, 13);
            this.labelFooter.TabIndex = 14;
            this.labelFooter.Text = "This will send X pings and use Y KB of data.";
            // 
            // dataGridResults
            // 
            this.dataGridResults.AllowUserToAddRows = false;
            this.dataGridResults.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            this.dataGridResults.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridResults.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Turquoise;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridResults.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridResults.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridResults.EnableHeadersVisualStyles = false;
            this.dataGridResults.GridColor = System.Drawing.Color.DimGray;
            this.dataGridResults.Location = new System.Drawing.Point(406, 28);
            this.dataGridResults.Name = "dataGridResults";
            this.dataGridResults.ReadOnly = true;
            this.dataGridResults.RowHeadersVisible = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.dataGridResults.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridResults.Size = new System.Drawing.Size(613, 465);
            this.dataGridResults.TabIndex = 15;
            this.dataGridResults.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridResults_CellContentClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "No";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Status";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Time (ms)";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Size (bytes)";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // Form2
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(1046, 505);
            this.Controls.Add(this.dataGridResults);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.labelPacketSize);
            this.Controls.Add(this.numericUpDownPacketMin);
            this.Controls.Add(this.numericUpDownPacketMax);
            this.Controls.Add(this.labelFrequency);
            this.Controls.Add(this.trackBarFrequency);
            this.Controls.Add(this.labelDuration);
            this.Controls.Add(this.trackBarDuration);
            this.Controls.Add(this.labelDelay);
            this.Controls.Add(this.trackBarDelay);
            this.Controls.Add(this.comboBoxPreset);
            this.Controls.Add(this.checkBoxWaitBeforeRecording);
            this.Controls.Add(this.comboBoxServer);
            this.Controls.Add(this.buttonStartTest);
            this.Controls.Add(this.labelFooter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form2";
            this.Text = "Test Settings";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPacketMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPacketMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarFrequency)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarDuration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    }
}