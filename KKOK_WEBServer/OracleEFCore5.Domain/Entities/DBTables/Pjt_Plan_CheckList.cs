using OracleEFCore5.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace OracleEFCore5.Domain.Entities.DBTables
{
    [Table("TEST_PJT_PLAN_CHECKLIST")]
    public class Pjt_Plan_CheckList : AuditableBaseEntity
    {
        [Column("PLAN_CODE")]
        public int Plan_Code { get; set; }
        [Column("PJT_CODE")]
        public int Pjt_Code { get; set; }
        [Column("PLAN_CHECKLIST_CODE")]
        public int Plan_CheckList_Code { get; set; }
        [Column("MEMBER_CODE")]
        public int Member_Code { get; set; }
        [Column("PLAN_CHECKLIST_NAME")]
        public string Plan_CheckList_Name { get; set; }
        [Column("PLAN_CHECKLIST_STATE")]
        public int Plan_CheckList_State { get; set; }
    }
}
