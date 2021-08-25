using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hunting_Game_001
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // --> Here is for label which show type your name in that way type name section doesn't take place <--
            if (textBox1.TextLength > 0)
            {
                label2.Visible = false;
            }
            else
            {
                label2.Visible = true;

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            // --> Skip to other window <--
            if (textBox1.TextLength > 0)
            {
                this.Hide();
                Form2 f2 = new Form2(textBox1.Text);
                f2.ShowDialog();
                this.Close();
            }
            else
            {
                // --> if you did't write your name program going to show that message <--
                MessageBox.Show("Please Type your Name", "Warning");
            }
            

        }



        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // --> tool strip system <--
            textBox2.Visible = true;
            button1.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // --> Help(How to Play?) Section <--
            button1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
        }

        private void creatorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // --> Creators Section <--
            textBox3.Visible = true;
            button1.Visible = true;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // --> About program section <--
            textBox4.Visible = true;
            button1.Visible = true;
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // --> Close Button <--
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
