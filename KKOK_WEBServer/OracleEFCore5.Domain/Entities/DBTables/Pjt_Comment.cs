using OracleEFCore5.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace OracleEFCore5.Domain.Entities.DBTables
{
    [Table("TEST_PJT_COMMENT")]
    public class Pjt_Comment : AuditableBaseEntity
    {
        [Column("PJT_CODE")]
        public int Pjt_Code { get; set; }
        [Column("PLAN_CODE")]
        public int Plan_Code { get; set; }
        [Column("ISSUE_CODE")] 
        public int Issue_Code { get; set; }
        [Column("COMMENT_CODE")] 
        public int Comment_Code { get; set; }
        [Column("MEMBER_CODE")] 
        public int Member_Code { get; set; }
        [Column("MEMBER_NAME")] 
        public string Member_Name { get; set; }
        [Column("COMMENT_DESCRIPTION")] 
        public string Comment_Description { get; set; }
        [Column("WR_MEMBER_CODE")] 
        public int Wr_Member_Code { get; set; }
        [Column("WR_MEMBER_MAME")]
        public string Wr_Member_Name { get; set; }
    }
}
