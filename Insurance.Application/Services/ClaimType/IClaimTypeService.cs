using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Insurance.Application.Common.ViewModels;
using Insurance.Domain.Entities;

namespace Insurance.Application.Services.ClaimTypeService
{
    public interface IClaimTypeService
    {
        public Task<IEnumerable<ClaimType>> GetClaimTypes();
    }
}
