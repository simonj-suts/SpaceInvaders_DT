using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceInvaders
{
    public partial class SinglePlayerMenu : Form
    {
        public SinglePlayerMenu()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                Client c = new Client(textBox1.Text);
                c.Show();
                this.Close();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void SinglePlayerMenu_Load(object sender, EventArgs e)
        {
            label2.Location = new Point(Convert.ToInt32((double)this.Width * 0.40), Convert.ToInt32((double)this.Height * 0.15));
            textBox1.Location = new Point(Convert.ToInt32((double)this.Width * 0.42), Convert.ToInt32((double)this.Height * 0.35));
            button1.Location = new Point(Convert.ToInt32((double)this.Width * 0.45), Convert.ToInt32((double)this.Height * 0.55));
        }
    }
}
