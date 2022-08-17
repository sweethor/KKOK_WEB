using Bogus;
using OracleEFCore5.Domain.Entities;
using OracleEFCore5.Domain.Entities.DBTables;

namespace OracleEFCore5.Infrastructure.Shared.Mock
{
    public class MemberNoticeInsertBogusConfig : Faker<Member_Notice>
    {
        public MemberNoticeInsertBogusConfig()
        {
            RuleFor(o => o.Pjt_Code, f => f.UniqueIndex);
            RuleFor(o => o.Member_Code, f => f.UniqueIndex);
            RuleFor(o => o.Issue_Code, f => f.UniqueIndex);
            RuleFor(o => o.Plan_Code, f => f.UniqueIndex);
            RuleFor(o => o.Notice_Name, f => f.Name.JobTitle());
            RuleFor(o => o.CreatedBy, f => f.Name.FullName());
        }
    }
}
