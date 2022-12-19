using System.Linq;
using AutoMapper;
using Insurance.Application.Common.ViewModels;
using Insurance.Domain.Entities;

namespace Insurance.Application.Common.Models.ModelMappings
{
    public class CompanyMapping : Profile
    {
        public CompanyMapping()
        {
            CreateMap<Company, CompanyViewModel>();
        }
    }
}
