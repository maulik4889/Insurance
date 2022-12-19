
using System.Threading.Tasks;
using Insurance.Application.Common.Interfaces;
using Insurance.Application.Repositories;
using Insurance.Domain.Entities;
using Insurance.Infrastructure.Persistence.Repositories;

namespace Insurance.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        private IClaimTypeRepository claimType;
        private IClaimsRepository claims;
        private ICompanyRepository company;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        public virtual IClaimTypeRepository ClaimType => claimType ??= new ClaimTypeRepository(_context);
        public virtual ICompanyRepository Company => company ??= new CompanyRepository(_context);
        public virtual IClaimsRepository Claims => claims ??= new ClaimsRepository(_context);

        public virtual async Task BeginTransactionAsync()
        {
            await _context.BeginTransactionAsync();
        }

        public virtual Task CommitTransactionAsync()
        {
            return _context.CommitTransactionAsync();
        }

        public virtual void RollbackTransaction()
        {
            _context.RollbackTransaction();
        }
    }
}
