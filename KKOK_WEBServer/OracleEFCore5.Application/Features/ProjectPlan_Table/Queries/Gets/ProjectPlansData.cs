using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OracleEFCore5.Application.Features.DbTestTable.Queries.Gets
{
    [Table("TEST_PJT_PLAN")]
    public class ProjectPlansData
    {
        [Column("PJT_CODE")]
        public int Pjt_Code { get; set; }
        [Column("MEMBER_CODE")]
        public int Member_Code { get; set; }
        [Column("PLAN_CODE")]
        public int Plan_Code { get; set; }
        [Column("PLAN_START_DATE")]
        public DateTime Plan_Start_Date { get; set; }
        [Column("PLAN_END_DATE")]
        public DateTime Plan_End_Date { get; set; }
        [Column("PLAN_DESCRIPTION")]
        public string Plan_Description { get; set; }
    }
}
