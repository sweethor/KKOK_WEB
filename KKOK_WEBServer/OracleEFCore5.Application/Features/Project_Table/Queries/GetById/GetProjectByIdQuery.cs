using MediatR;
using OracleEFCore5.Application.Exceptions;
using OracleEFCore5.Application.Interfaces.Repositories;
using OracleEFCore5.Application.Wrappers;
using OracleEFCore5.Domain.Entities;
using OracleEFCore5.Domain.Entities.DBTables;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OracleEFCore5.Application.Features.Project_Table.Queries.GetById
{
    public class GetProjectByIdQuery : IRequest<Response<Project>>
    {
        public Guid Id { get; set; }
        public class GetProjectByIdQueryHandler : IRequestHandler<GetProjectByIdQuery, Response<Project>>
        {
            private readonly IProjectRepositoryAsync _projectRepository;
            public GetProjectByIdQueryHandler(IProjectRepositoryAsync projectRepository)
            {
                _projectRepository = projectRepository;
            }
            public async Task<Response<Project>> Handle(GetProjectByIdQuery query, CancellationToken cancellationToken)
            {
                var project = await _projectRepository.GetByIdAsync(query.Id);
                if (project == null) throw new ApiException($"project Not Found.");
                return new Response<Project>(project);
            }
        }
    }
}
