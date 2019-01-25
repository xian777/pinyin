using System;
using System.Drawing;
using System.Windows.Forms;

namespace PinYin
{
    public partial class Form1 : Form
    {
        private Random rnd = new Random();
        private int rnd1;
        private int rnd2;
        private Graphics g;
        private Image img;
        
        private string[][] ary = new string[][]
        {
            new string[] { "b", "p",  "m", "f", "d", "t", "n", "l" },
            new string[] { "g", "k",  "h", "j", "q", "x", "zh", "ch" },
            new string[] { "sh", "r", "z", "c", "s", "a", "o", "e" },
            new string[] { "e", "ai", "ei", "ao", "ou", "an", "en", "ang" },
            new string[] { "eng", "er",  "yi", "wu", "yu", "", "", "" }
        };

        public Form1()
        {
            InitializeComponent();
            
        }

        private void RandomImage()
        {
            int r1 = this.rnd.Next(8);
            int r2 = this.rnd.Next(5);
            this.rnd1 = r1;
            this.rnd2 = r2;
            this.Text = $"r1: {rnd1}, r2: {rnd2}, value: {ary[rnd2][rnd1]} ";
            Rectangle rect = new Rectangle(r1 * 54, r2 * 42, 58, 42);
            this.g.DrawImage(this.img, 0, 0, rect, GraphicsUnit.Pixel);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue >= 65 && e.KeyValue <= 90)
            {
                this.label2.Text += e.KeyData;
            }
            else if (e.KeyData == Keys.Space)
            {
                if (this.label2.Text.ToLower() == ary[rnd2][rnd1])
                {
                    this.RandomImage();
                    this.label2.BackColor = Color.LightGray;
                }
                else
                {
                    this.label2.BackColor = Color.Red;
                }
                this.label2.Text = string.Empty;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.g = this.pictureBox1.CreateGraphics();
            this.img = PinYin.Properties.Resources.image1;
            this.RandomImage();
        }
    }
}
