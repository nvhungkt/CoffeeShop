using System;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CoffeeShop
{
    
    public partial class frmStaff : Form
    {        
        SqlDataAdapter dAdapt;
        DataSet myDS = new DataSet();
        private readonly string connStr = ConfigurationManager.ConnectionStrings["SqlProviderPubs"].ConnectionString;
        public frmStaff()
        {
            InitializeComponent();            
            InitRoleDataSet();
            LoadDataOnCombobox();
            InitStaffDataSet();
            LoadData();
        }
        public void InitSearchDataSet()
        {            
            dAdapt = new SqlDataAdapter(string.Format("SELECT * FROM Staff WHERE name LIKE N'{0}'", "%" + txtSearchValue.Text +"%"), connStr);
            SqlCommandBuilder invBuilder = new SqlCommandBuilder(dAdapt);
        }
        public void InitStaffDataSet()
        {
            dAdapt = new SqlDataAdapter("SELECT * FROM Staff", connStr);
            SqlCommandBuilder invBuilder = new SqlCommandBuilder(dAdapt);
        }
        public void InitRoleDataSet()
        {
            dAdapt = new SqlDataAdapter("SELECT role FROM Staff GROUP BY role", connStr);            
            SqlCommandBuilder invBuilder = new SqlCommandBuilder(dAdapt);
        }

        public void LoadSearchData()
        {
            try
            {
                dAdapt.Fill(myDS, "Search");
                dgvStaff.DataSource = myDS.Tables["Search"];
                for (int i = 0; i < dgvStaff.Columns.Count; i++)
                {
                    if (!dgvStaff.Columns[i].Name.Equals("isActive"))
                    {
                        dgvStaff.Columns[i].ReadOnly = true;
                    }                    
                }                
            }
            catch (Exception e)
            {
                MessageBox.Show("Cannot load data " + e.Message);
                dgvStaff.DataSource = null;
            }
        }

        public void LoadData()
        {
            try
            {
                dAdapt.Fill(myDS, "Staff");
                dgvStaff.DataSource = myDS.Tables["Staff"];
                for(int i = 0; i < dgvStaff.Columns.Count; i++)
                {
                    if(!dgvStaff.Columns[i].Name.Equals("isActive"))
                    {
                        dgvStaff.Columns[i].ReadOnly = true;
                    }
                }                                
                //dgvStaff.Columns["password"].Visible = false;
            }
            catch (Exception e)
            {
                MessageBox.Show("Cannot load data. " + e.Message);
                dgvStaff.DataSource = null;
            }
        }
        public void LoadDataOnCombobox()
        {
            try
            {                
                dAdapt.Fill(myDS, "Role");
                cmbRole.DataSource = myDS.Tables["Role"];
                myDS.Tables["Role"].Columns.Add("name");
                string[] roleName = { "Administrator", "Seller" };
                for(int i = 0; i < myDS.Tables["Role"].Rows.Count; i++)
                {
                    myDS.Tables["Role"].Rows[i][1] = roleName[i];
                }                
                cmbRole.ValueMember = "role";
                cmbRole.DisplayMember = "name";
            }
            catch (Exception e)
            {
                MessageBox.Show("Cannot load data " + e.Message);
                cmbRole.DataSource = null;
            }
        }
        
        private void dgvStaff_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = dgvStaff.SelectedCells[0].RowIndex;
            if (dgvStaff.Rows[row].Cells["id"].Value.ToString() == "")
            {
                txtUsername.Enabled = true;
                txtPassword.Text = "";
                txtConfirm.Text = "";
                txtUsername.Text = "";
                txtName.Text = "";
                txtPhone.Text = "";
                txtAddress.Text = "";
                txtEmail.Text = "";
                dtpBirthday.Value = DateTime.Today;
                dtpJoinDate.Value = DateTime.Today;
                rdMale.Checked = true;                
            }
            else
            {                                
                txtUsername.Text = dgvStaff.Rows[row].Cells["username"].Value.ToString();
                txtPassword.Text = dgvStaff.Rows[row].Cells["password"].Value.ToString();
                txtConfirm.Text = dgvStaff.Rows[row].Cells["password"].Value.ToString();
                txtName.Text = dgvStaff.Rows[row].Cells["name"].Value.ToString();
                txtPhone.Text = dgvStaff.Rows[row].Cells["phone"].Value.ToString();
                txtAddress.Text = dgvStaff.Rows[row].Cells["address"].Value.ToString();
                txtEmail.Text = dgvStaff.Rows[row].Cells["email"].Value.ToString();
                dtpBirthday.Value = (DateTime)dgvStaff.Rows[row].Cells["birthday"].Value;
                dtpJoinDate.Value = (DateTime)dgvStaff.Rows[row].Cells["joinDate"].Value;
                cmbRole.SelectedValue = dgvStaff.Rows[row].Cells["role"].Value;
                if (dgvStaff.Rows[row].Cells["gender"].Value.Equals("Male"))
                {
                    rdMale.Checked = true;
                }
                else
                {
                    rdFemale.Checked = true;
                }
                txtUsername.Enabled = false;                
            }                        
        }
                        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string validateStr = "";
                DataRow newRow = myDS.Tables["Staff"].NewRow();
                //Get username value
                newRow["username"] = txtUsername.Text;
                //Validate username
                if (!string.IsNullOrWhiteSpace(inputError.GetError(txtUsername)))
                {
                    throw new Exception(inputError.GetError(txtUsername));
                }
                //Validate username if not focus
                validateStr = ValidateRequiredTextBox(txtUsername, lbUsername);
                //Throw exception whether a required field is empty
                if (!string.IsNullOrWhiteSpace(validateStr))
                {
                    throw new Exception(validateStr);
                }
                //Get password value
                newRow["password"] = txtPassword.Text;
                //Validate password if not focus
                validateStr = ValidateRequiredTextBox(txtPassword, lbPassword);
                //Throw exception whether a required field is empty
                if (!string.IsNullOrWhiteSpace(validateStr))
                {
                    throw new Exception(validateStr);
                }
                //Validate password when focus
                if (!string.IsNullOrWhiteSpace(inputError.GetError(txtPassword)))
                {
                    throw new Exception(inputError.GetError(txtPassword));
                }
                //Confirm password
                if (!string.IsNullOrWhiteSpace(inputError.GetError(txtConfirm)))
                {
                    throw new Exception(inputError.GetError(txtConfirm));
                }
                if(!txtConfirm.Text.Equals(txtPassword.Text))
                {
                    throw new Exception("Confirm is not match Password");                    
                }                
                //Get name value
                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    newRow["name"] = null;
                }
                else
                {
                    newRow["name"] = txtName.Text.Trim();
                }
                //Get birthday value
                newRow["birthday"] = dtpBirthday.Value;               
                //Get address value
                if (string.IsNullOrWhiteSpace(txtAddress.Text))
                {
                    newRow["address"] = null;
                }
                else
                {
                    newRow["address"] = txtAddress.Text.Trim();
                }
                //Get join date value
                newRow["joinDate"] = dtpJoinDate.Value;
                //Get gender value
                if (rdMale.Checked)
                {
                    newRow["gender"] = "Male";
                }
                else
                {
                    newRow["gender"] = "Female";
                }
                //Get phone value
                if (txtPhone.Text.Equals("    -   -"))
                {
                    newRow["phone"] = null;
                }
                else
                {
                    newRow["phone"] = txtPhone.Text.Trim();
                }
                //Get email value
                if (string.IsNullOrWhiteSpace(txtEmail.Text))
                {
                    newRow["email"] = null;
                }
                else
                {
                    newRow["email"] = txtEmail.Text.Trim();
                }
                //Validate email format
                if (!string.IsNullOrWhiteSpace(inputError.GetError(txtEmail)))
                {
                    throw new Exception(inputError.GetError(txtEmail));
                }
                //Get role value
                newRow["role"] = cmbRole.SelectedValue.ToString();
                //Define isActive value
                newRow["isActive"] = true;
                //Define lastModified value is the current date
                newRow["lastModified"] = DateTime.Today;                
                //Add new row to data grid view
                myDS.Tables["Staff"].Rows.Add(newRow);
                //Update to DB
                dAdapt.Update(myDS.Tables["Staff"]);
                //Reload form
                //myDS.Reset();
                //InitRoleDataSet();
                //LoadDataOnCombobox();
                //InitStaffDataSet();
                //LoadData();
                myDS.Clear();
                InitStaffDataSet();
                LoadData();
            }
            catch (SqlException se)
            {    
                //Show message if duplicate username
                MessageBox.Show("Error! Username is existed! Canceling request");
                //Remove that row in data grid view
                DataRow[] rows = myDS.Tables["Staff"].Select(
                        string.Format("username = '{0}'", txtUsername.Text));
                rows[rows.Length - 1].Delete();                
            }
            catch (Exception qe)
            {
                //Show message about validate exception
                MessageBox.Show(qe.Message);             
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtUsername.Text != "")
                {                    
                    DataRow[] rows = myDS.Tables["Staff"].Select(
                        string.Format("username = '{0}'", txtUsername.Text));
                    rows[0]["password"] = txtPassword.Text.Trim();
                    //Validate password
                    if (!string.IsNullOrWhiteSpace(inputError.GetError(txtPassword)))
                    {
                        throw new Exception(inputError.GetError(txtPassword));
                    }
                    //Confirm password
                    if (!string.IsNullOrWhiteSpace(inputError.GetError(txtConfirm)))
                    {
                        throw new Exception(inputError.GetError(txtConfirm));
                    }
                    //Get Name value
                    if (string.IsNullOrWhiteSpace(txtName.Text))
                    {
                        rows[0]["name"] = null;
                    }
                    else
                    {
                        rows[0]["name"] = txtName.Text.Trim();
                    }
                    //Get birthday value
                    rows[0]["birthday"] = dtpBirthday.Value;                    
                    //Get join date value
                    rows[0]["joinDate"] = dtpJoinDate.Value;
                    //Get address value
                    if(string.IsNullOrWhiteSpace(txtAddress.Text))
                    {
                        rows[0]["address"] = null;
                    }
                    else
                    {
                        rows[0]["address"] = txtAddress.Text.Trim();
                    }                
                    //Get gender value
                    if(rdFemale.Checked)
                    {
                        rows[0]["gender"] = "Female";  
                    }
                    else
                    {
                        rows[0]["gender"] = "Male";
                    }
                    //Get phone value
                    if (txtPhone.Text.Equals("    -   -"))
                    {
                        rows[0]["phone"] = null;
                    }
                    else
                    {
                        rows[0]["phone"] = txtPhone.Text.Trim();
                    }            
                    //Get email value
                    if(string.IsNullOrWhiteSpace(txtEmail.Text))
                    {
                        rows[0]["email"] = null;
                    }
                    else
                    {
                        rows[0]["email"] = txtEmail.Text.Trim();
                    }      
                    //Validate email format
                    if (!string.IsNullOrWhiteSpace(inputError.GetError(txtEmail)))
                    {
                        throw new Exception(inputError.GetError(txtEmail));
                    }
                    //Get role value
                    rows[0]["role"] = cmbRole.SelectedValue.ToString();
                    //Define lastModified value is the current date
                    rows[0]["lastModified"] = DateTime.Today;
                    //Update to DB
                    dAdapt.Update(myDS.Tables["Staff"]);
                    changeNotIsActiveRowColor();
                }
            }
            catch (SqlException se)
            {
                //Show message if there is sql exception
                MessageBox.Show("Error! Canceling request");                
            }
            catch (Exception qe)
            {
                //Show validate exception
                MessageBox.Show(qe.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUsername.Text != "")
                {
                    DataRow[] rows = myDS.Tables["Staff"].Select(
                        string.Format("username = '{0}'", txtUsername.Text));
                    rows[0]["isActive"] = false;
                    dAdapt.Update(myDS.Tables["Staff"]);
                    changeNotIsActiveRowColor();
                }
            }
            catch (Exception se)
            {                
                MessageBox.Show("Error! Canceling request");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if(!string.IsNullOrWhiteSpace(txtSearchValue.Text))
                {
                    myDS.Reset();
                    InitSearchDataSet();
                    LoadSearchData();
                    changeNotIsActiveRowColor();
                }
                else
                {
                    myDS.Reset();
                    InitRoleDataSet();
                    LoadDataOnCombobox();
                    InitStaffDataSet();
                    LoadData();
                    changeNotIsActiveRowColor();
                }
            }
            catch (Exception se)
            {
                MessageBox.Show("Error! Canceling request");
            }
        }
        public string ValidateRequiredTextBox(TextBox txtContent, Label lbContent)
        {
            if (string.IsNullOrWhiteSpace(txtContent.Text))
            {
                return lbContent.Text + " is required";
            }
            else
            {
                return null;
            }
        }
        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                inputError.SetError(txtPassword, "Password is required");
            }
            else
            {
                inputError.SetError(txtPassword, "");
            }
        }

        private void txtUsername_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                inputError.SetError(txtUsername, "Username is required");
            }
            else
            {
                inputError.SetError(txtUsername, "");
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(txtEmail.Text);
            if (match.Success || txtEmail.Text == "")
            {
                inputError.SetError(txtEmail, "");
            }
            else
            {
                inputError.SetError(txtEmail, "Email is invalid");
            }
        }
        public void changeNotIsActiveRowColor()
        {
            for (int i = 0; i < dgvStaff.Rows.Count - 1; i++)
            {
                if (!(bool)dgvStaff.Rows[i].Cells["isActive"].Value)
                {
                    dgvStaff.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                }
                else
                {
                    dgvStaff.Rows[i].DefaultCellStyle.BackColor = Color.White;
                }
            }
        }
        private void frmStaff_Load(object sender, EventArgs e)
        {
            changeNotIsActiveRowColor();
            
        }

        private void txtConfirm_Validating(object sender, CancelEventArgs e)
        {
            if (!txtConfirm.Text.Equals(txtPassword.Text))
            {
                inputError.SetError(txtConfirm, "Confirm not match Password");
            }
            else
            {
                inputError.SetError(txtConfirm, "");
            }
        }        
    }
}
