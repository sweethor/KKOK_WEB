using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OracleEFCore5.Application.Features.DbTestTable.Queries.Gets
{
    [Table("TEST_MEMBER_ATTEND")]
    public class MembersAttendData
    {
        [Column("PJT_CODE")]
        public int Pjt_Code { get; set; }
        [Column("MEMBER_CODE")]
        public int Member_Code { get; set; }
        [Column("MEMBER_NAME")]
        public string Member_Name { get; set; }
        [Column("MEMBER_ISSUE_CNT")]
        public int Member_Issue_Cnt { get; set; }
        [Column("MEMBER_COM_ISSUE")]
        public int Member_Com_Issue { get; set; }

    }
}
