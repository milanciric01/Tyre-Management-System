using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.Data.DTO;
using TMS.Data.Interfaces;
using TMS.Data.Models;
using TMS.Data.Services.Interfaces;

namespace TMS.Data.Services
{
    public class ProductionService : IProductionService
    {
        private readonly IProductionRecordRepository _productionRecordRepository;
        private readonly IMapper _mapper;
        private readonly ILogRepository _logRepository;

        public ProductionService(IProductionRecordRepository productionRecordRepository,IMapper mapper,ILogRepository logRepository)
        {
            _productionRecordRepository = productionRecordRepository;
            _mapper = mapper;
            _logRepository = logRepository;
        }


        public async Task RegisterProductionAsync(ProductionDTO productionDTO,int LogId)
        {
            var productionRecord = _mapper.Map<ProductionRecord>(productionDTO);

            productionRecord.ProductionDate = DateTime.UtcNow;
            productionRecord.PerformedById = productionDTO.PerformedById;

            await _productionRecordRepository.AddAsync(productionRecord);
            await _logRepository.AddLog(new LogDTO { UserId = LogId, Action = "Register Production", ActionDateTime = DateTime.UtcNow });

            
        }

        public async Task<IEnumerable<ProductionRecord>> GetProductionRecordsByOpId(int operatorId,int LogId)
        {
            await _logRepository.AddLog(new LogDTO { UserId = LogId, Action = "Production History", ActionDateTime = DateTime.UtcNow });
            return await _productionRecordRepository.GetByOperatorIdAsync(operatorId);

        }

        
    }
}
