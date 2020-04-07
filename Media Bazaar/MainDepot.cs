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
        List<DBEmployee> employees = new List<DBEmployee>();
        List<int> restockID = new List<int>();
        List<int> employeeID = new List<int>();
        DataAccess db = null;

        public MainDepot()
        {
            InitializeComponent();
            db = new DataAccess();
        }

        private void MainDepot_Load(object sender, EventArgs e)
        {
            tabControl1.Appearance = TabAppearance.FlatButtons;
            tabControl1.ItemSize = new Size(0, 1);
            tabControl1.SizeMode = TabSizeMode.Fixed;
            tabControl1.TabPages[0].BackColor = Color.FromArgb(116, 208, 252);
            UpdateConfirmedRestockInfo();
            UpdateDepartamentInfo();
            UpdateEmployeeIDInfo();
            UpdateAllConfirmedStockInfo();
            UpdateAllRejectedStockInfo();
        }

        private void UpdateConfirmedRestockInfo()
        {
            // only confirmed requests will shown here

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


            if (this.clbIncomingStock.CheckedItems.Count == 0)
            {
                MessageBox.Show("Please select a stock!");
            }
            else
            {
                tabControl1.SelectedTab = tabIncomingStockDetails;
                UpdateStockDetails();
                while (clbIncomingStock.CheckedIndices.Count > 0)
                {
                    clbIncomingStock.SetItemChecked(clbIncomingStock.CheckedIndices[0], false);
                }
            }
        }

        private void UpdateStockDetails()
        {
            foreach (int i in restockID)
            {
                if (this.clbIncomingStock.SelectedItem != null)
                {
                    string stock = this.clbIncomingStock.GetItemText(this.clbIncomingStock.SelectedItem);
                    if (stock.Contains($"ID:{i}"))
                    {
                        this.lblSID.Text = db.GetDBStockIDById(i);
                        this.lblSName.Text = db.GetDBStockNameById(i);
                        this.lblSType.Text = db.GetDBStockTypeById(i);
                        this.lblDepartment.Text = db.GetDBDepartmentByStockId(i);
                        this.lblQuantity.Text = db.GetDBStockQuantityById(i);
                        this.lblOrderDate.Text = db.GetDBStockOrderDateById(i);
                        this.lblDeliverDate.Text = db.GetDBStockDeliverDateById(i);
                        this.lblStatus.Text = db.GetDBStockStatusById(i);
                        this.lblEID.Text = db.GetDBEmployeeIdByStockId(i);
                    }
                }
            }
        }

        private void UpdateAllConfirmedStockInfo()
        {
            this.clbAllConfirmedRequests.Items.Clear();

            incomingRestockRequests = db.GetAllConfirmedRestock();

            foreach (DBRestockRequest dBr in incomingRestockRequests)
            {
                this.clbAllConfirmedRequests.Items.Add(dBr.GetInfo());
            }
        }

        private void UpdateAllRejectedStockInfo()
        {
            this.lbxRejectedRequests.Items.Clear();

            incomingRestockRequests = db.GetAllRejectedRestock();

            foreach (DBRestockRequest dBr in incomingRestockRequests)
            {
                this.lbxRejectedRequests.Items.Add(dBr.GetInfo());
            }
        }

        private void btnViewStock_Click(object sender, EventArgs e)
        {
            //INFORMATION about stock MUST be parsed in this method

            if (this.clbAllConfirmedRequests.CheckedItems.Count == 0)
            {
                MessageBox.Show("Please select a confirmed stock!");
            }
            else
            {
                tabControl1.SelectedTab = tabInfoStock;
                UpdateAvailableStockDetails();
                while (clbAllConfirmedRequests.CheckedIndices.Count > 0)
                {
                    clbAllConfirmedRequests.SetItemChecked(clbAllConfirmedRequests.CheckedIndices[0], false);
                }
            }
        }

        private void UpdateAvailableStockDetails()
        {

            foreach (int i in restockID)
            {
                if (this.clbAllConfirmedRequests.SelectedItem != null)
                {
                    string stock = this.clbAllConfirmedRequests.GetItemText(this.clbAllConfirmedRequests.SelectedItem);

                    if (stock.Contains($"ID:{i}"))
                    {
                        this.lblAllStockID.Text = db.GetDBStockIDById(i);
                        this.lblAllStockName.Text = db.GetDBStockNameById(i);
                        this.lblAllStockType.Text = db.GetDBStockTypeById(i);
                        this.lblAllStockDepartment.Text = db.GetDBDepartmentByStockId(i);
                        this.lblAllStockQuantity.Text = db.GetDBStockQuantityById(i);
                        this.lblAllStockOrderDate.Text = db.GetDBStockOrderDateById(i);
                        this.lblAllStockDeliverDate.Text = db.GetDBStockDeliverDateById(i);
                        this.lblAllStatus.Text = db.GetDBStockStatusById(i);
                    }
                }
            }
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

            string type = "";
            int idEmp = -1;
            string orderDate;
            string orderDeliver = "";
            string name = "";
            int quantity = -1;
            string department = "";

            if (tbxEmployeeID.Text != " " && tbxStockName.Text != " " && tbxStockQuantity.Text != "" && dtpDateDeliver.Value != null)
            {
                idEmp = Convert.ToInt32(tbxEmployeeID.Text);
                name = tbxStockName.Text;
                department = this.cmbDepartment.Text.ToString();
                quantity = Convert.ToInt32(this.tbxStockQuantity.Text);
                orderDeliver = this.dtpDateDeliver.Value.ToString("dd/MM/yyyy");
                type = this.cmbType.Text.ToString();
                orderDate = DateTime.Now.ToShortDateString();
                db.InsertRequest(idEmp, name, type, department, quantity, orderDate, orderDeliver);
                MessageBox.Show("The request is sent to the administration.");
                clearBoxes1();
            }
            else
            {
                MessageBox.Show("Fill in all fields correctly!");
            }
        }

        private void clearBoxes1()
        {
            this.cmbType.Text = " ";
            this.tbxStockName.Text = " ";
            this.tbxStockQuantity.Text = " ";
            this.cmbDepartment.Text = " ";
        }

        private void UpdateDepartamentInfo()
        {

            departaments = db.GetAllDepartaments();


            foreach (DBDepartament dBD in departaments)
            {
                cmbDepartment.Items.Add(dBD.GetName());
            }
        }

        private void UpdateEmployeeIDInfo()
        {
            this.tbxEmployeeID.Text = db.GetDepotID();
        }


    }
}
