using System;

namespace MS.MediCenter.Core.Common
{
    public abstract class AuditableBaseEntity
    {
        public int Id { get; set; }
        public string CreateBy { get; set; }
        public DateTime Created { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? Modified { get; set; }
    }
}
