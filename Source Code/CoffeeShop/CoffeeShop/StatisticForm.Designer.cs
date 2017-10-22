namespace CoffeeShop
{
    partial class StatisticForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvOrderStatistic = new System.Windows.Forms.DataGridView();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lbFromDate = new System.Windows.Forms.Label();
            this.lbToDate = new System.Windows.Forms.Label();
            this.lbStatistic = new System.Windows.Forms.Label();
            this.btnReverse = new System.Windows.Forms.Button();
            this.btnShowPopularMenuItem = new System.Windows.Forms.Button();
            this.btnShowBenefit = new System.Windows.Forms.Button();
            this.btnShowTotalOrders = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtShowBenefits = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderStatistic)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvOrderStatistic
            // 
            this.dgvOrderStatistic.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrderStatistic.Location = new System.Drawing.Point(12, 72);
            this.dgvOrderStatistic.Name = "dgvOrderStatistic";
            this.dgvOrderStatistic.Size = new System.Drawing.Size(506, 299);
            this.dgvOrderStatistic.TabIndex = 0;
            // 
            // dtpTo
            // 
            this.dtpTo.Location = new System.Drawing.Point(539, 158);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(183, 20);
            this.dtpTo.TabIndex = 1;
            // 
            // dtpFrom
            // 
            this.dtpFrom.CustomFormat = "dd/MM/yyyy";
            this.dtpFrom.Location = new System.Drawing.Point(539, 99);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(183, 20);
            this.dtpFrom.TabIndex = 2;
            // 
            // lbFromDate
            // 
            this.lbFromDate.AutoSize = true;
            this.lbFromDate.Location = new System.Drawing.Point(536, 73);
            this.lbFromDate.Name = "lbFromDate";
            this.lbFromDate.Size = new System.Drawing.Size(33, 13);
            this.lbFromDate.TabIndex = 3;
            this.lbFromDate.Text = "From:";
            // 
            // lbToDate
            // 
            this.lbToDate.AutoSize = true;
            this.lbToDate.Location = new System.Drawing.Point(536, 132);
            this.lbToDate.Name = "lbToDate";
            this.lbToDate.Size = new System.Drawing.Size(23, 13);
            this.lbToDate.TabIndex = 4;
            this.lbToDate.Text = "To:";
            // 
            // lbStatistic
            // 
            this.lbStatistic.AutoSize = true;
            this.lbStatistic.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStatistic.Location = new System.Drawing.Point(9, 9);
            this.lbStatistic.Name = "lbStatistic";
            this.lbStatistic.Size = new System.Drawing.Size(120, 31);
            this.lbStatistic.TabIndex = 5;
            this.lbStatistic.Text = "Statistic";
            // 
            // btnReverse
            // 
            this.btnReverse.Location = new System.Drawing.Point(539, 205);
            this.btnReverse.Name = "btnReverse";
            this.btnReverse.Size = new System.Drawing.Size(183, 23);
            this.btnReverse.TabIndex = 5;
            this.btnReverse.Text = "Reverse";
            this.btnReverse.UseVisualStyleBackColor = true;
            this.btnReverse.Click += new System.EventHandler(this.btnReverse_Click);
            // 
            // btnShowPopularMenuItem
            // 
            this.btnShowPopularMenuItem.Location = new System.Drawing.Point(539, 254);
            this.btnShowPopularMenuItem.Name = "btnShowPopularMenuItem";
            this.btnShowPopularMenuItem.Size = new System.Drawing.Size(183, 23);
            this.btnShowPopularMenuItem.TabIndex = 6;
            this.btnShowPopularMenuItem.Text = "Show popular menu item";
            this.btnShowPopularMenuItem.UseVisualStyleBackColor = true;
            this.btnShowPopularMenuItem.Click += new System.EventHandler(this.btnShowPopularMenuItem_Click);
            // 
            // btnShowBenefit
            // 
            this.btnShowBenefit.Location = new System.Drawing.Point(539, 303);
            this.btnShowBenefit.Name = "btnShowBenefit";
            this.btnShowBenefit.Size = new System.Drawing.Size(183, 23);
            this.btnShowBenefit.TabIndex = 7;
            this.btnShowBenefit.Text = "Show benefits";
            this.btnShowBenefit.UseVisualStyleBackColor = true;
            this.btnShowBenefit.Click += new System.EventHandler(this.btnShowBenefit_Click);
            // 
            // btnShowTotalOrders
            // 
            this.btnShowTotalOrders.Location = new System.Drawing.Point(539, 348);
            this.btnShowTotalOrders.Name = "btnShowTotalOrders";
            this.btnShowTotalOrders.Size = new System.Drawing.Size(183, 23);
            this.btnShowTotalOrders.TabIndex = 8;
            this.btnShowTotalOrders.Text = "Show total orders";
            this.btnShowTotalOrders.UseVisualStyleBackColor = true;
            this.btnShowTotalOrders.Click += new System.EventHandler(this.btnShowTotalOrders_Click);
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Location = new System.Drawing.Point(15, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(710, 2);
            this.label4.TabIndex = 11;
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtShowBenefits);
            this.groupBox1.Location = new System.Drawing.Point(12, 377);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(710, 129);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Benefits";
            // 
            // txtShowBenefits
            // 
            this.txtShowBenefits.Location = new System.Drawing.Point(7, 20);
            this.txtShowBenefits.Multiline = true;
            this.txtShowBenefits.Name = "txtShowBenefits";
            this.txtShowBenefits.ReadOnly = true;
            this.txtShowBenefits.Size = new System.Drawing.Size(697, 102);
            this.txtShowBenefits.TabIndex = 0;
            // 
            // StatisticForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 511);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnShowTotalOrders);
            this.Controls.Add(this.btnShowBenefit);
            this.Controls.Add(this.btnShowPopularMenuItem);
            this.Controls.Add(this.btnReverse);
            this.Controls.Add(this.lbFromDate);
            this.Controls.Add(this.lbStatistic);
            this.Controls.Add(this.lbToDate);
            this.Controls.Add(this.dgvOrderStatistic);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.dtpFrom);
            this.Name = "StatisticForm";
            this.Text = "StatisticForm";
            this.Load += new System.EventHandler(this.StatisticForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrderStatistic)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvOrderStatistic;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lbFromDate;
        private System.Windows.Forms.Label lbToDate;
        private System.Windows.Forms.Label lbStatistic;
        private System.Windows.Forms.Button btnReverse;
        private System.Windows.Forms.Button btnShowPopularMenuItem;
        private System.Windows.Forms.Button btnShowBenefit;
        private System.Windows.Forms.Button btnShowTotalOrders;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtShowBenefits;
    }
}