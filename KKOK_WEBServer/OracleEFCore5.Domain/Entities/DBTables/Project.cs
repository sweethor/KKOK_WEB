using OracleEFCore5.Domain.Common;
using System;

namespace OracleEFCore5.Domain.Entities.DBTables
{
    public class Project : AuditableBaseEntity
    {
        public int pjt_code { get; set; }
        public string pjt_name { get; set; }
        public DateTime pjt_startdate { get; set; }
        public DateTime pjt_enddate { get; set; }
    }
}
