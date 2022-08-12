using AutoMapper;
using OracleEFCore5.Application.Features.DbTest_Table.Commands.Create;
using OracleEFCore5.Application.Features.DbTest_Table.Commands.Delete;
using OracleEFCore5.Application.Features.DbTest_Table.Commands.Update;
using OracleEFCore5.Application.Features.DbTestTable.Commands.Create;
using OracleEFCore5.Application.Features.DbTestTable.Commands.Delete;
using OracleEFCore5.Application.Features.DbTestTable.Commands.Update;
using OracleEFCore5.Application.Features.DbTestTable.Queries.GetById;
using OracleEFCore5.Application.Features.DbTestTable.Queries.Gets;
using OracleEFCore5.Application.Features.Project_Table.Commands.Create;
using OracleEFCore5.Application.Features.Project_Table.Commands.Delete;
using OracleEFCore5.Application.Features.Project_Table.Commands.Update;
using OracleEFCore5.Application.Features.Project_Table.Queries.GetById;
using OracleEFCore5.Application.Features.Project_Table.Queries.Gets;
using OracleEFCore5.Domain.Entities;
using OracleEFCore5.Domain.Entities.DBTables;

namespace OracleEFCore5.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<TestTable, Test_TableData>().ReverseMap();
            CreateMap<CreateTestTableCommand, TestTable>().ReverseMap();
            CreateMap<GetProjectsQuery, TestTable>().ReverseMap();
            CreateMap<GetTestTableByIdQuery, TestTable>().ReverseMap();
            CreateMap<InsertMockTestTableCommand, TestTable>().ReverseMap();
            CreateMap<UpdateTestTableCommand, TestTable>().ReverseMap();
            CreateMap<DeleteTestTableByIdCommand, TestTable>().ReverseMap();

            CreateMap<Member, MembersData>().ReverseMap();
            CreateMap<CreateProjectMemberCommand, Member>().ReverseMap();
            reateMap<CreateMemberCommand, Member>().ReverseMap();
            CreateMap<GetMembersQuery, Member>().ReverseMap();
            CreateMap<GetMemberByIdQuery, Member>().ReverseMap();
            CreateMap<InsertMockMemberCommand, Member>().ReverseMap();
            CreateMap<UpdateMemberCommand, Member>().ReverseMap();
            CreateMap<DeleteMemberByIdCommand, Member>().ReverseMap();

            CreateMap<Project, ProjectsData>().ReverseMap();
            CreateMap<CreateProjectCommand, Project>().ReverseMap();
            CreateMap<GetProjectsQuery, Project>().ReverseMap();
            CreateMap<GetProjectByIdQuery, Project>().ReverseMap();
            CreateMap<InsertMockProjectCommand, Project>().ReverseMap();
            CreateMap<UpdateProjectCommand, Project>().ReverseMap();
            CreateMap<DeleteProjectByIdCommand, Project>().ReverseMap();

            CreateMap<Pjt_Member, ProjectMembersData>().ReverseMap();
            CreateMap<CreateProjectMemberCommand, Pjt_Member>().ReverseMap();
            CreateMap<GetProjectMembersQuery, Pjt_Member>().ReverseMap();
            CreateMap<GetProjectMemberByIdQuery, Pjt_Member>().ReverseMap();
            CreateMap<InsertMockProjectMemberCommand, Pjt_Member>().ReverseMap();
            CreateMap<UpdateProjectMemberCommand, Pjt_Member>().ReverseMap();
            CreateMap<DeleteProjectMemberByIdCommand, Pjt_Member>().ReverseMap();

            CreateMap<Pjt_Plan, ProjectPlansData>().ReverseMap();
            CreateMap<CreateProjectPlanCommand, Pjt_Plan>().ReverseMap();
            CreateMap<GetProjectPlansQuery, Pjt_Plan>().ReverseMap();
            CreateMap<GetProjectPlanByIdQuery, Pjt_Plan>().ReverseMap();
            CreateMap<InsertMockProjectPlanCommand, Pjt_Plan>().ReverseMap();
            CreateMap<UpdateProjectPlanCommand, Pjt_Plan>().ReverseMap();
            CreateMap<DeleteProjectPlanByIdCommand, Pjt_Plan>().ReverseMap();

            CreateMap<Member_Attend, MembersAttendData>().ReverseMap();
            CreateMap<CreateMemberAttendCommand, Member_Attend>().ReverseMap();
            CreateMap<GetMembersAttendQuery, Member_Attend>().ReverseMap();
            CreateMap<GetMemberAttendByIdQuery, Member_Attend>().ReverseMap();
            CreateMap<InsertMockMemberAttendCommand, Member_Attend>().ReverseMap();
            CreateMap<UpdateMemberAttendCommand, Member_Attend>().ReverseMap();
            CreateMap<DeleteMemberAttendByIdCommand, Member_Attend>().ReverseMap();

            CreateMap<Pjt_Notice, ProjectNoticesData>().ReverseMap();
            CreateMap<CreateProjectNoticeCommand, Pjt_Notice>().ReverseMap();
            CreateMap<GetProjectNoticesQuery, Pjt_Notice>().ReverseMap();
            CreateMap<GetProjectNoticeByIdQuery, Pjt_Notice>().ReverseMap();
            CreateMap<InsertMockProjectNoticeCommand, Pjt_Notice>().ReverseMap();
            CreateMap<UpdateProjectNoticeCommand, Pjt_Notice>().ReverseMap();
            CreateMap<DeleteProjectNoticeByIdCommand, Pjt_Notice>().ReverseMap();

            CreateMap<Pjt_Plan_CheckList, ProjectPlanCheckListsData>().ReverseMap();
            CreateMap<CreateProjectPlanCheckListCommand, Pjt_Plan_CheckList>().ReverseMap();
            CreateMap<GetProjectPlanCheckListsQuery, Pjt_Plan_CheckList>().ReverseMap();
            CreateMap<GetProjectPlanCheckListByIdQuery, Pjt_Plan_CheckList>().ReverseMap();
            CreateMap<InsertMockProjectPlanCheckListCommand, Pjt_Plan_CheckList>().ReverseMap();
            CreateMap<UpdateProjectPlanCheckListCommand, Pjt_Plan_CheckList>().ReverseMap();
            CreateMap<DeleteProjectPlanCheckListByIdCommand, Pjt_Plan_CheckList>().ReverseMap();

            CreateMap<Member_Notice, MembersNoticeData>().ReverseMap();
            CreateMap<CreateMemberNoticeCommand, Member_Notice>().ReverseMap();
            CreateMap<GetMembersNoticeQuery, Member_Notice>().ReverseMap();
            CreateMap<GetMemberNoticeByIdQuery, Member_Notice>().ReverseMap();
            CreateMap<InsertMockMemberNoticeCommand, Member_Notice>().ReverseMap();
            CreateMap<UpdateMemberNoticeCommand, Member_Notice>().ReverseMap();
            CreateMap<DeleteMemberNoticeByIdCommand, Member_Notice>().ReverseMap();

            CreateMap<Pjt_Comment, ProjectCommentsData>().ReverseMap();
            CreateMap<CreateProjectCommentCommand, Pjt_Comment>().ReverseMap();
            CreateMap<GetProjectCommentsQuery, Pjt_Comment>().ReverseMap();
            CreateMap<GetProjectCommentByIdQuery, Pjt_Comment>().ReverseMap();
            CreateMap<InsertMockProjectCommentCommand, Pjt_Comment>().ReverseMap();
            CreateMap<UpdateProjectCommentCommand, Pjt_Comment>().ReverseMap();
            CreateMap<DeleteProjectCommentByIdCommand, Pjt_Comment>().ReverseMap();

            CreateMap<Pjt_Mention, ProjectMentionsData>().ReverseMap();
            CreateMap<CreateProjectMentionCommand, Pjt_Mention>().ReverseMap();
            CreateMap<GetProjectMentionsQuery, Pjt_Mention>().ReverseMap();
            CreateMap<GetProjectMentionByIdQuery, Pjt_Mention>().ReverseMap();
            CreateMap<InsertMockProjectMentionCommand, Pjt_Mention>().ReverseMap();
            CreateMap<UpdateProjectMentionCommand, Pjt_Mention>().ReverseMap();
            CreateMap<DeleteProjectMentionByIdCommand, Pjt_Mention>().ReverseMap();
        }
    }

}
