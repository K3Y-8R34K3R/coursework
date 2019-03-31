using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Threading;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;

namespace CourseWork
{
    public partial class Main_Form : Form
    {
        const int particles_amount = 15; //количество кругов для отрисовки

        SolidBrush figure_brush;    //объект для заливки рисуемой фигуры
        Pen outline_pen;            //объект для обводки рисуемой фигуры
        BufferedGraphicsContext buff_graphics_context = BufferedGraphicsManager.Current;
        BufferedGraphics buff_graphics;     //графический буфер
        Graphics main_graphics;     //объект графики для отрисовки с привязкой к форме

        Random rand;                // объект для получения случайных чисел

        int[] alpha_value = new int[particles_amount]; //массив для хранения прозрачности кругов
        int[,] coords = new int[2, particles_amount];  //массив для хранения координат кругов
        int[] radiuses = new int[particles_amount];    //массив для хранения радиусов кругов
        int outline_alpha = 20;                        //значение альфа-канала обводки

        //функция, которая рисует круг по координатам его центра
        private void DrawCircle(int x, int y, int r)
        {
            int xc, yc;
            xc = x - r;
            yc = y - r;
            buff_graphics.Graphics.FillEllipse(figure_brush, xc, yc, r, r);
            buff_graphics.Graphics.DrawEllipse(outline_pen, xc, yc, r, r);
        }

        public Main_Form()
        {
            InitializeComponent();
            DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            menuStrip1.BackColor = Color.Transparent;
            main_graphics = this.CreateGraphics();           //задание графики с привязкой к форме
            main_graphics.SmoothingMode = SmoothingMode.AntiAlias;
            buff_graphics = buff_graphics_context.Allocate(main_graphics, this.ClientRectangle);
        }

        private void form_background_painter()
        {
            rand = new Random(); //инициализация объекта для псевдослучайных чисел
            start_circles_draw();
        }

        private void start_circles_draw()
        {
            outline_pen = new Pen(Color.FromArgb(20, 255, 255, 255)); //задание цвета для карандаша

            fill_form_background();

            //вызов функции для отрисовки круга с предварительным выбором координат центра круга
            //значений прозрачностей и радиусов
            for (int i = 0; i < particles_amount; i++)
            {
                alpha_value[i] = rand.Next(20, 40);
                radiuses[i] = rand.Next(5, 150);

                //задание цвета для кисти
                figure_brush = new SolidBrush(Color.FromArgb(alpha_value[i], 255, 244, 244));

                coords[0, i] = rand.Next(this.Width);
                coords[1, i] = rand.Next(this.Height);
                DrawCircle(coords[0, i], coords[1, i], radiuses[i]);
            }

            buff_graphics.Render(main_graphics);

            fadeout();
            start_circles_draw();
        }

        private void fill_form_background()
        {
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
            buff_graphics.Graphics.FillRectangle(gradient_brush, ClientRectangle.X, ClientRectangle.Y,
                                        ClientRectangle.Width, ClientRectangle.Height);
        }

        private void fadeout()
        {
            for (int i = 0; i < 40; i++)
            {
                fill_form_background();
                if (outline_alpha != 0) outline_alpha--;
                for (int j = 0; j < 15; j++)
                {
                    if (alpha_value[j] != 0) alpha_value[j]--;
                    figure_brush = new SolidBrush(Color.FromArgb(alpha_value[j], 255, 244, 244));
                    outline_pen = new Pen(Color.FromArgb(outline_alpha, 255, 255, 255));
                    DrawCircle(coords[0, j], coords[1, j], radiuses[j]);
                }
                buff_graphics.Render(main_graphics);
                Thread.Sleep(50);
            }

            buff_graphics.Render(main_graphics);
        }
        private void Main_Form_Load(object sender, EventArgs e)
        {
            form_background_painter();
            #region somecode
            //List<PictureBox> picturebox = new List<PictureBox>();
            //DirectoryInfo directoryInfo = new DirectoryInfo("media\\logosmall.png");
            //var recentpics = directoryInfo.GetFiles().ToList();
            //var y = 10;

            //foreach (var file in recentpics)
            //{
            //    var pb = new PictureBox();
            //    pb.Location = new Point(picturebox.Count * 120 + 20, y);
            //    pb.Size = new Size(100, 120);
            //    try
            //    {
            //        pb.Image = Image.FromFile(file.FullName);
            //    }
            //    catch (OutOfMemoryException) { continue; }
            //    pb.SizeMode = PictureBoxSizeMode.StretchImage;
            //    flowLayoutPanel1.Controls.Add(pb);
            //    picturebox.Add(pb);
            //}
            #endregion
        }

        private void Main_Form_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            main_graphics.Dispose();
            buff_graphics.Dispose();
            this.Close();
        }
    }
}

