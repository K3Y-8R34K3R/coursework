using System;
using System.Drawing;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label1.Location = new Point((this.Width - 304) / 2, label1.Location.Y);
            textBox1.Width = this.Width - 24;
            button1.Location = new Point(this.Width - 138, this.Height - 38);
        }
        public string TxtBox
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
