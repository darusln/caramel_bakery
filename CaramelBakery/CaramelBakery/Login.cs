using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace CaramelBakery
{
    public partial class Login : Form
    {
        public static int idCLient;
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CaramelBakery.mdf;Integrated Security=True");
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(emailTextBox.Text) || string.IsNullOrEmpty(passwordTextBox.Text))
                {
                    MessageBox.Show("Please enter both email and password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                connection.Open();

                string selectQuery = "SELECT * FROM Clients WHERE Email = @Email AND Password = @Password";
                SqlCommand command = new SqlCommand(selectQuery, connection);
                
                command.Parameters.AddWithValue("@Email", emailTextBox.Text);
                command.Parameters.AddWithValue("@Password", passwordTextBox.Text);

                SqlDataReader dr = command.ExecuteReader();

                if (dr.Read())
                {
                    idCLient = dr.GetInt32(0);
                    //MessageBox.Show("Caca");
                    this.Hide();
                    MainPage pp = new MainPage();
                    pp.Show();
                }
                else
                {
                    MessageBox.Show("Password or email invalid!\nPlease try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                connection.Close();
            } 
            catch (Exception ex){
               MessageBox.Show("Application exception: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void registerLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Register inr = new Register();
            //inr.Show();
        }

        private void exitLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Exit();
        }

        private void prevPageLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           /* FirstPage pp1 = new FirstPage();
            this.Hide();
            pp1.Closed += (s, args) => this.Close();
            pp1.Show();*/
        }


        private void showPasCheckedChanged(object sender, EventArgs e)
        {
            if (showPasswordCheckbox.Checked)
                passwordTextBox.PasswordChar = '\0';
            else
                passwordTextBox.PasswordChar = '✧';
        }

    }

}

