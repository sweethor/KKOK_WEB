using AutoMapper;
using OracleEFCore5.Application.Features.DbTestTable.Commands.Create;
using OracleEFCore5.Application.Features.DbTestTable.Commands.Delete;
using OracleEFCore5.Application.Features.DbTestTable.Commands.Update;
using OracleEFCore5.Application.Features.DbTestTable.Queries.GetById;
using OracleEFCore5.Application.Features.DbTestTable.Queries.Gets;
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
            CreateMap<GetTestTablesQuery, TestTable>().ReverseMap();
            CreateMap<GetTestTableByIdQuery, TestTable>().ReverseMap();
            CreateMap<InsertMockTestTableCommand, TestTable>().ReverseMap();
            CreateMap<UpdateTestTableCommand, TestTable>().ReverseMap();
            CreateMap<DeleteTestTableByIdCommand, TestTable>().ReverseMap();

            CreateMap<Member, MembersData>().ReverseMap();
            CreateMap<CreateProjectMemberCommand, Member>().ReverseMap();

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
        }
    }

}
