using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Insurance.Application.Repositories;
using Insurance.Domain.Entities;

namespace Insurance.Infrastructure.Persistence.Repositories
{
    public class ClaimTypeRepository : BaseRepository<ClaimType>, IClaimTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public ClaimTypeRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ClaimType>> GetAllClaimTypes()
        {
            return await _context.ClaimType
               .Select(x => new ClaimType
               {
                   Id = x.Id,
                   Name = x.Name,
               })
               .AsNoTracking()
               .ToListAsync();
        }

    }
}
