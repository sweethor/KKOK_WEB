using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OracleEFCore5.Application.Features.DbTestTable.Queries.Gets
{
    [Table("TEST_MEMBER")]
    public class ProjectMembersData
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
