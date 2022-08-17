using Bogus;
using OracleEFCore5.Domain.Entities;
using OracleEFCore5.Domain.Entities.DBTables;

namespace OracleEFCore5.Infrastructure.Shared.Mock
{
    public class ProjectInsertBogusConfig : Faker<Project>
    {
        public ProjectInsertBogusConfig()
        {
            RuleFor(o => o.pjt_code, f => f.Name.JobTitle());
            RuleFor(o => o.pjt_name, f => f.Name.JobTitle());
            RuleFor(o => o.CreatedBy, f => f.Name.FullName());
        }
    }
}
