using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Insurance.Application.Common.RequestModels
{
    public class UpdateClaimRequest
    {
        public int? CompanyId { get; set; }
        public DateTime? ClaimDate { get; set; }
        public DateTime? LossDate { get; set; }
        public string? AssuredName { get; set; }
        public decimal? IncurredLoss { get; set; }
        public bool Closed { get; set; }
    }
}
