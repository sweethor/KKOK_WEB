using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OracleEFCore5.Application.Features.DbTestTable.Queries.Gets
{
    [Table("TEST_MEMBER")]
    public class ProjectMembersData
    {
        [Column("PJT_CODE")]
        public int pjt_code { get; set; }
        [Column("MEMBER_CODE")]
        public int member_code { get; set; }
        [Column("MEMBER_NAME")]
        public string member_name { get; set; }
        [Column("MEMBER_JOB")]
        public string member_job { get; set; }
        [Column("MEMBER_PJT_PERMISSION")]
        public int member_pjt_permission { get; set; }
    }
}
