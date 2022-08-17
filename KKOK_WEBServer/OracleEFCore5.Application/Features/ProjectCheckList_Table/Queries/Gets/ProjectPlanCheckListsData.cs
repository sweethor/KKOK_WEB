using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OracleEFCore5.Application.Features.DbTestTable.Queries.Gets
{
    [Table("TEST_PJT_PLAN_CHECKLIST")]
    public class ProjectPlanCheckListsData
    {
        [Column("PLAN_CODE")]
        public int Plan_Code { get; set; }
        [Column("PJT_CODE")]
        public int Pjt_Code { get; set; }
        [Column("PLAN_CHECKLIST_CODE")]
        public int Plan_Checklist_Code { get; set; }
        [Column("MEMBER_CODE")]
        public int Member_Code { get; set; }
        [Column("PLAN_CHECKLIST_NAME")]
        public string Plan_Checklist_Name { get; set; }
        [Column("PLAN_CHECKLIST_STATE")]
        public int Plan_Checklist_State { get; set; }
    }
}
