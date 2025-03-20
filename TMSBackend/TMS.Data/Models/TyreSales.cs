using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Data.Models
{
    public class TyreSales
    {
        public int Id { get; set; }
        public string TyreName { get; set; }
        public int QuantitySold { get; set; }
        public string UnitOfMeasure { get; set; }  
        public decimal Price { get; set; }
        public DateTime DateOfSale { get; set; }
        public int ReferenceProductionId { get; set; }  // Foreign key to TyreProduction
        public string DestinationMarket { get; set; }
        public string PurchasingCompany { get; set; }

        // Navigation properties
        public TyreProduction ReferenceProduction { get; set; }  // Relationship with TyreProduction
    }   
}
