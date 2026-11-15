using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class Services : Form
    {
        public Services()
        {
            InitializeComponent();
            displayServices();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=.\SQLEXPRESS01;Initial Catalog=CarWashDB;Integrated Security=True;TrustServerCertificate=True");
        int Key = 0;
        private void Reset()
        {
            SNameTb.Text = "";
            PriceTb.Text = "";
  
        }
        private void displayServices()
        {
            Con.Open();
            string Query = "select * from ServiceTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ServiceDGV.DataSource = ds.Tables[0];

            Con.Close();
        }
        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (SNameTb.Text == "" || SPriceTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    if (Con.State == ConnectionState.Closed) Con.Open();

                    string Query = "insert into ServiceTbl (SName, SPrice) values (@Sn, @Sp)";
                    SqlCommand cmd = new SqlCommand(Query, Con);

                    cmd.Parameters.AddWithValue("@Sn", SNameTb.Text);
                    cmd.Parameters.AddWithValue("@Sp", Convert.ToInt32(SPriceTb.Text));
                    cmd.Parameters.AddWithValue("@SKey", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Service Updated!");

                    Con.Close();
                    displayServices();
                    Reset();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                    Con.Close();
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Select The Service");
            }
            else
            {
                try
                {
                    if (Con.State == ConnectionState.Closed) Con.Open();
                    string Query = "delete from ServiceTbl where SId = @SId";
                    SqlCommand cmd = new SqlCommand(Query, Con);
                    cmd.Parameters.AddWithValue("@SId", Key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Service Deleted Successfully");
                    Con.Close();
                    displayServices();
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                    if (Con.State == ConnectionState.Open) Con.Close();
                }
            }
        }

        private void ServiceDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Saari lines is bracket ke andar honi chahiye
                SNameTb.Text = ServiceDGV.SelectedRows[0].Cells[1].Value.ToString();
                SPriceTb.Text = ServiceDGV.SelectedRows[0].Cells[2].Value.ToString();

                if (SNameTb.Text == "")
                {
                    Key = 0;
                }
                else
                {
                    Key = Convert.ToInt32(ServiceDGV.SelectedRows[0].Cells[0].Value.ToString());
                }
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Logins Obj = new Logins();
            Obj.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Employees Obj = new Employees();
            Obj.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Customers Obj = new Customers();
            Obj.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Services Obj = new Services();
            Obj.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            carwash Obj = new carwash();
            Obj.Show();
            this.Hide();
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (SNameTb.Text == "" || SPriceTb.Text == "")
            {
                MessageBox.Show("Please select a service to edit.");
            }
            else
            {
                try
                {
                    Con.Open();
                    // Update query: Service Name aur Price ko badalne ke liye
                    // Key yahan wo ID hai jo aapne GridView se select ki hogi (Variable: Key)
                    string query = "update ServiceTbl set SName=@Sn, SPrice=@Sp where SId=@SKey";

                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.Parameters.AddWithValue("@Sn", SNameTb.Text);
                    cmd.Parameters.AddWithValue("@Sp", SPriceTb.Text);
                    cmd.Parameters.AddWithValue("@SKey", Key); // 'Key' wo variable hai jo selected row ki ID store karta hai

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Service Updated Successfully!");
                    Con.Close();

                    // Data refresh karne ke liye function
                    displayServices();
                    // Textboxes khaali karne ke liye
                    Reset();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                    Con.Close();
                }
            }
        }
    }
    
}
