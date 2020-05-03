using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media_Bazaar
{
    public class Account : IAccounts
    {
        public AutoGeneratePassword generatePassword { get; set; } = new AutoGeneratePassword();

        public EmployeeModel Create(IEmployeeModel person)
        {
            EmployeeModel output = new EmployeeModel();

            output.FirstName = person.FirstName;
            output.LastName = person.LastName;
            output.Username = $"{person.FirstName.ToLower()}.{person.LastName}@mediabazaar";
            output.Password = generatePassword.autoGeneratePassword();
            return output;
        }

       
    }
}