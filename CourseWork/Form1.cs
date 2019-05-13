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
        #region global vars
        /// <summary>
        ///блок ресурсов для отрисовки кнопок
        /// </summary>
        Image loading_file_img = Image.FromFile("res\\loading.gif");
        Image bg_img = Image.FromFile("res\\bg.png");
        Image button_exit_img = Image.FromFile("res\\button_exit.png");
        Image button_start_img = Image.FromFile("res\\button_start.png");
        Image button_draw_img = Image.FromFile("res\\button_draw.png");
        Image peer_img = Image.FromFile("res\\peer.png");



        /// <summary>
        /// Массив с "пирами" и булевы переменные для корректной отрисовки
        /// </summary>
        PictureBox[] pb_array = new PictureBox[11];

        bool init_once = true;
        bool movement = false;

        /// <summary>
        /// Объекты графики для отрисовки GUI
        /// </summary>
        Point temp;

        Graphics main_graphics;
        BufferedGraphics buff;
        //BufferedGraphicsContext buff_cont;
        #endregion

        #region Main_Form code
        public Main_Form()
        {
            InitializeComponent();
            DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            main_graphics = this.CreateGraphics();           //задание графики с привязкой к форме
            main_graphics.SmoothingMode = SmoothingMode.AntiAlias;
            buff = BufferedGraphicsManager.Current.Allocate(main_graphics, ClientRectangle);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.UserPaint, true);
        }

        private void Main_Form_Load(object sender, EventArgs e)
        {
            loading_screen();
        }

        private void Main_Form_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void Main_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region custom methods
        private void loading_screen()
        {
            this.BackColor = Color.Black;
            loading_picture.Parent = this;
            loading_picture.Image = loading_file_img;
            loading_picture.Size = loading_file_img.Size;
            loading_picture.Location = new Point((this.ClientRectangle.Width / 2) - (loading_picture.Width / 2),
                                            (this.ClientRectangle.Height / 2) + (loading_picture.Height - 2));
        }

        private void draw_gui()
        {
            try
            {
                //
                // label1
                //
                label1.Visible = true;
                label1.Location = new Point(48,48);
                //
                // trackbar1
                //
                trackBar1.Visible = true;
                trackBar1.Location = new Point(label1.Location.X, label1.Location.Y + 48);
                trackBar1.Size = new Size(355, 100);
                //
                // отрисовка кнопки
                //
                //button_draw.Visible = true;
                //button_draw.Location = new Point(trackBar1.Location.X, trackBar1.Location.Y + 48);
                //button_exit.Size = button_draw_img.Size;
                //button_exit.Image = button_draw_img;
                //
                //button exit
                //
                button_exit.Visible = true;
                button_exit.Location = new Point(this.Width - 48 - button_exit_img.Width, this.Height - 48 - button_exit_img.Height);
                button_exit.Size = button_exit_img.Size;
                button_exit.Image = button_exit_img;
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("\"File Not Found\" exception called.\nApplication will close soon.\nTry to re-install the application.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            picturebox_draw(this, trackBar1.Value, new PaintEventArgs(CreateGraphics(), ClientRectangle));
        }

        //
        // Прорисовка "пиров", назначение методов и их рендер
        //
        private void picturebox_draw(object sender, int amount, PaintEventArgs e)
        {
            buff.Dispose();
            buff = BufferedGraphicsManager.Current.Allocate(main_graphics, ClientRectangle);
            buff.Graphics.DrawImage(this.BackgroundImage, ClientRectangle);
            int iter = 0;
            while (pb_array[iter] != null)
            {
                pb_array[iter].Dispose();
                iter++;
            }
            for (int i = 0; i < amount; i++)
            {
                pb_array[i] = new PictureBox();
                pb_array[i].Image = peer_img;
                pb_array[i].Size = peer_img.Size;
                pb_array[i].Location = new Point(48 + i * (pb_array[i].Width + 50), 148);
                pb_array[i].MouseDown += new MouseEventHandler(pb_MouseDown);
                pb_array[i].MouseUp += new MouseEventHandler(pb_MouseUp);
                pb_array[i].MouseMove += new MouseEventHandler(pb_MouseMove);
                Controls.Add(pb_array[i]);
            }
            for (int i = 0; i < amount - 1; i++)
                for (int j = i + 1; j < amount; j++)
                    buff.Graphics.DrawLine(new Pen(Color.Black),
                        new Point(pb_array[i].Location.X + pb_array[i].Width, pb_array[i].Location.Y + pb_array[i].Height / 2), new Point(pb_array[j].Location.X, pb_array[j].Location.Y + pb_array[j].Height / 2));
            buff.Render();
        }

        void pb_MouseDown(object sender, MouseEventArgs e)
        {
            temp = e.Location;
            movement = true;
        }

        void pb_MouseMove(object sender, MouseEventArgs e)
        {
            if (movement)
            {
                PictureBox pb = (PictureBox)sender;
                Point pt = pb.Location;
                pt.X += e.X - temp.X;
                pt.Y += e.Y - temp.Y;
                pb.Location = pt;
            }
        }

        void pb_MouseUp(object sender, MouseEventArgs e)
        {
            movement = false;

            buff.Dispose();
            buff = BufferedGraphicsManager.Current.Allocate(main_graphics, ClientRectangle);
            buff.Graphics.DrawImage(this.BackgroundImage, ClientRectangle);

            for (int i = 0; i < trackBar1.Value - 1; i++)
                for (int j = i + 1; j < trackBar1.Value; j++)
                    buff.Graphics.DrawLine(new Pen(Color.Black),
                        new Point(pb_array[i].Location.X + pb_array[i].Width / 2, pb_array[i].Location.Y + pb_array[i].Height / 2), new Point(pb_array[j].Location.X + pb_array[j].Width / 2, pb_array[j].Location.Y + pb_array[j].Height / 2));
            buff.Render();
        }

        #endregion

        #region controls methods
        /// <summary>
        /// Метод для тайминга анимации загрузки
        /// </summary>
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            loading_picture.Image = null;
            loading_picture.Visible = false;
            this.BackColor = Color.Transparent;
            this.BackgroundImage = bg_img;
            draw_gui();
        }

        //
        // Блок анимаций кнопок на триггеры "MouseHover" и "MouseLeave"
        //
        private void button_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_exit_MouseLeave(object sender, EventArgs e)
        {
            button_exit.Visible = false;
            button_exit.Size = button_exit_img.Size;
            button_exit.Image = button_exit_img;
            button_exit.Location = new Point(this.Width - 48 - button_exit_img.Width, this.Height - 48 - button_exit_img.Height);
            button_exit.Visible = true;
            init_once = true;
        }

        private void button_exit_MouseHover(object sender, EventArgs e)
        {
            if (init_once)
            {
                Image img = new Bitmap(button_exit_img, button_exit.Width + 35, button_exit.Height + 5);
                button_exit.Size = img.Size;
                button_exit.Image = img;
                button_exit.Location = new Point(button_exit.Location.X - 17, button_exit.Location.Y - 3);
                button_exit.Visible = false;
                button_exit.Visible = true;
                init_once = false;
            }
        }

        //
        // Метод-событие для триггера "ValueChanged"
        //
        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            picturebox_draw(this, trackBar1.Value, new PaintEventArgs(CreateGraphics(), ClientRectangle));
        }
        #endregion
    }
}

