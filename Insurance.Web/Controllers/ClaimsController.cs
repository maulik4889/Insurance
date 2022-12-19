using Microsoft.AspNetCore.Mvc;
using Insurance.Application.Services.ClaimTypeService;
using Insurance.Domain.Entities;
using Insurance.Application.Services.ClaimService;
using Microsoft.AspNetCore.Authorization;
using Insurance.Application.Common.RequestModels;
using Insurance.Application.Common.ViewModels;

namespace Insurance.Web.Controllers.V1
{
    [Route("[controller]")]
    [ApiController]
    public class ClaimsController : ControllerBase
    {
        private readonly IClaimService _claimsService;

        public ClaimsController(IClaimService claimsService)
        {
            _claimsService = claimsService;
        }


        /// <summary>
        /// Returns only one claim
        /// </summary>
        /// <remarks>
        /// ## Notes:
        /// - Claim Details
        /// - Return with how old the claim is in days
        /// </remarks>
        /// <param name="claimId"></param>
        /// <returns></returns> 
        [HttpGet("claimDetail/{claim-id}")]
        public async Task<ClaimDetailsViewModel> GetClaimDetail([FromRoute(Name = "claim-id")] int claimId)
        {
            return await _claimsService.GetClaimDetail(claimId);
        }

        /// <summary>
        /// Updates existing claim.
        /// </summary>
        /// <param name="claimId"></param>
        /// <param name="updateClaimRequest"></param>
        /// <returns></returns>
        [HttpPut("claims/{claim-id}")]
        public async Task<ClaimViewModel> UpdateClaim([FromRoute(Name = "claim-id")] int claimId, [FromForm] UpdateClaimRequest updateClaimRequest)
        {
            return await _claimsService.UpdateClaim(claimId, updateClaimRequest);
        }
    }    
}
