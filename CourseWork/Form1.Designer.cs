namespace CourseWork
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.loading_picture = new System.Windows.Forms.PictureBox();
            this.button_picture1 = new System.Windows.Forms.PictureBox();
            this.button_picture2 = new System.Windows.Forms.PictureBox();
            this.button_picture3 = new System.Windows.Forms.PictureBox();
            this.button_exit = new System.Windows.Forms.PictureBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.loading_picture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.button_picture1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.button_picture2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.button_picture3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.button_exit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
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
            // button_picture1
            // 
            this.button_picture1.Location = new System.Drawing.Point(12, 12);
            this.button_picture1.Name = "button_picture1";
            this.button_picture1.Size = new System.Drawing.Size(16, 20);
            this.button_picture1.TabIndex = 2;
            this.button_picture1.TabStop = false;
            this.button_picture1.MouseLeave += new System.EventHandler(this.button_picture1_MouseLeave);
            this.button_picture1.MouseHover += new System.EventHandler(this.button_picture1_MouseHover);
            // 
            // button_picture2
            // 
            this.button_picture2.Location = new System.Drawing.Point(34, 12);
            this.button_picture2.Name = "button_picture2";
            this.button_picture2.Size = new System.Drawing.Size(16, 20);
            this.button_picture2.TabIndex = 3;
            this.button_picture2.TabStop = false;
            this.button_picture2.MouseLeave += new System.EventHandler(this.button_picture2_MouseLeave);
            this.button_picture2.MouseHover += new System.EventHandler(this.button_picture2_MouseHover);
            // 
            // button_picture3
            // 
            this.button_picture3.Location = new System.Drawing.Point(56, 12);
            this.button_picture3.Name = "button_picture3";
            this.button_picture3.Size = new System.Drawing.Size(16, 20);
            this.button_picture3.TabIndex = 4;
            this.button_picture3.TabStop = false;
            this.button_picture3.MouseLeave += new System.EventHandler(this.button_picture3_MouseLeave);
            this.button_picture3.MouseHover += new System.EventHandler(this.button_picture3_MouseHover);
            // 
            // button_exit
            // 
            this.button_exit.Location = new System.Drawing.Point(756, 263);
            this.button_exit.Name = "button_exit";
            this.button_exit.Size = new System.Drawing.Size(16, 20);
            this.button_exit.TabIndex = 5;
            this.button_exit.TabStop = false;
            this.button_exit.Click += new System.EventHandler(this.button_exit_Click);
            this.button_exit.MouseLeave += new System.EventHandler(this.button_exit_MouseLeave);
            this.button_exit.MouseHover += new System.EventHandler(this.button_exit_MouseHover);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(668, 12);
            this.trackBar1.Minimum = 2;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(104, 45);
            this.trackBar1.TabIndex = 6;
            this.trackBar1.Value = 2;
            this.trackBar1.Visible = false;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // Main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 295);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.button_exit);
            this.Controls.Add(this.button_picture3);
            this.Controls.Add(this.button_picture2);
            this.Controls.Add(this.button_picture1);
            this.Controls.Add(this.loading_picture);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Main_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_Form_FormClosing);
            this.Load += new System.EventHandler(this.Main_Form_Load);
            this.Resize += new System.EventHandler(this.Main_Form_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.loading_picture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.button_picture1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.button_picture2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.button_picture3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.button_exit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox loading_picture;
        private System.Windows.Forms.PictureBox button_picture1;
        private System.Windows.Forms.PictureBox button_picture2;
        private System.Windows.Forms.PictureBox button_picture3;
        private System.Windows.Forms.PictureBox button_exit;
        private System.Windows.Forms.TrackBar trackBar1;
    }
}

