using OracleEFCore5.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace OracleEFCore5.Domain.Entities.DBTables
{
    [Table("TEST_MEMBER_NOTICE")]
    public class Member_Notice : AuditableBaseEntity
    {
        [Column("PJT_CODE")]
        public int Pjt_Code { get; set; }
        [Column("MEMBER_CODE")]
        public int Member_Code { get; set; }
        [Column("PLAN_CODE")]
        public int Plan_Code { get; set; }
        [Column("ISSUE_CODE")]
        public int Issue_Code { get; set; }
        [Column("NOTICE_NAME")]
        public string Notice_Name { get; set; }
    }
}
