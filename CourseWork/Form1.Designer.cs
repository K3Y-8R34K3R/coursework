﻿namespace CourseWork
{
    partial class Main_Form
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main_Form));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.loading_picture = new System.Windows.Forms.PictureBox();
            this.button_exit = new System.Windows.Forms.PictureBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.button_start = new System.Windows.Forms.PictureBox();
            this.button_logs = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.loading_picture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.button_exit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.button_start)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.button_logs)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 5400;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // loading_picture
            // 
            this.loading_picture.Location = new System.Drawing.Point(371, 263);
            this.loading_picture.Name = "loading_picture";
            this.loading_picture.Size = new System.Drawing.Size(17, 18);
            this.loading_picture.TabIndex = 1;
            this.loading_picture.TabStop = false;
            // 
            // button_exit
            // 
            this.button_exit.Location = new System.Drawing.Point(756, 263);
            this.button_exit.Name = "button_exit";
            this.button_exit.Size = new System.Drawing.Size(16, 20);
            this.button_exit.TabIndex = 5;
            this.button_exit.TabStop = false;
            this.button_exit.Visible = false;
            this.button_exit.Click += new System.EventHandler(this.button_exit_Click);
            this.button_exit.MouseLeave += new System.EventHandler(this.button_exit_MouseLeave);
            this.button_exit.MouseHover += new System.EventHandler(this.button_exit_MouseHover);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(12, 60);
            this.trackBar1.Minimum = 2;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(104, 45);
            this.trackBar1.TabIndex = 6;
            this.trackBar1.Value = 2;
            this.trackBar1.Visible = false;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(12, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(555, 22);
            this.label1.TabIndex = 7;
            this.label1.Text = "Переместите бегунок для изменения количества пиров в сети.";
            this.label1.Visible = false;
            // 
            // button_start
            // 
            this.button_start.Location = new System.Drawing.Point(687, 60);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(16, 20);
            this.button_start.TabIndex = 8;
            this.button_start.TabStop = false;
            this.button_start.Visible = false;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // button_logs
            // 
            this.button_logs.Location = new System.Drawing.Point(756, 218);
            this.button_logs.Name = "button_logs";
            this.button_logs.Size = new System.Drawing.Size(16, 20);
            this.button_logs.TabIndex = 9;
            this.button_logs.TabStop = false;
            this.button_logs.Visible = false;
            this.button_logs.Click += new System.EventHandler(this.button_logs_Click);
            // 
            // Main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 295);
            this.Controls.Add(this.button_logs);
            this.Controls.Add(this.button_start);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.button_exit);
            this.Controls.Add(this.loading_picture);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "P2P Network Visualisation";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_Form_FormClosing);
            this.Load += new System.EventHandler(this.Main_Form_Load);
            this.Resize += new System.EventHandler(this.Main_Form_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.loading_picture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.button_exit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.button_start)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.button_logs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox loading_picture;
        private System.Windows.Forms.PictureBox button_exit;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox button_start;
        private System.Windows.Forms.PictureBox button_logs;
    }
}

