using Media_Bazaar.LogicLayer.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media_Bazaar
{
    public class DepotWorkerManagment
    {
        DataAccess dataAccess = new DataAccess();

        public List<RestockRequestBase> GetIncomingRestockRequests()
        {
            return dataAccess.GetAllConfirmedRestock();
        }

        public List<RestockRequestBase> GetRejectedRestockRequests()
        {
            return dataAccess.GetAllRejectedRestock();
        }

        public List<DepartmentModel> GetDepartments()
        {
            return dataAccess.GetAllDepartaments();
        }

        List<Product> products = new List<Product>();
        List<RestockRequest> stocks = new List<RestockRequest>();

        public bool MakeRestockRequest(string idEmp, string name, string type, string department, string quantity, string orderDate, string orderDeliver)
        {
            if (!String.IsNullOrEmpty(idEmp) && !String.IsNullOrEmpty(name) && !String.IsNullOrEmpty(department) && !String.IsNullOrEmpty(quantity) && !String.IsNullOrEmpty(orderDeliver) && !String.IsNullOrEmpty(type))
            {
                dataAccess.InsertRequest(Convert.ToInt32(idEmp), name, type, department, Convert.ToInt32(quantity), orderDate, orderDeliver);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void MakeRequest(string idEmp, string name, string type, string department, string quantity, string orderDate, string orderDeliver)
        {
            if (!String.IsNullOrEmpty(idEmp) && !String.IsNullOrEmpty(name) && !String.IsNullOrEmpty(department) && !String.IsNullOrEmpty(quantity) && !String.IsNullOrEmpty(orderDeliver) && !String.IsNullOrEmpty(type))
            {
                dataAccess.InsertRequest(Convert.ToInt32(idEmp), name, type, department, Convert.ToInt32(quantity), orderDate, orderDeliver);
                
            }
        }

        public int GetProductID(string brand)
        {
            products = dataAccess.GetFromDBProductInfo(brand);
            foreach (Product p in products)
            {
                return p.id;
            }
            return -1;
        }

        public string GetProductBrand(string brand)
        {
            products = dataAccess.GetFromDBProductInfo(brand);
            foreach (Product p in products)
            {
                return p.Brand;
            }
            return null;
        }

        public string GetProductName(string brand)
        {
            products = dataAccess.GetFromDBProductInfo(brand);
            foreach (Product p in products)
            {
                return p.product_name;
            }
            return null;
        }

        public string GetProductCategory(string brand)
        {
            products = dataAccess.GetFromDBProductInfo(brand);
            foreach (Product p in products)
            {
                return p.Category;
            }
            return null;
        }

        public string GetProductDepartment(string brand)
        {
            stocks = dataAccess.GetFromDBRestockInfo(brand);
            foreach (RestockRequest r in stocks)
            {
                return r.Departament;
            }
            return null;
        }

        public int GetProductQuantity(string brand)
        {
            stocks = dataAccess.GetFromDBRestockInfo(brand);
            foreach (RestockRequest r in stocks)
            {
                return r.Quantity;
            }
            return -1;
        }

        public string GetStockNameById(int id)
        {
            return dataAccess.GetDBStockNameById(id);
        }

        public string GetStockTypeById(int id)
        {
            return dataAccess.GetDBStockTypeById(id);
        }

        public string GetDepartmentByStockId(int id)
        {
            return dataAccess.GetDBDepartmentByStockId(id);
        }

        public string GetStockQuantityById(int id)
        {
            return dataAccess.GetDBStockQuantityById(id);
        }

        public string GetStockOrderDateById(int id)
        {
            return dataAccess.GetDBStockOrderDateById(id);
        }

        public string GetStockDeliverDateById(int id)
        {
            return dataAccess.GetDBStockDeliverDateById(id);
        }

        public string GetStockStatusById(int id)
        {
            return dataAccess.GetDBStockStatusById(id);
        }

        public string GetEmployeeIdByStockId(int id)
        {
            return dataAccess.GetDBEmployeeIdByStockId(id);
        }

        public string GetDepotID()
        {
            return dataAccess.GetDepotID();
        }
    }
}
