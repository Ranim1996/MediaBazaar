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
using Media_Bazaar.LogicLayer.Products;
using Media_Bazaar.LogicLayer.Product;

namespace Media_Bazaar
{
    public partial class MainDepot : Form
    {
        private DepotWorkerManagment depotWorkerManagment = new DepotWorkerManagment();
        private DataAccess db = new DataAccess();

        List<int> restockID = new List<int>();
        List<Product> products = new List<Product>();
        List<RestockRequest> stocks = new List<RestockRequest>();

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
            UpdateProductsList();
        }

        private void UpdateProductsList()
        {
            this.clbProducts.DataSource = products;
            this.clbProducts.DisplayMember = "FullInfo";
        }

        private void UpdateConfirmedRestockInfo()
        {
            foreach (RestockRequestBase rr in depotWorkerManagment.GetIncomingRestockRequests())
            {
                restockID.Add(rr.RequestID);
            }
            
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

        private void UpdateAllConfirmedStockInfo()
        {
            this.clbAllConfirmedRequests.Items.Clear();

            foreach (RestockRequestBase dBr in depotWorkerManagment.GetIncomingRestockRequests())
            {
                this.clbAllConfirmedRequests.Items.Add(dBr.FullInfo);
            }
        }

        private void UpdateAllRejectedStockInfo()
        {
            this.lbxRejectedRequests.Items.Clear();

            foreach (RestockRequestBase dBr in depotWorkerManagment.GetRejectedRestockRequests())
            {
                this.lbxRejectedRequests.Items.Add(dBr.FullInfo);
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
            //need to be fixed.


            //string type = "";
            //string idEmp = "";
            //string orderDate;
            //string orderDeliver = "";
            //string name = "";
            //string quantity = "";
            //string department = "";

            //idEmp = this.tbxEmployeeID.Text;
            //name = this.tbxProductName.Text;
            //department = this.cmbDepartment.Text.ToString();
            //quantity = this.tbxStockQuantity.Text;
            //orderDeliver = this.dtpDateDeliver.Value.ToString("dd/MM/yyyy");
            //orderDate = DateTime.Now.ToShortDateString();

            //if (tbxEmployeeID.Text != " " && tbxProductName.Text != " " && tbxStockQuantity.Text != "" && dtpDateDeliver.Value != null)
            //{
            //    depotWorkerManagment.MakeRequest(idEmp, name, type, department, quantity, orderDate, orderDeliver);
            //    MessageBox.Show("Request is sent.");
            //}
            //else
            //{
            //    MessageBox.Show("Something went wrong!");
            //}

            //if (depotWorkerManagment.MakeRestockRequest(idEmp, name, type, department, quantity, orderDate, orderDeliver))
            //{
            //    MessageBox.Show("The request is sent to the administration.");
            //    clearBoxes1();
            //}
            //else
            //{
            //    MessageBox.Show("Fill in all fields correctly!");
            //}
        }

        private void clearBoxes1()
        {
            this.cmbProductCategory.Text = " ";
            this.tbxProductName.Text = " ";
            this.tbxStockQuantity.Text = " ";
            this.cmbDepartment.Text = " ";
        }

        private void UpdateDepartamentInfo()
        {
            foreach (DepartmentModel dBD in depotWorkerManagment.GetDepartments())
            {
                cmbDepartment.Items.Add(dBD.DepartamentName);
            }
        }

        private void UpdateEmployeeIDInfo()
        {
            this.tbxEmployeeID.Text = depotWorkerManagment.GetDepotID();
        }

        private void BtnSearchForProduct_Click(object sender, EventArgs e)
        {
            products = db.GetFromDBProductInfo(this.cmbBrand.Text);
            if (products.Count == 0)
            {
                MessageBox.Show("We do not have such Brand in our stock.");
                this.cmbBrand.Text = "";
            }
            else
            {
                UpdateProductsList();
                UpdateDetails(this.cmbBrand.Text);
                this.clbProducts.Visible = true;
                this.btnViewProductsDetails.Visible = true;
            }

        }

        private void UpdateDetails(string brand)
        {
            this.lblProductID.Text = depotWorkerManagment.GetProductID(brand).ToString();
            this.lblProductBrand.Text = depotWorkerManagment.GetProductBrand(brand);
            this.lblProductCategory.Text = depotWorkerManagment.GetProductCategory(brand);
            this.lblProductName.Text = depotWorkerManagment.GetProductName(brand);
            this.lblSearchDepartment.Text = depotWorkerManagment.GetProductDepartment(brand);
            this.lblSearchQuantity.Text = depotWorkerManagment.GetProductQuantity(brand).ToString();
        }

        private void BtnViewProductsDetails_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = this.tabIncomingStockDetails;
        }
    }
}
