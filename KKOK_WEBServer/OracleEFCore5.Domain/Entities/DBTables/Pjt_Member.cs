using OracleEFCore5.Domain.Common;
namespace OracleEFCore5.Domain.Entities.DBTables
{
    public class Pjt_Member : AuditableBaseEntity
    {
        public int pjt_code { get; set; }
        public int member_code { get; set; }
        public string member_name { get; set; }
        public string member_job { get; set; }
        public int member_pjt_premission { get; set; }
    }
}
