using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace AABbillingProject
{
    public partial class RegisterProductFrom : Form
    {
        int product_id = 001;
        public RegisterProductFrom()
        {
            

            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=LENOVO-T560-BX3;Initial Catalog=AABbillingProject;Integrated Security=True");


        private void RegisterProductFrom_Load(object sender, EventArgs e)
        {
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Products", conn);

            DataTable dt = new DataTable();

            adapter.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void btn_register_product_Click(object sender, EventArgs e)
        {   
            if(txt_product_name.Text == "" ||
                txt_product_price.Text == "" ||
                txt_product_desc.Text == "")
            {
                MessageBox.Show("Please fill out all the fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                conn.Open();
                string sql = "INSERT INTO Products (Name, Description, Price, Quantity) VALUES(@Name, @Description, @Price, @Quantity)";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    //cmd.Parameters.AddWithValue("@CustomerID", id);
                    cmd.Parameters.AddWithValue("@Name", txt_product_name.Text);
                    cmd.Parameters.AddWithValue("@Description", txt_product_desc.Text);
                    cmd.Parameters.AddWithValue("@Price", txt_product_price.Text);
                    cmd.Parameters.AddWithValue("@Quantity", num_product_quantity.Value);
                    cmd.ExecuteNonQuery();

                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Products", conn);

                    DataTable dt = new DataTable();

                    adapter.Fill(dt);

                    dataGridView1.DataSource = dt;

                }

             /*   string id = Guid.NewGuid().ToString().Substring(0, 15).ToUpper();
                id = id.Substring(0, 4) + "-" + id.Substring(4, 4) + "-" + id.Substring(8, 4);

                dataGridView1.Rows.Add(id, txt_product_name.Text, txt_product_price.Text, num_product_quantity.Value, txt_product_desc.Text);
             */


                txt_product_name.Clear();
                txt_product_price.Clear();
                num_product_quantity.Value = 0;
                txt_product_desc.Clear();

            }



        }

        private void button1_Click(object sender, EventArgs e)
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

        private void txt_product_price_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(txt_product_price.Text, out decimal price))
            {
                // Format the value as a currency value
                string formattedPrice = price.ToString("C", new CultureInfo("fr-FR"));

                // Display the formatted value
                txt_product_price.Text = formattedPrice;
            }
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            Form1 F1 = new Form1();
            F1.Show();
            this.Hide();
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            RegisterClients RegisterClientsForm = new RegisterClients();
            RegisterClientsForm.Show();
            this.Hide();
        }
    }
}
