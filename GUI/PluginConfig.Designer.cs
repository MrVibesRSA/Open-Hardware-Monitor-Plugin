using SuchByte.MacroDeck.GUI.CustomControls;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MrVibesRSA.OpenHardwareMonitor.GUI
{
    partial class PluginConfig
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            btn_OK = new ButtonPrimary();
            linkLabel1 = new LinkLabel();
            roundedPanel2 = new RoundedPanel();
            label3 = new Label();
            label2 = new Label();
            numericUpDown1 = new NumericUpDown();
            label6 = new Label();
            dataGridView1 = new DataGridView();
            checkboxColumn = new DataGridViewCheckBoxColumn();
            SensorName = new DataGridViewTextBoxColumn();
            SensorType = new DataGridViewTextBoxColumn();
            Value = new DataGridViewTextBoxColumn();
            Min = new DataGridViewTextBoxColumn();
            Max = new DataGridViewTextBoxColumn();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            buttonPrimary1 = new ButtonPrimary();
            roundedPanel2.SuspendLayout();
            ((ISupportInitialize)numericUpDown1).BeginInit();
            ((ISupportInitialize)dataGridView1).BeginInit();
            ((ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btn_OK
            // 
            btn_OK.BorderRadius = 8;
            btn_OK.FlatAppearance.BorderColor = Color.Cyan;
            btn_OK.FlatStyle = FlatStyle.Flat;
            btn_OK.Font = new Font("Tahoma", 9.75F);
            btn_OK.ForeColor = Color.White;
            btn_OK.HoverColor = Color.Empty;
            btn_OK.Icon = null;
            btn_OK.Location = new Point(325, 432);
            btn_OK.Name = "btn_OK";
            btn_OK.Progress = 0;
            btn_OK.ProgressColor = Color.FromArgb(0, 103, 205);
            btn_OK.Size = new Size(75, 23);
            btn_OK.TabIndex = 8;
            btn_OK.Text = "OK";
            btn_OK.UseVisualStyleBackColor = false;
            btn_OK.UseWindowsAccentColor = true;
            btn_OK.WriteProgress = true;
            btn_OK.Click += btn_OK_Click;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.LinkColor = Color.White;
            linkLabel1.Location = new Point(542, 7);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(53, 16);
            linkLabel1.TabIndex = 14;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "How to?";
            // 
            // roundedPanel2
            // 
            roundedPanel2.BackColor = Color.FromArgb(36, 36, 36);
            roundedPanel2.Controls.Add(numericUpDown1);
            roundedPanel2.Controls.Add(label3);
            roundedPanel2.Controls.Add(label2);
            roundedPanel2.Controls.Add(linkLabel1);
            roundedPanel2.Controls.Add(label6);
            roundedPanel2.Controls.Add(dataGridView1);
            roundedPanel2.Location = new Point(18, 80);
            roundedPanel2.Name = "roundedPanel2";
            roundedPanel2.Size = new Size(606, 348);
            roundedPanel2.TabIndex = 13;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(300, 320);
            label3.Name = "label3";
            label3.Size = new Size(57, 16);
            label3.TabIndex = 17;
            label3.Text = "seconds.";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 320);
            label2.Name = "label2";
            label2.Size = new Size(249, 16);
            label2.TabIndex = 16;
            label2.Text = "Macro Deck global variable update interval";
            // 
            // numericUpDown1
            // 
            numericUpDown1.BackColor = Color.FromArgb(35, 35, 35);
            numericUpDown1.ForeColor = Color.Gainsboro;
            numericUpDown1.Location = new Point(261, 318);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(39, 23);
            numericUpDown1.TabIndex = 15;
            numericUpDown1.Value = new decimal(new int[] { 15, 0, 0, 0 });
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.FromArgb(36, 36, 36);
            label6.Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(12, 4);
            label6.Name = "label6";
            label6.Size = new Size(119, 19);
            label6.TabIndex = 3;
            label6.Text = "Gobal Variables";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.BackgroundColor = Color.FromArgb(35, 35, 35);
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(35, 35, 35);
            dataGridViewCellStyle3.Font = new Font("Tahoma", 9.75F);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { checkboxColumn, SensorName, SensorType, Value, Min, Max });
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(86, 86, 86);
            dataGridViewCellStyle4.Font = new Font("Tahoma", 9.75F);
            dataGridViewCellStyle4.ForeColor = Color.Gainsboro;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle4;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.GridColor = Color.FromArgb(45, 45, 45);
            dataGridView1.Location = new Point(12, 26);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(583, 286);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // checkboxColumn
            // 
            checkboxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            checkboxColumn.HeaderText = "Use";
            checkboxColumn.Name = "checkboxColumn";
            checkboxColumn.Width = 34;
            // 
            // SensorName
            // 
            SensorName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            SensorName.HeaderText = "Name";
            SensorName.Name = "SensorName";
            SensorName.ReadOnly = true;
            // 
            // SensorType
            // 
            SensorType.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            SensorType.HeaderText = "SensorType";
            SensorType.Name = "SensorType";
            SensorType.ReadOnly = true;
            SensorType.Width = 99;
            // 
            // Value
            // 
            Value.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Value.HeaderText = "Value";
            Value.Name = "Value";
            Value.ReadOnly = true;
            Value.Width = 99;
            // 
            // Min
            // 
            Min.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Min.HeaderText = "Min";
            Min.Name = "Min";
            Min.ReadOnly = true;
            Min.Width = 98;
            // 
            // Max
            // 
            Max.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            Max.HeaderText = "Max";
            Max.Name = "Max";
            Max.ReadOnly = true;
            Max.Width = 99;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(89, 19);
            label1.Name = "label1";
            label1.Size = new Size(466, 45);
            label1.TabIndex = 14;
            label1.Text = "Open Hardware Monitor";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.ExtensionIcon;
            pictureBox1.Location = new Point(20, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(75, 70);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 15;
            pictureBox1.TabStop = false;
            // 
            // buttonPrimary1
            // 
            buttonPrimary1.BorderRadius = 8;
            buttonPrimary1.FlatAppearance.BorderColor = Color.Cyan;
            buttonPrimary1.FlatStyle = FlatStyle.Flat;
            buttonPrimary1.Font = new Font("Tahoma", 9.75F);
            buttonPrimary1.ForeColor = Color.White;
            buttonPrimary1.HoverColor = Color.Empty;
            buttonPrimary1.Icon = null;
            buttonPrimary1.Location = new Point(239, 432);
            buttonPrimary1.Name = "buttonPrimary1";
            buttonPrimary1.Progress = 0;
            buttonPrimary1.ProgressColor = Color.FromArgb(0, 103, 205);
            buttonPrimary1.Size = new Size(75, 23);
            buttonPrimary1.TabIndex = 16;
            buttonPrimary1.Text = "Refresh";
            buttonPrimary1.UseVisualStyleBackColor = false;
            buttonPrimary1.UseWindowsAccentColor = true;
            buttonPrimary1.WriteProgress = true;
            buttonPrimary1.Click += buttonPrimary1_Click;
            // 
            // PluginConfig
            // 
            AutoScaleDimensions = new SizeF(7F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(642, 461);
            Controls.Add(buttonPrimary1);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Controls.Add(roundedPanel2);
            Controls.Add(btn_OK);
            ForeColor = Color.Gainsboro;
            Location = new Point(0, 0);
            Name = "PluginConfig";
            Controls.SetChildIndex(btn_OK, 0);
            Controls.SetChildIndex(roundedPanel2, 0);
            Controls.SetChildIndex(pictureBox1, 0);
            Controls.SetChildIndex(label1, 0);
            Controls.SetChildIndex(buttonPrimary1, 0);
            roundedPanel2.ResumeLayout(false);
            roundedPanel2.PerformLayout();
            ((ISupportInitialize)numericUpDown1).EndInit();
            ((ISupportInitialize)dataGridView1).EndInit();
            ((ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ButtonPrimary btn_OK;
        private RoundedPanel roundedPanel2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private Label label6;
        private LinkLabel linkLabel1;
        private Label label1;
        private PictureBox pictureBox1;
        private ButtonPrimary buttonPrimary1;
        private NumericUpDown numericUpDown1;
        private Label label2;
        private Label label3;
        private DataGridViewCheckBoxColumn checkboxColumn;
        private DataGridViewTextBoxColumn SensorName;
        private DataGridViewTextBoxColumn SensorType;
        private DataGridViewTextBoxColumn Value;
        private DataGridViewTextBoxColumn Min;
        private DataGridViewTextBoxColumn Max;
    }
}
