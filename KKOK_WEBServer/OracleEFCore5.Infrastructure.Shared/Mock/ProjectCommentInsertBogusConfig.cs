using Bogus;
using OracleEFCore5.Domain.Entities;
using OracleEFCore5.Domain.Entities.DBTables;

namespace OracleEFCore5.Infrastructure.Shared.Mock
{
    public class ProjectCommentInsertBogusConfig : Faker<Pjt_Comment>
    {
        public ProjectCommentInsertBogusConfig()
        {
            RuleFor(o => o.Pjt_Code, f => f.UniqueIndex);
            RuleFor(o => o.Plan_Code, f => f.UniqueIndex);
            RuleFor(o => o.Issue_Code, f => f.UniqueIndex);
            RuleFor(o => o.Comment_Code, f => f.UniqueIndex);
            RuleFor(o => o.Member_Code, f => f.UniqueIndex);
            RuleFor(o => o.Member_Name, f => f.Name.JobTitle());
            RuleFor(o => o.Wr_Member_Code.ToString(), f => f.Name.JobTitle());
            RuleFor(o => o.Wr_Member_Name, f => f.Name.JobTitle());
            RuleFor(o => o.CreatedBy, f => f.Name.FullName());
        }
    }
}
