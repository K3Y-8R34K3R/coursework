using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Threading;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CourseWork
{
    public partial class Main_Form : Form
    {
        const string filepath = "media\\loading.gif";
        //SolidBrush figure_brush;    //объект для заливки рисуемой фигуры
        //Pen outline_pen;            //объект для обводки рисуемой фигуры
        BufferedGraphicsContext buff_graphics_context = BufferedGraphicsManager.Current;
        BufferedGraphics buff_graphics;     //графический буфер
        Graphics main_graphics;     //объект графики для отрисовки с привязкой к форме

        //Random rand;                // объект для получения случайных чисел

        //int[] alpha_value = new int[particles_amount]; //массив для хранения прозрачности кругов
        //int[,] coords = new int[2, particles_amount];  //массив для хранения координат кругов
        //int[] radiuses = new int[particles_amount];    //массив для хранения радиусов кругов
        //int outline_alpha = 20;                        //значение альфа-канала обводки
        //bool first_init = true;
        //функция, которая рисует круг по координатам его центра
        //private void DrawCircle(int x, int y, int r)
        //{
        //    int xc, yc;
        //    xc = x - r;
        //    yc = y - r;
        //    buff_graphics.Graphics.FillEllipse(figure_brush, xc, yc, r, r);
        //    buff_graphics.Graphics.DrawEllipse(outline_pen, xc, yc, r, r);
        //}

        public Main_Form()
        {
            InitializeComponent();
            DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            main_graphics = this.CreateGraphics();           //задание графики с привязкой к форме
            main_graphics.SmoothingMode = SmoothingMode.AntiAlias;
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            buff_graphics = buff_graphics_context.Allocate(main_graphics, this.ClientRectangle);
        }

        private void fill_form_background_start()
        {
            pictureBox1.Image = Image.FromFile(filepath);
            pictureBox1.Size = Image.FromFile(filepath).Size;
            pictureBox1.Location = new Point((this.ClientRectangle.Width / 2) - (pictureBox1.Width / 2),
                                            (this.ClientRectangle.Height / 2) + (pictureBox1.Height - 2));
            this.BackColor = Color.Black;
            pictureBox1.BackColor = Color.Transparent;
        }

        private void fill_form_background_onwork()
        {
            buff_graphics = buff_graphics_context.Allocate(main_graphics, this.ClientRectangle);

            //создание и инициализация объекта кисти для отрисовки линейного градиента
            LinearGradientBrush gradient_brush = new LinearGradientBrush(ClientRectangle,
                                                                    Color.FromArgb(10, 29, 59),
                                                                    Color.FromArgb(14, 40, 64),
                                                                    LinearGradientMode.Horizontal);

            ColorBlend color_blend = new ColorBlend();
            color_blend.Colors = new Color[] { Color.FromArgb(10, 29, 59),
                                               Color.FromArgb(11, 32, 61),
                                               Color.FromArgb(12, 35, 62),
                                               Color.FromArgb(13, 38, 63),
                                               Color.FromArgb(14, 40, 64),};
            color_blend.Positions = new float[] { (float)0.0, (float)0.2, (float)0.5, (float)0.8, (float)1.0 };
            gradient_brush.InterpolationColors = color_blend;

            //закраска области рисования кистью линейного градиента
            main_graphics.FillRectangle(gradient_brush, ClientRectangle.X, ClientRectangle.Y,
                                        ClientRectangle.Width, ClientRectangle.Height);
        }

        private void Main_Form_Load(object sender, EventArgs e)
        {
            fill_form_background_start();
        }

        private void Main_Form_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            main_graphics.Dispose();
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            pictureBox1.Image = null;
            pictureBox1.Enabled = false;
            pictureBox1.Visible = false;
            fill_form_background_onwork();
            button1.Visible = true;
        }
    }
}

