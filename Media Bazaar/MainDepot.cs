using Media_Bazaar.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace Media_Bazaar
{
    public partial class MainDepot : Form
    {
        List<DBRestockRequest> incomingRestockRequests = new List<DBRestockRequest>();
        List<DBDepartament> departaments = new List<DBDepartament>();
        List<int> restockID = new List<int>();

        public MainDepot()
        {
            InitializeComponent();
        }

        private void MainDepot_Load(object sender, EventArgs e)
        {
            tabControl1.Appearance = TabAppearance.FlatButtons;
            tabControl1.ItemSize = new Size(0, 1);
            tabControl1.SizeMode = TabSizeMode.Fixed;
            tabControl1.TabPages[0].BackColor = Color.FromArgb(116, 208, 252);
            UpdateConfirmedRestockInfo();
            UpdateDepartamentInfo();
        }

        private void UpdateConfirmedRestockInfo()
        {
            // only confirmed requests will shown here
            DataAccess db = new DataAccess();
            incomingRestockRequests = db.GetAllConfirmedRestock();
            foreach (DBRestockRequest rr in incomingRestockRequests)
            {
                restockID.Add(rr.GetID());
            }
            clbIncomingStock.DataSource = incomingRestockRequests;
            clbIncomingStock.DisplayMember = "FullInfo";
        }


        //----------------------------------Start
        //All buttons connections for the AdminForm 
        //DO NOT Modify THIS !!!
        private void btnIncomingStockTABrequest_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabIncomingStock;
            UpdateConfirmedRestockInfo();
        }

        private void btnStockTABrequest_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabStock;
        }

        private void btnLogOutTABrequest_Click(object sender, EventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Visible = false;
        }

        private void MainDepot_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnMakeReqTABincomingStock_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabMakeReq;
        }


        private void btnCheckIncomingStock_Click(object sender, EventArgs e)
        {
            //INFORMATION about the incoming stock MUST be parsed in this method
            tabControl1.SelectedTab = tabIncomingStockDetails;
        }

        private void btnViewStock_Click(object sender, EventArgs e)
        {
            //INFORMATION about stock MUST be parsed in this method
            tabControl1.SelectedTab = tabInfoStock;
        }
        //----------------------------------------Finish


        //------------------------------start
        //Method for changing back color of the selected menu
        public void ChangeMenuColor(TabControl tc)
        {
            if (tc.SelectedTab == tabMakeReq)
            {
                btnMakeReqTABrequest.BackColor = Color.FromArgb(32, 126, 177);
            }
            else
            {
                if (tc.SelectedTab == tabIncomingStock || tc.SelectedTab == tabIncomingStockDetails)
                {
                    btnIncomingStockTABincomingStock.BackColor = Color.FromArgb(32, 126, 177);
                    btnIncomingStockTABincomingStockDet.BackColor = Color.FromArgb(32, 126, 177);
                }
                else
                {
                    if (tc.SelectedTab == tabStock || tc.SelectedTab == tabInfoStock)
                    {
                        btnStockTABstock.BackColor = Color.FromArgb(32, 126, 177);
                        btnStockTABstockInfo.BackColor = Color.FromArgb(32, 126, 177);
                    }
                }
            }
        }
        private void timerChangeMenuColor_Tick(object sender, EventArgs e)
        {
            ChangeMenuColor(tabControl1);
        }

        private void btnIncomingStockTABincomingStock_Click(object sender, EventArgs e)
        {
            UpdateConfirmedRestockInfo();
        }

        private void BtnMakeRequest_Click(object sender, EventArgs e)
        {

            string type = this.cmbType.Text.ToString();
            int idEmp = Convert.ToInt32(this.tbxEmployeeID.Text);
            string orderDate = this.dtpDateOrder.Value.ToString("dd/MM/yyyy");
            string orderDeliver = this.dtpDateDeliver.Value.ToString("dd/MM/yyyy");
            string name = this.tbxStockName.Text;
            int quantity = Convert.ToInt32(this.tbxStockQuantity.Text);
            string department = this.cmbDepartment.Text.ToString();

            if (type != " " && name != " " && quantity != 0 && orderDate != " " && orderDeliver != " "
                && idEmp != 0 && department != " ")
            {
             
                 DataAccess db = new DataAccess();
                 db.InsertRequest(idEmp, name, type, department, quantity, orderDate,orderDeliver );
            }
            UpdateRequestedStocks();
        }

        private void UpdateRequestedStocks()
        {
            DataAccess db = new DataAccess();
            incomingRestockRequests = db.GetAllRequests();
            foreach (DBRestockRequest rr in incomingRestockRequests)
            {
                restockID.Add(rr.GetID());
            }
            lbxRequestedItems.DataSource = incomingRestockRequests;
            lbxRequestedItems.DisplayMember = "FullInfo";
        }

        private void UpdateDepartamentInfo()
        {
            DataAccess db = new DataAccess();

            departaments = db.GetAllDepartaments();
            

            foreach (DBDepartament dBD in departaments)
            {
                cmbDepartment.Items.Add(dBD.GetName());
            }
        }

        //----------------------------------------Finish



    }
}
