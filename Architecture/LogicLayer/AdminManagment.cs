using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Media_Bazaar
{
    public class AdminManagment
    {
        private DataAccess dataAccess = new DataAccess();
        private SendEmail sendEmail = new SendEmail();
        private IEmployeeModel employeeModel;

        public string CreateNewProfile(string fName, string lName, string dateOfBirth, string email, string phoneNr, string nationality, string pos)
        {
            if (!String.IsNullOrEmpty(fName) && !String.IsNullOrEmpty(lName) && !String.IsNullOrEmpty(dateOfBirth) && !String.IsNullOrEmpty(email) && !String.IsNullOrEmpty(phoneNr) && !String.IsNullOrEmpty(nationality))
            {
                return AddEmpl(fName, lName, dateOfBirth, email, phoneNr, nationality, pos);
            }
            else
            {
                return null;
            }
        }

        public string AddEmpl(string fName, string lName, string dateOfBirth, string email, string phoneNr, string nationality, string pos)
        {         
            if(pos== "ADMINISTRATOR")
            {
                employeeModel = new AdministratorModel {FirstName=fName, LastName=lName,DateOfBirth=dateOfBirth,Email=email,PhoneNumber=phoneNr,Nationality=nationality };
            }
            else if(pos== "MANAGER")
            {
                employeeModel = new ManagerModel { FirstName = fName, LastName = lName, DateOfBirth = dateOfBirth, Email = email, PhoneNumber = phoneNr, Nationality = nationality };
            }
            else if (pos == "DEPOTWORKER")
            {
                employeeModel = new DepotWorkerModel { FirstName = fName, LastName = lName, DateOfBirth = dateOfBirth, Email = email, PhoneNumber = phoneNr, Nationality = nationality };
            }
            else if (pos == "EMPLOYEE")
            {
                employeeModel = new EmployeeModel { FirstName = fName, LastName = lName, DateOfBirth = dateOfBirth, Email = email, PhoneNumber = phoneNr, Nationality = nationality };
            }

            dataAccess.InsertEmployee(fName, lName, dateOfBirth, email, phoneNr, nationality, employeeModel.Position, employeeModel.Username, employeeModel.Password);

            int employeeID = dataAccess.GetIdOfEmployeeByName(fName, lName);
            string employeeCredentials = "";
            employeeCredentials = $"{employeeID.ToString()} \r\n {employeeModel.Username} \r\n {employeeModel.Password}";

            sendEmail.Send(email, employeeModel.Username, employeeModel.Password);
            return employeeCredentials;
        }    

        public bool FireEmployee(string ExtraInformationForFire, int id, string emplID)
        {
            if (String.IsNullOrEmpty(ExtraInformationForFire))
            {
                return false;
            }
            else
            {
                if (emplID.Contains($"ID:{id}"))
                {
                    dataAccess.FireEmployeeByID(ExtraInformationForFire, id);
                    return true;
                }
                return false;
            }
        }

        public bool AssignEmployeeToDepartment(int id, string departament, string emplID)
        {
            if (emplID.Contains($"ID:{id}"))
            {
                dataAccess.AssignEmployeeToDepartament(id, departament);
                return true;
            }
            return false;
        }

        public bool ConfirmRequest(int id,string req)
        {
            if (req.Contains($"ID:{id}"))
            {
                dataAccess.ConfirmRequest(id);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool RejectRequest(int id, string req)
        {
            if (req.Contains($"ID:{id}"))
            {
                dataAccess.RejectRequest(id);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CreateDepartment(string DepartmentName,string minNr, string MaxNr)
        {
            if (!String.IsNullOrEmpty(DepartmentName) && !String.IsNullOrEmpty(minNr) && !String.IsNullOrEmpty(MaxNr))
            {
                dataAccess.InsertDepartament(DepartmentName, Convert.ToInt32(minNr), Convert.ToInt32(MaxNr));
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<IEmployeeModel> GetNotFiredEmployees()
        {
            return dataAccess.GetNotFiredEmployees();
        }

        public List<IDepartmentModel> GetAllDepartaments()
        {
            return dataAccess.GetAllDepartaments();
        }

        public List<IRestockRequest> GetAllRestockRequests()
        {
            return dataAccess.GetAllRequests();
        }

        public List<IEmails> GetEmails()
        {
            return dataAccess.GetEmails();
        }

        public string GetFirstNameOfEmployeeById(int id)
        {
            return dataAccess.GetFirstNameOfEmployeeById(id);
        }

        public void EmailStatusRead(int emailid)
        {
            dataAccess.EmailStatusRead(emailid);
        }

        public void DeleteEmailById(int id)
        {
            dataAccess.DeleteEmailById(id);
        }
    }
}