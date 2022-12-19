using Microsoft.AspNetCore.Mvc;
using Insurance.Domain.Entities;
using Insurance.Application.Services.CompanyService;
using Insurance.Application.Common.ViewModels;
using System.Collections.Generic;

namespace Insurance.Web.Controllers.V1
{
    [Route("[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        /// <summary>
        /// Returns only one claim
        /// </summary>
        /// <remarks>
        /// ## Notes:
        /// - list of claims for one company
        /// </remarks>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [HttpGet("company/{company-id}")]
        public async Task<Company> GetCompany([FromRoute(Name = "company-id")] int companyId)
        {
            return await _companyService.GetCompany(companyId);
        }

        /// <summary>
        /// Returns list of company
        /// </summary>
        /// <remarks>
        /// ## Notes:
        /// - Company has an active insurance policy
        /// </remarks>
        /// <returns></returns>
        [HttpGet("company")]
        public async Task<IEnumerable<CompanyViewModel>> GetCompanyies()
        {
            return await _companyService.GetAllActiveCompanies();
        }
    }
}
