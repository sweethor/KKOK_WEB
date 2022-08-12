using OracleEFCore5.Domain.Common;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OracleEFCore5.Domain.Entities.DBTables
{
    [Table("TEST_PJT_NOTICE")]
    public class Pjt_Notice : AuditableBaseEntity
    {
        [Column("PJT_CODE")]
        public int Pjt_Code { get; set; }
        [Column("MEMBER_CODE")]
        public int Member_Code { get; set; }
        [Column("NOTICE_CODE")]
        public int Notice_Code { get; set; }
        [Column("MEMBER_NAME")]
        public string Member_Name { get; set; }
        [Column("NOTICE_DATE")]
        public DateTime Notice_Date { get; set; }
        [Column("NOTICE_NAME")]
        public string Notice_Name { get; set; }
        [Column("NOTICE_DESCRIPTION")]
        public string Notice_Description { get; set; }
    }
}
