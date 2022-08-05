using OracleEFCore5.Domain.Common;
using System;

namespace OracleEFCore5.Domain.Entities.DBTables
{
    public class Pjt_Plan : AuditableBaseEntity
    {
        public int pjt_code { get; set; }
        public int member_code { get; set; }
        public int plan_code { get; set; }
        public DateTime plan_start_date { get; set; }
        public DateTime plan_end_date { get; set; }
        public string plan_description { get; set; }
    }
}
