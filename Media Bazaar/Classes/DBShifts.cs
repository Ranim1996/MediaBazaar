using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Media_Bazaar.Classes
{
    public class DBShifts
    {
        //fields
        public string morningShift { get; set; }
        public int afternoonShift { get; set; }
        public string eveningShift { get; set; }

        //method
        public string FullInfo
        {
            get
            {
                return "Morning Shift: " +this.morningShift + " Afternoon Shift: " + this.afternoonShift + 
                    " Evening Shift: "+this.eveningShift;
            }
        }
    }
}
