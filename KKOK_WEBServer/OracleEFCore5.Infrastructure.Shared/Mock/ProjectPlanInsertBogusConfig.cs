using Bogus;
using OracleEFCore5.Domain.Entities;
using OracleEFCore5.Domain.Entities.DBTables;

namespace OracleEFCore5.Infrastructure.Shared.Mock
{
    public class ProjectPlanInsertBogusConfig : Faker<Pjt_Plan>
    {
        public ProjectPlanInsertBogusConfig()
        {
            RuleFor(o => o.Pjt_Code, f => f.UniqueIndex);
            RuleFor(o => o.Member_Code, f => f.UniqueIndex);
            RuleFor(o => o.Plan_Code, f => f.UniqueIndex);
            RuleFor(o => o.Plan_Start_Date, f => f.Date.Past(1));
            RuleFor(o => o.Plan_End_Date, f => f.Date.Past(1));
            RuleFor(o => o.Plan_Description, f => f.Name.JobTitle());
            RuleFor(o => o.CreatedBy, f => f.Name.FullName());
        }
    }
}
