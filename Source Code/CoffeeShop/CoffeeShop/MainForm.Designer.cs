namespace CoffeeShop
{
    partial class MainForm
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
            this.menuBar = new System.Windows.Forms.MenuStrip();
            this.optSystem = new System.Windows.Forms.ToolStripMenuItem();
            this.itmLogin = new System.Windows.Forms.ToolStripMenuItem();
            this.itmLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.itmExit = new System.Windows.Forms.ToolStripMenuItem();
            this.optSale = new System.Windows.Forms.ToolStripMenuItem();
            this.itmSale = new System.Windows.Forms.ToolStripMenuItem();
            this.optHR = new System.Windows.Forms.ToolStripMenuItem();
            this.itmHR = new System.Windows.Forms.ToolStripMenuItem();
            this.optMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.itmMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.itmStatistic = new System.Windows.Forms.ToolStripMenuItem();
            this.optAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.itmAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuBar
            // 
            this.menuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optSystem,
            this.optSale,
            this.optHR,
            this.optMenu,
            this.optAbout});
            this.menuBar.Location = new System.Drawing.Point(0, 0);
            this.menuBar.Name = "menuBar";
            this.menuBar.Size = new System.Drawing.Size(707, 24);
            this.menuBar.TabIndex = 1;
            this.menuBar.Text = "menuStrip1";
            // 
            // optSystem
            // 
            this.optSystem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itmLogin,
            this.itmLogout,
            this.itmExit});
            this.optSystem.Name = "optSystem";
            this.optSystem.Size = new System.Drawing.Size(57, 20);
            this.optSystem.Text = "System";
            // 
            // itmLogin
            // 
            this.itmLogin.Name = "itmLogin";
            this.itmLogin.Size = new System.Drawing.Size(152, 22);
            this.itmLogin.Text = "Log in";
            this.itmLogin.Click += new System.EventHandler(this.itmLogin_Click);
            // 
            // itmLogout
            // 
            this.itmLogout.Name = "itmLogout";
            this.itmLogout.Size = new System.Drawing.Size(152, 22);
            this.itmLogout.Text = "Log out";
            this.itmLogout.Click += new System.EventHandler(this.itmLogout_Click);
            // 
            // itmExit
            // 
            this.itmExit.Name = "itmExit";
            this.itmExit.Size = new System.Drawing.Size(152, 22);
            this.itmExit.Text = "Exit";
            this.itmExit.Click += new System.EventHandler(this.itmExit_Click);
            // 
            // optSale
            // 
            this.optSale.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itmSale});
            this.optSale.Name = "optSale";
            this.optSale.Size = new System.Drawing.Size(40, 20);
            this.optSale.Text = "Sale";
            // 
            // itmSale
            // 
            this.itmSale.Name = "itmSale";
            this.itmSale.Size = new System.Drawing.Size(178, 22);
            this.itmSale.Text = "Order Management";
            this.itmSale.Click += new System.EventHandler(this.itmSale_Click);
            // 
            // optHR
            // 
            this.optHR.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itmHR});
            this.optHR.Name = "optHR";
            this.optHR.Size = new System.Drawing.Size(35, 20);
            this.optHR.Text = "HR";
            // 
            // itmHR
            // 
            this.itmHR.Name = "itmHR";
            this.itmHR.Size = new System.Drawing.Size(172, 22);
            this.itmHR.Text = "Staff Management";
            this.itmHR.Click += new System.EventHandler(this.itmHR_Click);
            // 
            // optMenu
            // 
            this.optMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itmMenu,
            this.itmStatistic});
            this.optMenu.Name = "optMenu";
            this.optMenu.Size = new System.Drawing.Size(50, 20);
            this.optMenu.Text = "Menu";
            // 
            // itmMenu
            // 
            this.itmMenu.Name = "itmMenu";
            this.itmMenu.Size = new System.Drawing.Size(179, 22);
            this.itmMenu.Text = "Menu Management";
            this.itmMenu.Click += new System.EventHandler(this.itmMenu_Click);
            // 
            // itmStatistic
            // 
            this.itmStatistic.Name = "itmStatistic";
            this.itmStatistic.Size = new System.Drawing.Size(179, 22);
            this.itmStatistic.Text = "Statistical Report";
            this.itmStatistic.Click += new System.EventHandler(this.itmStatistic_Click);
            // 
            // optAbout
            // 
            this.optAbout.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itmAbout});
            this.optAbout.Name = "optAbout";
            this.optAbout.Size = new System.Drawing.Size(52, 20);
            this.optAbout.Text = "About";
            // 
            // itmAbout
            // 
            this.itmAbout.Name = "itmAbout";
            this.itmAbout.Size = new System.Drawing.Size(152, 22);
            this.itmAbout.Text = "About us";
            this.itmAbout.Click += new System.EventHandler(this.itmAbout_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 359);
            this.Controls.Add(this.menuBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuBar;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "The Coffee Shop Management";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuBar.ResumeLayout(false);
            this.menuBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuBar;
        private System.Windows.Forms.ToolStripMenuItem optSale;
        private System.Windows.Forms.ToolStripMenuItem itmSale;
        private System.Windows.Forms.ToolStripMenuItem optHR;
        private System.Windows.Forms.ToolStripMenuItem optSystem;
        private System.Windows.Forms.ToolStripMenuItem itmLogin;
        private System.Windows.Forms.ToolStripMenuItem itmLogout;
        private System.Windows.Forms.ToolStripMenuItem itmExit;
        private System.Windows.Forms.ToolStripMenuItem itmHR;
        private System.Windows.Forms.ToolStripMenuItem optMenu;
        private System.Windows.Forms.ToolStripMenuItem itmMenu;
        private System.Windows.Forms.ToolStripMenuItem itmStatistic;
        private System.Windows.Forms.ToolStripMenuItem optAbout;
        private System.Windows.Forms.ToolStripMenuItem itmAbout;
    }
}

