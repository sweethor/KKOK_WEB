using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OracleEFCore5.Domain.Common
{
    public abstract class BaseEntity
    {
        [Column("ID")]
        public virtual Guid Id { get; set; }
    }
}