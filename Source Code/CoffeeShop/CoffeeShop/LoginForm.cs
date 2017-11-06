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
        

        public delegate bool CheckLogin(string username, string password);

        public event CheckLogin checkLogin;

        public LoginForm()
        {
            InitializeComponent();
            Design.ApplyButton(btnExit);
            Design.ApplyButtonSuccess(btnLogin);
            Design.ApplyFormColor(this);
            btnExit.BackColor = Color.FromArgb(170, 170, 170);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (checkLogin(txtUsername.Text, txtPassword.Text))
                this.Close();
            else
                MessageBox.Show("Invalid username or password!!");
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt)
                MessageBox.Show("Alt is prohibit!!");
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt)
                MessageBox.Show("Alt is prohibit!!");
        }
    }
}
