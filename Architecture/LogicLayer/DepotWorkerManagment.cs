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
