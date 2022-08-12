using OracleEFCore5.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace OracleEFCore5.Domain.Entities.DBTables
{
    [Table("TEST_PJT_MENTION")]
    public class Pjt_Mention : AuditableBaseEntity
    {
        [Column("COMMENT_CODE")]
        public int Comment_Code { get; set; }
        [Column("PJT_CODE")]
        public int Pjt_Code { get; set; }
        [Column("PLAN_CODE")]
        public int Plan_Code { get; set; }
        [Column("ISSUE_CODE")]
        public int Issue_Code { get; set; }
        [Column("MEMBER_CODE")]
        public int Member_Code { get; set; }
        [Column("REF_MEMBER_CODE")]
        public int Ref_Member_Code { get; set; }
        [Column("REF_MEMBER_NAME")]
        public string Ref_Member_Name { get; set; }
    }
}
