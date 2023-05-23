using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using System.Data.SqlClient;
using System.Reflection.Emit;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace AABbillingProject
{
    public partial class Form1 : Form
    {
        string globalString;

        public static Form1 instance;
        public Form1()
        {
            InitializeComponent();
            instance = this;
        }
        SqlConnection conn = new SqlConnection(@"Data Source=LENOVO-T560-BX3;Initial Catalog=AABbillingProject;Integrated Security=True");

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(rtReceipt.Text);
            total_price();

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult iExit;

            try{
                iExit = MessageBox.Show("Confirm if you want to exit",
                    "Billing Management Systems", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (iExit == DialogResult.Yes)
                {
                    System.Windows.Forms.Application.Exit();
                }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {

            rtReceipt.Clear();
            lblBread.Text = "";
            comboBox1.Text = "";

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            
            try
            {
                printPreviewDialog1.ShowDialog();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message,
                  "Billing Management Systems", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                System.Drawing.Font fntString = new System.Drawing.Font("Arial", 18, FontStyle.Regular);
                e.Graphics.DrawString(rtReceipt.Text, fntString, Brushes.Black, 150, 150);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    "Billing Management Systems", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void NumerBread_ValueChanged(object sender, EventArgs e)
        {
            

        }

        private void NumberRice_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void NumberMilk_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void btnReceipt_Click(object sender, EventArgs e)
        {
            
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void lblBread_Click(object sender, EventArgs e)
        {

        }

        private void rtReceipt_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            System.Drawing.Image receiptImage = System.Drawing.Image.FromFile("C:\\Users\\Lenovo\\Desktop\\BazatDhenatProject\\receipt-highlighted icon.png");

            int newReceiptWidth = receiptImage.Width / 14;
            int newReceiptHeight = receiptImage.Height / 14;
            Size newReceiptSize = new Size(newReceiptWidth, newReceiptHeight);
            System.Drawing.Image passsmallerImage = new Bitmap(receiptImage, newReceiptSize);
            pictureBox1.Image = passsmallerImage;

            System.Drawing.Image addProductImage = System.Drawing.Image.FromFile("C:\\Users\\Lenovo\\Desktop\\BazatDhenatProject\\add_product_highlighted_icon.png");

            int newAddProductWidth = addProductImage.Width / 14;
            int newAddProductHeight = addProductImage.Height / 14;
            Size newAddProductSize = new Size(newAddProductWidth, newAddProductHeight);
            System.Drawing.Image addProductSmallerImage = new Bitmap(addProductImage, newAddProductSize);
            pictureBox2.Image = addProductSmallerImage;

            // Add the names from Customers table to the dropdown
            conn.Open();
            String querry = "SELECT Name FROM Customers";
            SqlCommand command = new SqlCommand(querry, conn);
            // Execute the command and retrieve the data
            SqlDataReader reader = command.ExecuteReader();
            // Loop through the reader and add the names to the comboBox.
            while (reader.Read())
            {
                comboBox1.Items.Add(reader["Name"].ToString());
            }
            reader.Close();

            //set the DataSource property to a DataTable or other data source.

            SqlDataAdapter adapter = new SqlDataAdapter("SELECT ProductID, Name, Description, Price, Quantity FROM Products", conn);

            DataTable dt = new DataTable();

            adapter.Fill(dt);


            DataGridViewTextBoxColumn quantityColumn = new DataGridViewTextBoxColumn();
            quantityColumn.HeaderText = "Quantity";
            quantityColumn.Name = "quantity_client";

            // Add the column to the DataGridView
            dataGridView1.Columns.Add(quantityColumn);
            dataGridView1.CellParsing += DataGridView1_CellParsing;
            dataGridView1.CellValidated += DataGridView1_CellValidated;

            dataGridView1.DataSource = dt;

            dataGridView1.Columns["Quantity"].Visible = false;

            // Set th SelectionMode property to FullRowSelect.
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //Handle the SelectionChanged event to show the data from the selected row in a TextBox control.
            dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;

            conn.Close();

        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            
            lblBread.Text = selectedRow.Cells[5].Value.ToString();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            conn.Open();          

                if (comboBox1.Text == "")
                {
                    MessageBox.Show("Please Select a Client.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    //conn.Open();

                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                    String clickeddRow = "  " + selectedRow.Cells[1].Value.ToString() +
                            "\t" + selectedRow.Cells[2].Value.ToString() +
                            '\t' + selectedRow.Cells[4].Value.ToString() +
                            '\t' + selectedRow.Cells[0].Value.ToString() + '\n';

                    String querry = "SELECT Quantity FROM Products WHERE ProductID = 1";


                    SqlCommand command = new SqlCommand(querry, conn);


                    command.Parameters.AddWithValue("@ProductID", selectedRow.Cells[1].Value.ToString());
                    object result = command.ExecuteScalar();

                    int availableQuantity = Convert.ToInt32(result);

                    // If it is successful, the parsed integer is stored in the userQuantity variable

                    int userQuantity;
                    bool isInteger = int.TryParse(selectedRow.Cells[0].Value.ToString(), out userQuantity);

                    if (isInteger)
                    {
                        if (userQuantity > availableQuantity)
                        {
                            MessageBox.Show("There are only " + lblBread.Text + " " + selectedRow.Cells[2].Value.ToString() + "s available", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                        else
                        {

                        updateQuantity(selectedRow.Cells[0].Value.ToString(), selectedRow.Cells[1].Value.ToString());


                            if (string.IsNullOrWhiteSpace(rtReceipt.Text))
                            {
                                rtReceipt.Clear();
                                rtReceipt.Text += "  ID  ";
                                rtReceipt.Text += "  Name  ";
                                rtReceipt.Text += "  Price  ";
                                rtReceipt.Text += "  Quantity  \n";
                                rtReceipt.Text += clickeddRow;
                            }
                            else
                            {                                
                                rtReceipt.Text += clickeddRow;
                                //total_price();
                            }
                            globalString += clickeddRow;

                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Enter a Number. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                }
            conn.Close();
         }
       
        // CellParsing event handler
        private void DataGridView1_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            // Check if the column being parsed is the new column
            if (dataGridView1.Columns[e.ColumnIndex].Name == "quantity")
            {
                // Get the entered value
                string enteredValue = e.Value?.ToString();

                // Try to parse the value as an integer
                if (!int.TryParse(enteredValue, out int value))
                {
                    // Set the error text and cancel the parsing
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "Invalid input. Please enter a numeric value.";
                    e.ParsingApplied = true;
                }
                else
                {
                    // Clear the error text if the value is valid
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = string.Empty;
                    e.ParsingApplied = false;
                }
            }
        }

        // CellValidated event handler
        private void DataGridView1_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the column being validated is the new column
            if (dataGridView1.Columns[e.ColumnIndex].Name == "quantity")
            {
                // Get the cell value
                string cellValue = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();

                // Check if the value is not empty
                if (!string.IsNullOrEmpty(cellValue))
                {
                    // Parse the value as an integer
                    if (int.TryParse(cellValue, out int value))
                    {
                        // Check if the value is greater than 50
                        if (value > 50)
                        {
                            // Set the error text
                            dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = "Value cannot be greater than 50.";
                        }
                    }
                }
            }
        }
        private void updateQuantity(string quantity, string id)
        {
            string updateQuery = "UPDATE Products SET Quantity = Quantity - @QuantityToSubtract WHERE ProductID = " + id;

            using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
            {
                cmd.Parameters.AddWithValue("@QuantityToSubtract", quantity);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    // Update successful
                    string selectQuery = "SELECT Quantity FROM Products WHERE ProductID = @RecordID";
                    using (SqlCommand selectCommand = new SqlCommand(selectQuery, conn))
                    {
                        selectCommand.Parameters.AddWithValue("@RecordID", id);
                        object updatedQuantity = selectCommand.ExecuteScalar();
                        if (updatedQuantity != null && updatedQuantity != DBNull.Value)
                        {
                            // Set the updated quantity in the TextBox
                            lblBread.Text = updatedQuantity.ToString();
                        }
                    }
                }
                else
                {
                    // No rows affected (record not found)
                    MessageBox.Show("Record not found or no quantity update performed.");
                }

            }
        }
        private void total_price()
        {
            //lblBread.Text = "Total Price";
            /*DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            String clickeddRow = "  " + selectedRow.Cells[1].Value.ToString() +
                    "\t" + selectedRow.Cells[2].Value.ToString() +
                    '\t' + selectedRow.Cells[4].Value.ToString() +
                    '\t' + selectedRow.Cells[0].Value.ToString() + '\n';
            */

            // string priceString = selectedRow.Cells[4].Value.ToString();

            //DataGridViewSelectedRowCollection selectedRows = dataGridView1.SelectedRows

            //;
            /*
            string removeEuroSign = priceString.Replace("€", "");
            if(!decimal.TryParse(removeEuroSign, out price))
            {
                return;
            }
            int qunatity = Convert.ToInt32(selectedRow.Cells[0].Value);

            price *= qunatity;
            decimal result = price * qunatity;

            String updatedPriceString = price.ToString("N2") + "€";
           // MessageBox.Show("result: ", result.ToString());
           // MessageBox.Show("Price: ", price.ToString());
            MessageBox.Show(globalString);
            rtReceipt.AppendText(" \n \n \n \n Total Price: " + updatedPriceString);
            */

            //foreach (DataGridViewRow row in dataGridView1.Rows)
            // {

            //String rowPrice = selectedRow.Cells[4].Value.ToString();
            //int rowQuantity = Convert.ToInt32(row.Cells["quantity_client"].Value);
            //lblBread.Text = rowQuantity.ToString();

            //MessageBox.Show(row.Cells["Price"].Value.ToString());


            //String priceString = row.Cells[4].Value.ToString();
            //lblBread.Text = priceString;
            //MessageBox.Show(priceString);
            //decimal price;
            //works until here

            // Step 1: Remove the "$" symbol

            //String numericalPart = priceString.Replace("€", "");
            //lblBread.Text = numericalPart;


            // Step 2: Parse the numerical part as a decimal
            // if (!decimal.TryParse(numericalPart, out price))
            //{
            // Handle invalid price format
            //Console.WriteLine("Invalid price format");
            // return;
            //}

            // Step 3: Add 10 to the price
            //price *= rowQuantity;
            //lblBread.Text = price.ToString();
            //decimal total_Price = price * rowQuantity;

            // Step 4: Format the result back into a string with "$" symbol

            //String updatedPriceString = price.ToString("N2") + "€";
            //lblBread.Text = updatedPriceString;
            //MessageBox.Show(updatedPriceString);

            //}
            /*
            if(updatedPriceString == "")
            {
                MessageBox.Show("Why is it null");
            }
            else
            {
                lblBread.Text = updatedPriceString;
                rtReceipt.AppendText(" \n \n \n \n Total Price: " + updatedPriceString);

            }
            */


        }
    }
}