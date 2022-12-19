using Microsoft.AspNetCore.Mvc;
using Insurance.Application.Services.ClaimTypeService;
using Insurance.Domain.Entities;

namespace Insurance.Web.Controllers.V1
{
    [Route("[controller]")]
    [ApiController]
    public class ClaimTypeController : ControllerBase
    {
        private readonly IClaimTypeService _claimTypeService;

        public ClaimTypeController(IClaimTypeService claimTypeService)
        {
            _claimTypeService = claimTypeService;
        }

        [HttpGet("claimtypes")]
        public async Task<IEnumerable<ClaimType>> GetClaimTypes()
        {
            return await _claimTypeService.GetClaimTypes();
        }
    }
}
