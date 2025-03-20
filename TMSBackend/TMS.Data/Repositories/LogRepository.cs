using AutoMapper;
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
    public class LogRepository : ILogRepository
    {
        private readonly TMSContext _db;
        private readonly IMapper _mapper;

        public LogRepository(TMSContext db,IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task AddLog(LogDTO logDto)
        {
            Log log = _mapper.Map<Log>(logDto);
            await _db.AddAsync(log);
            await _db.SaveChangesAsync();

        }
    }
}
