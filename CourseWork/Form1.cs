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

        Image peer_img_file = Image.FromFile("res\\peer.png");

        PictureBox[] pb_array = new PictureBox[11];
        Graphics main_graphics;

        public Main_Form()
        {
            InitializeComponent();
            DoubleBuffered = true; // double bufferisation support
            this.SetStyle(ControlStyles.ResizeRedraw, true); // resize redraw support
            main_graphics = this.CreateGraphics();           // making graphics based on form
            main_graphics.SmoothingMode = SmoothingMode.AntiAlias; // smoothing enabling
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true); // transparency support
            this.SetStyle(ControlStyles.UserPaint, true); //user paint support
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
            picturebox_draw(2);
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
                button_exit.Location = new Point(this.Width - 48 - Image.FromFile(button_image_file + "_exit.png").Size.Width, this.Height - 48 - Image.FromFile(button_image_file + "_exit.png").Size.Height);
                button_exit.Size = Image.FromFile(button_image_file + "_exit.png").Size;
                button_exit.Image = Image.FromFile(button_image_file + "_exit.png");
                //
                // trackBar
                //
                trackBar1.Location = new Point(button_picture3.Location.X + button_picture3.Width + 48, 52);
                trackBar1.Size = new Size(355, 97);
                trackBar1.Visible = true;
            }
            catch
            {
                //ArgumentNullException
            }
        }

        private void picturebox_draw(int amount)
        {
            // disposing cntrls
            int iter = 0;
            while (pb_array[iter] != null)
            {
                this.pb_array[iter].Dispose();
                iter++;
            }
            // drawing pictureboxes on form
            for (int i = 0; i < amount; i++)
            {
                pb_array[i] = new PictureBox();
                pb_array[i].Image = peer_img_file;
                pb_array[i].Location = new Point(48 + i * peer_img_file.Width + 40 * i, 193);
                pb_array[i].Name = "pictureBox" + i.ToString();
                pb_array[i].Size = peer_img_file.Size;
                Controls.Add(pb_array[i]);
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
            draw_gui();
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            picturebox_draw(trackBar1.Value);
        }

        private void Main_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Main_Form_Paint(object sender, PaintEventArgs e)
        {
            Pen myPen = new Pen(Color.Black, 1);
            e.Graphics.DrawLine(myPen, 10, 10, 30 * trackBar1.Value, 30 * trackBar1.Value);
            myPen.Dispose(); //disposing pen
        }
    }
}

