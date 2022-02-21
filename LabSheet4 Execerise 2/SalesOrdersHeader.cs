using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabSheet4_Execerise_2
{
    public partial class SalesOrderHeader
    {
        public override string ToString()
        {
            return string.Format("{0}: {1} {2:c}",
                OrderDate.ToShortDateString(),
                SalesOrderID,
                TotalDue);
           
        }
    }
}
