namespace Media_Bazaar
{
    partial class MainDepot
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
            this.btnSchedule = new System.Windows.Forms.Button();
            this.btnStock = new System.Windows.Forms.Button();
            this.btnProfile = new System.Windows.Forms.Button();
            this.depotSchedule1 = new Media_Bazaar.DepotSchedule();
            this.depotProfile1 = new Media_Bazaar.DepotProfile();
            this.depotStock1 = new Media_Bazaar.DepotStock();
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
            this.pnlTabs.Controls.Add(this.btnSchedule);
            this.pnlTabs.Controls.Add(this.btnStock);
            this.pnlTabs.Controls.Add(this.btnProfile);
            this.pnlTabs.Controls.Add(this.btnLogout);
            this.pnlTabs.Controls.Add(this.btnWhite);
            this.pnlTabs.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlTabs.Location = new System.Drawing.Point(0, 0);
            this.pnlTabs.Name = "pnlTabs";
            this.pnlTabs.Size = new System.Drawing.Size(120, 450);
            this.pnlTabs.TabIndex = 1;
            // 
            // btnSchedule
            // 
            this.btnSchedule.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnSchedule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSchedule.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSchedule.ForeColor = System.Drawing.Color.White;
            this.btnSchedule.Location = new System.Drawing.Point(43, 121);
            this.btnSchedule.Name = "btnSchedule";
            this.btnSchedule.Size = new System.Drawing.Size(77, 28);
            this.btnSchedule.TabIndex = 8;
            this.btnSchedule.Text = "Schedule";
            this.btnSchedule.UseVisualStyleBackColor = true;
            this.btnSchedule.Click += new System.EventHandler(this.btnSchedule_Click);
            // 
            // btnStock
            // 
            this.btnStock.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnStock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStock.ForeColor = System.Drawing.Color.White;
            this.btnStock.Location = new System.Drawing.Point(58, 155);
            this.btnStock.Name = "btnStock";
            this.btnStock.Size = new System.Drawing.Size(62, 28);
            this.btnStock.TabIndex = 7;
            this.btnStock.Text = "Stock";
            this.btnStock.UseVisualStyleBackColor = true;
            this.btnStock.Click += new System.EventHandler(this.btnStock_Click);
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
            this.btnProfile.TabIndex = 6;
            this.btnProfile.Text = "Profile";
            this.btnProfile.UseVisualStyleBackColor = true;
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);
            // 
            // depotSchedule1
            // 
            this.depotSchedule1.Location = new System.Drawing.Point(126, -1);
            this.depotSchedule1.Name = "depotSchedule1";
            this.depotSchedule1.Size = new System.Drawing.Size(680, 450);
            this.depotSchedule1.TabIndex = 3;
            // 
            // depotProfile1
            // 
            this.depotProfile1.Location = new System.Drawing.Point(126, 0);
            this.depotProfile1.Name = "depotProfile1";
            this.depotProfile1.Size = new System.Drawing.Size(680, 450);
            this.depotProfile1.TabIndex = 2;
            // 
            // depotStock1
            // 
            this.depotStock1.Location = new System.Drawing.Point(126, 0);
            this.depotStock1.Name = "depotStock1";
            this.depotStock1.Size = new System.Drawing.Size(680, 450);
            this.depotStock1.TabIndex = 4;
            // 
            // MainDepot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(810, 450);
            this.Controls.Add(this.pnlTabs);
            this.Controls.Add(this.depotSchedule1);
            this.Controls.Add(this.depotProfile1);
            this.Controls.Add(this.depotStock1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainDepot";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainDepot";
            this.pnlTabs.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnWhite;
        private System.Windows.Forms.Panel pnlTabs;
        private System.Windows.Forms.Button btnSchedule;
        private System.Windows.Forms.Button btnStock;
        private System.Windows.Forms.Button btnProfile;
        private DepotProfile depotProfile1;
        private DepotSchedule depotSchedule1;
        private DepotStock depotStock1;
    }
}