using Bogus;
using OracleEFCore5.Domain.Entities;
using OracleEFCore5.Domain.Entities.DBTables;

namespace OracleEFCore5.Infrastructure.Shared.Mock
{
    public class TestTableInsertBogusConfig : Faker<TestTable>
    {
        public TestTableInsertBogusConfig()
        {
            RuleFor(o => o.test_name, f => f.Name.JobTitle());
            RuleFor(o => o.CreatedBy, f => f.Name.FullName());
        }
    }
}
