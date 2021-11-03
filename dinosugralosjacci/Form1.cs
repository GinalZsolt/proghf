using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dinosugralosjacci
{
    public partial class Form1 : Form
    {
         
        static int magassag = 16;
        static bool gravitacio = false;
        static int pont=0;
        
        public Form1()
        {
            
            InitializeComponent();
            timer2.Start();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (magassag != 0 && gravitacio == false)
            {
                pictureBox1.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y - 5);
                magassag--;
            }
            if (magassag == 0 && gravitacio == false)
            {
                gravitacio = true;
            }
            if (gravitacio == true)
            {
                pictureBox1.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y + 5);
                magassag++;
            }
            if (magassag == 16 && gravitacio == true)
            {
                gravitacio = false;
                timer1.Stop();
            }
            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            pictureBox2.Location = new Point(pictureBox2.Location.X - 5, pictureBox2.Location.Y);
            if (talalat())
            {
                timer2.Stop();
                timer1.Stop();
                button1.Enabled = true;
            }
            if (pictureBox2.Location.X+pictureBox2.Width<=0)
            {
                pictureBox2.Location = new Point(400, 138);
                pont++;
                label2.Text = pont.ToString();
            }
        }
        public bool talalat()
        {
           
            if (pictureBox1.Location.Y+pictureBox1.Height>pictureBox2.Location.Y)
            {
                if (pictureBox1.Location.X+pictureBox1.Width>pictureBox2.Location.X && pictureBox1.Location.X<pictureBox2.Location.X+pictureBox2.Width)
                {
                    return true;
                }
            }
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            this.InitializeComponent();
            timer2.Start();
            button1.Enabled = false;
            magassag = 16;
            gravitacio = false;
            pont = 0;
            label2.Text = pont.ToString();
        }
    }
}
