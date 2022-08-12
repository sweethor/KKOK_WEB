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
    public class GetProjectPlanCheckListsQuery : QueryParameter, IRequest<PagedResponse<IEnumerable<Entity>>>
    {
        public int Plan_Code { get; set; }

        public int Pjt_Code { get; set; }

        public int Plan_CheckList_Code { get; set; }

        public int Member_Code { get; set; }

        public string Plan_CheckList_Name { get; set; }

        public int Plan_CheckList_State { get; set; }
    }

    public class GetAllProjectPlanCheckListsQueryHandler : IRequestHandler<GetProjectPlanCheckListsQuery, PagedResponse<IEnumerable<Entity>>>
    {
        private readonly IProjectPlanCheckListRepositoryAsync _projectplanchecklistRepository;
        private readonly IMapper _mapper;
        private readonly IModelHelper _modelHelper;

        public GetAllProjectPlanCheckListsQueryHandler(IProjectPlanCheckListRepositoryAsync projectplanchecklistRepository, IMapper mapper, IModelHelper modelHelper)
        {
            _projectplanchecklistRepository = projectplanchecklistRepository;
            _mapper = mapper;
            _modelHelper = modelHelper;
        }

        public async Task<PagedResponse<IEnumerable<Entity>>> Handle(GetProjectPlanCheckListsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = request;
            var pagination = request;
            //filtered fields security
            if (!string.IsNullOrEmpty(validFilter.Fields))
            {
                //limit to fields in view model
                validFilter.Fields = _modelHelper.ValidateModelFields<ProjectPlanCheckListsData>(validFilter.Fields);
            }
            if (string.IsNullOrEmpty(validFilter.Fields))
            {
                //default fields from view model
                validFilter.Fields = _modelHelper.GetModelFields<ProjectPlanCheckListsData>();
            }
            // query based on filter
            var entityplanchecklists = await _projectplanchecklistRepository.GetPagedProjectPlanCheckListReponseAsync(validFilter);
            var data = entityplanchecklists.data;
            RecordsCount recordCount = entityplanchecklists.recordsCount;
            // response wrapper
            return new PagedResponse<IEnumerable<Entity>>(data, validFilter.PageNumber, validFilter.PageSize, recordCount);
        }
    }
}
