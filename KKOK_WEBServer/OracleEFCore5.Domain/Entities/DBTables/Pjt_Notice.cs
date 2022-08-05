using OracleEFCore5.Domain.Common;
using System;

namespace OracleEFCore5.Domain.Entities.DBTables
{
    public class Pjt_Notice : AuditableBaseEntity
    {
        public int pjt_code { get; set; }
        public int member_code { get; set; }
        public int notice_code { get; set; }
        public string member_name { get; set; }
        public DateTime notice_date { get; set; }
        public string notice_name { get; set; }
        public string notice_description { get; set; }
    }
}
