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
    public class GetProjectMentionsQuery : QueryParameter, IRequest<PagedResponse<IEnumerable<Entity>>>
    {
        public int Comment_Code { get; set; }

        public int Pjt_Code { get; set; }

        public int Plan_Code { get; set; }

        public int Issue_Code { get; set; }

        public int Member_Code { get; set; }

        public int Ref_Member_Code { get; set; }

        public string Ref_Member_Name { get; set; }

    }

    public class GetAllProjectMentionsQueryHandler : IRequestHandler<GetProjectMentionsQuery, PagedResponse<IEnumerable<Entity>>>
    {
        private readonly IProjectMentionRepositoryAsync _projectmentionRepository;
        private readonly IMapper _mapper;
        private readonly IModelHelper _modelHelper;

        public GetAllProjectMentionsQueryHandler(IProjectMentionRepositoryAsync projectmentionRepository, IMapper mapper, IModelHelper modelHelper)
        {
            _projectmentionRepository = projectmentionRepository;
            _mapper = mapper;
            _modelHelper = modelHelper;
        }

        public async Task<PagedResponse<IEnumerable<Entity>>> Handle(GetProjectMentionsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = request;
            var pagination = request;
            //filtered fields security
            if (!string.IsNullOrEmpty(validFilter.Fields))
            {
                //limit to fields in view model
                validFilter.Fields = _modelHelper.ValidateModelFields<ProjectMentionsData>(validFilter.Fields);
            }
            if (string.IsNullOrEmpty(validFilter.Fields))
            {
                //default fields from view model
                validFilter.Fields = _modelHelper.GetModelFields<ProjectMentionsData>();
            }
            // query based on filter
            var entitymembers = await _projectmentionRepository.GetPagedProjectMentionReponseAsync(validFilter);
            var data = entitymembers.data;
            RecordsCount recordCount = entitymembers.recordsCount;
            // response wrapper
            return new PagedResponse<IEnumerable<Entity>>(data, validFilter.PageNumber, validFilter.PageSize, recordCount);
        }
    }
}
