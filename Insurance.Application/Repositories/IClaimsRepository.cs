using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Insurance.Domain.Entities;

namespace Insurance.Application.Repositories
{
    public interface IClaimsRepository : IBaseRepository<Claims>
    {
        public Task<IEnumerable<Claims>> GetClaimsById(int Id);

        public Task<Claims> GetClaimById(int Id);

        public Task UpdateClaim(Claims claim);
    }
}
