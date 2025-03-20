using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Data.DTO;
using TMS.Data.Models;

namespace TMS.Data.Services.Interfaces
{
    public interface ISupervisorService
    {
        Task RegisterTyreSalesAsync(TyreSalesDTO tyreSalesDTO, int LogId);
        Task<IEnumerable<TyreSalesDTO>> GetAllSalesAsync();
        Task<bool> UpdateProdutionRecords(ProductionDTO productionDTO, int LogId);
        Task<List<ProductionDTO>> GetAllProductionRecordsAsync(int LogId);
    }
}
