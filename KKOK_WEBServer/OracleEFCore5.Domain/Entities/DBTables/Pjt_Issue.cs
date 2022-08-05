using OracleEFCore5.Domain.Common;
namespace OracleEFCore5.Domain.Entities.DBTables
{
    public class Pjt_Issue : AuditableBaseEntity
    {
        public int pjt_code { get; set; }
        public int member_code { get; set; }
        public int plan_code { get; set; }
        public int issue_code { get; set; }
        public int issue_number { get; set; }
        public int member_name { get; set; }
        public int issue_state { get; set; }
        public string issue_name { get; set; }
        public string issue_description { get; set; }
    }
}
