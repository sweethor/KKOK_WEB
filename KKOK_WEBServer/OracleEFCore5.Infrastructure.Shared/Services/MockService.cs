using OracleEFCore5.Application.Interfaces;
using OracleEFCore5.Domain.Entities;
using OracleEFCore5.Domain.Entities.DBTables;
using OracleEFCore5.Infrastructure.Shared.Mock;
using System.Collections.Generic;

namespace OracleEFCore5.Infrastructure.Shared.Services
{
    public class MockService : IMockService
    {
        public List<TestTable> GetTestTables(int rowCount)
        {
            var positionFaker = new TestTableInsertBogusConfig();
            return positionFaker.Generate(rowCount);
        }
        public List<TestTable> SeedTestTables(int rowCount)
        {
            var seedPositionFaker = new TestTableSeedBogusConfig();
            return seedPositionFaker.Generate(rowCount);
        }
        public List<Member> GetMembers(int rowCount)
        {
            var positionFaker = new MemberInsertBogusConfig();
            return positionFaker.Generate(rowCount);
        }
        public List<Member> SeedMembers(int rowCount)
        {
            var seedPositionFaker = new MemberSeedBogusConfig();
            return seedPositionFaker.Generate(rowCount);
        }
        public List<Project> GetProjects(int rowCount)
        {
            var positionFaker = new ProjectInsertBogusConfig();
            return positionFaker.Generate(rowCount);
        }
        public List<Project> SeedProjects(int rowCount)
        {
            var seedPositionFaker = new ProjectSeedBogusConfig();
            return seedPositionFaker.Generate(rowCount);
        }

        public List<Pjt_Member> GetProjectMembers(int rowCount)
        {
            var positionFaker = new ProjectMemberInsertBogusConfig();
            return positionFaker.Generate(rowCount);
        }
        public List<Pjt_Member> SeedProjectMembers(int rowCount)
        {
            var seedPositionFaker = new ProjectMemberSeedBogusConfig();
            return seedPositionFaker.Generate(rowCount);
        }
        public List<Pjt_Plan> GetProjectPlans(int rowCount)
        {
            var positionFaker = new ProjectPlanInsertBogusConfig();
            return positionFaker.Generate(rowCount);
        }
        public List<Pjt_Plan> SeedProjectPlans(int rowCount)
        {
            var seedPositionFaker = new ProjectPlanSeedBogusConfig();
            return seedPositionFaker.Generate(rowCount);
        }
        public List<Member_Attend> GetMembersAttend(int rowCount)
        {
            var positionFaker = new MemberAttendInsertBogusConfig();
            return positionFaker.Generate(rowCount);
        }
        public List<Member_Attend> SeedMembersAttend(int rowCount)
        {
            var seedPositionFaker = new MemberAttendSeedBogusConfig();
            return seedPositionFaker.Generate(rowCount);
        }
        public List<Pjt_Notice> GetProjectNotices(int rowCount)
        {
            var positionFaker = new ProjectNoticeInsertBogusConfig();
            return positionFaker.Generate(rowCount);
        }
        public List<Pjt_Notice> SeedProjectNotices(int rowCount)
        {
            var seedPositionFaker = new ProjectNoticeSeedBogusConfig();
            return seedPositionFaker.Generate(rowCount);
        }
        public List<Pjt_Plan_CheckList> GetProjectPlanCheckLists(int rowCount)
        {
            var positionFaker = new ProjectPlanCheckListInsertBogusConfig();
            return positionFaker.Generate(rowCount);
        }
        public List<Pjt_Plan_CheckList> SeedProjectPlanCheckLists(int rowCount)
        {
            var seedPositionFaker = new ProjectPlanCheckListSeedBogusConfig();
            return seedPositionFaker.Generate(rowCount);
        }
        public List<Member_Notice> GetMembersNotice(int rowCount)
        {
            var positionFaker = new MemberNoticeInsertBogusConfig();
            return positionFaker.Generate(rowCount);
        }
        public List<Member_Notice> SeedMembersNotice(int rowCount)
        {
            var seedPositionFaker = new MemberNoticeSeedBogusConfig();
            return seedPositionFaker.Generate(rowCount);
        }
        public List<Pjt_Comment> GetProjectComments(int rowCount)
        {
            var positionFaker = new ProjectCommentInsertBogusConfig();
            return positionFaker.Generate(rowCount);
        }
        public List<Pjt_Comment> SeedProjectComments(int rowCount)
        {
            var seedPositionFaker = new ProjectCommentSeedBogusConfig();
            return seedPositionFaker.Generate(rowCount);
        }
        public List<Pjt_Mention> GetProjectMentions(int rowCount)
        {
            var positionFaker = new ProjectMentionInsertBogusConfig();
            return positionFaker.Generate(rowCount);
        }
        public List<Pjt_Mention> SeedProjectMentions(int rowCount)
        {
            var seedPositionFaker = new ProjectMentionSeedBogusConfig();
            return seedPositionFaker.Generate(rowCount);
        }
    }
}
