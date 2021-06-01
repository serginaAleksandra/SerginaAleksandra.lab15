using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab15
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        DateTime date1 = new DateTime(0, 0);
        DateTime date2 = new DateTime(1, 1, 1);
        int time = 0, knull = 0;
        double Tao = 0;
        double[,] Q = new double[3, 2] { { 0.75, 0.25 }, { 0.5, 0.5 }, { 0.2, 0.8 } };
        double[] Statistika = new double[3];

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
            date2 = date2.AddHours(3);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            date1 = date1.AddHours(1);
            label1.Text = date1.ToString("dd.HH");

            Random a = new Random();
            double r = a.NextDouble();


            if (date1.ToString("HH") == date2.ToString("HH"))
            {
                if (knull == 0)
                {
                    label2.Text = "It's sunny now";
                    if (r - Q[0, 0] <= 0) knull = 1;
                    else knull = 2;
                    Tao = Math.Log(r) / (-0.4);
                    time += Convert.ToInt32(Tao);
                    Statistika[knull]++;
                    date2 = date1.AddHours(Tao);
                    pictureBox1.Image = lab15.Properties.Resources.sun;
                }
                else
                if (knull == 1)
                {
                    label2.Text = "It's raining now";
                    if (r - Q[1, 0] <= 0) knull = 0;
                    else knull = 2;
                    Tao = Math.Log(r) / (-0.8);
                    time += Convert.ToInt32(Tao);
                    Statistika[knull]++;
                    date2 = date1.AddHours(Tao);
                    pictureBox1.Image = lab15.Properties.Resources.rain;
                }
                else
                if (knull == 2)
                {
                    label2.Text = "It's cloudy now";
                    if (r - Q[2, 0] <= 0) knull = 0;
                    else knull = 1;
                    Tao = Math.Log(r) / -0.5;
                    time += Convert.ToInt32(Tao);
                    Statistika[knull]++;
                    date2 = date1.AddHours(Tao);
                    pictureBox1.Image = lab15.Properties.Resources.cloud;
                }
            }
            
            if ((date1.ToString("HH") == "00") & (label3.Text == "Sun")) label3.Text = "Mon";
            else
                if ((date1.ToString("HH") == "00") & (label3.Text == "Mon")) label3.Text = "Tue";
            else
                if ((date1.ToString("HH") == "00") & (label3.Text == "Tue")) label3.Text = "Wed";
            else
                if ((date1.ToString("HH") == "00") & (label3.Text == "Wed")) label3.Text = "Thu";
            else
                if ((date1.ToString("HH") == "00") & (label3.Text == "Thu")) label3.Text = "Fri";
            else
                if ((date1.ToString("HH") == "00") & (label3.Text == "Fri")) label3.Text = "Sat";
            else
                if ((date1.ToString("HH") == "00") & (label3.Text == "Sat")) label3.Text = "Sun";
        }
    }
}
