using AutoMapper;
using MediatR;
using OracleEFCore5.Application.Interfaces;
using OracleEFCore5.Application.Interfaces.Repositories;
using OracleEFCore5.Application.Parameters;
using OracleEFCore5.Application.Wrappers;
using OracleEFCore5.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace OracleEFCore5.Application.Features.DbTestTable.Queries.Gets
{
    public class GetMembersAttendQuery : QueryParameter, IRequest<PagedResponse<IEnumerable<Entity>>>
    {
        public int Pjt_Code { get; set; }
        public int Member_Code { get; set; }
        public string Member_Name { get; set; }
        public int Member_Issue_Cnt { get; set; }
        public int Member_Com_Issue { get; set; }
    }

    public class GetAllMembersAttendQueryHandler : IRequestHandler<GetMembersAttendQuery, PagedResponse<IEnumerable<Entity>>>
    {
        private readonly IMemberAttendRepositoryAsync _memberattendRepository;
        private readonly IMapper _mapper;
        private readonly IModelHelper _modelHelper;

        public GetAllMembersAttendQueryHandler(IMemberAttendRepositoryAsync memberattendRepository, IMapper mapper, IModelHelper modelHelper)
        {
            _memberattendRepository = memberattendRepository;
            _mapper = mapper;
            _modelHelper = modelHelper;
        }

        public async Task<PagedResponse<IEnumerable<Entity>>> Handle(GetMembersAttendQuery request, CancellationToken cancellationToken)
        {
            var validFilter = request;
            var pagination = request;
            //filtered fields security
            if (!string.IsNullOrEmpty(validFilter.Fields))
            {
                //limit to fields in view model
                validFilter.Fields = _modelHelper.ValidateModelFields<MembersAttendData>(validFilter.Fields);
            }
            if (string.IsNullOrEmpty(validFilter.Fields))
            {
                //default fields from view model
                validFilter.Fields = _modelHelper.GetModelFields<MembersAttendData>();
            }
            // query based on filter
            var entitymembers = await _memberattendRepository.GetPagedMemberAttendReponseAsync(validFilter);
            var data = entitymembers.data;
            RecordsCount recordCount = entitymembers.recordsCount;
            // response wrapper
            return new PagedResponse<IEnumerable<Entity>>(data, validFilter.PageNumber, validFilter.PageSize, recordCount);
        }
    }
}
