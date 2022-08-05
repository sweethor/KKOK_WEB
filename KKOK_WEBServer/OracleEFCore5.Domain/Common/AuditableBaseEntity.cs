using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OracleEFCore5.Domain.Common
{
    public abstract class AuditableBaseEntity : BaseEntity
    {
        [Column("CREATEDBY")]
        public string CreatedBy { get; set; }
        [Column("CREATED")]
        public DateTime Created { get; set; }
        [Column("LASTMODIFIEDBY")]
        public string LastModifiedBy { get; set; }
        [Column("LASTMODIFIED")]
        public DateTime? LastModified { get; set; }
    }
}
