using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceInvaders.Windows_Form
{
    public partial class InstructionMultiplayer : Form
    {
        public InstructionMultiplayer()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void InstructionMultiplayer_Load(object sender, EventArgs e)
        {
            label1.Location = new Point(Convert.ToInt32((double)this.Width * 0.15), Convert.ToInt32((double)this.Height * 0.10));
            
            label3.Location = new Point(Convert.ToInt32((double)this.Width * 0.15), Convert.ToInt32((double)this.Height * 0.20));
            



            button1.Location = new Point(Convert.ToInt32((double)this.Width * 0.60), Convert.ToInt32((double)this.Height * 0.60));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Versus v = new Versus();
            v.Show();
            this.Close();
        }
    }
}
