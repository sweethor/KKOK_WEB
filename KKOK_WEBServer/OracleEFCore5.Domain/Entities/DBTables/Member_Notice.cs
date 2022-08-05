using OracleEFCore5.Domain.Common;
namespace OracleEFCore5.Domain.Entities.DBTables
{
    public class Member_Notice : AuditableBaseEntity
    {
        public int pjt_code { get; set; }
        public int member_code { get; set; }
        public int plan_code { get; set; }
        public int issue_code { get; set; }
        public string notice_name { get; set; }
    }
}
