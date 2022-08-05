﻿using AutoMapper;
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
            CreateMap<CreateMemberCommand, Member>().ReverseMap();
        }
    }

}