using OracleEFCore5.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace OracleEFCore5.Domain.Entities.DBTables
{
    [Table("TEST_MEMBER")]
    public class Member : AuditableBaseEntity
    {
        [Column("MEMBER_CODE")]
        public string Member_Code { get; set; }
        [Column("MEMBER_ID")]
        public string Member_ID { get; set; }
        [Column("MEMBER_PWD")]
        public string Member_PWD { get; set; }
        [Column("MEMBER_NAME")]
        public string Member_Name { get; set; }
        [Column("MEMBER_EMAIL")]
        public string Member_Email { get; set; }
        [Column("MEMBER_PHONE")]
        public string Member_Phone { get; set; }
        [Column("MEMBER_PERMISSION")]
        public string Member_Permission { get; set; }
    }
}
