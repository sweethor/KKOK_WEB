using OracleEFCore5.Domain.Common;

namespace OracleEFCore5.Domain.Entities.DBTables
{
    public class Member_Attend : AuditableBaseEntity
    {
        public int pjt_code { get; set; }
        public int member_code { get; set; }
        public string member_name { get; set; }
        public int member_issue_cnt { get; set; }
        public int member_com_issue { get; set; }
    }
}
