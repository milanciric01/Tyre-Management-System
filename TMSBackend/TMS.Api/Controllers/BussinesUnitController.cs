using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TMS.Data.Services.Interfaces;

namespace TMS.Api.Controllers
{
    
    [ApiController]
    [Route("api/bussines-unit")]
    public class BussinesUnitController : Controller
    {
        private readonly IBusinessUnitService _businessUnitService;

        public BussinesUnitController(IBusinessUnitService businessUnitService)
        {
            _businessUnitService = businessUnitService;
        }

        [HttpGet("production-reports-day")]
        public async Task<IActionResult> GetProductionByDay()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
            int LogId = 0;

            if(userId != null)
            {
                LogId = int.Parse(userId.Value);
            }

            var result = await _businessUnitService.GetProductionByDayServiceAsync(LogId);
            return Ok(result);
        }

        [HttpGet("production-reports-shift")]
        public async Task<IActionResult> GetProductionByShift()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
            int LogId = 0;

            if (userId != null)
            {
                LogId = int.Parse(userId.Value);
            }

            var result = await _businessUnitService.GetProductionByShiftServiceASync(LogId);
            return Ok(result);
        }
        [HttpGet("production-reports-machine")]
        public async Task<IActionResult> GetProductionByMachine()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
            int LogId = 0;

            if (userId != null)
            {
                LogId = int.Parse(userId.Value);
            }

            var result = await _businessUnitService.GetProductionByMachineServiceAsync(LogId);
            return Ok(result);
        }
        [HttpGet("production-reports-operator")]
        public async Task<IActionResult> GetProductionByOperatorId()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
            int LogId = 0;

            if (userId != null)
            {
                LogId = int.Parse(userId.Value);
            }
            var result = await _businessUnitService.GetProductionByOperatorServiceASync(LogId);
            return Ok(result);
        }
        [HttpGet("production-reports-stockbalance")]
        public async Task<IActionResult> GetProductionByStockBalance()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
            int LogId = 0;

            if (userId != null)
            {
                LogId = int.Parse(userId.Value);
            }
            var result = await _businessUnitService.GetStockBalanceServiceAsync(LogId);
            return Ok(result);
        }
    }
}
