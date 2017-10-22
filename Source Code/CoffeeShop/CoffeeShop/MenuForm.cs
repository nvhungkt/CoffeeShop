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
    public partial class MenuForm : Form
    {
        private readonly string dp = ConfigurationManager.AppSettings["provider"];
        private readonly string conString = ConfigurationManager.ConnectionStrings["SqlProviderPubs"].ConnectionString;
        private SqlDataAdapter adaptCategory;
        private DataSet categories = new DataSet();
        private SqlDataAdapter adaptMenu;
        private DataSet menu = new DataSet();

        private string curCategoryName;
        private bool isWorkingWithCategory;

        public MenuForm()
        {
            InitializeComponent();
            InitDataSet();
        }

        public void InitDataSet()
        {
            adaptCategory = new SqlDataAdapter("SELECT * FROM Category WHERE isActive=1", conString);
            SqlCommandBuilder invBuilder = new SqlCommandBuilder(adaptCategory);
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {
            LoadCategory();
        }

        private void LoadCategory()
        {
            try
            {
                //clear old data
                categories.Clear();
                //fill new data
                adaptCategory.Fill(categories, "Category");
                dgvCategory.DataSource = categories.Tables["Category"];

                //set visible some columns
                dgvCategory.RowHeadersVisible = false;
                dgvCategory.Columns["id"].Visible = false;
                dgvCategory.Columns["isActive"].Visible = false;
                dgvCategory.Columns["lastModified"].Visible = false;

                dgvCategory.Columns.Add("add", "add");
                //dgvCategory.AllowUserToAddRows = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot load data " + ex.Message);
                dgvCategory.DataSource = null;
            }
        }

        private void LoadMenu(string curCategoryID)
        {
            //define category selected to prepare query string
            if (string.IsNullOrEmpty(curCategoryID))
                adaptMenu = new SqlDataAdapter("SELECT * FROM Product "
                    + "WHERE isActive=1 AND categoryID IS NULL", conString);
            else
                adaptMenu = new SqlDataAdapter("SELECT * FROM Product "
                    + "WHERE isActive=1 AND categoryID='" + curCategoryID + "'", conString);
            SqlCommandBuilder invBuilder = new SqlCommandBuilder(adaptCategory);

            try
            {
                //clear old data
                menu.Clear();
                //fill new data
                adaptMenu.Fill(menu, "Product");
                dgvMenu.DataSource = menu.Tables["Product"];

                //set visible some columns
                dgvMenu.RowHeadersVisible = false;
                dgvMenu.Columns["id"].Visible = false;
                dgvMenu.Columns["isActive"].Visible = false;
                dgvMenu.Columns["lastModified"].Visible = false;
                dgvMenu.Columns["categoryID"].Visible = false;

                dgvMenu.AllowUserToAddRows = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot load data " + ex.Message);
                dgvCategory.DataSource = null;
            }
        }

        private bool ValidateName()
        {
            string name = txtName.Text;
            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
            {
                error.SetError(txtName, "Name required!");
                return false;
            }
            if (name.Length < 3 || name.Length > 50)
            {
                error.SetError(txtName, "Name must have 3-50 characters!");
                return false;
            }
            return true;
        }

        public bool ValidateDescription()
        {
            string description = txtDescription.Text;
            if (description.Length > 250)
            {
                error.SetError(txtDescription, "Description must not have over 250 characters!");
                return false;
            }
            return true;
        }

        private void dgvCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCategory.SelectedCells.Count > 0)
            {
                //set data in form
                int row = dgvCategory.SelectedCells[0].RowIndex;
                txtName.Text = dgvCategory.Rows[row].Cells["name"].Value.ToString();
                curCategoryName = txtName.Text;
                txtDescription.Text = dgvCategory.Rows[row].Cells["description"].Value.ToString();
                string lastModified = dgvCategory.Rows[row].Cells["lastModified"].Value.ToString();
                if (string.IsNullOrEmpty(lastModified))
                    lbModifiedTime.Text = "";
                else
                    lbModifiedTime.Text = "last modified on " + lastModified;

                //visible form and disable price, category
                groupContent.Text = "Category Details";
                isWorkingWithCategory = true;
                groupContent.Visible = true;
                lbPrice.Visible = false;
                txtPrice.Visible = false;
                lbCategory.Visible = false;

                //load menu
                string curCategoryID = dgvCategory.Rows[row].Cells["id"].Value.ToString();
                LoadMenu(curCategoryID);

                //Change to update/deactive mode
                btnAddNew.Text = "New";
                btnUpdate.Enabled = true;
                btnDeactive.Enabled = true;
            }
        }

        private void dgvMenu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMenu.SelectedCells.Count > 0)
            {
                //set data in form
                int row = dgvMenu.SelectedCells[0].RowIndex;
                txtName.Text = dgvMenu.Rows[row].Cells["name"].Value.ToString();
                txtDescription.Text = dgvMenu.Rows[row].Cells["description"].Value.ToString();
                txtPrice.Text = dgvMenu.Rows[row].Cells["price"].Value.ToString();
                lbCategory.Text = "Category:      " + curCategoryName;
                string lastModified = dgvMenu.Rows[row].Cells["lastModified"].Value.ToString();
                if (string.IsNullOrEmpty(lastModified))
                    lbModifiedTime.Text = "";
                else
                    lbModifiedTime.Text = "last modified on " + lastModified;

                //visible price and category
                groupContent.Text = "Meal Details";
                isWorkingWithCategory = false;
                lbPrice.Visible = true;
                txtPrice.Visible = true;
                lbCategory.Visible = true;

                //Change to update/deactive mode
                btnAddNew.Text = "New";
                btnUpdate.Enabled = true;
                btnDeactive.Enabled = true;
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            if (btnAddNew.Text.Equals("New"))
            {
                //Clear input data, disable some buttons
                txtName.Clear();
                txtDescription.Clear();
                txtPrice.Clear();
                lbCategory.Text = "Category:";
                lbModifiedTime.Text = "";
                btnAddNew.Text = "Add";
                btnUpdate.Enabled = false;
                btnDeactive.Enabled = false;
            }
            else
            {
                if (!ValidateName() || !ValidateDescription())
                    return;
                if (isWorkingWithCategory)
                {
                    DataRow newProduct = categories.Tables["Category"].NewRow();
                    newProduct["name"] = txtName.Text;
                    newProduct["description"] = txtDescription.Text;
                    newProduct["isActive"] = true;
                    newProduct["lastModified"] = DBNull.Value;

                    categories.Tables["Category"].Rows.Add(newProduct);

                    try
                    {
                        adaptCategory.Update(categories.Tables["Category"]);
                        //reload category
                        LoadCategory();
                        txtName.Clear();
                        txtDescription.Clear();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Update", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                return;
            if (isWorkingWithCategory)
            {
                //get row
                int row = dgvCategory.SelectedCells[0].RowIndex;
                //check if this row is last row
                if (row == dgvCategory.RowCount - 1) return;
                //get ID
                string curCategoryID = dgvCategory.Rows[row].Cells["id"].Value.ToString();
                DataRow[] category = categories.Tables["Category"].Select("id=" + curCategoryID);

                category[0]["name"] = txtName.Text;
                category[0]["description"] = txtDescription.Text;
                category[0]["lastModified"] = DateTime.Now;
                try
                {
                    adaptCategory.Update(categories.Tables["Category"]);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnDeactive_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Deactive", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                return;
            if (isWorkingWithCategory)
            {
                //get row
                int row = dgvCategory.SelectedCells[0].RowIndex;
                //check if this row is last row
                if (row == dgvCategory.RowCount - 1) return;
                //get ID
                string curCategoryID = dgvCategory.Rows[row].Cells["id"].Value.ToString();
                DataRow[] category = categories.Tables["Category"].Select("id=" + curCategoryID);

                category[0]["isActive"] = false;
                try
                {
                    adaptCategory.Update(categories.Tables["Category"]);
                    //reload category
                    LoadCategory();
                    txtName.Clear();
                    txtDescription.Clear();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
