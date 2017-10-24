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
    public partial class ProgressBarForm : Form
    {
        public static bool checkConnection = false;
        public ProgressBarForm()
        {
            InitializeComponent();
        }

        //private void timerCheck_Tick(object sender, EventArgs e)
        //{

        //}

        //private void backgroundWorking_DoWork(object sender, DoWorkEventArgs e)
        //{

        //}

        //private void backgroundWorking_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        //{

        //}

        public void CheckConn()
        {
            try
            {
                string connString = ConfigurationManager.ConnectionStrings["SqlProviderPubs"].ConnectionString;
                using (SqlConnection conn = new System.Data.SqlClient.SqlConnection(connString))
                {
                    conn.Open();
                }

                checkConnection = true;
            }
            catch (Exception ex)
            {
                checkConnection = false;
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private void timerCheck_Tick(object sender, EventArgs e)
        {
            if (checkConnection == false)
            {
                if (pgbRunning.Value == 100)
                {
                    timerCheck.Stop();
                    backgroundWorking.WorkerSupportsCancellation = true;
                    backgroundWorking.CancelAsync();
                    MessageBox.Show("Time out");
                    this.Close();
                }
                else
                {
                    pgbRunning.Increment(10);
                }
            }
            else
            {
                timerCheck.Stop();
                MainForm mainFrm = new MainForm();
                mainFrm.Show();
                this.Hide();
            }
        }

        private void backgroundWorking_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                CheckConn();
            }
            catch (Exception ex)
            {
                timerCheck.Stop();
                MessageBox.Show(ex.Message);
                Application.Exit();
            }
        }

        private void backgroundWorking_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pgbRunning.Value = pgbRunning.Maximum;
        }

        private void ProgressBarForm_Load(object sender, EventArgs e)
        {
            timerCheck.Start();
            backgroundWorking.RunWorkerAsync();
        }

        private void ProgressBarForm_Load_1(object sender, EventArgs e)
        {
            timerCheck.Start();
            backgroundWorking.RunWorkerAsync();
        }
    }
}
