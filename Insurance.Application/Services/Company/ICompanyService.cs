using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Insurance.Application.Common.ViewModels;
using Insurance.Domain.Entities;

namespace Insurance.Application.Services.CompanyService
{
    public interface ICompanyService
    {
        public Task<Company> GetCompany(int Id);
        public Task<IEnumerable<CompanyViewModel>> GetAllActiveCompanies();
    }
}
