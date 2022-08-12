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
    public class GetProjectMentionByIdQuery : IRequest<Response<Pjt_Mention>>
    {
        public Guid Id { get; set; }
        public class GetProjectMentionByIdQueryHandler : IRequestHandler<GetProjectMentionByIdQuery, Response<Pjt_Mention>>
        {
            private readonly IProjectMentionRepositoryAsync _projectmentionRepository;
            public GetProjectMentionByIdQueryHandler(IProjectMentionRepositoryAsync projectmentionRepository)
            {
                _projectmentionRepository = projectmentionRepository;
            }
            public async Task<Response<Pjt_Mention>> Handle(GetProjectMentionByIdQuery query, CancellationToken cancellationToken)
            {
                var projectmention = await _projectmentionRepository.GetByIdAsync(query.Id);
                if (projectmention == null) throw new ApiException($"Project Mention Not Found.");
                return new Response<Pjt_Mention>(projectmention);
            }
        }
    }
}
