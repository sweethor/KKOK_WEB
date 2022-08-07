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

namespace OracleEFCore5.Application.Features.DbTestTable.Queries.Gets
{
    public class GetProjectPlansQuery : QueryParameter, IRequest<PagedResponse<IEnumerable<Entity>>>
    {
        public int Pjt_Code { get; set; }
        public int Member_Code { get; set; }
        public int Plan_Code { get; set; }
        public DateTime Plan_Start_Date { get; set; }
        public DateTime Plan_End_Date { get; set; }
        public string Plan_Description { get; set; }
    }

    public class GetAllProjectPlansQueryHandler : IRequestHandler<GetProjectPlansQuery, PagedResponse<IEnumerable<Entity>>>
    {
        private readonly IProjectPlanRepositoryAsync _projectplanRepository;
        private readonly IMapper _mapper;
        private readonly IModelHelper _modelHelper;

        public GetAllProjectPlansQueryHandler(IProjectPlanRepositoryAsync projectplanRepository, IMapper mapper, IModelHelper modelHelper)
        {
            _projectplanRepository = projectplanRepository;
            _mapper = mapper;
            _modelHelper = modelHelper;
        }

        public async Task<PagedResponse<IEnumerable<Entity>>> Handle(GetProjectPlansQuery request, CancellationToken cancellationToken)
        {
            var validFilter = request;
            var pagination = request;
            //filtered fields security
            if (!string.IsNullOrEmpty(validFilter.Fields))
            {
                //limit to fields in view model
                validFilter.Fields = _modelHelper.ValidateModelFields<ProjectPlansData>(validFilter.Fields);
            }
            if (string.IsNullOrEmpty(validFilter.Fields))
            {
                //default fields from view model
                validFilter.Fields = _modelHelper.GetModelFields<ProjectPlansData>();
            }
            // query based on filter
            var entitymembers = await _projectplanRepository.GetPagedProjectPlanReponseAsync(validFilter);
            var data = entitymembers.data;
            RecordsCount recordCount = entitymembers.recordsCount;
            // response wrapper
            return new PagedResponse<IEnumerable<Entity>>(data, validFilter.PageNumber, validFilter.PageSize, recordCount);
        }
    }
}
