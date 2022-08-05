using OracleEFCore5.Domain.Common;
namespace OracleEFCore5.Domain.Entities.DBTables
{
    public class Pjt_Mention : AuditableBaseEntity
    {
        public int comment_code { get; set; }
        public int pjt_code { get; set; }
        public int plan_code { get; set; }
        public int issue_code { get; set; }
        public int member_code { get; set; }
        public int ref_member_code { get; set; }
        public string ref_member_name { get; set; }
    }
}
