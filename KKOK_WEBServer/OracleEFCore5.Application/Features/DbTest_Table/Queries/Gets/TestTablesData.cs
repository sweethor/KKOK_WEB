using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OracleEFCore5.Application.Features.DbTestTable.Queries.Gets
{
    [Table("TESTTABLES")]
    public class Test_TableData
    {
        [Column("ID")]
        public Guid Id { get; set; }
        [Column("TEST_NAME")]
        public string Test_Name { get; set; }
    }
}
