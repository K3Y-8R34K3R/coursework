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
            ((System.ComponentModel.ISupportInitialize)(this.loading_picture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.button_picture1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.button_picture2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.button_picture3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.button_exit)).BeginInit();
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
            // 
            // button_picture2
            // 
            this.button_picture2.Location = new System.Drawing.Point(34, 12);
            this.button_picture2.Name = "button_picture2";
            this.button_picture2.Size = new System.Drawing.Size(16, 20);
            this.button_picture2.TabIndex = 3;
            this.button_picture2.TabStop = false;
            // 
            // button_picture3
            // 
            this.button_picture3.Location = new System.Drawing.Point(56, 12);
            this.button_picture3.Name = "button_picture3";
            this.button_picture3.Size = new System.Drawing.Size(16, 20);
            this.button_picture3.TabIndex = 4;
            this.button_picture3.TabStop = false;
            // 
            // button_exit
            // 
            this.button_exit.Location = new System.Drawing.Point(756, 263);
            this.button_exit.Name = "button_exit";
            this.button_exit.Size = new System.Drawing.Size(16, 20);
            this.button_exit.TabIndex = 5;
            this.button_exit.TabStop = false;
            this.button_exit.Click += new System.EventHandler(this.button_exit_Click);
            // 
            // Main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 295);
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
            this.Load += new System.EventHandler(this.Main_Form_Load);
            this.Resize += new System.EventHandler(this.Main_Form_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.loading_picture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.button_picture1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.button_picture2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.button_picture3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.button_exit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox loading_picture;
        private System.Windows.Forms.PictureBox button_picture1;
        private System.Windows.Forms.PictureBox button_picture2;
        private System.Windows.Forms.PictureBox button_picture3;
        private System.Windows.Forms.PictureBox button_exit;
    }
}

