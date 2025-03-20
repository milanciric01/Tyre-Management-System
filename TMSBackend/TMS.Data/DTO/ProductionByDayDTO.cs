using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Data.DTO
{
    public class ProductionByDayDTO
    {
        public DateTime ProductionDate { get; set; }

        public int TotalProduction { get; set; }
    }
}
