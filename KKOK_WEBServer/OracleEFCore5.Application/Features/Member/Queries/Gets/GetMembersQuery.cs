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
    public class GetMembersQuery : QueryParameter, IRequest<PagedResponse<IEnumerable<Entity>>>
    {
        public int Member_Code { get; set; }
        public string Member_ID { get; set; }
        public string Member_PWD { get; set; }
        public string Member_Name { get; set; }
        public string Member_Email { get; set; }
        public string Member_Phone { get; set; }
        public string Member_Permission { get; set; }
    }

    public class GetAllMembersQueryHandler : IRequestHandler<GetMembersQuery, PagedResponse<IEnumerable<Entity>>>
    {
        private readonly IMemberRepositoryAsync _memberRepository;
        private readonly IMapper _mapper;
        private readonly IModelHelper _modelHelper;

        public GetAllMembersQueryHandler(IMemberRepositoryAsync memberRepository, IMapper mapper, IModelHelper modelHelper)
        {
            _memberRepository = memberRepository;
            _mapper = mapper;
            _modelHelper = modelHelper;
        }

        public async Task<PagedResponse<IEnumerable<Entity>>> Handle(GetMembersQuery request, CancellationToken cancellationToken)
        {
            var validFilter = request;
            var pagination = request;
            //filtered fields security
            if (!string.IsNullOrEmpty(validFilter.Fields))
            {
                //limit to fields in view model
                validFilter.Fields = _modelHelper.ValidateModelFields<MembersData>(validFilter.Fields);
            }
            if (string.IsNullOrEmpty(validFilter.Fields))
            {
                //default fields from view model
                validFilter.Fields = _modelHelper.GetModelFields<MembersData>();
            }
            // query based on filter
            var entitymembers = await _memberRepository.GetPagedMemberReponseAsync(validFilter);
            var data = entitymembers.data;
            RecordsCount recordCount = entitymembers.recordsCount;
            // response wrapper
            return new PagedResponse<IEnumerable<Entity>>(data, validFilter.PageNumber, validFilter.PageSize, recordCount);
        }
    }
}
