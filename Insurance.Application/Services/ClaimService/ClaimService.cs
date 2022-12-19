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
using Insurance.Application.Common.RequestModels;
using InsuranceException = Insurance.Domain.Exceptions.InsuranceException;
using System.Security.Cryptography;
using System.Security.Claims;

namespace Insurance.Application.Services.ClaimService
{
    public class ClaimService : IClaimService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ClaimService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ClaimViewModel> UpdateClaim(int claimId, UpdateClaimRequest updateClaimRequest)
        {
            var claim = await _unitOfWork.Claims.GetClaimById(claimId);
            if (claim == null)
            {
                throw InsuranceException.NotFound;
            }

            await _unitOfWork.BeginTransactionAsync();

            try
            {
                claim.CompanyId = updateClaimRequest.CompanyId ?? claim.CompanyId;
                claim.ClaimDate = updateClaimRequest.ClaimDate ?? claim.ClaimDate;
                claim.LossDate = updateClaimRequest.LossDate ?? claim.LossDate;
                claim.AssuredName = updateClaimRequest.AssuredName ?? claim.AssuredName;
                claim.IncurredLoss = updateClaimRequest.IncurredLoss ?? claim.IncurredLoss;
                claim.Closed = updateClaimRequest.Closed;

                await _unitOfWork.Claims.UpdateClaim(claim);

                await _unitOfWork.CommitTransactionAsync();

                return _mapper.Map<ClaimViewModel>(claim);
            }
            catch
            {
                _unitOfWork.RollbackTransaction();
                throw;
            }
        }

        public async Task<ClaimDetailsViewModel> GetClaimDetail(int Id)
        {
            var claim = await _unitOfWork.Claims.GetClaimById(Id);

            if (claim == null)
            {
                throw InsuranceException.NotFound;
            }

            var claimDetail = _mapper.Map<ClaimDetailsViewModel>(claim);

            claimDetail.ClaimDays = (DateTime.Now - claimDetail.ClaimDate).Days;

            return claimDetail;
        }
    }
}
