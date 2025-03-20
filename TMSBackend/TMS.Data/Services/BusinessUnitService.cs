using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Data.DTO;
using TMS.Data.Interfaces;
using TMS.Data.Services.Interfaces;

namespace TMS.Data.Services
{
    public class BusinessUnitService : IBusinessUnitService
    {
        private readonly ILogRepository _logRepository;
        private readonly ITyreProductionRepository _tyreProductionRep;
        public BusinessUnitService(ITyreProductionRepository tyreProductionRep, ILogRepository logRepository)
        {
            _tyreProductionRep = tyreProductionRep;
            _logRepository = logRepository;
        }

        public async Task<IEnumerable<ProductionByDayDTO>> GetProductionByDayServiceAsync(int LogId)
        {
            await _logRepository.AddLog(new LogDTO { UserId = LogId,Action = "Production by Day",ActionDateTime = DateTime.UtcNow });
            return await _tyreProductionRep.GetProductionByDayAsync();
        }

        public async Task<IEnumerable<ProductionByShiftDTO>> GetProductionByShiftServiceASync(int LogId)
        {
            await _logRepository.AddLog(new LogDTO { UserId = LogId, Action = "Production by shift", ActionDateTime = DateTime.UtcNow });
            return await _tyreProductionRep.GetProductionByShiftAsync();
        }

        public async Task<IEnumerable<ProductionByMachineDTO>> GetProductionByMachineServiceAsync(int LogId)
        {
            await _logRepository.AddLog(new LogDTO { UserId = LogId, Action = "Production by machine", ActionDateTime = DateTime.UtcNow });
            return await _tyreProductionRep.GetProductionByMachinesAsync();
        }

        public async Task<IEnumerable<ProductionByOperatorDTO>> GetProductionByOperatorServiceASync(int LogId)
        {
            await _logRepository.AddLog(new LogDTO { UserId = LogId, Action = "Production by Operator", ActionDateTime = DateTime.UtcNow });
            return await _tyreProductionRep.GetProductionByOperatorAsync();
        }

        public async Task<IEnumerable<StockBalanceDTO>> GetStockBalanceServiceAsync(int LogId)
        {
            await _logRepository.AddLog(new LogDTO { UserId = LogId, Action = "Stock Balance", ActionDateTime = DateTime.UtcNow });
            return await _tyreProductionRep.GetStockBalanceASync();
        }

    }
}
