using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OracleEFCore5.Application.Features.Project_Table.Queries.Gets
{
    [Table("TEST_PROJECT")]
    public class ProjectsData
    {
        [Column("ID")]
        public Guid Id { get; set; }
        [Column("PJT_CODE")]
        public string pjt_code { get; set; }
        [Column("PJT_NAME")]
        public string pjt_name { get; set; }
        [Column("PJT_STARTDATE")]
        public DateTime pjt_startdate { get; set; }
        [Column("PJT_ENDDATE")]
        public DateTime pjt_enddate { get; set; }
    }
}
