namespace Media_Bazaar
{
    partial class AssignShift
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
            this.grpBxViewShifts = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAbsent = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnLate = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnPresent = new Bunifu.Framework.UI.BunifuFlatButton();
            this.lbShifts = new System.Windows.Forms.ListBox();
            this.grpBxAssignShift = new System.Windows.Forms.GroupBox();
            this.tbDate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAssignWorkShift = new Bunifu.Framework.UI.BunifuFlatButton();
            this.cmbBxWorkShiftSunday = new System.Windows.Forms.ComboBox();
            this.cmbBxWorkShiftSaturday = new System.Windows.Forms.ComboBox();
            this.cmbBxWorkShiftWeekDay = new System.Windows.Forms.ComboBox();
            this.label26 = new System.Windows.Forms.Label();
            this.tbEmployeeIdAssignShift = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.grpBxViewShifts.SuspendLayout();
            this.grpBxAssignShift.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBxViewShifts
            // 
            this.grpBxViewShifts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBxViewShifts.Controls.Add(this.label2);
            this.grpBxViewShifts.Controls.Add(this.btnAbsent);
            this.grpBxViewShifts.Controls.Add(this.btnLate);
            this.grpBxViewShifts.Controls.Add(this.btnPresent);
            this.grpBxViewShifts.Controls.Add(this.lbShifts);
            this.grpBxViewShifts.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBxViewShifts.Location = new System.Drawing.Point(43, 354);
            this.grpBxViewShifts.Name = "grpBxViewShifts";
            this.grpBxViewShifts.Size = new System.Drawing.Size(403, 389);
            this.grpBxViewShifts.TabIndex = 12;
            this.grpBxViewShifts.TabStop = false;
            this.grpBxViewShifts.Text = "View Shifts";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(151, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(203, 15);
            this.label2.TabIndex = 14;
            this.label2.Text = "(click twice on the shift to delete it.";
            // 
            // btnAbsent
            // 
            this.btnAbsent.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(208)))), ((int)(((byte)(252)))));
            this.btnAbsent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(61)))), ((int)(((byte)(89)))));
            this.btnAbsent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAbsent.BorderRadius = 0;
            this.btnAbsent.ButtonText = "Absent";
            this.btnAbsent.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAbsent.DisabledColor = System.Drawing.Color.Gray;
            this.btnAbsent.Iconcolor = System.Drawing.Color.Transparent;
            this.btnAbsent.Iconimage = null;
            this.btnAbsent.Iconimage_right = null;
            this.btnAbsent.Iconimage_right_Selected = null;
            this.btnAbsent.Iconimage_Selected = null;
            this.btnAbsent.IconMarginLeft = 0;
            this.btnAbsent.IconMarginRight = 0;
            this.btnAbsent.IconRightVisible = false;
            this.btnAbsent.IconRightZoom = 0D;
            this.btnAbsent.IconVisible = false;
            this.btnAbsent.IconZoom = 90D;
            this.btnAbsent.IsTab = false;
            this.btnAbsent.Location = new System.Drawing.Point(249, 344);
            this.btnAbsent.Margin = new System.Windows.Forms.Padding(43, 81, 43, 81);
            this.btnAbsent.Name = "btnAbsent";
            this.btnAbsent.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(61)))), ((int)(((byte)(89)))));
            this.btnAbsent.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(208)))), ((int)(((byte)(252)))));
            this.btnAbsent.OnHoverTextColor = System.Drawing.Color.White;
            this.btnAbsent.selected = false;
            this.btnAbsent.Size = new System.Drawing.Size(110, 32);
            this.btnAbsent.TabIndex = 13;
            this.btnAbsent.Text = "Absent";
            this.btnAbsent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAbsent.Textcolor = System.Drawing.Color.White;
            this.btnAbsent.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbsent.Click += new System.EventHandler(this.btnAbsent_Click);
            // 
            // btnLate
            // 
            this.btnLate.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(208)))), ((int)(((byte)(252)))));
            this.btnLate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(61)))), ((int)(((byte)(89)))));
            this.btnLate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLate.BorderRadius = 0;
            this.btnLate.ButtonText = "Late";
            this.btnLate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLate.DisabledColor = System.Drawing.Color.Gray;
            this.btnLate.Iconcolor = System.Drawing.Color.Transparent;
            this.btnLate.Iconimage = null;
            this.btnLate.Iconimage_right = null;
            this.btnLate.Iconimage_right_Selected = null;
            this.btnLate.Iconimage_Selected = null;
            this.btnLate.IconMarginLeft = 0;
            this.btnLate.IconMarginRight = 0;
            this.btnLate.IconRightVisible = false;
            this.btnLate.IconRightZoom = 0D;
            this.btnLate.IconVisible = false;
            this.btnLate.IconZoom = 90D;
            this.btnLate.IsTab = false;
            this.btnLate.Location = new System.Drawing.Point(129, 344);
            this.btnLate.Margin = new System.Windows.Forms.Padding(20, 44, 20, 44);
            this.btnLate.Name = "btnLate";
            this.btnLate.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(61)))), ((int)(((byte)(89)))));
            this.btnLate.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(208)))), ((int)(((byte)(252)))));
            this.btnLate.OnHoverTextColor = System.Drawing.Color.White;
            this.btnLate.selected = false;
            this.btnLate.Size = new System.Drawing.Size(110, 32);
            this.btnLate.TabIndex = 12;
            this.btnLate.Text = "Late";
            this.btnLate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnLate.Textcolor = System.Drawing.Color.White;
            this.btnLate.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLate.Click += new System.EventHandler(this.btnLate_Click);
            // 
            // btnPresent
            // 
            this.btnPresent.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(208)))), ((int)(((byte)(252)))));
            this.btnPresent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(61)))), ((int)(((byte)(89)))));
            this.btnPresent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPresent.BorderRadius = 0;
            this.btnPresent.ButtonText = "Present";
            this.btnPresent.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPresent.DisabledColor = System.Drawing.Color.Gray;
            this.btnPresent.Iconcolor = System.Drawing.Color.Transparent;
            this.btnPresent.Iconimage = null;
            this.btnPresent.Iconimage_right = null;
            this.btnPresent.Iconimage_right_Selected = null;
            this.btnPresent.Iconimage_Selected = null;
            this.btnPresent.IconMarginLeft = 0;
            this.btnPresent.IconMarginRight = 0;
            this.btnPresent.IconRightVisible = false;
            this.btnPresent.IconRightZoom = 0D;
            this.btnPresent.IconVisible = false;
            this.btnPresent.IconZoom = 90D;
            this.btnPresent.IsTab = false;
            this.btnPresent.Location = new System.Drawing.Point(10, 344);
            this.btnPresent.Margin = new System.Windows.Forms.Padding(9, 24, 9, 24);
            this.btnPresent.Name = "btnPresent";
            this.btnPresent.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(61)))), ((int)(((byte)(89)))));
            this.btnPresent.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(208)))), ((int)(((byte)(252)))));
            this.btnPresent.OnHoverTextColor = System.Drawing.Color.White;
            this.btnPresent.selected = false;
            this.btnPresent.Size = new System.Drawing.Size(110, 32);
            this.btnPresent.TabIndex = 11;
            this.btnPresent.Text = "Present";
            this.btnPresent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnPresent.Textcolor = System.Drawing.Color.White;
            this.btnPresent.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPresent.Click += new System.EventHandler(this.btnPresent_Click);
            // 
            // lbShifts
            // 
            this.lbShifts.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbShifts.FormattingEnabled = true;
            this.lbShifts.ItemHeight = 19;
            this.lbShifts.Location = new System.Drawing.Point(10, 43);
            this.lbShifts.Name = "lbShifts";
            this.lbShifts.Size = new System.Drawing.Size(349, 251);
            this.lbShifts.TabIndex = 0;
            this.lbShifts.DoubleClick += new System.EventHandler(this.lbItem_DoubleClick);
            // 
            // grpBxAssignShift
            // 
            this.grpBxAssignShift.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBxAssignShift.Controls.Add(this.tbDate);
            this.grpBxAssignShift.Controls.Add(this.label1);
            this.grpBxAssignShift.Controls.Add(this.btnAssignWorkShift);
            this.grpBxAssignShift.Controls.Add(this.cmbBxWorkShiftSunday);
            this.grpBxAssignShift.Controls.Add(this.cmbBxWorkShiftSaturday);
            this.grpBxAssignShift.Controls.Add(this.cmbBxWorkShiftWeekDay);
            this.grpBxAssignShift.Controls.Add(this.label26);
            this.grpBxAssignShift.Controls.Add(this.tbEmployeeIdAssignShift);
            this.grpBxAssignShift.Controls.Add(this.label24);
            this.grpBxAssignShift.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBxAssignShift.Location = new System.Drawing.Point(43, 24);
            this.grpBxAssignShift.Name = "grpBxAssignShift";
            this.grpBxAssignShift.Size = new System.Drawing.Size(403, 304);
            this.grpBxAssignShift.TabIndex = 10;
            this.grpBxAssignShift.TabStop = false;
            this.grpBxAssignShift.Text = "Assign Shift";
            // 
            // tbDate
            // 
            this.tbDate.Enabled = false;
            this.tbDate.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDate.Location = new System.Drawing.Point(129, 62);
            this.tbDate.Name = "tbDate";
            this.tbDate.Size = new System.Drawing.Size(230, 27);
            this.tbDate.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 19);
            this.label1.TabIndex = 10;
            this.label1.Text = "Date:";
            // 
            // btnAssignWorkShift
            // 
            this.btnAssignWorkShift.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(208)))), ((int)(((byte)(252)))));
            this.btnAssignWorkShift.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(61)))), ((int)(((byte)(89)))));
            this.btnAssignWorkShift.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAssignWorkShift.BorderRadius = 0;
            this.btnAssignWorkShift.ButtonText = "Assign";
            this.btnAssignWorkShift.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAssignWorkShift.DisabledColor = System.Drawing.Color.Gray;
            this.btnAssignWorkShift.Iconcolor = System.Drawing.Color.Transparent;
            this.btnAssignWorkShift.Iconimage = null;
            this.btnAssignWorkShift.Iconimage_right = null;
            this.btnAssignWorkShift.Iconimage_right_Selected = null;
            this.btnAssignWorkShift.Iconimage_Selected = null;
            this.btnAssignWorkShift.IconMarginLeft = 0;
            this.btnAssignWorkShift.IconMarginRight = 0;
            this.btnAssignWorkShift.IconRightVisible = false;
            this.btnAssignWorkShift.IconRightZoom = 0D;
            this.btnAssignWorkShift.IconVisible = false;
            this.btnAssignWorkShift.IconZoom = 90D;
            this.btnAssignWorkShift.IsTab = false;
            this.btnAssignWorkShift.Location = new System.Drawing.Point(24, 234);
            this.btnAssignWorkShift.Margin = new System.Windows.Forms.Padding(4, 13, 4, 13);
            this.btnAssignWorkShift.Name = "btnAssignWorkShift";
            this.btnAssignWorkShift.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(61)))), ((int)(((byte)(89)))));
            this.btnAssignWorkShift.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(208)))), ((int)(((byte)(252)))));
            this.btnAssignWorkShift.OnHoverTextColor = System.Drawing.Color.White;
            this.btnAssignWorkShift.selected = false;
            this.btnAssignWorkShift.Size = new System.Drawing.Size(335, 28);
            this.btnAssignWorkShift.TabIndex = 8;
            this.btnAssignWorkShift.Text = "Assign";
            this.btnAssignWorkShift.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnAssignWorkShift.Textcolor = System.Drawing.Color.White;
            this.btnAssignWorkShift.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAssignWorkShift.Click += new System.EventHandler(this.btnAssignWorkShift_Click);
            // 
            // cmbBxWorkShiftSunday
            // 
            this.cmbBxWorkShiftSunday.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbBxWorkShiftSunday.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBxWorkShiftSunday.FormattingEnabled = true;
            this.cmbBxWorkShiftSunday.Items.AddRange(new object[] {
            "Afternoon -> 12:00-18:00"});
            this.cmbBxWorkShiftSunday.Location = new System.Drawing.Point(129, 148);
            this.cmbBxWorkShiftSunday.Name = "cmbBxWorkShiftSunday";
            this.cmbBxWorkShiftSunday.Size = new System.Drawing.Size(230, 27);
            this.cmbBxWorkShiftSunday.TabIndex = 7;
            this.cmbBxWorkShiftSunday.Visible = false;
            // 
            // cmbBxWorkShiftSaturday
            // 
            this.cmbBxWorkShiftSaturday.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBxWorkShiftSaturday.FormattingEnabled = true;
            this.cmbBxWorkShiftSaturday.Items.AddRange(new object[] {
            "Morning -> 09:00-15:00",
            "Afternoon -> 15:00-18:00"});
            this.cmbBxWorkShiftSaturday.Location = new System.Drawing.Point(129, 148);
            this.cmbBxWorkShiftSaturday.Name = "cmbBxWorkShiftSaturday";
            this.cmbBxWorkShiftSaturday.Size = new System.Drawing.Size(230, 27);
            this.cmbBxWorkShiftSaturday.TabIndex = 6;
            this.cmbBxWorkShiftSaturday.Visible = false;
            // 
            // cmbBxWorkShiftWeekDay
            // 
            this.cmbBxWorkShiftWeekDay.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBxWorkShiftWeekDay.FormattingEnabled = true;
            this.cmbBxWorkShiftWeekDay.Items.AddRange(new object[] {
            "Morning -> 07:00-12:00",
            "Afternoon -> 12:00-17:00",
            "Evening -> 17:00-22:00"});
            this.cmbBxWorkShiftWeekDay.Location = new System.Drawing.Point(129, 148);
            this.cmbBxWorkShiftWeekDay.Name = "cmbBxWorkShiftWeekDay";
            this.cmbBxWorkShiftWeekDay.Size = new System.Drawing.Size(230, 27);
            this.cmbBxWorkShiftWeekDay.TabIndex = 5;
            this.cmbBxWorkShiftWeekDay.Visible = false;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(6, 156);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(92, 19);
            this.label26.TabIndex = 4;
            this.label26.Text = "Work shift:";
            // 
            // tbEmployeeIdAssignShift
            // 
            this.tbEmployeeIdAssignShift.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbEmployeeIdAssignShift.Location = new System.Drawing.Point(129, 107);
            this.tbEmployeeIdAssignShift.Name = "tbEmployeeIdAssignShift";
            this.tbEmployeeIdAssignShift.Size = new System.Drawing.Size(230, 27);
            this.tbEmployeeIdAssignShift.TabIndex = 1;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(6, 110);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(111, 19);
            this.label24.TabIndex = 0;
            this.label24.Text = "Employee ID:";
            // 
            // AssignShift
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(208)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(458, 760);
            this.Controls.Add(this.grpBxViewShifts);
            this.Controls.Add(this.grpBxAssignShift);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AssignShift";
            this.Text = "AssignShift";
            this.Load += new System.EventHandler(this.AssignShift_Load);
            this.grpBxViewShifts.ResumeLayout(false);
            this.grpBxViewShifts.PerformLayout();
            this.grpBxAssignShift.ResumeLayout(false);
            this.grpBxAssignShift.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBxViewShifts;
        private System.Windows.Forms.GroupBox grpBxAssignShift;
        private Bunifu.Framework.UI.BunifuFlatButton btnAssignWorkShift;
        private System.Windows.Forms.ComboBox cmbBxWorkShiftSunday;
        private System.Windows.Forms.ComboBox cmbBxWorkShiftSaturday;
        private System.Windows.Forms.ComboBox cmbBxWorkShiftWeekDay;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox tbEmployeeIdAssignShift;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbShifts;
        private Bunifu.Framework.UI.BunifuFlatButton btnAbsent;
        private Bunifu.Framework.UI.BunifuFlatButton btnLate;
        private Bunifu.Framework.UI.BunifuFlatButton btnPresent;
        private System.Windows.Forms.TextBox tbDate;
        private System.Windows.Forms.Label label2;
    }
}