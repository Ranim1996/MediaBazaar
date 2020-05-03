using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media_Bazaar
{
    public class AdministratorAccount:IAccounts
    {
        public AutoGeneratePassword generatePassword { get; set; } = new AutoGeneratePassword();

        public EmployeeModel Create(IPersonModel person)
        {
            EmployeeModel output = new EmployeeModel();

            output.FirstName = person.FirstName;
            output.LastName = person.LastName;

            output.Username = $"{person.FirstName.ToLower()}.{person.LastName}.administrator@mediabazaar";
            output.Password = generatePassword.autoGeneratePassword();

            output.IsAdministrator = true;
           
            return output;
        }
    }
}
