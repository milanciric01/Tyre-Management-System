using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Data.Models;

namespace TMS.Data.DTO
{
    public class TyreSalesDTO
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
    }
}
