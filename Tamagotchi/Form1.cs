using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tamagotchi
{
    public partial class Form1 : Form
    {
        bool IsSleeping = false;
        bool IsDead = false;
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image = imageList1.Images[0];
            button4.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(progressBar1.Value - 5 >= 0 && !IsSleeping)
            {
                pictureBox1.Image = imageList1.Images[3];
                progressBar1.Value -= 5;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!IsSleeping && progressBar2.Value - 5 >= 0)
            {
                button2.Text = "wake up";
                IsSleeping = true;
                pictureBox1.Image = imageList1.Images[1];
            }
            else if (IsSleeping)
            {
                Wakeup();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(progressBar3.Value + 5 <= 100 && !IsSleeping)
            {
                progressBar3.Value += 5;
                pictureBox1.Image = imageList1.Images[2];
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            IsDead = CheckHealth();
            if (!IsDead) AddCharacteristics();
            if (IsDead) DeathImitation();
        }
        public void Wakeup()
        {
            IsSleeping = false;
            button2.Text = "sleep";
            pictureBox1.Image = imageList1.Images[0];
        }
        public void AddCharacteristics()
        {
            progressBar1.Value += 1;
            if (IsSleeping && progressBar2.Value - 1 != 0) progressBar2.Value -= 1;
            else if (IsSleeping && progressBar2.Value - 1 == 0) Wakeup();
            else progressBar2.Value += 1;
            progressBar3.Value -= 1;
        }
        public bool CheckHealth()
        {
            if (progressBar1.Value == progressBar1.Maximum || progressBar2.Value == progressBar2.Maximum)
            {

                return true;
            }
            else return false;
        }
        public void DeathImitation()
        {
            pictureBox1.Image = imageList1.Images[4];
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = true;
            timer1.Enabled = false;
            MessageBox.Show("Your Tamagotchi is died(");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = imageList1.Images[0];
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = false;
            timer1.Enabled = true;
            progressBar1.Value = 10;
            progressBar2.Value = 10;
            progressBar3.Value = 100;
        }
    }
}
