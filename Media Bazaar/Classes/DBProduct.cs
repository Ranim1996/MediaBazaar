using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media_Bazaar.Classes
{
    public class DBProduct
    {

        //Properties
        public int id { get; set; }
        public string product_name { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }

        //methods

        public string FullInfo
        {
            get
            {
                return $"ID: {id} Name: {product_name} Category: {Category} Brand: {Brand} ";

            }
        }
        public int GetProductID() // return product id
        {
            return id;
        }
    }
}
