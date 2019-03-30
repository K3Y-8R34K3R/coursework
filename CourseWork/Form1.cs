using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class Main_Form : Form
    {
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
            Graphics MyFormGrap = this.CreateGraphics();
            LinearGradientBrush gradBrush = new LinearGradientBrush(ClientRectangle, Color.Green, Color.Blue, LinearGradientMode.Horizontal);
            MyFormGrap.FillRectangle(gradBrush, ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width, ClientRectangle.Height);
            MyFormGrap.Dispose();
        }

        private void Main_Form_Load(object sender, EventArgs e)
        {

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

