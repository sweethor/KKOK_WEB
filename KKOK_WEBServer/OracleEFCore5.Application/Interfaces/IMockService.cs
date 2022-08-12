using OracleEFCore5.Domain.Entities;
using OracleEFCore5.Domain.Entities.DBTables;
using System.Collections.Generic;

namespace OracleEFCore5.Application.Interfaces
{
    public interface IMockService
    {
        List<TestTable> GetTestTables(int rowCount);
        List<TestTable> SeedTestTables(int rowCount);
        List<Member> GetMembers(int rowCount);
        List<Member> SeedMembers(int rowCount);
        List<Pjt_Member> GetProjectMembers(int rowCount);
        List<Pjt_Member> SeedProjectMembers(int rowCount);
        List<Pjt_Plan> GetProjectPlans(int rowCount);
        List<Pjt_Plan> SeedProjectPlans(int rowCount);
        List<Member_Attend> GetMembersAttend(int rowCount);
        List<Member_Attend> SeedMembersAttend(int rowCount);
        List<Pjt_Notice> GetProjectNotices(int rowCount);
        List<Pjt_Notice> SeedProjectNotices(int rowCount);
        List<Pjt_Plan_CheckList> GetProjectPlanCheckLists(int rowCount);
        List<Pjt_Plan_CheckList> SeedProjectPlanCheckLists(int rowCount);
        List<Member_Notice> GetMembersNotice(int rowCount);
        List<Member_Notice> SeedMembersNotice(int rowCount);
        List<Pjt_Comment> GetProjectComments(int rowCount);
        List<Pjt_Comment> SeedProjectComments(int rowCount);
        List<Pjt_Mention> GetProjectMentions(int rowCount);
        List<Pjt_Mention> SeedProjectMentions(int rowCount);
    }
}