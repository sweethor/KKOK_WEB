using Bogus;
using OracleEFCore5.Domain.Entities;
using OracleEFCore5.Domain.Entities.DBTables;

namespace OracleEFCore5.Infrastructure.Shared.Mock
{
    public class MemberInsertBogusConfig : Faker<Member>
    {
        public MemberInsertBogusConfig()
        {
            RuleFor(o => o.Member_Code, f => f.Name.JobTitle());
            RuleFor(o => o.Member_ID, f => f.Name.JobTitle());
            RuleFor(o => o.Member_PWD, f => f.Name.JobTitle());
            RuleFor(o => o.Member_Name, f => f.Name.JobTitle());
            RuleFor(o => o.Member_Email, f => f.Name.JobTitle());
            RuleFor(o => o.Member_Phone, f => f.Name.JobTitle());
            RuleFor(o => o.Member_Permission, f => f.Name.JobTitle());
            RuleFor(o => o.CreatedBy, f => f.Name.FullName());
        }
    }
}
