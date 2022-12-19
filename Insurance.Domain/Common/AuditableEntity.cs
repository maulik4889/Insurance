using System;

namespace Insurance.Domain.Common
{
    public abstract class AuditableEntity
    {
        public virtual int Id { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime TimeModified { get; set; }
    }
}
