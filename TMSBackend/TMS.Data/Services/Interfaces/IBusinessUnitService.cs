using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Data.DTO;

namespace TMS.Data.Services.Interfaces
{
    public interface IBusinessUnitService
    {
        Task<IEnumerable<ProductionByDayDTO>> GetProductionByDayServiceAsync(int LogId);
        Task<IEnumerable<ProductionByShiftDTO>> GetProductionByShiftServiceASync(int LogId);
        Task<IEnumerable<ProductionByMachineDTO>> GetProductionByMachineServiceAsync(int LogId);
        Task<IEnumerable<ProductionByOperatorDTO>> GetProductionByOperatorServiceASync(int LogId);
        Task<IEnumerable<StockBalanceDTO>> GetStockBalanceServiceAsync(int LogId);
    }
}
