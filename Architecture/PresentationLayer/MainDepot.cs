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
        private DepotWorkerManagment depotWorkerManagment = new DepotWorkerManagment();

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
            UpdateEmployeeIDInfo();
            UpdateAllConfirmedStockInfo();
            UpdateAllRejectedStockInfo();
        }

        private void UpdateConfirmedRestockInfo()
        {
            foreach (IRestockRequest rr in depotWorkerManagment.GetIncomingRestockRequests())
            {
                restockID.Add(rr.RequestID);
            }
            clbIncomingStock.DataSource = depotWorkerManagment.GetIncomingRestockRequests();
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
                        this.lblSID.Text = i.ToString();
                        this.lblSName.Text = depotWorkerManagment.GetStockNameById(i);
                        this.lblSType.Text = depotWorkerManagment.GetStockTypeById(i);
                        this.lblDepartment.Text = depotWorkerManagment.GetDepartmentByStockId(i);
                        this.lblQuantity.Text = depotWorkerManagment.GetStockQuantityById(i);
                        this.lblOrderDate.Text = depotWorkerManagment.GetStockOrderDateById(i);
                        this.lblDeliverDate.Text = depotWorkerManagment.GetStockDeliverDateById(i);
                        this.lblStatus.Text = depotWorkerManagment.GetStockStatusById(i);
                        this.lblEID.Text = depotWorkerManagment.GetEmployeeIdByStockId(i);
                    }
                }
            }
        }

        private void UpdateAllConfirmedStockInfo()
        {
            this.clbAllConfirmedRequests.Items.Clear();

            foreach (IRestockRequest dBr in depotWorkerManagment.GetIncomingRestockRequests())
            {
                this.clbAllConfirmedRequests.Items.Add(dBr.GetInfo());
            }
        }

        private void UpdateAllRejectedStockInfo()
        {
            this.lbxRejectedRequests.Items.Clear();

            foreach (IRestockRequest dBr in depotWorkerManagment.GetRejectedRestockRequests())
            {
                this.lbxRejectedRequests.Items.Add(dBr.GetInfo());
            }
        }

        private void btnViewStock_Click(object sender, EventArgs e)
        {
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
                        this.lblAllStockID.Text = i.ToString();
                        this.lblAllStockName.Text = depotWorkerManagment.GetStockNameById(i);
                        this.lblAllStockType.Text = depotWorkerManagment.GetStockTypeById(i);
                        this.lblAllStockDepartment.Text = depotWorkerManagment.GetDepartmentByStockId(i);
                        this.lblAllStockQuantity.Text = depotWorkerManagment.GetStockQuantityById(i);
                        this.lblAllStockOrderDate.Text = depotWorkerManagment.GetStockOrderDateById(i);
                        this.lblAllStockDeliverDate.Text = depotWorkerManagment.GetStockDeliverDateById(i);
                        this.lblAllStatus.Text = depotWorkerManagment.GetStockStatusById(i);
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
            string idEmp = "";
            string orderDate;
            string orderDeliver = "";
            string name = "";
            string quantity = "";
            string department = "";

            idEmp = tbxEmployeeID.Text;
            name = tbxStockName.Text;
            department = cmbDepartment.Text.ToString();
            quantity = tbxStockQuantity.Text;
            orderDeliver = dtpDateDeliver.Value.ToString("dd/MM/yyyy");
            orderDate = DateTime.Now.ToShortDateString();

            if (depotWorkerManagment.MakeRestockRequest(idEmp, name, type, department, quantity, orderDate, orderDeliver))
            {
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
            foreach (IDepartmentModel dBD in depotWorkerManagment.GetDepartments())
            {
                cmbDepartment.Items.Add(dBD.DepartamentName);
            }
        }

        private void UpdateEmployeeIDInfo()
        {
            this.tbxEmployeeID.Text = depotWorkerManagment.GetDepotID();
        }
    }
}
