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
    public class GetProjectPlanCheckListByIdQuery : IRequest<Response<Pjt_Plan_CheckList>>
    {
        public Guid Id { get; set; }
        public class GetProjectPlanCheckListByIdQueryHandler : IRequestHandler<GetProjectPlanCheckListByIdQuery, Response<Pjt_Plan_CheckList>>
        {
            private readonly IProjectPlanCheckListRepositoryAsync _projectplanchecklistRepository;
            public GetProjectPlanCheckListByIdQueryHandler(IProjectPlanCheckListRepositoryAsync projectplanchecklistRepository)
            {
                _projectplanchecklistRepository = projectplanchecklistRepository;
            }
            public async Task<Response<Pjt_Plan_CheckList>> Handle(GetProjectPlanCheckListByIdQuery query, CancellationToken cancellationToken)
            {
                var projectplanchecklist = await _projectplanchecklistRepository.GetByIdAsync(query.Id);
                if (projectplanchecklist == null) throw new ApiException($"Project PlanCheckList Not Found.");
                return new Response<Pjt_Plan_CheckList>(projectplanchecklist);
            }
        }
    }
}
