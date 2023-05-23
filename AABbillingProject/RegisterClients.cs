using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace AABbillingProject
{
    public partial class RegisterClients : Form
    {
        public RegisterClients()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=LENOVO-T560-BX3;Initial Catalog=AABbillingProject;Integrated Security=True");

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            if(txt_ClientName.Text == "" || txt_client_email.Text == "" || txt_client_address.Text == ""
                || txt_client_phone.Text == "") {
                MessageBox.Show("Please fill out all the fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
            {
                conn.Open();

                string sql = "INSERT INTO Customers (Name, Address, Phone, Email) VALUES(@Name, @Address, @Phone, @Email)";
                using (SqlCommand cmd = new SqlCommand(sql, conn)) {
                    //cmd.Parameters.AddWithValue("@CustomerID", id);
                    cmd.Parameters.AddWithValue("@Name", txt_ClientName.Text);
                    cmd.Parameters.AddWithValue("@Address", txt_client_address.Text);
                    cmd.Parameters.AddWithValue("@Phone", txt_client_phone.Text);
                    cmd.Parameters.AddWithValue("@Email", txt_client_email.Text);

                    //execute the query and return the number of rows that were affected by the insert operation

                    cmd.ExecuteNonQuery();

                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Customers", conn);

                    DataTable dt = new DataTable();

                    adapter.Fill(dt);

                    dataGridView1.DataSource = dt;

                }


                txt_ClientName.Clear();
                txt_client_address.Clear();
                txt_client_phone.Clear();
                txt_client_email.Clear();
            }
        }

        private void btn_client_next_Click(object sender, EventArgs e)
        {
            RegisterProductFrom RPF = new RegisterProductFrom();
            RPF.Show();
            this.Hide();
        }

        private void btn_client_exit_Click(object sender, EventArgs e)
        {
            DialogResult iExit;

            try
            {
                iExit = MessageBox.Show("Confirm if you want to exit",
                    "Billing Management Systems", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (iExit == DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void RegisterClients_Load(object sender, EventArgs e)
        {
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Customers", conn);

            // create a new DataTable to store the data
            DataTable dt = new DataTable();

            // fill the DataTable with data from the database
            adapter.Fill(dt);

            // assign the DataTable as the DataSource for the DataGridView
            dataGridView1.DataSource = dt;

        }
    }
}
