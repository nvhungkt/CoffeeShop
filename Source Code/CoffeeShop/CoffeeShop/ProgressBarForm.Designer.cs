namespace CoffeeShop
{
    partial class ProgressBarForm
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
            this.components = new System.ComponentModel.Container();
            this.pgbRunning = new System.Windows.Forms.ProgressBar();
            this.timerCheck = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorking = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // pgbRunning
            // 
            this.pgbRunning.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pgbRunning.Location = new System.Drawing.Point(0, 227);
            this.pgbRunning.Name = "pgbRunning";
            this.pgbRunning.Size = new System.Drawing.Size(500, 23);
            this.pgbRunning.TabIndex = 0;
            // 
            // timerCheck
            // 
            this.timerCheck.Interval = 1000;
            this.timerCheck.Tick += new System.EventHandler(this.timerCheck_Tick);
            // 
            // backgroundWorking
            // 
            this.backgroundWorking.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorking_DoWork);
            this.backgroundWorking.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorking_RunWorkerCompleted);
            // 
            // ProgressBarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CoffeeShop.Properties.Resources.index;
            this.ClientSize = new System.Drawing.Size(500, 250);
            this.Controls.Add(this.pgbRunning);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ProgressBarForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProgressBarForm";
            this.Load += new System.EventHandler(this.ProgressBarForm_Load_1);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar pgbRunning;
        private System.Windows.Forms.Timer timerCheck;
        private System.ComponentModel.BackgroundWorker backgroundWorking;
    }
}