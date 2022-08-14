using AutoMapper;
using MediatR;
using OracleEFCore5.Application.Interfaces;
using OracleEFCore5.Application.Interfaces.Repositories;
using OracleEFCore5.Application.Parameters;
using OracleEFCore5.Application.Wrappers;
using OracleEFCore5.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace OracleEFCore5.Application.Features.Project_Table.Queries.Gets
{
    public class GetProjectrsQuery : QueryParameter, IRequest<PagedResponse<IEnumerable<Entity>>>
    {
        public string pjt_code { get; set; }
        public string pjt_name { get; set; }
        public DateTime pjt_startdate { get; set; }
        public DateTime pjt_enddate { get; set; }
    }

    public class GetAllProjectQueryHandler : IRequestHandler<GetProjectrsQuery, PagedResponse<IEnumerable<Entity>>>
    {
        private readonly IProjectRepositoryAsync _projectRepository;
        private readonly IMapper _mapper;
        private readonly IModelHelper _modelHelper;

        public GetAllProjectQueryHandler(IProjectRepositoryAsync projectRepository, IMapper mapper, IModelHelper modelHelper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
            _modelHelper = modelHelper;
        }

        public async Task<PagedResponse<IEnumerable<Entity>>> Handle(GetProjectrsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = request;
            var pagination = request;
            //filtered fields security
            if (!string.IsNullOrEmpty(validFilter.Fields))
            {
                //limit to fields in view model
                validFilter.Fields = _modelHelper.ValidateModelFields<ProjectsData>(validFilter.Fields);
            }
            if (string.IsNullOrEmpty(validFilter.Fields))
            {
                //default fields from view model
                validFilter.Fields = _modelHelper.GetModelFields<ProjectsData>();
            }
            // query based on filter
            var entityprojects = await _projectRepository.GetPagedProjectReponseAsync(validFilter);
            var data = entityprojects.data;
            RecordsCount recordCount = entityprojects.recordsCount;
            // response wrapper
            return new PagedResponse<IEnumerable<Entity>>(data, validFilter.PageNumber, validFilter.PageSize, recordCount);
        }
    }
}
