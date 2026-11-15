using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class Logins : Form
    {
        public Logins()
        {
            InitializeComponent();
        }

        private void ENameTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            AdminLogin obj = new AdminLogin();
            obj.Show();
            this.Hide();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=.\SQLEXPRESS01;Initial Catalog=CarWashDB;Integrated Security=True;TrustServerCertificate=True");
        public static string Username = "";
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            carwash obj1 = new carwash();
            obj1.Show();
            this.Hide();
            return;

            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from EmployeeTbl where EName='"+UNameTb.Text+"' and EPass='"+PasswordTb.Text+"'", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                Username = UNameTb.Text;
                carwash Obj = new carwash();
                Obj.Show();
                this.Hide();
                Con.Close();
            }else
            {
                MessageBox.Show("Wrong UserName or Password");
            }
            Con.Close();
        }
    }
}
