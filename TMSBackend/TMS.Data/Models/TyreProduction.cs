using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Data.Enums;

namespace TMS.Data.Models
{
    public class TyreProduction
    {
        public int Id { get; set; }
        public string TyreCode { get; set; }
        public int Quantity { get; set; }
        public int OperatorId { get; set; }  // Foreign key to the User entity
        public DateTime ProductionDate { get; set; }
        public ProductionShift ProductionShift { get; set; }
        public string MachineNumber { get; set; }

        // Navigation properties
        public User Operator { get; set; }  // Relationship with User

        public ICollection<TyreSales> TyreSales { get; set; }
    }   
}
