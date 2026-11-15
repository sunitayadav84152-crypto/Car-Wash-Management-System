using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class Splashs : Form
    {
        public Splashs()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        int startp = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            startp += 1;
            progressBar1.Value = startp; // Myprogress ko progressBar1 kar dein
            if (progressBar1.Value == 100) // Myprogress ko progressBar1 kar dein
            {
                progressBar1.Value = 0; // Myprogress ko progressBar1 kar dein
                timer1.Stop();
                Logins Mylogin = new Logins();
                this.Hide();
                Mylogin.Show();
            }
        }

        private void Splashs_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
