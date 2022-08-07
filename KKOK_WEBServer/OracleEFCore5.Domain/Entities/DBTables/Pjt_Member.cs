using OracleEFCore5.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace OracleEFCore5.Domain.Entities.DBTables
{
    [Table("TEST_PJT_MEMBER")]
    public class Pjt_Member : AuditableBaseEntity
    {
        [Column("PJT_CODE")]
        public int Pjt_Code { get; set; }
        [Column("MEMBER_CODE")]
        public int Member_Code { get; set; }
        [Column("MEMBER_NAME")]
        public string Member_Name { get; set; }
        [Column("MEMBER_JOB")]
        public string Member_Job { get; set; }
        [Column("MEMBER_PJT_PERMISSION")]
        public string Member_Pjt_Permission { get; set; }
    }
}
