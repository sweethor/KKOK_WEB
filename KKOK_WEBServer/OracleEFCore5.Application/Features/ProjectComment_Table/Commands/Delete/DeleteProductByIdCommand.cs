using MediatR;
using OracleEFCore5.Application.Exceptions;
using OracleEFCore5.Application.Interfaces.Repositories;
using OracleEFCore5.Application.Wrappers;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OracleEFCore5.Application.Features.DbTestTable.Commands.Delete
{
    public class DeleteProjectCommentByIdCommand : IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }
        public class DeleteProjectCommentByIdCommandHandler : IRequestHandler<DeleteProjectCommentByIdCommand, Response<Guid>>
        {
            private readonly IProjectCommentRepositoryAsync _projectcommentRepository;
            public DeleteProjectCommentByIdCommandHandler(IProjectCommentRepositoryAsync projectcommentRepository)
            {
                _projectcommentRepository = projectcommentRepository;
            }
            public async Task<Response<Guid>> Handle(DeleteProjectCommentByIdCommand command, CancellationToken cancellationToken)
            {
                var projectcomment = await _projectcommentRepository.GetByIdAsync(command.Id);
                if (projectcomment == null) throw new ApiException($"Project Comment Not Found.");
                await _projectcommentRepository.DeleteAsync(projectcomment);
                return new Response<Guid>(projectcomment.Id);
            }
        }
    }
}
