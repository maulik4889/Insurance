using Insurance.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance.Domain.Entities
{
    public class ClaimType : AuditableEntity
    {
        public string Name { get; set; }
    }
}
