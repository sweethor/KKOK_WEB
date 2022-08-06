using AutoBogus;
using Bogus;
using OracleEFCore5.Domain.Entities;
using OracleEFCore5.Domain.Entities.DBTables;
using System;

namespace OracleEFCore5.Infrastructure.Shared.Mock
{
    public class ProjectMemberSeedBogusConfig : AutoFaker<Pjt_Member>
    {
        public ProjectMemberSeedBogusConfig()
        {
            Randomizer.Seed = new Random(8675309);
            var id = 1;
            RuleFor(m => m.Id, f => Guid.NewGuid());
            RuleFor(o => o.Pjt_Code, f => f.Name.JobTitle());
            RuleFor(o => o.Member_Code, f => f.Name.JobTitle());
            RuleFor(o => o.Member_Name, f => f.Name.JobTitle());
            RuleFor(o => o.Member_Job, f => f.Name.JobTitle());
            RuleFor(o => o.Member_Pjt_Permission, f => f.Name.JobTitle());
            RuleFor(o => o.Created, f => f.Date.Past(1));
            RuleFor(o => o.CreatedBy, f => f.Name.FullName());
            RuleFor(o => o.LastModified, f => f.Date.Recent(1));
            RuleFor(o => o.LastModifiedBy, f => f.Name.FullName());
        }
    }
}
