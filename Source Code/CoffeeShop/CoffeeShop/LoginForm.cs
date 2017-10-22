using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShop
{
    public partial class LoginForm : Form
    {
        SqlDataAdapter dAdapt;
        DataSet myDS = new DataSet();
        private readonly string connStr = ConfigurationManager.ConnectionStrings["SqlProviderPubs"].ConnectionString;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "admin" && txtPassword.Text == "123")
            {
                this.Close();
            }
        }
    }
}
