using Bogus;
using OracleEFCore5.Domain.Entities;
using OracleEFCore5.Domain.Entities.DBTables;

namespace OracleEFCore5.Infrastructure.Shared.Mock
{
    public class ProjectMemberInsertBogusConfig : Faker<Pjt_Member>
    {
        public ProjectMemberInsertBogusConfig()
        {
            RuleFor(o => o.Pjt_Code, f => f.UniqueIndex);
            RuleFor(o => o.Member_Code, f => f.UniqueIndex);
            RuleFor(o => o.Member_Name, f => f.Name.JobTitle());
            RuleFor(o => o.Member_Job, f => f.Name.JobTitle());
            RuleFor(o => o.Member_Pjt_Permission, f => f.Name.JobTitle());
            RuleFor(o => o.CreatedBy, f => f.Name.FullName());
        }
    }
}
