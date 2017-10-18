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
    
    public partial class frmStaff : Form
    {
        private int id;
        private int role;
        SqlDataAdapter dAdapt;
        DataSet myDS = new DataSet();
        private readonly string connStr = ConfigurationManager.ConnectionStrings["SqlProviderPubs"].ConnectionString;
        public frmStaff(int id, int role)
        {
            InitializeComponent();
            this.id = id;
            this.role = role;
            InitRoleDataSet();
            LoadDataOnCombobox();        
            InitStaffDataSet();
            LoadData();
        }
        public void InitStaffDataSet()
        {
            dAdapt = new SqlDataAdapter("SELECT * FROM Staff WHERE isActive = 'true'", connStr);
            SqlCommandBuilder invBuilder = new SqlCommandBuilder(dAdapt);
        }
        public void InitRoleDataSet()
        {
            dAdapt = new SqlDataAdapter("SELECT role FROM Staff GROUP BY role", connStr);
            SqlCommandBuilder invBuilder = new SqlCommandBuilder(dAdapt);
        }
        public void LoadData()
        {
            try
            {
                dAdapt.Fill(myDS, "Staff");
                dgvStaff.DataSource = myDS.Tables["Staff"];
            }
            catch (Exception e)
            {
                MessageBox.Show("Cannot load data " + e.Message);
                dgvStaff.DataSource = null;
            }
        }
        public void LoadDataOnCombobox()
        {
            try
            {
                dAdapt.Fill(myDS, "Role");
                cmbRole.DataSource = myDS.Tables["Role"];
                
            }
            catch (Exception e)
            {
                MessageBox.Show("Cannot load data " + e.Message);
                cmbRole.DataSource = null;
            }
        }
    }
}
