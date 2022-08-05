using OracleEFCore5.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace OracleEFCore5.Domain.Entities.DBTables
{
    [Table("TESTTABLES")]
    public class TestTable : AuditableBaseEntity
    {
        [Column("TEST_NAME")]
        public string test_name {get; set;}
    }
}
