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

namespace CaramelBakery
{
    public partial class MainPage : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\CaramelBakery.mdf;Integrated Security=True");
        public MainPage()
        {
            InitializeComponent();
        }

        private void PaginaPrincipala_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            /*con.Open();
            SqlCommand cmd = new SqlCommand("delete from comenzi where stare is NULL", con);
            cmd.ExecuteNonQuery();
            con.Close();*/
            Application.Exit();
        }

        private void orderButton_Click(object sender, EventArgs e)
        {
            /*Order co = new Order();
            co.Show();*/
        }

        private void placedOrderbutton_Click(object sender, EventArgs e)
        {
            /*PlacedOrders cp = new PlacedOrders();
            this.Hide();
            cp.Show();*/
        }

        private void accountButton_Click(object sender, EventArgs e)
        {
            /*Account cn = new Account();
            this.Hide();
            cn.Show();*/
        }

        private void backLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login lg = new Login();
            this.Hide();
            lg.Show();
        }

        private void exitLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Exit();
        }
    }
}
