using AutoBogus;
using Bogus;
using OracleEFCore5.Domain.Entities;
using OracleEFCore5.Domain.Entities.DBTables;
using System;

namespace OracleEFCore5.Infrastructure.Shared.Mock
{
    public class ProjectMentionSeedBogusConfig : AutoFaker<Pjt_Mention>
    {
        public ProjectMentionSeedBogusConfig()
        {
            Randomizer.Seed = new Random(8675309);
            var id = 1;
            RuleFor(m => m.Id, f => Guid.NewGuid());
            RuleFor(o => o.Comment_Code, f => f.UniqueIndex);
            RuleFor(o => o.Pjt_Code, f => f.UniqueIndex);
            RuleFor(o => o.Plan_Code, f => f.UniqueIndex);
            RuleFor(o => o.Issue_Code, f => f.UniqueIndex);
            RuleFor(o => o.Member_Code, f => f.UniqueIndex);
            RuleFor(o => o.Ref_Member_Code, f => f.UniqueIndex);
            RuleFor(o => o.Ref_Member_Name, f => f.Name.JobTitle());
            RuleFor(o => o.Created, f => f.Date.Past(1));
            RuleFor(o => o.CreatedBy, f => f.Name.FullName());
            RuleFor(o => o.LastModified, f => f.Date.Recent(1));
            RuleFor(o => o.LastModifiedBy, f => f.Name.FullName());
        }
    }
}
