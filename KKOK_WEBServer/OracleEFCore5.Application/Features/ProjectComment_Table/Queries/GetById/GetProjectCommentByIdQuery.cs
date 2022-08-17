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
    public class GetProjectCommentByIdQuery : IRequest<Response<Pjt_Comment>>
    {
        public Guid Id { get; set; }
        public class GetProjectCommentByIdQueryHandler : IRequestHandler<GetProjectCommentByIdQuery, Response<Pjt_Comment>>
        {
            private readonly IProjectCommentRepositoryAsync _projectcommentRepository;
            public GetProjectCommentByIdQueryHandler(IProjectCommentRepositoryAsync projectcommentRepository)
            {
                _projectcommentRepository = projectcommentRepository;
            }
            public async Task<Response<Pjt_Comment>> Handle(GetProjectCommentByIdQuery query, CancellationToken cancellationToken)
            {
                var projectcomment = await _projectcommentRepository.GetByIdAsync(query.Id);
                if (projectcomment == null) throw new ApiException($"ProjectMember Not Found.");
                return new Response<Pjt_Comment>(projectcomment);
            }
        }
    }
}
