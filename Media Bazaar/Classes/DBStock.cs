using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media_Bazaar.Classes
{
    public class DBStock
    {
        //property
        public string StockType { get; set; }
        public int quantity { get; set; }

        public string FullInfo
        {
            get
            {
                return $"Stock type:{StockType} , quantity is : {quantity})";
            }
        }

        // method

        public string GetType()
        {
            return StockType;
        }
    }
}
