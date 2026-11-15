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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
namespace WindowsForms
{
    public partial class Employees : Form
    {
        public Employees()
        {
            InitializeComponent();
            displayEmp();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=.\SQLEXPRESS01;Initial Catalog=CarWashDB;Integrated Security=True;TrustServerCertificate=True");
        private void Reset()
        {
            ENameTb.Text = "";
            EAddTb.Text = "";
            EPhoneTb.Text = "";
            EGenCb.SelectedIndex = -1;
        }
        private void displayEmp()
        {
            Con.Open();
            string Query = "select * from EmployeeTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            EmployeeDGV.DataSource = ds.Tables[0];

            Con.Close();
        }
        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {


        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (ENameTb.Text == "" || EAddTb.Text == "" || EGenCb.SelectedIndex == -1 || EPhoneTb.Text == "") 
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into EmployeeTbl(EName,EPhone,EGen,EAdd,EPass) values(@En,@Ep,@Eg,@Ea,@Epa)", Con);
                    cmd.Parameters.AddWithValue("@En", ENameTb.Text);
                    cmd.Parameters.AddWithValue("@Ep", EPhoneTb.Text);
                    cmd.Parameters.AddWithValue("@Eg", EGenCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Ea", EAddTb.Text);
                    cmd.Parameters.AddWithValue("@Epa", PasswordTb.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Saved");
                    
                    Con.Close();
                    displayEmp();
                    Reset();

                }
                catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void EPhoneTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void EmployeeDGV_Paint(object sender, PaintEventArgs e)
        {

        }
        int Key = 0; // Sabse pehle variable define karein
private void EmployeeDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
{
    if (e.RowIndex >= 0) 
    {
        ENameTb.Text = EmployeeDGV.SelectedRows[0].Cells[1].Value.ToString();
        EPhoneTb.Text = EmployeeDGV.SelectedRows[0].Cells[2].Value.ToString();
        EGenCb.SelectedItem = EmployeeDGV.SelectedRows[0].Cells[3].Value.ToString();
        EAddTb.Text = EmployeeDGV.SelectedRows[0].Cells[4].Value.ToString();

        if (ENameTb.Text == "")
        {
            Key = 0;
        }
        else
        {
            // Yahan dhyan dein: 'Key' wahi hona chahiye jo upar define kiya hai
            Key = Convert.ToInt32(EmployeeDGV.SelectedRows[0].Cells[0].Value.ToString());
        }
    }
}

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if(Key == 0)
            {
                MessageBox.Show("Select The Employee");
            }else
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("delete from EmployeeTbl where EId=@EmId", Con);
                cmd.Parameters.AddWithValue("@EmId", Key);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Employee Deleted");
                Con.Close();
                displayEmp();
                Reset();
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (ENameTb.Text == "" || EAddTb.Text == "" || EGenCb.SelectedIndex == -1 || EPhoneTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                Con.Open();
                SqlCommand cmd = new SqlCommand("Update EmployeeTbl set EName=@En, EPhone=@Ep, EGen=@Eg, EAdd=@Ea where EId=@EmId", Con);
                cmd.Parameters.AddWithValue("@En", ENameTb.Text);
                cmd.Parameters.AddWithValue("@Ep", EPhoneTb.Text);
                cmd.Parameters.AddWithValue("@Eg", EGenCb.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@Ea", EAddTb.Text);
                cmd.Parameters.AddWithValue("@EmId", Key);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Employee Updated");

                Con.Close();
                displayEmp();
                Reset();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Services Obj = new Services();
            Obj.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Logins Obj = new Logins();
            Obj.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            carwash Obj = new carwash();
            Obj.Show();
            this.Hide();
        }
    }
}
