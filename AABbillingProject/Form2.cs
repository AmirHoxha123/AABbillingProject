using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AABbillingProject
{
    public partial class Form2 : Form
    {
        public static Form2 Instance;
        public Form2()
        {
            InitializeComponent();
            Instance = this;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            
            DialogResult confirm_next;
            confirm_next = MessageBox.Show("Confirm if you to go to next",
                    "Billing Management Systems", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm_next == DialogResult.Yes) {
                f1.Show();
                this.Hide();
            }
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btn_add_Click(
            
            object sender, EventArgs e)
        {
            MessageBox.Show(txt_name.Text + " Added Successfully");
            txt_name.Text = "";
            txt_price.Text = "$0.00";
            num_quantity.Text = "0";
            txt_description.Text = "";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void num_quantity_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

            Image image = Image.FromFile("C:\\Users\\Lenovo\\Desktop\\BazatDhenatProject\\productname_highlighted_icon.png");

            int newWidth = image.Width / 13;
            int newHeight = image.Height / 13;
            Size newSize = new Size(newWidth, newHeight);
            Image smallerImage = new Bitmap(image, newSize);
            pictureBox1.Image = smallerImage;

            Image priceImage = Image.FromFile("C:\\Users\\Lenovo\\Desktop\\BazatDhenatProject\\price_highlighted_icon.png");
            int newPriceWidth = priceImage.Width / 14;
            int newPriceHeight = priceImage.Height / 14;
            Size newPriceSize = new Size(newPriceWidth, newPriceHeight);
            Image smallerPriceImage = new Bitmap(priceImage, newPriceSize);
            pictureBox2.Image = smallerPriceImage;

            Image quantityImage = Image.FromFile("C:\\Users\\Lenovo\\Desktop\\BazatDhenatProject\\quantity_highlighted_icon.png");
            int newquantityWidth = quantityImage.Width / 13;
            int newquantityHeight = quantityImage.Height / 13;
            Size newquantitySize = new Size(newquantityWidth, newquantityHeight);
            Image smallerquantityImage = new Bitmap(quantityImage, newquantitySize);
            pictureBox3.Image = smallerquantityImage;

            Image descImage = Image.FromFile("C:\\Users\\Lenovo\\Desktop\\BazatDhenatProject\\description_receipt_highlighted_icon.png");
            int newdescWidth = descImage.Width / 12;
            int newdescHeight = descImage.Height / 12;
            Size newdescSize = new Size(newdescWidth, newdescHeight);
            Image smallerdescyImage = new Bitmap(descImage, newdescSize);
            pictureBox4.Image = smallerdescyImage;

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
