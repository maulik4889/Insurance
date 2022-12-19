using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Insurance.Domain.Entities;

namespace Insurance.Application.Repositories
{
    public interface IClaimTypeRepository : IBaseRepository<ClaimType>
    {
        public Task<IEnumerable<ClaimType>> GetAllClaimTypes();
    }
}
