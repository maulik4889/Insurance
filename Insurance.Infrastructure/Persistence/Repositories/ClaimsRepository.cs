using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Insurance.Application.Repositories;
using Insurance.Domain.Entities;
using System.Security.Cryptography;
using System;

namespace Insurance.Infrastructure.Persistence.Repositories
{
    public class ClaimsRepository : BaseRepository<Claims>, IClaimsRepository
    {
        private readonly ApplicationDbContext _context;

        public ClaimsRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Claims>> GetClaimsById(int Id)
        {
            return await _context.Claims
               .Select(x => new Claims
               {
                   Id = x.Id,
                   CompanyId = x.CompanyId,
               })
               .AsNoTracking()
               .ToListAsync();
        }

        public async Task<Claims> GetClaimById(int Id)
        {
            return await _context.Claims
            .Include(x => x.Company)
            .Where(x => x.Id == Id)
                .Select(x => new Claims
                {
                    Id = x.Id,
                    CompanyId = x.CompanyId,
                    ClaimDate = x.ClaimDate,
                    LossDate = x.LossDate,
                    AssuredName = x.AssuredName,
                    IncurredLoss = x.IncurredLoss,
                    Closed = x.Closed,
                    TimeCreated = x.TimeCreated,
                    TimeModified = x.TimeModified,
                    Company = new Company
                    {
                        Name = x.Company.Name,
                    }
                })
            .AsNoTracking()
            .FirstOrDefaultAsync();
        }

        public Task UpdateClaim(Claims claim)
        {
            var dbClaim = new Claims { Id = claim.Id };
            _context.Claims.Attach(dbClaim);

            dbClaim.CompanyId = claim.CompanyId;
            dbClaim.ClaimDate = claim.ClaimDate;
            dbClaim.LossDate = claim.LossDate;
            dbClaim.AssuredName = claim.AssuredName;
            dbClaim.IncurredLoss = claim.IncurredLoss;
            dbClaim.Closed = claim.Closed;
            dbClaim.TimeModified = DateTime.Now;

            return _context.SaveChangesAsync();
        }

    }
}
