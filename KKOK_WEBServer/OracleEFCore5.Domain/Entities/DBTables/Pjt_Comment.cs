using OracleEFCore5.Domain.Common;
namespace OracleEFCore5.Domain.Entities.DBTables
{
    public class Pjt_Comment : AuditableBaseEntity
    {
        public int pjt_code { get; set; }
        public int plan_code { get; set; }
        public int issue_code { get; set; }
        public int comment_code { get; set; }
        public int member_code { get; set; }
        public string member_name { get; set; }
        public string comment_description { get; set; }
        public int wr_member_code { get; set; }
        public string wr_member_name { get; set; }
    }
}
