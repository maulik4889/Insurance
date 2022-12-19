using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Insurance.Application.Common.Interfaces;
using Insurance.Application.Common.Models;
using Insurance.Application.Common.ViewModels;
using Insurance.Domain.Entities;
using InsuranceException = Insurance.Domain.Exceptions.InsuranceException;
using System.Security.Claims;

namespace Insurance.Application.Services.CompanyService
{
    public class CompanyService : ICompanyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CompanyService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Company> GetCompany(int Id)
        {
            var company = await _unitOfWork.Company.GetCompanyById(Id);

            if (company == null)
            {
                throw InsuranceException.NotFound;
            }

            return company;
        }

        public async Task<IEnumerable<CompanyViewModel>> GetAllActiveCompanies()
        {
            var companies = await _unitOfWork.Company.GetAllActiveCompanies();

            if (companies == null)
            {
                throw InsuranceException.NotFound;
            }

            return _mapper.Map<IEnumerable<CompanyViewModel>>(companies);
        }

    }
}
