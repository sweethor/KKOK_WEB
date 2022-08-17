using Bogus;
using OracleEFCore5.Domain.Entities;
using OracleEFCore5.Domain.Entities.DBTables;

namespace OracleEFCore5.Infrastructure.Shared.Mock
{
    public class ProjectPlanCheckListInsertBogusConfig : Faker<Pjt_Plan_CheckList>
    {
        public ProjectPlanCheckListInsertBogusConfig()
        {
            RuleFor(o => o.Pjt_Code, f => f.UniqueIndex);
            RuleFor(o => o.Member_Code, f => f.UniqueIndex);
            RuleFor(o => o.Plan_Code, f => f.UniqueIndex);
            RuleFor(o => o.Plan_CheckList_Code, f => f.UniqueIndex);
            RuleFor(o => o.Plan_CheckList_Name, f => f.Name.JobTitle());
            RuleFor(o => o.Plan_CheckList_State.ToString(), f => f.Name.JobTitle());
            RuleFor(o => o.CreatedBy, f => f.Name.FullName());
        }
    }
}
