using System.Linq;
using AutoMapper;
using Insurance.Application.Common.ViewModels;
using Insurance.Domain.Entities;

namespace Insurance.Application.Common.Models.ModelMappings
{
    public class ClaimMapping : Profile
    {
        public ClaimMapping()
        {
            CreateMap<Claims, ClaimViewModel>()
                .ForMember(x => x.CompanyName, memberOption => memberOption.MapFrom(claim => claim.Company.Name));

            CreateMap<Claims, ClaimDetailsViewModel>();
        }
    }
}
