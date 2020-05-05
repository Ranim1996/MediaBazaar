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
        List<DBProduct> products = new List<DBProduct>();
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
            UpdateProductsList();
            Combo();
        }

        private void Combo()
        {
            this.cmbBrand.Items.Add(ProductBrand.Amazon);
            this.cmbBrand.Items.Add(ProductBrand.Apple);
            this.cmbBrand.Items.Add(ProductBrand.Asus);
            this.cmbBrand.Items.Add(ProductBrand.HUAWEI);
            this.cmbBrand.Items.Add(ProductBrand.Microsoft);
            this.cmbBrand.Items.Add(ProductBrand.MSI);
            this.cmbBrand.Items.Add(ProductBrand.Razer);
            this.cmbBrand.Items.Add(ProductBrand.Samsung);
        }


        private void UpdateProductsList()
        {
            this.clbProducts.DataSource = products;
            this.clbProducts.DisplayMember = "FullInfo";
        }

        private void UpdateConfirmedRestockInfo()
        {
            // only confirmed requests will shown here

            incomingRestockRequests = db.GetAllConfirmedRestock();
            foreach (DBRestockRequest rr in incomingRestockRequests)
            {
                restockID.Add(rr.GetID());
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

        private void btnCheckIncomingStock_Click(object sender, EventArgs e)
        {

        }

        private void BtnSearchForProduct_Click(object sender, EventArgs e)
        {
            if (this.cmbBrand.Text != null)
            {
                products = db.GetDBProductInfo(this.cmbBrand.Text);
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
            else
            {
                MessageBox.Show("Type the brand first!");
            }
            
        }

        private void UpdateDetails(string product)
        {

            products = db.GetDBProductInfo(product);
            foreach (DBProduct p in products)
            {
                this.lblProductID.Text = p.id.ToString();
                this.lblProductBrand.Text = p.Brand;
                this.lblProductCategory.Text = p.Category;
                this.lblProductName.Text = p.product_name;
            }
        }

        private void BtnViewProductsDetails_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = this.tabIncomingStockDetails;
        }
    }
}
