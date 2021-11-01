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

namespace Login1
{
    public partial class Form1 : Form
    {
        SqlConnection con;
        SqlDataAdapter sda;
        DataTable dt;
        public Form1()
        {
            InitializeComponent();
            try
            {
                con = new SqlConnection("Data Source = DESKTOP-OSTDV7J; Initial Catalog = testLogin; User ID = admin; Password = 123456");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sda = new SqlDataAdapter("Select Count(*) from Login where Username = '"+txtUsername.Text+"' and Password = '"+txtPassword.Text+"'", con);
            dt = new DataTable();
            sda.Fill(dt);
            if(dt.Rows[0][0].ToString() == "1")
            {
                this.Hide();
                Main ss = new Main();
                ss.Show();
            }
            else
            {
                MessageBox.Show("Please check you login credentials");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
