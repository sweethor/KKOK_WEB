using Bogus;
using OracleEFCore5.Domain.Entities;
using OracleEFCore5.Domain.Entities.DBTables;

namespace OracleEFCore5.Infrastructure.Shared.Mock
{
    public class MemberAttendInsertBogusConfig : Faker<Member_Attend>
    {
        public MemberAttendInsertBogusConfig()
        {
            RuleFor(o => o.Pjt_Code, f => f.UniqueIndex);
            RuleFor(o => o.Member_Code, f => f.UniqueIndex);
            RuleFor(o => o.Member_Name, f => f.Name.JobTitle());
            RuleFor(o => o.Member_Issue_Cnt.ToString(), f => f.Name.JobTitle());
            RuleFor(o => o.Member_Com_Issue.ToString(), f => f.Name.JobTitle());
            RuleFor(o => o.CreatedBy, f => f.Name.FullName());
        }
    }
}
