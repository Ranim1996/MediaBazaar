namespace Media_Bazaar
{
    partial class MainManager
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
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnWhite = new System.Windows.Forms.Button();
            this.pnlTabs = new System.Windows.Forms.Panel();
            this.btnProfile = new System.Windows.Forms.Button();
            this.btnStocks = new System.Windows.Forms.Button();
            this.btnEmployees = new System.Windows.Forms.Button();
            this.btnStatistics = new System.Windows.Forms.Button();
            this.managerStocks1 = new Media_Bazaar.ManagerStocks();
            this.managerEmployees1 = new Media_Bazaar.ManagerEmployees();
            this.managerStatistics1 = new Media_Bazaar.ManagerStatistics();
            this.managerProfile1 = new Media_Bazaar.ManagerProfile();
            this.pnlTabs.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLogout
            // 
            this.btnLogout.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(58, 422);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(62, 28);
            this.btnLogout.TabIndex = 1;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnWhite
            // 
            this.btnWhite.BackColor = System.Drawing.Color.White;
            this.btnWhite.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnWhite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWhite.Location = new System.Drawing.Point(3, 418);
            this.btnWhite.Name = "btnWhite";
            this.btnWhite.Size = new System.Drawing.Size(13, 31);
            this.btnWhite.TabIndex = 0;
            this.btnWhite.UseVisualStyleBackColor = false;
            // 
            // pnlTabs
            // 
            this.pnlTabs.BackColor = System.Drawing.Color.Black;
            this.pnlTabs.Controls.Add(this.btnProfile);
            this.pnlTabs.Controls.Add(this.btnStocks);
            this.pnlTabs.Controls.Add(this.btnEmployees);
            this.pnlTabs.Controls.Add(this.btnStatistics);
            this.pnlTabs.Controls.Add(this.btnLogout);
            this.pnlTabs.Controls.Add(this.btnWhite);
            this.pnlTabs.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlTabs.Location = new System.Drawing.Point(0, 0);
            this.pnlTabs.Name = "pnlTabs";
            this.pnlTabs.Size = new System.Drawing.Size(120, 450);
            this.pnlTabs.TabIndex = 1;
            // 
            // btnProfile
            // 
            this.btnProfile.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProfile.ForeColor = System.Drawing.Color.White;
            this.btnProfile.Location = new System.Drawing.Point(58, 87);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Size = new System.Drawing.Size(62, 28);
            this.btnProfile.TabIndex = 9;
            this.btnProfile.Text = "Profile";
            this.btnProfile.UseVisualStyleBackColor = true;
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);
            // 
            // btnStocks
            // 
            this.btnStocks.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnStocks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStocks.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStocks.ForeColor = System.Drawing.Color.White;
            this.btnStocks.Location = new System.Drawing.Point(58, 189);
            this.btnStocks.Name = "btnStocks";
            this.btnStocks.Size = new System.Drawing.Size(62, 28);
            this.btnStocks.TabIndex = 8;
            this.btnStocks.Text = "Stocks";
            this.btnStocks.UseVisualStyleBackColor = true;
            this.btnStocks.Click += new System.EventHandler(this.btnStocks_Click);
            // 
            // btnEmployees
            // 
            this.btnEmployees.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnEmployees.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmployees.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmployees.ForeColor = System.Drawing.Color.White;
            this.btnEmployees.Location = new System.Drawing.Point(26, 155);
            this.btnEmployees.Name = "btnEmployees";
            this.btnEmployees.Size = new System.Drawing.Size(94, 28);
            this.btnEmployees.TabIndex = 7;
            this.btnEmployees.Text = "Employees";
            this.btnEmployees.UseVisualStyleBackColor = true;
            this.btnEmployees.Click += new System.EventHandler(this.btnEmployees_Click);
            // 
            // btnStatistics
            // 
            this.btnStatistics.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnStatistics.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStatistics.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStatistics.ForeColor = System.Drawing.Color.White;
            this.btnStatistics.Location = new System.Drawing.Point(46, 121);
            this.btnStatistics.Name = "btnStatistics";
            this.btnStatistics.Size = new System.Drawing.Size(74, 28);
            this.btnStatistics.TabIndex = 6;
            this.btnStatistics.Text = "Statistics";
            this.btnStatistics.UseVisualStyleBackColor = true;
            this.btnStatistics.Click += new System.EventHandler(this.btnStatistics_Click);
            // 
            // managerStocks1
            // 
            this.managerStocks1.Location = new System.Drawing.Point(126, 0);
            this.managerStocks1.Name = "managerStocks1";
            this.managerStocks1.Size = new System.Drawing.Size(680, 450);
            this.managerStocks1.TabIndex = 4;
            // 
            // managerEmployees1
            // 
            this.managerEmployees1.Location = new System.Drawing.Point(126, 0);
            this.managerEmployees1.Name = "managerEmployees1";
            this.managerEmployees1.Size = new System.Drawing.Size(680, 450);
            this.managerEmployees1.TabIndex = 2;
            // 
            // managerStatistics1
            // 
            this.managerStatistics1.Location = new System.Drawing.Point(126, 0);
            this.managerStatistics1.Name = "managerStatistics1";
            this.managerStatistics1.Size = new System.Drawing.Size(680, 450);
            this.managerStatistics1.TabIndex = 3;
            // 
            // managerProfile1
            // 
            this.managerProfile1.Location = new System.Drawing.Point(126, 0);
            this.managerProfile1.Name = "managerProfile1";
            this.managerProfile1.Size = new System.Drawing.Size(680, 450);
            this.managerProfile1.TabIndex = 5;
            // 
            // MainManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(810, 450);
            this.Controls.Add(this.managerProfile1);
            this.Controls.Add(this.pnlTabs);
            this.Controls.Add(this.managerStocks1);
            this.Controls.Add(this.managerEmployees1);
            this.Controls.Add(this.managerStatistics1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainManager";
            this.pnlTabs.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnWhite;
        private System.Windows.Forms.Panel pnlTabs;
        private System.Windows.Forms.Button btnStocks;
        private System.Windows.Forms.Button btnEmployees;
        private System.Windows.Forms.Button btnStatistics;
        private ManagerEmployees managerEmployees1;
        private ManagerStatistics managerStatistics1;
        private ManagerStocks managerStocks1;
        private System.Windows.Forms.Button btnProfile;
        private ManagerProfile managerProfile1;
    }
}