using AutoMapper;
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
    public class ProductionRecordRepository : IProductionRecordRepository
    {
        private readonly TMSContext _db;
        private readonly IMapper _mapper;

        public ProductionRecordRepository(TMSContext db,IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task AddAsync(ProductionRecord productionRecord)
        {
            await _db.ProductionRecords.AddAsync(productionRecord);
            await _db.SaveChangesAsync();
        }


        public async Task<IEnumerable<ProductionRecord>> GetByOperatorIdAsync(int operatorId)
        {
            return await _db.ProductionRecords.Where(pr => pr.PerformedById == operatorId).ToListAsync();

        }

        public ProductionDTO UpdateRecord(ProductionDTO productionDTO)
        {
            var existingRecord = _db.ProductionRecords.FirstOrDefault(r=>r.Id == productionDTO.Id);
            if (existingRecord != null)
            {
                _mapper.Map(productionDTO,existingRecord);
                _db.SaveChanges();
                return _mapper.Map<ProductionDTO>(existingRecord);
            }
            throw new Exception("Record not found");
        }

        public List<ProductionDTO> GetAll()
        {
            return _db.ProductionRecords.Select(r=>new ProductionDTO
            {
                Id = r.Id,
                TyreCode = r.TyreCode,
                Quantity = r.Quantity,
                ProductionDate = r.ProductionDate,
                ProductionShift = r.ProductionShift,
                MachineNumber = r.MachineNumber
            }).ToList();

        }
    }
}
