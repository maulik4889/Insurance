using System.Threading.Tasks;
using Insurance.Application.Repositories;

namespace Insurance.Application.Common.Interfaces
{
    public interface IUnitOfWork
    {
        public IClaimsRepository Claims { get; }
        public IClaimTypeRepository ClaimType { get; }
        public ICompanyRepository Company { get; }

        public Task BeginTransactionAsync();
        public Task CommitTransactionAsync();
        public void RollbackTransaction();
    }
}
