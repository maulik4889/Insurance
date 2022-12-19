using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Insurance.Application.Repositories;
using Insurance.Domain.Entities;

namespace Insurance.Infrastructure.Persistence.Repositories
{
    public class CompanyRepository : BaseRepository<Company>, ICompanyRepository
    {
        private readonly ApplicationDbContext _context;

        public CompanyRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Company> GetCompanyById(int Id)
        {
            return await _context.Company
                .Include(x => x.Claims)
                .Where(x => x.Id == Id)
               .Select(x => new Company
               {
                   Id = x.Id,
                   Name = x.Name,
                   Address1 = x.Address1,
                   Address2 = x.Address2,
                   Address3 = x.Address3,
                   Active = x.Active,
                   Postcode = x.Postcode,
                   Country = x.Country,
                   InsuranceEndDate = x.InsuranceEndDate,
                   Claims = x.Claims.ToList(),
               })
               .AsNoTracking()
               .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Company>> GetAllActiveCompanies()
        {
            return await _context.Company
                .Where(x => x.Active == true)
               .Select(x => new Company
               {
                   Id = x.Id,
                   Name = x.Name,
                   Address1 = x.Address1,
                   Address2 = x.Address2,
                   Address3 = x.Address3,
                   Active = x.Active,
                   Postcode = x.Postcode,
                   Country = x.Country,
                   InsuranceEndDate = x.InsuranceEndDate
               })
               .AsNoTracking()
               .ToListAsync();
        }

    }
}
