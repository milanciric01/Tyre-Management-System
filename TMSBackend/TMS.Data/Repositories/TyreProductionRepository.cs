using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Data.Context;
using TMS.Data.DTO;
using TMS.Data.Interfaces;

namespace TMS.Data.Repositories
{
    public class TyreProductionRepository : ITyreProductionRepository
    {
        private readonly TMSContext _db;
        public TyreProductionRepository(TMSContext db)
        {
            _db = db;          
        }


        public async Task<IEnumerable<ProductionByDayDTO>> GetProductionByDayAsync()
        {
            return await _db.ProductionByDay.FromSqlRaw("EXEC GetProductionByDay").ToListAsync();
        } 

        public async Task<IEnumerable<ProductionByShiftDTO>> GetProductionByShiftAsync()
        {
            return await _db.ProductionByShift.FromSqlRaw("EXEC GetProductionByShift").ToListAsync();
        }

        public async Task<IEnumerable<ProductionByMachineDTO>> GetProductionByMachinesAsync()
        {
            return await _db.ProductionByMachine.FromSqlRaw("EXEC GetProductionByMachine").ToListAsync();
        }

        public async Task<IEnumerable<ProductionByOperatorDTO>> GetProductionByOperatorAsync()
        {
            return await _db.ProductionByOperator.FromSqlRaw("EXEC GetProductionByOperator").ToListAsync();
        }

        public async Task<IEnumerable<StockBalanceDTO>> GetStockBalanceASync()
        {
            return await _db.StockBalance.FromSqlRaw("EXEC GetStockBalance").ToListAsync();
        }





    }
}
