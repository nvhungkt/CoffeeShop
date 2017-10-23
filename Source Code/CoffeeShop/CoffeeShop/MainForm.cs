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
    public partial class MainForm : Form
    {
        private string staffName;
        private int staffID, role;

        private bool CheckLogin(string username, string password)
        {
            if (!username.Trim().Equals("") && !password.Trim().Equals(""))
            {
                SqlDataAdapter da;
                DataSet ds = new DataSet();
                string connStr = ConfigurationManager.ConnectionStrings["SqlProviderPubs"].ConnectionString;
                SqlConnection conn = new SqlConnection(connStr);

                da = new SqlDataAdapter("SELECT * FROM Staff WHERE username = '" + username + "' AND password = '" + password + "'", conn);
                try
                {
                    da.Fill(ds, "User");
                    if (ds.Tables["User"].Rows.Count > 0)
                    {
                        staffName = (string) ds.Tables["User"].Rows[0]["name"];
                        staffID = (int) ds.Tables["User"].Rows[0]["id"];
                        role = (int)ds.Tables["User"].Rows[0]["role"];

                        switch (role)
                        {
                            case 1:
                                optHR.Visible = true;
                                optMenu.Visible = true;
                                break;
                            case 2:
                                optSale.Visible = true;
                                break;
                        }

                        itmLogin.Enabled = false;
                        itmLogout.Enabled = true;

                        return true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return false;
        }
        public MainForm()
        {
            InitializeComponent();

            itmLogout.Enabled = false;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            DisableMenuBar();
            LoginForm frm = new LoginForm();
            frm.checkLogin += CheckLogin;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }

        private void DisableMenuBar()
        {
            optSale.Visible = false;
            optMenu.Visible = false;
            optHR.Visible = false;
        }

        private void itmSale_Click(object sender, EventArgs e)
        {
            if (!CloseCurrentTabs())
                return;

            CreateOrder frm = new CreateOrder(staffName, staffID);
            frm.MdiParent = this;
            frm.Show();
        }

        private bool CloseCurrentTabs()
        {
            if (this.MdiChildren.Length > 0)
            {
                if (MessageBox.Show("Close current tabs?", "WARNING", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    foreach (var item in this.MdiChildren)
                    {
                        item.Close();
                    }
                    return true;
                }
                return false;
            }
            return true;
        }

        private void itmHR_Click(object sender, EventArgs e)
        {
            if (!CloseCurrentTabs())
                return;

            frmStaff frm = new frmStaff();
            frm.MdiParent = this;
            frm.Show();
        }

        private void itmMenu_Click(object sender, EventArgs e)
        {
            if (!CloseCurrentTabs())
                return;

            MenuForm frm = new MenuForm();
            frm.MdiParent = this;
            frm.Show();
        }

        private void itmExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void itmLogout_Click(object sender, EventArgs e)
        {
            if (!CloseCurrentTabs())
                return;
            DisableMenuBar();
            LoginForm frm = new LoginForm();
            frm.checkLogin += CheckLogin;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
            itmLogin.Enabled = true;
        }

        private void itmLogin_Click(object sender, EventArgs e)
        {
            if (!CloseCurrentTabs())
                return;
            DisableMenuBar();
            LoginForm frm = new LoginForm();
            frm.checkLogin += CheckLogin;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }

        private void itmAbout_Click(object sender, EventArgs e)
        {
            AboutForm frm = new AboutForm();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.ShowDialog();
        }

        private void itmStatistic_Click(object sender, EventArgs e)
        {
            if (!CloseCurrentTabs())
                return;

            StatisticForm frm = new StatisticForm();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
