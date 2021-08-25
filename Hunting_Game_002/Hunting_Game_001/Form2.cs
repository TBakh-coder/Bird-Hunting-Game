using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Hunting_Game_001
{


    public partial class Form2 : Form
    {



        public Form2()
        {
            InitializeComponent();

        }
        public Form2(String value)
        {
            // --> here is for transfering data between windows <--
            InitializeComponent();
            label4.Text = "Hello " + value + " Choose the difficulty then start!";
            timer2.Interval = 1000;
            timer2.Tick += new EventHandler(timer2_Tick);
            timer2.Start();
         }
            public string value { get; set; }
        private void label3_Click(object sender, EventArgs e)
        {
            // --> Exit button <--
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
           
        }

        public void  setValue(bool value)
        {
            // --> method for difficulities <--
            radioButton1.Visible = value;
            radioButton2.Visible = value;
            radioButton3.Visible = value;
            pictureBox8.Visible = value;
            pictureBox9.Visible = value;
            pictureBox10.Visible = value;
        }
       
        public void Starting(bool value)
        {
            // --> method for starting screen <--
            label1.Visible = value;
            label2.Visible = value;
            label3.Visible = value;
            pictureBox3.Visible = value;
            pictureBox4.Visible = value;
            pictureBox5.Visible = value;
            label4.Visible = value;
            pictureBox1.Visible = value;
            pictureBox2.Visible = value;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked || radioButton2.Checked || radioButton3.Checked)
            {
                // --> when click start button any difficulity has to be choosen <--
                label10.Visible = true;
                panel1.Visible = true;
                Starting(false);
                setValue(false);
                
                timer2.Start();
                if (radioButton1.Checked || radioButton2.Checked)
                {
                    label6.Text = 30.ToString();
                }
                else if (radioButton3.Checked)
                {
                    label6.Text = 40.ToString();
                }
                pictureBox7.Visible = true;


                timer3.Start();
                Random rnd2 = new Random();
                label12.Text = rnd2.Next(35, 40).ToString();
                
            }

            else
            {
                MessageBox.Show("Please Choose a difficulty", "Warning");
            }

        }
        // --> for random points <--
        int X = 0;
        int Y = 0;
        private void timer2_Tick(object sender, EventArgs e)
        {
            

            // --> difficulity system <--
            if (radioButton1.Checked)
            {
                timer2.Interval = 900;

            }
            else if (radioButton2.Checked)
            {
                timer2.Interval = 700;
            }
            else if (radioButton3.Checked)
            {
                timer2.Interval = 500;
            }

            // --> Ramdom Movement <--
            if (int.Parse(label9.Text) >= 0)
            {
                X = ((int)(new Random().Next(0, 1025)));
                Y = ((int)(new Random().Next(0, 600)));
               
            }
            if (int.Parse(label9.Text) >= 10)
            {
                X = ((int)(new Random().Next(0, 1075)));
                Y = ((int)(new Random().Next(0, 615)));
            }
            if (int.Parse(label9.Text) >= 17)
            {
                X = ((int)(new Random().Next(0, 1100)));
                Y = ((int)(new Random().Next(0, 620)));
            }
            if (int.Parse(label9.Text) >= 25)
            {
                X = ((int)(new Random().Next(0, 1125)));
                Y = ((int)(new Random().Next(0, 625)));
            }
            if (int.Parse(label9.Text) >= 35)
            {
                X = ((int)(new Random().Next(0, 1150)));
                Y = ((int)(new Random().Next(0, 630)));
            }
            
            // --> it helps to keep character in frame // without this character go to out of window <--
            if (X > 1025 - pictureBox7.Width)
            {
                X = 1025 - pictureBox7.Width;


            }
            if (Y > 545 - pictureBox7.Height)
            {
                Y = 545 - pictureBox7.Height;

            }

            pictureBox7.Location = new Point(X, Y);

            // --> Award System <--
           
            int a = int.Parse(label6.Text);
            int b = int.Parse(label9.Text);

            if (label9.Text == 10.ToString())
            {   a += 3;
                b += 1;
                


            }
            else if (int.Parse(label9.Text) == 20 )
             {
                 
                 a += 4;
                b += 1;
                 
             }
             else if (int.Parse(label9.Text) == 30)
             {
                a += 5;
                b += 1;
             }
            label6.Text = a.ToString();
            label9.Text = b.ToString();



        }


        int count;
       
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            // --> scoring system <--
            if (radioButton1.Checked || radioButton2.Checked || radioButton3.Checked)
            { count += 1; }
            label9.Text = count.ToString();
            if (int.Parse(label12.Text) <= int.Parse(label9.Text))
            {
                pictureBox7.Visible = false;

                timer3.Stop();
                pictureBox13.Visible = true;
                label17.Visible = true;
                label13.Visible = true;
                label15.Visible = true;
                label14.Visible = true;
                label16.Visible = true;
                label9.Visible = false;
                label8.Visible = false;
                label7.Visible = false;
                label6.Visible = false;

            }

            if (label6.Text == 0.ToString())
            {
                // --> Game over system <--
                pictureBox7.Visible = false;
                pictureBoxgif.Visible = true;
                labelgameover.Visible = true;
                timer3.Stop();
            }
            int d = int.Parse(label6.Text);
            int c = Convert.ToInt32(label9.Text);
            label16.Text = c.ToString() + " Point";
            label14.Text = d.ToString() + " Second Left";


            //--> Leveling System <--

            Random rnd2 = new Random();
            int rnd3 = rnd2.Next(0, 9);
            
            if (int.Parse(label9.Text) == 10)
            {
                timer1.Start();
                labellevel.Visible = true;
                labellevel.Text = "You got 1 Level...";
                pictureBox7.Image = imageList1.Images[rnd3];
                this.Size = new Size(1050, 610);
            }
            if (int.Parse(label9.Text) == 17)
            {
                timer1.Start();
                labellevel.Visible = true;
                labellevel.Text = "You got 2 Level...";
                pictureBox7.Image = imageList1.Images[rnd3]; 
                this.Size = new Size(1075, 615);
            }
            if (int.Parse(label9.Text) == 20)
            {
                timer1.Start();
                labellevel.Visible = true;
                labellevel.Text = "You got 3 Level...";
                pictureBox7.Image = imageList1.Images[rnd3]; 
                this.Size = new Size(1100, 620);
            }
            if (int.Parse(label9.Text) == 25)
            {
                timer1.Start();
                labellevel.Visible = true;
                labellevel.Text = "You got 4 Level...";
                pictureBox7.Image = imageList1.Images[rnd3]; 
                this.Size = new Size(1125, 625);
            }
            if (int.Parse(label9.Text) >= 35)
            {
                timer1.Start(); timer1.Start();
                labellevel.Visible = true;
                labellevel.Text = "You got 5 and last Level...";
                pictureBox7.Image = imageList1.Images[rnd3]; 
                this.Size = new Size(1150, 630);
            }
        }

       

        private void label2_Click(object sender, EventArgs e)
        {
            // --> Diffulicity Button <--
          setValue(true); 
             pictureBox5.Visible = false;
             
        }

        private void label6_Click(object sender, EventArgs e)
        {
            label1.Enabled = true;

        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            
            double timeleft = Convert.ToDouble(label6.Text);
            if (timeleft == 0)
            {// --> Timer system <--
                pictureBox7.Visible = false;
                labelgameover.Visible = true;
                pictureBoxgif.Visible = true;
                timer3.Stop();
                MessageBox.Show("Game over"); // --> When player game over so timer finished and he/she will see that message in message box <--


            }
            else
            {
                timeleft -= 1;
            }
            label6.Text = (timeleft.ToString());

            

        }
        
        private void label10_Click(object sender, EventArgs e)
        {
            // --> Back button <--
            Starting(true);
            pictureBox13.Visible = false;
            label17.Visible = false;
            label13.Visible = false;
            label15.Visible = false;
            label14.Visible = false;
            label16.Visible = false;
            label9.Visible = true;
            label8.Visible = true;
            label7.Visible = true;
            label6.Visible = true;
            label10.Visible = false;
            pictureBoxgif.Visible = false;
            labelgameover.Visible = false;
            pictureBox7.Visible = false;
            label9.Text = 0.ToString();
            count = 0;
            timer2.Stop();
            label6.Text = 0.ToString();
            timer3.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labellevel.Visible = false;
            timer1.Stop();
        }

        
    }
}
// ALL COPYRIGHTS RESERVED BY VISTULA UNIVERSITY. THANK YOU FOR REVIEWING, BEST REGARDS BAKHTIYAR AGHAYEV
