#region using's
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;
using System.Threading;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using System.Linq;
#endregion

namespace CourseWork
{
    public partial class Main_Form : Form
    {
        const string loading_file = "res\\loading.gif";
        const string bg_image_file = "res\\bg.png";
        const string button_image_file = "res\\button";
        Graphics main_graphics;     //объект графики для отрисовки с привязкой к форме

        public Main_Form()
        {
            InitializeComponent();
            DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            main_graphics = this.CreateGraphics();           //задание графики с привязкой к форме
            main_graphics.SmoothingMode = SmoothingMode.AntiAlias;
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.UserPaint, true);
        }

        private void loading_screen()
        {
            this.BackColor = Color.Black;
            loading_picture.Parent = this;
            loading_picture.Image = Image.FromFile(loading_file);
            loading_picture.Size = Image.FromFile(loading_file).Size;
            loading_picture.Location = new Point((this.ClientRectangle.Width / 2) - (loading_picture.Width / 2),
                                            (this.ClientRectangle.Height / 2) + (loading_picture.Height - 2));
        }

        private void draw_gui()
        {
            try
            {
                //
                //button 1
                //
                button_picture1.Location = new Point(48, 48);
                button_picture1.Size = Image.FromFile(button_image_file + "1.png").Size;
                button_picture1.Image = Image.FromFile(button_image_file + "1.png");
                //
                //button 2
                //
                button_picture2.Location = new Point(button_picture1.Location.X + button_picture1.Width + 48, 48);
                button_picture2.Size = Image.FromFile(button_image_file + "2.png").Size;
                button_picture2.Image = Image.FromFile(button_image_file + "2.png");
                //
                //button 3
                //
                button_picture3.Location = new Point(button_picture2.Location.X + button_picture2.Width + 48, 48);
                button_picture3.Size = Image.FromFile(button_image_file + "3.png").Size;
                button_picture3.Image = Image.FromFile(button_image_file + "3.png");
                //
                //button exit
                //
                button_exit.Location = new Point(this.Width -48-Image.FromFile(button_image_file + "_exit.png").Size.Width, this.Height - 48 - Image.FromFile(button_image_file + "_exit.png").Size.Height);
                button_exit.Size = Image.FromFile(button_image_file + "_exit.png").Size;
                button_exit.Image = Image.FromFile(button_image_file + "_exit.png");
            }
            catch
            {
                //ArgumentNullException
            }
        }

        private void Main_Form_Load(object sender, EventArgs e)
        {
            loading_screen();
        }

        private void Main_Form_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            loading_picture.Image = null;
            loading_picture.Visible = false;
            this.BackColor = Color.Transparent;
            this.BackgroundImage = Image.FromFile(bg_image_file);
            button1.Visible = true;
            draw_gui();
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

