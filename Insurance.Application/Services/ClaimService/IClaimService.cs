using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Insurance.Application.Common.ViewModels;
using Insurance.Domain.Entities;
using Insurance.Application.Common.RequestModels;

namespace Insurance.Application.Services.ClaimService
{
    public interface IClaimService
    {
        public Task<ClaimViewModel> UpdateClaim(int claimId, UpdateClaimRequest updateClaimRequest);

        public Task<ClaimDetailsViewModel> GetClaimDetail(int Id);
    }
}
