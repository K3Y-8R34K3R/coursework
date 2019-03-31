using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CourseWork
{
    public partial class Main_Form : Form
    {
        SolidBrush figure_brush;    //объект для заливки рисуемой фигуры
        Pen outline_pen;            //объект для обводки рисуемой фигуры
        Graphics form_graphics;     //объект графики

        int circle_radius;          // переменная для хранения радиуса рисуемых кругов
        Random rand;                // объект для получения случайных чисел

        //функция, которая рисует круг по координатам его центра
        void DrawCircle(int x, int y)
        {
            int xc, yc;
            circle_radius = rand.Next(10, 100);
            xc = x - circle_radius;
            yc = y - circle_radius;
            form_graphics.FillEllipse(figure_brush, xc, yc, circle_radius, circle_radius);

            form_graphics.DrawEllipse(outline_pen, xc, yc, circle_radius, circle_radius);

        }
        public Main_Form()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        private void Paint_btn_Click(object sender, EventArgs e)
        {
            form_background_painter();
        }

        private void form_background_painter()
        {
            form_graphics = this.CreateGraphics();           //задание графики с привязкой к форме
            outline_pen = new Pen(Color.White);              //задание цвета для карандаша 
            figure_brush = new SolidBrush(Color.WhiteSmoke); //задание цвета для кисти

            rand = new Random();                             //инициализация объекта для псевдослучайных чисел

            //создание и инициализация объекта кисти для отрисовки линейного градиента
            LinearGradientBrush gradient_brush = new LinearGradientBrush(ClientRectangle,
                                                                    Color.FromArgb(10, 29, 59),
                                                                    Color.FromArgb(14, 40, 64),
                                                                    LinearGradientMode.Horizontal);

            //закраска области рисования кистью линейного градиента
            form_graphics.FillRectangle(gradient_brush, ClientRectangle.X, ClientRectangle.Y,
                                        ClientRectangle.Width, ClientRectangle.Height);

            //вызов функции для отрисовки круга с предварительным выбором координат центра круга
            int x, y;

            for (int i = 0; i < 15; i++)
            {
                x = rand.Next(this.Width);
                y = rand.Next(this.Height);
                DrawCircle(x, y);
            }
            
            //включение таймера
            timer1.Enabled = true;

           
            form_graphics.Dispose();
        }

        private void Main_Form_Load(object sender, EventArgs e)
        {
            List<PictureBox> picturebox = new List<PictureBox>();
            DirectoryInfo directoryInfo = new DirectoryInfo("media\\logosmall.png");
            var recentpics = directoryInfo.GetFiles().ToList();
            var y = 10;

            foreach (var file in recentpics)
            {
                var pb = new PictureBox();
                pb.Location = new Point(picturebox.Count * 120 + 20, y);
                pb.Size = new Size(100, 120);
                try
                {
                    pb.Image = Image.FromFile(file.FullName);
                }
                catch (OutOfMemoryException) { continue; }
                pb.SizeMode = PictureBoxSizeMode.StretchImage;
                flowLayoutPanel1.Controls.Add(pb);
                picturebox.Add(pb);
            }
        }

        private void Exit_Btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Main_Form_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
        }

    }
}

