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
    public partial class StatisticForm : Form
    {
        SqlDataAdapter dAdapt;
        DataSet myDS = new DataSet();
        private readonly string connStr = ConfigurationManager.ConnectionStrings["SqlProviderPubs"].ConnectionString;

        private bool orderShowing; //use for determine whether datagridview is showing Order details

        public void ShowPopularMenuItem()
        {
            myDS.Clear();
            dgvOrderStatistic.DataSource = null;
            DateTime dateFrom = dtpFrom.Value;
            DateTime dateTo = dtpTo.Value;
            if(dateFrom > dateTo)
            {
                return;
            }
            string dFrom = string.Format("{0}-{1}-{2}",dateFrom.Year, dateFrom.Month, dateFrom.Day);
            string dTo = string.Format("{0}-{1}-{2}", dateTo.Year, dateTo.Month, dateTo.Day);
            string queryPopularEachItem = "select p.id, count(p.id) popular \n"
                           + "from Product p, OrderDetail o, [Order] ord \n"
                           + "where p.id = o.productID and o.orderID = ord.id and ord.takenDate >= '" + dFrom + "' and ord.takenDate <= '" + dTo + "' and ord.status = 'paid'\n"
                           + "group by p.id \n";
            string itemsInRange = "select pr.id, pr.name, pr.description, pr.categoryID, pr.price, f.popular \n"
                + "from (" + queryPopularEachItem + ") f, Product pr \n"
                + "where f.id = pr.id ";
            string sql = "SELECT por.name, por.description, por.categoryID, por.price, poo.popular \n"
                + "FROM Product por \n"
                + "full join \n"
                + "(" + itemsInRange +") poo ON por.id = poo.id \n"
                + "ORDER BY poo.popular DESC";
            dAdapt = new SqlDataAdapter(sql, connStr);
            SqlCommandBuilder builder = new SqlCommandBuilder(dAdapt);
            try
            {
                dAdapt.Fill(myDS, "PopularItem");
                AddNoColumnToDataTable("PopularItem");
                foreach (DataRow row in myDS.Tables["PopularItem"].Rows)
                {
                    if (row["popular"].ToString().Equals(""))
                    {
                        row["popular"] = "0";
                    }
                }
                dgvOrderStatistic.DataSource = myDS.Tables["PopularItem"];
            }
            catch (Exception se)
            {
                MessageBox.Show(se.Message);
            }
        }

        public void Reverse()
        {
            // reverse by the column No.
            DataGridViewColumn col = dgvOrderStatistic.Columns[0];
            if (dgvOrderStatistic.SortOrder == System.Windows.Forms.SortOrder.Ascending)
            {
                dgvOrderStatistic.Sort(col, ListSortDirection.Descending);
            }
            else
            {
                dgvOrderStatistic.Sort(col, ListSortDirection.Ascending);
            }
            
        }

        public StatisticForm()
        {
            InitializeComponent();
        }

        public void AddNoColumnToDataTable(string tableName)
        {
            DataTable tbl = myDS.Tables[tableName];
            if (tbl.Columns["No."] == null)
            {
                System.Data.DataColumn newColumn = new System.Data.DataColumn("No.", typeof(Int32));
                tbl.Columns.Add(newColumn);
            }
            tbl.Columns["No."].SetOrdinal(0);
            int index = 1;
            foreach (DataRow row in tbl.Rows)
            {
                row["No."] = index;
                index++;
            }
        }

        public void ShowTotalOrders()
        {
            myDS.Clear();
            dgvOrderStatistic.DataSource = null;
            DateTime dateFrom = dtpFrom.Value;
            DateTime dateTo = dtpTo.Value;
            string dFrom = string.Format("{0}-{1}-{2}", dateFrom.Year, dateFrom.Month, dateFrom.Day);
            string dTo = string.Format("{0}-{1}-{2}", dateTo.Year, dateTo.Month, dateTo.Day);
            string queryOrderStay = "select count(o.id) as OrderQuanity from[Order] o where o.tableNumber is not Null and o.takenDate >= '" + dFrom + "' and o.takenDate <= '" + dTo + "'";
            string queryOrderLeave = "select count(o.id) as OrderQuanity from[Order] o where o.tableNumber is Null and o.takenDate >= '" + dFrom + "' and o.takenDate <= '" + dTo + "'";
            string sql = queryOrderStay + " union all " + queryOrderLeave;
            dAdapt = new SqlDataAdapter(sql, connStr);
            SqlCommandBuilder builder = new SqlCommandBuilder(dAdapt);
            try
            {
                dAdapt.Fill(myDS, "Quantity");
                AddNoColumnToDataTable("Quantity");

                if (myDS.Tables["Quantity"].Columns["Order Type"] == null)
                {
                    System.Data.DataColumn newColumn = new System.Data.DataColumn("Order Type", typeof(string));
                    myDS.Tables["Quantity"].Columns.Add(newColumn);
                }
                myDS.Tables["Quantity"].Columns["Order Type"].SetOrdinal(1);
                int index = 0;
                foreach (DataRow row in myDS.Tables["Quantity"].Rows)
                {
                    string value;
                    if(index == 0)
                    {
                        value = "Stay";
                    } else
                    {
                        value = "Leaving";
                    }
                    row["Order Type"] = value;
                    index++;
                }
                
                dgvOrderStatistic.DataSource = myDS.Tables["Quantity"];

            }
            catch (Exception se)
            {
                MessageBox.Show(se.Message);
            }
        }

        public void ShowOrderBenefit()
        {
            myDS.Clear();
            dgvOrderStatistic.DataSource = null;
            DateTime dateFrom = dtpFrom.Value;
            DateTime dateTo = dtpTo.Value;
            string dFrom = string.Format("{0}-{1}-{2}", dateFrom.Year, dateFrom.Month, dateFrom.Day);
            string dTo = string.Format("{0}-{1}-{2}", dateTo.Year, dateTo.Month, dateTo.Day);

            string sql = "select o.id, o.customerName, s.name, o.takenDate, o.takenTime, o.tableNumber, o.totalPrice from [Order] o, Staff s where status = 'paid' and o.staffId = s.id and o.takenDate >= '" + dFrom + "' and o.takenDate <= '" + dTo + "'";
            dAdapt = new SqlDataAdapter(sql, connStr);
            SqlCommandBuilder builder = new SqlCommandBuilder(dAdapt);
            try
            {
                dAdapt.Fill(myDS, "Benefit");
                AddNoColumnToDataTable("Benefit");

                dgvOrderStatistic.DataSource = myDS.Tables["Benefit"];

            }
            catch (Exception se)
            {
                MessageBox.Show(se.Message);
            }
        }

        public void ShowAvarageBenefit()
        {
            DateTime dateFrom = dtpFrom.Value;
            DateTime dateTo = dtpTo.Value;
            string dFrom = string.Format("{0}-{1}-{2}", dateFrom.Year, dateFrom.Month, dateFrom.Day);
            string dTo = string.Format("{0}-{1}-{2}", dateTo.Year, dateTo.Month, dateTo.Day);

            string sql = "select avg(o.totalPrice) as AverageBenefit from [Order] o where status = 'paid' and o.takenDate >= '" + dFrom + "' and o.takenDate <= '" + dTo + "'";
            dAdapt = new SqlDataAdapter(sql, connStr);
            SqlCommandBuilder builder = new SqlCommandBuilder(dAdapt);
            try
            {
                dAdapt.Fill(myDS, "AverageBenefit");
                txtShowBenefits.Text = "Average: " + myDS.Tables["AverageBenefit"].Rows[0][0].ToString();

            }
            catch (Exception se)
            {
                MessageBox.Show(se.Message);
            }
        }

        public void ClearBenefit()
        {
            txtShowBenefits.Text = "";
        }

        private void StatisticForm_Load(object sender, EventArgs e)
        {
            Design.ApplyFormColor(this);
            Design.ApplyDGVColor(dgvOrderStatistic);
            Design.ApplyButtonInfo(btnReverse);
            Design.ApplyButtonSuccess(btnShowBenefit);
            Design.ApplyButtonSuccess(btnShowPopularMenuItem);
            Design.ApplyButtonSuccess(btnShowTotalOrders);
            dtpFrom.Format = DateTimePickerFormat.Custom;
            dtpFrom.CustomFormat = "dd/MM/yyyy";
            dtpTo.Format = DateTimePickerFormat.Custom;
            dtpTo.CustomFormat = "dd/MM/yyyy";
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnShowPopularMenuItem_Click(object sender, EventArgs e)
        {
            orderShowing = false;
            ShowPopularMenuItem();
            ClearBenefit();
        }

        private void btnShowBenefit_Click(object sender, EventArgs e)
        {
            orderShowing = true;
            ShowOrderBenefit();
            ShowAvarageBenefit();
        }

        private void btnShowTotalOrders_Click(object sender, EventArgs e)
        {
            orderShowing = false;
            ShowTotalOrders();
            ClearBenefit();
        }

        private void btnReverse_Click(object sender, EventArgs e)
        {
            if (dgvOrderStatistic.RowCount > 0) {
                Reverse();
            }
        }

        private void dgvOrderStatistic_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            myDS.Tables["OrderDetail"]?.Rows.Clear();
            if (orderShowing)
            {
                int orderID = (int) myDS.Tables["Benefit"].Rows[e.RowIndex]["id"];

                SqlDataAdapter da = new SqlDataAdapter("SELECT [no], p.name, d.price, d.quantity, d.price * d.quantity AS total FROM [Order] o, OrderDetail d, Product p WHERE p.id = d.productID AND o.id = d.orderID AND o.id = " + orderID, connStr);

                da.Fill(myDS, "OrderDetail");

                string msg = String.Format("{0,-5} {1,-70} {2,-10} {3,-10} {4,-10}\n", "No", "Name", "Price", "Quantity", "Total");
                foreach (DataRow item in myDS.Tables["OrderDetail"].Rows)
                {
                    string padding = "";
                    for (int i = 0; i < 50 - ((string)item["name"]).Length; i++)
                    {
                        padding += " ";
                    }
                    msg += String.Format("{0,-5} {1} {2,-10} {3,-10} {4,-10}\n", item["no"], item["name"] + padding, item["price"], item["quantity"], item["total"]);
                }
                MessageBox.Show(msg);
            }
        }
    }
}
