using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class Customers : Form
    {
        public Customers()
        {
            InitializeComponent();
            displayCust();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=.\SQLEXPRESS01;Initial Catalog=CarWashDB;Integrated Security=True;TrustServerCertificate=True");
        private void Reset()
        {
            CNameTb.Text = "";
            CAddTb.Text = "";
            CCarTb.Text = "";
            CPhoneTb.Text = "";
            CStatusCb.SelectedIndex = -1;
        }
        private void displayCust()
        {
            Con.Open();
            string Query = "select * from CustomerTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            CustomerDGV.DataSource = ds.Tables[0];

            Con.Close();
        }
        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Employees Obj = new Employees();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            Logins Obj = new Logins();
            Obj.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            Services Obj = new Services();
            Obj.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Customers Obj = new Customers();
            Obj.Show();
            this.Hide();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }
       
        private void button3_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Select The Customer");
            }
            else
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("delete from CustomerTbl where CId=@CuId", Con);
                cmd.Parameters.AddWithValue("@CuId", Key);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Customer Deleted");
                Con.Close();
                displayCust();
                Reset();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (CNameTb.Text == "" || CAddTb.Text == "" || CStatusCb.SelectedIndex == -1 || CPhoneTb.Text == "" || CCarTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("Update CustomerTbl set CName=@Cn, CPhone=@Cp, CAdd=@Ca, CStatus=@Cs, CCar=@Cc where CId=@CuId", Con);
                cmd.Parameters.AddWithValue("@Cn", CNameTb.Text);
                cmd.Parameters.AddWithValue("@Cp", CPhoneTb.Text);
                cmd.Parameters.AddWithValue("@Ca", CAddTb.Text);
                cmd.Parameters.AddWithValue("@Cs", CStatusCb.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@Cc", CCarTb.Text);
                cmd.Parameters.AddWithValue("@CuId", Key);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Customer Updated");

                Con.Close();
                displayCust();
                Reset();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CNameTb.Text == "" || CAddTb.Text == "" || CStatusCb.SelectedIndex == -1 || CPhoneTb.Text == ""||CCarTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into CustomerTbl(CName,CPhone,CAdd,CStatus,CCar) values(@Cn,@Cp,@Ca,@Cs,@Cc)", Con);
                    cmd.Parameters.AddWithValue("@Cn", CNameTb.Text);
                    cmd.Parameters.AddWithValue("@Cp", CPhoneTb.Text);
                    cmd.Parameters.AddWithValue("@Ca", CAddTb.Text);
                    cmd.Parameters.AddWithValue("@Cs", CStatusCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Cc", CCarTb.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Customer Saved");

                    Con.Close();
                    displayCust();
                    Reset();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            carwash Obj = new carwash();
            Obj.Show();
            this.Hide();
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void panel5_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        int Key = 0;
        private void CustomerDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CNameTb.Text = CustomerDGV.SelectedRows[0].Cells[1].Value.ToString();
            CPhoneTb.Text = CustomerDGV.SelectedRows[0].Cells[2].Value.ToString();
            CAddTb.Text = CustomerDGV.SelectedRows[0].Cells[3].Value.ToString();
            CStatusCb.SelectedItem = CustomerDGV.SelectedRows[0].Cells[4].Value.ToString();
            CCarTb.Text = CustomerDGV.SelectedRows[0].Cells[5].Value.ToString();


            if (CNameTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                // Yahan dhyan dein: 'Key' wahi hona chahiye jo upar define kiya hai
                Key = Convert.ToInt32(CustomerDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }
    }
}
