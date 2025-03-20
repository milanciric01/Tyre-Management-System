using AutoMapper;
using TMS.Data.DTO;
using TMS.Data.Interfaces;
using TMS.Data.Models;
using TMS.Data.Repositories;
using TMS.Data.Services.Interfaces;

namespace TMS.Data.Services
{
    public class SupervisorService : ISupervisorService
    {
        private readonly ITyreSalesRepository _tyreSalesRepository;
        private readonly IProductionRecordRepository _productionRecordRepository;
        private readonly IMapper _mapper;
        private readonly ILogRepository _logRepository;
        public SupervisorService(ITyreSalesRepository tyreSalesRepository, IMapper mapper,IProductionRecordRepository productionRecordRepository, ILogRepository logRepository)
        {
            _tyreSalesRepository = tyreSalesRepository;
            _mapper = mapper;
            _productionRecordRepository = productionRecordRepository;
            _logRepository = logRepository;
        }

        public async Task RegisterTyreSalesAsync(TyreSalesDTO tyreSalesDTO,int LogId)
        {
            var tyreSalesRecord = _mapper.Map<TyreSales>(tyreSalesDTO);
            tyreSalesRecord.DateOfSale = DateTime.UtcNow;
            tyreSalesRecord.ReferenceProductionId = tyreSalesDTO.ReferenceProductionId;
            await _logRepository.AddLog(new LogDTO { UserId = LogId,Action="Register Tyre Sales",ActionDateTime=DateTime.UtcNow });
            await _tyreSalesRepository.addTyreSalesAsync(tyreSalesRecord);
        }

        public async Task<IEnumerable<TyreSalesDTO>> GetAllSalesAsync()
        {
            return await _tyreSalesRepository.GetAllSales();
        }

        public async Task<bool> UpdateProdutionRecords(ProductionDTO productionDTO,int LogId)
        {
            ProductionDTO newProductionDTO = _productionRecordRepository.UpdateRecord(productionDTO);
            if(newProductionDTO == null)
            {
                throw new Exception("Failed to update record");
            }
            await _logRepository.AddLog(new LogDTO { UserId = LogId,Action = "update records",ActionDateTime = DateTime.UtcNow });
            return true;
        }

        public async Task<List<ProductionDTO>> GetAllProductionRecordsAsync(int LogId)
        {
            List<ProductionDTO> productionDTO = _productionRecordRepository.GetAll();
            if(productionDTO == null)
            {
                throw new InvalidOperationException("Failed to get all production records");
            }
            await _logRepository.AddLog(new LogDTO { UserId = LogId, Action = "Get All production records", ActionDateTime = DateTime.UtcNow });
            return productionDTO;
        }
    }
}
