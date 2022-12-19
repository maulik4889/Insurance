using System;
using Insurance.Application.Common;

namespace Insurance.Application.Common.ViewModels
{
    public class ClaimViewModel
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public DateTime ClaimDate { get; set; }
        public DateTime LossDate { get; set; }
        public string AssuredName { get; set; }
        public decimal IncurredLoss { get; set; }
        public bool Closed { get; set; }
    }
}
