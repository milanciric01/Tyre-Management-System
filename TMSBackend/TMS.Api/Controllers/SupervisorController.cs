using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TMS.Data.DTO;
using TMS.Data.Models;
using TMS.Data.Services.Interfaces;

namespace TMS.Api.Controllers
{
    
    [ApiController]
    [Route("api/supervisor")]
    public class SupervisorController : Controller
    {

        private readonly ISupervisorService _supervisorService;
        public SupervisorController(ISupervisorService supervisorService)
        {
            _supervisorService = supervisorService;
        }
        [HttpPost("register-sale")]
        public async Task<IActionResult> RegisterTyreSale([FromBody] TyreSalesDTO tyreSalesDTO)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
            int LogId = 0;

            if (userId != null)
            {
                LogId = int.Parse(userId.Value);
            }

            if (tyreSalesDTO == null)
            {
                return BadRequest("Invalid production data");
            }

            await _supervisorService.RegisterTyreSalesAsync(tyreSalesDTO, LogId);

            return CreatedAtAction(nameof(RegisterTyreSale), new { id = tyreSalesDTO.Id }, tyreSalesDTO);
        }
        [HttpGet("supervisor-history")]
        public async Task<IActionResult> GetTyreSalesHistory()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
            int LogId = 0;

            if (userId != null)
            {
                LogId = int.Parse(userId.Value);
            }

            var record = await _supervisorService.GetAllSalesAsync();

            if(record == null || !record.Any())
            {
                return NotFound("No TyreSales Record found");
            }
            return Ok(record);
        }
        [HttpPut("update")]
        public async Task<IActionResult> UpdateProductionRecords([FromForm]ProductionDTO productionDTO)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
            int LogId = 0;

            if (userId != null)
            {
                LogId = int.Parse(userId.Value);
            }

            bool result = await _supervisorService.UpdateProdutionRecords(productionDTO,LogId);
            if (result == false)
            {
                return BadRequest(new { Message = "Error while modifing record!" });
            }

            return Ok();
        }
        [HttpGet("all-history")]
        public async Task<IActionResult> GetAllHistoryAsync()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
            int LogId = 0;
            if(userId != null)
            {
                LogId = int.Parse(userId.Value);
            }
            var record = await _supervisorService.GetAllProductionRecordsAsync(LogId);
            if(record == null || !record.Any())
            {
                return NotFound("No Production records found");
            }
            return Ok(record);
        }


       
    }
}
