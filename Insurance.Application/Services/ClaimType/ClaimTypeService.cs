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
using Insurance.Domain.Exceptions;

namespace Insurance.Application.Services.ClaimTypeService
{
    public class ClaimTypeService : IClaimTypeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ClaimTypeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ClaimType>> GetClaimTypes()
        {
            var claimTypes = await _unitOfWork.ClaimType.GetAllClaimTypes();

            return claimTypes;
        }
    }
}
