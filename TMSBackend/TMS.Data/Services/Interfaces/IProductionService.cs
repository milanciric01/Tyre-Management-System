using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Data.DTO;
using TMS.Data.Models;

namespace TMS.Data.Services.Interfaces
{
    public interface IProductionService
    {
        Task RegisterProductionAsync(ProductionDTO productionDTO,int LogId);
        Task<IEnumerable<ProductionRecord>> GetProductionRecordsByOpId(int operatorId,int LogId);
    }
}
