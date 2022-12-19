using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Insurance.Application.Common.ViewModels;
using Insurance.Domain.Entities;

namespace Insurance.Application.Repositories
{
    public interface ICompanyRepository : IBaseRepository<Company>
    {
        public Task<Company> GetCompanyById(int Id);
        public Task<IEnumerable<Company>> GetAllActiveCompanies();
    }
}
