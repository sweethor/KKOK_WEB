using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OracleEFCore5.Application.Features.DbTestTable.Queries.Gets
{
    [Table("TEST_PJT_NOTICE")]
    public class ProjectNoticesData
    {
        [Column("PJT_CODE")]
        public int Pjt_Code { get; set; }
        [Column("MEMBER_CODE")]
        public int Member_Code { get; set; }
        [Column("NOTICE_CODE")]
        public int Notice_Code { get; set; }
        [Column("MEMBER_NAME")]
        public string Member_Name { get; set; }
        [Column("NOTICE_DATE")]
        public DateTime Notice_Date { get; set; }
        [Column("NOTICE_NAME")]
        public string Notice_Name { get; set; }
        [Column("NOTICE_DESCRIPTION")]
        public string Notice_Description { get; set; }
    }
}
