using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Data.Context;
using TMS.Data.DTO;
using TMS.Data.Interfaces;
using TMS.Data.Models;

namespace TMS.Data.Repositories
{
    public class TyreSalesRepository : ITyreSalesRepository
    {
        private readonly TMSContext _db;
        public TyreSalesRepository(TMSContext db)
        {
            _db = db;
        }

        public async Task addTyreSalesAsync(TyreSales tyreSales)
        {
            await _db.AddAsync(tyreSales); 
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<TyreSalesDTO>> GetAllSales()
        {
            var sales = await _db.TyreSales
        .Include(ts => ts.ReferenceProduction)
        .ToListAsync();

            return sales.Select(ts => new TyreSalesDTO
            {
                Id = ts.Id,
                TyreName = ts.TyreName,
                QuantitySold = ts.QuantitySold,
                UnitOfMeasure = ts.UnitOfMeasure,
                Price = ts.Price,
                DateOfSale = ts.DateOfSale,
                ReferenceProductionId = ts.ReferenceProductionId,
                DestinationMarket = ts.DestinationMarket,
                PurchasingCompany = ts.PurchasingCompany
            });
        }

        



    }
}
