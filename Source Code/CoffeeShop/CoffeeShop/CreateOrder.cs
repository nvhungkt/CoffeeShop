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
using Microsoft.VisualBasic;

namespace CoffeeShop
{
    public partial class CreateOrder : Form
    {
        private string conStr = ConfigurationManager.ConnectionStrings["SqlProviderPubs"].ConnectionString;
        private SqlConnection conn;
        private DataSet ds = new DataSet();
        private SqlDataAdapter daCate, daMenu, daOrder, daOrderDetail;

        private Dictionary<DataRow, int> detail;

        private string date, time;

        private void PrepareOrder()
        {
            daOrder = new SqlDataAdapter("SELECT * FROM [Order]", conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(daOrder);

            daOrder.Fill(ds, "Order");

            //prepare Order view
            lbDate.Text = DateTime.Now.ToLocalTime().ToString();
            lbOrderPrice.Text = "0";
        }

        private void PrepareOrderDetail()
        {
            daOrderDetail = new SqlDataAdapter("SELECT * FROM OrderDetail", conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(daOrderDetail);

            daOrderDetail.Fill(ds, "OrderDetail");

            //prepare Order Detail view
            FormFillSelectedOrderDetail();
        }

        private void InsertDBOrder()
        {
            DateTime dt = new DateTime(DateTime.Now.Ticks);
            date = dt.ToString("dd-MM-yyyy");
            time = dt.ToString("hh:mm:ss");

            DataRow newRow = ds.Tables["Order"].NewRow();

            newRow["customerName"] = (txtCustomerName.Text.Equals("") ? "KHACH HANG" : txtCustomerName.Text);
            newRow["staffID"] = 1;
            newRow["takenDate"] = DateTime.Parse(date);
            newRow["takenTime"] = TimeSpan.Parse(time);
            if (txtTableNumber.Text.Equals(""))
                newRow["tableNumber"] = DBNull.Value;
            else
                newRow["tableNumber"] = int.Parse(txtTableNumber.Text);
            newRow["totalPrice"] = float.Parse(lbOrderPrice.Text);
            newRow["status"] = "paid";

            try
            {
                ds.Tables["Order"].Rows.Add(newRow);
                daOrder.Update(ds.Tables["Order"]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void InsertDBOrderDetails()
        {
            //Reupdate the dataset
            daOrder.Fill(ds, "Order");
            //get the latest order ID (which has just been inserted)
            int lastRow = ds.Tables["Order"].Rows.Count - 1;
            int orderID = int.Parse(ds.Tables["Order"].Rows[lastRow]["id"].ToString());

            foreach (var entry in detail)
            {
                DataRow newRow = ds.Tables["OrderDetail"].NewRow();

                newRow["orderID"] = orderID;
                newRow["productID"] = entry.Key["id"];
                newRow["quantity"] = entry.Value;
                newRow["price"] = entry.Key["price"];

                try
                {
                    ds.Tables["OrderDetail"].Rows.Add(newRow);
                    daOrderDetail.Update(ds.Tables["OrderDetail"]);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void InitPseudoDetailGridView()
        {
            DataTable detail = new DataTable("Detail");

            DataColumn no = new DataColumn("No", typeof(int));
            DataColumn name = new DataColumn("Item", typeof(string));
            DataColumn unitPrice = new DataColumn("Unit Price", typeof(float));
            DataColumn quantity = new DataColumn("Quantity", typeof(int));
            DataColumn price = new DataColumn("Price", typeof(float));
            
            detail.Columns.AddRange(new DataColumn[] { no, name, unitPrice, quantity, price });

            ds.Tables.Add(detail);

            //Set view for Order Detail
            dgvOrderDetail.DataSource = ds.Tables["Detail"];
            dgvOrderDetail.RowHeadersVisible = false;
            dgvOrderDetail.AllowUserToAddRows = false;
            dgvOrderDetail.Columns["No"].Width = dgvOrderDetail.Width / 10;
        }

        private void LoadCategory()
        {
            daCate = new SqlDataAdapter("SELECT * FROM Category WHERE isActive = 1", conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(daCate);

            daCate.Fill(ds, "Category");
            dgvCategory.DataSource = ds.Tables["Category"];
            dgvCategory.Columns["id"].Visible = false;
            dgvCategory.Columns["description"].Visible = false;
            dgvCategory.Columns["isActive"].Visible = false;
            dgvCategory.Columns["lastModified"].Visible = false;
            dgvCategory.Columns["name"].Width = dgvCategory.Width - 3;
            dgvCategory.RowHeadersVisible = false;

        }

        private void LoadMenu()
        {
            daMenu = new SqlDataAdapter("SELECT * FROM Product WHERE isActive = 1", conn);
            SqlCommandBuilder builder = new SqlCommandBuilder(daCate);

            daMenu.Fill(ds, "Menu");
        }

        public CreateOrder()
        {
            InitializeComponent();

            conn = new SqlConnection(conStr);

            detail = new Dictionary<DataRow, int>();

            //DataGridView: remove the last blank row of Grid View
            dgvCategory.AllowUserToAddRows = false;
            dgvMenu.AllowUserToAddRows = false;
            dgvOrderDetail.AllowUserToAddRows = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DataRow row = null;
            foreach (var entry in detail)
            {
                if (entry.Key["name"].Equals(lbItemName.Text))
                {
                    row = entry.Key;
                    break;
                }
            }

            if (row != null)
            {
                int quantity = int.Parse(txtQuantity.Text);
                if (quantity <= 0)
                {
                    detail.Remove(row);
                }
                else
                {
                    detail[row] = quantity;
                }
            }

            UpdateOrderDetailView();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            DataRow row = null;

            //Find out the row that has productName matches the itemName label
            foreach (var entry in detail)
            {
                if (entry.Key["name"].Equals(lbItemName.Text))
                {
                    row = entry.Key;
                    break;
                }
            }

            //If the was a row then remove it from the Dictionary<> @detail
            if (row != null)
            {
                detail.Remove(row);
            }

            //reload view
            UpdateOrderDetailView();
        }

        private void dgvOrderDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            FormFillSelectedOrderDetail();
        }

        private void FormFillSelectedOrderDetail()
        {
            if (dgvOrderDetail.SelectedCells.Count > 0)
            {
                int row = dgvOrderDetail.SelectedCells[0].RowIndex;
                lbItemName.Text = dgvOrderDetail.Rows[row].Cells["Item"].Value.ToString();
                lbItemPrice.Text = dgvOrderDetail.Rows[row].Cells["Unit Price"].Value.ToString();
                lbTotalPrice.Text = dgvOrderDetail.Rows[row].Cells["Price"].Value.ToString();
                txtQuantity.Text = dgvOrderDetail.Rows[row].Cells["Quantity"].Value.ToString();
            }
            else if (dgvOrderDetail.SelectedRows.Count == 0)
            {
                lbItemName.Text = "";
                lbItemPrice.Text = "";
                lbTotalPrice.Text = "";
                txtQuantity.Text = "";
            }
        }

        private void dgvCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCategory.SelectedCells.Count > 0)
            {
                int row = dgvCategory.SelectedCells[0].RowIndex;
                int selectedCate = (int)dgvCategory.Rows[row].Cells["id"].Value;
                dgvMenu.DataSource = ds.Tables["Menu"].Select("categoryID = " + selectedCate).CopyToDataTable();

                dgvMenu.Columns["id"].Visible = false;
                dgvMenu.Columns["categoryID"].Visible = false;
                dgvMenu.Columns["description"].Visible = false;
                dgvMenu.Columns["isActive"].Visible = false;
                dgvMenu.Columns["lastModified"].Visible = false;
                dgvMenu.Columns["name"].Width = dgvCategory.Width - 3;
                dgvMenu.RowHeadersVisible = false;

                //Customize the Width of Menu
                dgvMenu.Columns["name"].Width = dgvMenu.Width / 3 * 2 + 10;
            }
        }

        private void dgvMenu_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string quantity = Interaction.InputBox("Quantity = ?", dgvMenu.Rows[e.RowIndex].Cells[e.ColumnIndex].Value + "", "1");

            DataRow selectedRow = ((DataRowView)dgvMenu.Rows[e.RowIndex].DataBoundItem).Row;

            //To check if item is already added in to wishlist
            bool pass = false;
            foreach (var entry in detail)
            {
                if (entry.Key["name"].Equals(selectedRow["name"]))
                {
                    detail[entry.Key] += int.Parse(quantity);
                    pass = true;
                    break;
                }
            }
            if (!pass)
                detail.Add(selectedRow, int.Parse(quantity));

            UpdateOrderDetailView();
        }

        private void btnNewOrder_Click(object sender, EventArgs e)
        {
            if (detail.Count > 0)
            {
                if (MessageBox.Show("There is a current order not yet processed, are you sure to cancel anyway it?", "WARNING", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
            }
            detail.Clear();
            ds.Tables["Detail"].Rows.Clear();
            dgvOrderDetail.DataSource = ds.Tables["Detail"];
            UpdateOrderDetailView();

            txtCustomerName.Text = "";
            txtTableNumber.Text = "";
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            if (detail.Count == 0)
                return;
            InsertDBOrder();
            InsertDBOrderDetails();

            MessageBox.Show("Order is printing...", "SUCCESS!!", MessageBoxButtons.OK);
            detail.Clear();
            btnNewOrder_Click(null, null);
        }

        private void UpdateOrderDetailView()
        {
            ReloadOrderDetailDataGridView();
            FormFillSelectedOrderDetail();
        }

        private void ReloadOrderDetailDataGridView()
        {
            //Clear to reset the "No." column, by @count = 1
            ds.Tables["Detail"].Rows.Clear();
            int count = 1;
            float totalPrice = 0;
            foreach (var entry in detail)
            {
                DataRow row = ds.Tables["Detail"].NewRow();
                row["Item"] = entry.Key["name"];
                row["Unit Price"] = entry.Key["price"];
                row["Quantity"] = entry.Value;
                row["Price"] = float.Parse(entry.Key["price"].ToString()) * entry.Value;
                row["No"] = count++;

                ds.Tables["Detail"].Rows.Add(row);

                totalPrice += float.Parse(row["Price"].ToString());
            }

            lbOrderPrice.Text = totalPrice.ToString();
        }

        private void CreateOrder_Load(object sender, EventArgs e)
        {
            LoadCategory();
            LoadMenu();
            PrepareOrder();
            PrepareOrderDetail();
            InitPseudoDetailGridView();
        }
    }
}
