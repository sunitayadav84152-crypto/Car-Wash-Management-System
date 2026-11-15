using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class carwash : Form
    {
        public carwash()
        {
            InitializeComponent();
            FillCust();
            FillServices();
            ENamelbl.Text = Logins.Username;
        }
        SqlConnection Con = new SqlConnection(@"Data Source=.\SQLEXPRESS01;Initial Catalog=CarWashDB;Integrated Security=True;TrustServerCertificate=True");
        private void FillServices()
        {
            if (Con.State == ConnectionState.Open)
            {
                Con.Close();
            }
            Con.Open();
            SqlCommand cmd = new SqlCommand("select SName from ServiceTbl", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("SName", typeof(string));
            dt.Load(rdr);
            ServiceCb.ValueMember = "SName";
            ServiceCb.DataSource = dt;
            Con.Close();
        }
        private void FillCust()
        {
            if (Con.State == ConnectionState.Open)
            {
                Con.Close();
            }
            Con.Open();
            SqlCommand cmd = new SqlCommand("select CName from CustomerTbl", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("Name", typeof(string));
            dt.Load(rdr);
            CustomerNameCb.ValueMember = "CName";
            CustomerNameCb.DataSource = dt;
            Con.Close();
        }
        private void GetCustData()
        {
            if (CustomerNameCb.SelectedValue != null)
            {
                if (Con.State == ConnectionState.Open)
                {
                    Con.Close();
                }
                Con.Open();
                string query = "select * from CustomerTbl where CName='" + CustomerNameCb.SelectedValue.ToString() + "'";
                SqlCommand cmd = new SqlCommand(query, Con);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    CustPhoneTb.Text = dr["Cphone"].ToString();
                }
                Con.Close();
            }
        }
        private void GetServiceData()
        {
            if (CustomerNameCb.SelectedValue != null)
            {
                if (Con.State == ConnectionState.Open)
                {
                    Con.Close();
                }
                Con.Open();
                string query = "select * from ServiceTbl where SName='" + ServiceCb.SelectedValue.ToString() + "'";
                SqlCommand cmd = new SqlCommand(query, Con);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    PriceTb.Text = dr["Sprice"].ToString();
                }
                Con.Close();
            }
        }
        int n = 0, Grdtotal = 0;
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (PriceTb.Text=="")
            {
                MessageBox.Show("Select a Service");
            }
            else
            {
                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(ServiceDGV);
                newRow.Cells[0].Value = n + 1;
                newRow.Cells[1].Value = ServiceCb.SelectedValue.ToString();
                newRow.Cells[2].Value = PriceTb.Text;
                ServiceDGV.Rows.Add(newRow);
                n++;
                Grdtotal = Grdtotal + Convert.ToInt32(PriceTb.Text);
                TotalTbl.Text = "Rs" + Grdtotal;
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void EAddTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CustomerNameCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetCustData();
        }

        private void ServiceCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetServiceData();
        }
        private void Reset()
        {
            CustomerNameCb.SelectedIndex = -1;
            CustPhoneTb.Text = "";
            ServiceCb.SelectedIndex = -1;
            PriceTb.Text = "";
            ServiceDGV.Refresh();
        }
        
        private void AddBillBtn_Click(object sender, EventArgs e)
        {
            if (Con.State == ConnectionState.Open)
            {
                Con.Close();
            }
            if (CustPhoneTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into InvoiceTbl(CustName, CustPhone, EName, Amt, IDate) values(@Cn, @Cp, @En, @Am, @Id)", Con);
                    cmd.Parameters.AddWithValue("@Cn", CustomerNameCb.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@Cp", CustPhoneTb.Text);
                    cmd.Parameters.AddWithValue("@En", ENamelbl.Text);
                    cmd.Parameters.AddWithValue("@Am", Grdtotal);
                    cmd.Parameters.AddWithValue("@Id", TodayDate.Value.Date);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Invoice Saved");
                    Con.Close();

                    Reset();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Logins Obj = new Logins();
            Obj.Show();
            this.Hide();
        }

        private void PriceTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void EmployeeDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
