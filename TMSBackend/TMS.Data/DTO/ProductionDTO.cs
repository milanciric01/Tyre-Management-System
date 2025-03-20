using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Data.Models;

namespace TMS.Data.DTO
{
    public class ProductionDTO
    {
        public int Id { get; set; }
        public string TyreCode { get; set; } // Added tyre code
        public int Quantity { get; set; } // Added quantity
        public DateTime ProductionDate { get; set; } // Added production date
        public string ProductionShift { get; set; } // Added production shift
        public string MachineNumber { get; set; } // Added machine number
        public int PerformedById { get; set; } // FK to User


    }
}
