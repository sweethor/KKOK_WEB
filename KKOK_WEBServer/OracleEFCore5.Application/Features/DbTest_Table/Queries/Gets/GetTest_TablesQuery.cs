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
    public class GetTestTablesQuery : QueryParameter, IRequest<PagedResponse<IEnumerable<Entity>>>
    {
        public string TestName { get; set; }
    }

    public class GetAllTestTablesQueryHandler : IRequestHandler<GetTestTablesQuery, PagedResponse<IEnumerable<Entity>>>
    {
        private readonly ITestTableRepositoryAsync _testtableRepository;
        private readonly IMapper _mapper;
        private readonly IModelHelper _modelHelper;

        public GetAllTestTablesQueryHandler(ITestTableRepositoryAsync testTableRepository, IMapper mapper, IModelHelper modelHelper)
        {
            _testtableRepository = testTableRepository;
            _mapper = mapper;
            _modelHelper = modelHelper;
        }

        public async Task<PagedResponse<IEnumerable<Entity>>> Handle(GetTestTablesQuery request, CancellationToken cancellationToken)
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
            var entitytestTables = await _testtableRepository.GetPagedTestTableReponseAsync(validFilter);
            var data = entitytestTables.data;
            RecordsCount recordCount = entitytestTables.recordsCount;
            // response wrapper
            return new PagedResponse<IEnumerable<Entity>>(data, validFilter.PageNumber, validFilter.PageSize, recordCount);
        }
    }
}
