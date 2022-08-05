using OracleEFCore5.Domain.Common;
namespace OracleEFCore5.Domain.Entities.DBTables
{
    public class Pjt_Plan_CheckList : AuditableBaseEntity
    {
        public int plan_code { get; set; }
        public int pjt_code { get; set; }
        public int plan_checklist_code { get; set; }
        public int member_code { get; set; }
        public string plan_checklist_name { get; set; }
        public int plan_checklist_state { get; set; }
    }
}
