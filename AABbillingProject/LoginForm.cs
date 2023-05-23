using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;
using System.Globalization;

namespace AABbillingProject
{
    public partial class LoginForm : Form
    {
        public static LoginForm Instance;      
        public LoginForm()
        {
            InitializeComponent();
            Instance = this;
        }

        // establish the connection with database 

        SqlConnection conn = new SqlConnection(@"Data Source=LENOVO-T560-BX3;Initial Catalog=AABbillingProject;Integrated Security=True");


        private void Form2_Load(object sender, EventArgs e)
        {
            txt_username.Focus();
            // On form load create a line between the login and exit button
            Label line = new Label();
            line.Height = 1;
            line.Width = 150;
            line.BackColor = Color.White;
            line.Location = new Point(login_btn.Left - 25, login_btn.Bottom + 25);
            line.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(line);

            // Import an image and resize it to use it as an icon

            Image image = Image.FromFile("C:\\Users\\Lenovo\\Desktop\\BazatDhenatProject\\user_highlighted_icon.png");

            int newWidth = image.Width / 9;
            int newHeight = image.Height / 9;
            Size newSize = new Size(newWidth, newHeight);
            Image smallerImage = new Bitmap(image, newSize);
            pictureBox1.Image = smallerImage;

            Image passImage = Image.FromFile("C:\\Users\\Lenovo\\Desktop\\BazatDhenatProject\\password_highlighted_icon.png");

            int newPassWidth = image.Width / 9;
            int newPassHeight = image.Height / 9;
            Size newPassSize = new Size(newPassWidth, newPassHeight);
            Image passsmallerImage = new Bitmap(passImage, newPassSize);
            pictureBox2.Image = passsmallerImage;




            //this.Controls.Add(txt_username)


        }
        private void label1_Click(object sender, EventArgs e)
        {
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
        private void login_btn_Click(object sender, EventArgs e)
        {
            String username, user_password;
            username = txt_username.Text;
            user_password = txt_password.Text;

            try
            {
                //  create a querry to check if there is a matching record in the Logins table for username and password
                String querry = "SELECT * FROM Logins WHERE Username = '" + username + "' AND  Password = '" + user_password + "'";

                SqlDataAdapter sda = new SqlDataAdapter(querry, conn);

                DataTable dTable = new DataTable();
                sda.Fill(dTable);

                if(dTable.Rows.Count > 0)
                {
                    //Load new form

                    RegisterClients RegisterClientsForm = new RegisterClients();
                    RegisterClientsForm.Show();
                    this.Hide();
                   
                }
                else
                {
                    MessageBox.Show("Password or Username are incorrect", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    txt_username.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Error Occurred");
            }
            finally
            {
                conn.Close();
            }
            
        }

        private void exit_btn_Click(object sender, EventArgs e)
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

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txt_password.Text = "";
            txt_username.Text = "";
        }

        private void lbl_password_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
