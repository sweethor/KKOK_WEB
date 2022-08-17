using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OracleEFCore5.Application.Features.DbTestTable.Queries.Gets
{
    [Table("TEST_MEMBER_ATTEND")]
    public class MembersNoticeData
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
