using MediatR;
using OracleEFCore5.Application.Exceptions;
using OracleEFCore5.Application.Interfaces.Repositories;
using OracleEFCore5.Application.Wrappers;
using OracleEFCore5.Domain.Entities;
using OracleEFCore5.Domain.Entities.DBTables;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OracleEFCore5.Application.Features.DbTestTable.Queries.GetById
{
    public class GetProjectPlanByIdQuery : IRequest<Response<Pjt_Plan>>
    {
        public Guid Id { get; set; }
        public class GetProjectPlanByIdQueryHandler : IRequestHandler<GetProjectPlanByIdQuery, Response<Pjt_Plan>>
        {
            private readonly IProjectPlanRepositoryAsync _projectplanRepository;
            public GetProjectPlanByIdQueryHandler(IProjectPlanRepositoryAsync projectplanRepository)
            {
                _projectplanRepository = projectplanRepository;
            }
            public async Task<Response<Pjt_Plan>> Handle(GetProjectPlanByIdQuery query, CancellationToken cancellationToken)
            {
                var projectplan = await _projectplanRepository.GetByIdAsync(query.Id);
                if (projectplan == null) throw new ApiException($"ProjectPlan Not Found.");
                return new Response<Pjt_Plan>(projectplan);
            }
        }
    }
}
