using System.Windows.Forms;
using System.Drawing;

namespace pingtester
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private Button button2;
        private Button tracerButton;
        private Button button4;
        private Button button5;
        private DataGridView dataGridResults;
        private Timer fadeInTimer;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button2 = new System.Windows.Forms.Button();
            this.tracerButton = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.dataGridResults = new System.Windows.Forms.DataGridView();
            this.fadeInTimer = new System.Windows.Forms.Timer(this.components);
            this.button6 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.labelLogo = new System.Windows.Forms.Label();
            this.button11 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridResults)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(47)))), ((int)(((byte)(72)))));
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(75)))), ((int)(((byte)(100)))));
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(60)))), ((int)(((byte)(90)))));
            resources.ApplyResources(this.button2, "button2");
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(188)))), ((int)(((byte)(255)))));
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tracerButton
            // 
            this.tracerButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(47)))), ((int)(((byte)(72)))));
            this.tracerButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tracerButton.FlatAppearance.BorderSize = 0;
            this.tracerButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(75)))), ((int)(((byte)(100)))));
            this.tracerButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(60)))), ((int)(((byte)(90)))));
            resources.ApplyResources(this.tracerButton, "tracerButton");
            this.tracerButton.ForeColor = System.Drawing.Color.Orange;
            this.tracerButton.Name = "tracerButton";
            this.tracerButton.UseVisualStyleBackColor = false;
            this.tracerButton.Click += new System.EventHandler(this.tracerButton_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(47)))), ((int)(((byte)(72)))));
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(75)))), ((int)(((byte)(100)))));
            this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(60)))), ((int)(((byte)(90)))));
            resources.ApplyResources(this.button4, "button4");
            this.button4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(188)))), ((int)(((byte)(255)))));
            this.button4.Name = "button4";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(47)))), ((int)(((byte)(72)))));
            this.button5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(75)))), ((int)(((byte)(100)))));
            this.button5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(60)))), ((int)(((byte)(90)))));
            resources.ApplyResources(this.button5, "button5");
            this.button5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(188)))), ((int)(((byte)(255)))));
            this.button5.Name = "button5";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // dataGridResults
            // 
            this.dataGridResults.AllowUserToAddRows = false;
            this.dataGridResults.AllowUserToDeleteRows = false;
            this.dataGridResults.AllowUserToResizeColumns = false;
            this.dataGridResults.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(44)))), ((int)(((byte)(66)))));
            this.dataGridResults.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridResults.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(47)))), ((int)(((byte)(72)))));
            this.dataGridResults.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridResults.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(55)))), ((int)(((byte)(80)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridResults.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(47)))), ((int)(((byte)(72)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(60)))), ((int)(((byte)(85)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridResults.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridResults.EnableHeadersVisualStyles = false;
            resources.ApplyResources(this.dataGridResults, "dataGridResults");
            this.dataGridResults.Name = "dataGridResults";
            this.dataGridResults.ReadOnly = true;
            this.dataGridResults.RowHeadersVisible = false;
            this.dataGridResults.RowTemplate.Height = 30;
            this.dataGridResults.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridResults_CellContentClick);
            // 
            // fadeInTimer
            // 
            this.fadeInTimer.Enabled = true;
            this.fadeInTimer.Interval = 20;
            this.fadeInTimer.Tick += new System.EventHandler(this.fadeInTimer_Tick);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(47)))), ((int)(((byte)(72)))));
            this.button6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(75)))), ((int)(((byte)(100)))));
            this.button6.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(60)))), ((int)(((byte)(90)))));
            resources.ApplyResources(this.button6, "button6");
            this.button6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(188)))), ((int)(((byte)(255)))));
            this.button6.Name = "button6";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(47)))), ((int)(((byte)(72)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(75)))), ((int)(((byte)(100)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(60)))), ((int)(((byte)(90)))));
            resources.ApplyResources(this.button1, "button1");
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(188)))), ((int)(((byte)(255)))));
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(47)))), ((int)(((byte)(72)))));
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(75)))), ((int)(((byte)(100)))));
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(60)))), ((int)(((byte)(90)))));
            resources.ApplyResources(this.button3, "button3");
            this.button3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(188)))), ((int)(((byte)(255)))));
            this.button3.Name = "button3";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click_2);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(47)))), ((int)(((byte)(72)))));
            this.button8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button8.FlatAppearance.BorderSize = 0;
            this.button8.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(75)))), ((int)(((byte)(100)))));
            this.button8.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(60)))), ((int)(((byte)(90)))));
            resources.ApplyResources(this.button8, "button8");
            this.button8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(188)))), ((int)(((byte)(255)))));
            this.button8.Name = "button8";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(47)))), ((int)(((byte)(72)))));
            this.button9.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button9.FlatAppearance.BorderSize = 0;
            this.button9.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(75)))), ((int)(((byte)(100)))));
            this.button9.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(60)))), ((int)(((byte)(90)))));
            resources.ApplyResources(this.button9, "button9");
            this.button9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(188)))), ((int)(((byte)(255)))));
            this.button9.Name = "button9";
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // labelLogo
            // 
            resources.ApplyResources(this.labelLogo, "labelLogo");
            this.labelLogo.ForeColor = System.Drawing.Color.LightBlue;
            this.labelLogo.Name = "labelLogo";
            this.labelLogo.Click += new System.EventHandler(this.labelLogo_Click);
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(47)))), ((int)(((byte)(72)))));
            this.button11.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button11.FlatAppearance.BorderSize = 0;
            this.button11.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(75)))), ((int)(((byte)(100)))));
            this.button11.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(60)))), ((int)(((byte)(90)))));
            resources.ApplyResources(this.button11, "button11");
            this.button11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(188)))), ((int)(((byte)(255)))));
            this.button11.Name = "button11";
            this.button11.UseVisualStyleBackColor = false;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(47)))), ((int)(((byte)(72)))));
            this.button10.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button10.FlatAppearance.BorderSize = 0;
            this.button10.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(75)))), ((int)(((byte)(100)))));
            this.button10.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(60)))), ((int)(((byte)(90)))));
            resources.ApplyResources(this.button10, "button10");
            this.button10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(188)))), ((int)(((byte)(255)))));
            this.button10.Name = "button10";
            this.button10.UseVisualStyleBackColor = false;
            this.button10.Click += new System.EventHandler(this.button10_Click_1);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(47)))), ((int)(((byte)(72)))));
            this.button7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button7.FlatAppearance.BorderSize = 0;
            this.button7.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(75)))), ((int)(((byte)(100)))));
            this.button7.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(60)))), ((int)(((byte)(90)))));
            resources.ApplyResources(this.button7, "button7");
            this.button7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(188)))), ((int)(((byte)(255)))));
            this.button7.Name = "button7";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button12_Click);
            // 
            // button12
            // 
            this.button12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(47)))), ((int)(((byte)(72)))));
            this.button12.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button12.FlatAppearance.BorderSize = 0;
            this.button12.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(75)))), ((int)(((byte)(100)))));
            this.button12.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(60)))), ((int)(((byte)(90)))));
            resources.ApplyResources(this.button12, "button12");
            this.button12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(188)))), ((int)(((byte)(255)))));
            this.button12.Name = "button12";
            this.button12.UseVisualStyleBackColor = false;
            this.button12.Click += new System.EventHandler(this.button12_Click_2);
            // 
            // button13
            // 
            this.button13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(47)))), ((int)(((byte)(72)))));
            this.button13.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button13.FlatAppearance.BorderSize = 0;
            this.button13.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(75)))), ((int)(((byte)(100)))));
            this.button13.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(60)))), ((int)(((byte)(90)))));
            resources.ApplyResources(this.button13, "button13");
            this.button13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(188)))), ((int)(((byte)(255)))));
            this.button13.Name = "button13";
            this.button13.UseVisualStyleBackColor = false;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(24)))), ((int)(((byte)(43)))));
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.labelLogo);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.tracerButton);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.dataGridResults);
            this.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Opacity = 0D;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Button button6;
        private Button button1;
        private Button button3;
        private Button button8;
        private Button button9;
        private Label labelLogo;
        private Button button11;
        private Button button10;
        private Button button7;
        private Button button12;
        private Button button13;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}
