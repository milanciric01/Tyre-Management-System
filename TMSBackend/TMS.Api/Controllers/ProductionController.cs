using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TMS.Data.DTO;
using TMS.Data.Services.Interfaces;

namespace TMS.Api.Controllers
{
  
    [ApiController]
    [Route("api/controller")]
    public class ProductionController : Controller
    {
        private readonly IProductionService _productionService;

        public ProductionController(IProductionService productionService)
        {
            _productionService = productionService;
        }

        [HttpPost("createRecord")]
        public async Task<IActionResult> CreateProductionRecord([FromBody] ProductionDTO productionDTO)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
            int LogId = 0;

            if (userId != null)
            {
                LogId = int.Parse(userId.Value);
            }
            if (productionDTO == null)
            {
                return BadRequest("Invalid production data.");
            }

            await _productionService.RegisterProductionAsync(productionDTO,LogId);

            return CreatedAtAction(nameof(CreateProductionRecord), new { id = productionDTO.Id }, productionDTO);
        }

        [HttpGet("history/{operatorId}")]
        public async Task<IActionResult> GetHistory(int operatorId)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
            int LogId = 0;

            if (userId != null)
            {
                LogId = int.Parse(userId.Value);
            }
            var records = await _productionService.GetProductionRecordsByOpId(operatorId, LogId);

            if (records == null || !records.Any())
            {
                return NotFound("No production records found");
            }
            return Ok(records);
                    
        }


    }
}
