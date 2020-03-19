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
            UpdateEmployeeIDInfo();
            UpdateAllConfirmedStockInfo();
            UpdateAllRejectedStockInfo();
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
            DataAccess db = new DataAccess();
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
            DataAccess db = new DataAccess();

            incomingRestockRequests = db.GetAllConfirmedRestock();

            foreach (DBRestockRequest dBr in incomingRestockRequests)
            {
                this.clbAllConfirmedRequests.Items.Add(dBr.GetInfo());
            }
        }

        private void UpdateAllRejectedStockInfo()
        {
            this.lbxRejectedRequests.Items.Clear();
            DataAccess db = new DataAccess();

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
            DBRestockRequest temp = new DBRestockRequest();
            DataAccess db = new DataAccess();

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
            DataAccess db = new DataAccess();

            string type = "";
            int idEmp = -1;
            string orderDate ;
            string orderDeliver = "";
            string name = "";
            int quantity = -1;
            string department = "";

            if (tbxEmployeeID.Text != " " && tbxStockName.Text != " " && tbxStockQuantity.Text != ""  && dtpDateDeliver.Value != null)
            {
                idEmp = Convert.ToInt32(tbxEmployeeID.Text);
                name = tbxStockName.Text;
                department = this.cmbDepartment.Text.ToString();
                quantity = Convert.ToInt32(this.tbxStockQuantity.Text);
                orderDeliver = this.dtpDateDeliver.Value.ToString("dd/MM/yyyy");
                type = this.cmbType.Text.ToString();
                orderDate = DateTime.Now.ToShortDateString();
                db.InsertRequest(idEmp, name, type, department, quantity, orderDate,orderDeliver );
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
            DataAccess db = new DataAccess();

            departaments = db.GetAllDepartaments();
            

            foreach (DBDepartament dBD in departaments)
            {
                cmbDepartment.Items.Add(dBD.GetName());
            }
        }

        private void UpdateEmployeeIDInfo ()
        {
            /*DataAccess db = new DataAccess();

            employees = db.GetAllEmployees();

            foreach (DBEmployee dBE in employees)
            {
                cmbEmployeeID.Items.Add(dBE.GetID());
            }*/

            DataAccess db = new DataAccess();
            this.tbxEmployeeID.Text = db.GetDepotID();
        }

        //private void BfbtnMakeRequestForExistingStock_Click(object sender, EventArgs e)
        //{
        //    int idStock = Convert.ToInt32(this.cmbExistStockID.Text.ToString());
        //    int idEmp = Convert.ToInt32(this.cmbExistEmpID.Text.ToString());
        //    string name = this.tbxExistName.Text;
        //    string type = this.tbxExistType.Text;
        //    string department = this.tbxExistDepartment.Text;
        //    string orderDate = DateTime.Now.ToShortDateString();
        //    string orderDeliver = this.dtpDateDeliver.Value.ToString("dd/MM/yyyy");
        //    int quantity = Convert.ToInt32(this.tbcExistQuantity.Text);

        //    if (quantity != 0 && orderDate != " " && orderDeliver != " " && idEmp != 0 )
        //    {
        //        DataAccess db = new DataAccess();
        //        db.InsertRequestForAnExistingstock(idStock, idEmp, name, type, department,quantity, orderDate, orderDeliver);
        //        MessageBox.Show("The request is sent to the administration.");
        //        clearBoxes2();
        //    }
        //}

        //private DBRestockRequest GetNameByID (int id)
        //{
        //    DataAccess db = new DataAccess();
        //    incomingRestockRequests = db.GetAllAvailableStocks();

        //    for (int i = 0; i < incomingRestockRequests.Count; i++)
        //    {
        //        if (incomingRestockRequests[i].GetID() == id)
        //        {
        //            return incomingRestockRequests[i];
        //        }
        //    }
        //    return null;
        //}

        //private void CmbExistStockID_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    DataAccess db = new DataAccess();
        //    if (this.cmbExistStockID.Text.ToString() != " ")
        //    {
        //        int stockID = Convert.ToInt32(this.cmbExistStockID.Text);
        //        GetNameByID(stockID);
        //        this.tbxExistName.Text = db.GetDBStockNameById(stockID);
        //        this.tbxExistType.Text = db.GetDBStockTypeById(stockID);
        //        this.tbxExistDepartment.Text = db.GetDBDepartmentByStockId(stockID);
        //    }
        //}
        //private void clearBoxes2 ()
        //{
        //    this.cmbExistStockID.Text = " ";
        //    this.cmbExistEmpID.Text = " ";
        //    this.tbcExistQuantity.Text = " ";
        //}

        //private void UpdateStockIDInfo()
        //{
        //    DataAccess db = new DataAccess();

        //    incomingRestockRequests = db.GetAllAvailableStocks();

        //    foreach (DBRestockRequest dBR in incomingRestockRequests)
        //    {
        //        cmbExistStockID.Items.Add(dBR.GetID());
        //    }
        //}

        //private void UpdateEmployeeIDInfoForAnExistingStock()
        //{
        //    DataAccess db = new DataAccess();

        //    employees = db.GetAllEmployees();

        //    foreach (DBEmployee dBE in employees)
        //    {
        //        cmbExistEmpID.Items.Add(dBE.GetID());
        //    }
        //}

        //----------------------------------------Finish



    }
}
