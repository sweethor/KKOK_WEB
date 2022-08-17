using Bogus;
using OracleEFCore5.Domain.Entities;
using OracleEFCore5.Domain.Entities.DBTables;

namespace OracleEFCore5.Infrastructure.Shared.Mock
{
    public class ProjectNoticeInsertBogusConfig : Faker<Pjt_Notice>
    {
        public ProjectNoticeInsertBogusConfig()
        {
            RuleFor(o => o.Pjt_Code, f => f.UniqueIndex);
            RuleFor(o => o.Member_Code, f => f.UniqueIndex);
            RuleFor(o => o.Member_Name, f => f.Name.JobTitle());
            RuleFor(o => o.Notice_Code, f => f.UniqueIndex);
            RuleFor(o => o.Notice_Date, f => f.Date.Past(1));
            RuleFor(o => o.Notice_Name, f => f.Name.JobTitle());
            RuleFor(o => o.Notice_Description, f => f.Name.JobTitle());
            RuleFor(o => o.CreatedBy, f => f.Name.FullName());
        }
    }
}
