using MediatR;
using OracleEFCore5.Application.Exceptions;
using OracleEFCore5.Application.Interfaces.Repositories;
using OracleEFCore5.Application.Wrappers;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OracleEFCore5.Application.Features.DbTestTable.Commands.Delete
{
    public class DeleteProjectMentionByIdCommand : IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }
        public class DeleteProjectMentionByIdCommandHandler : IRequestHandler<DeleteProjectMentionByIdCommand, Response<Guid>>
        {
            private readonly IProjectMentionRepositoryAsync _projectmentionRepository;
            public DeleteProjectMentionByIdCommandHandler(IProjectMentionRepositoryAsync projectmentionRepository)
            {
                _projectmentionRepository = projectmentionRepository;
            }
            public async Task<Response<Guid>> Handle(DeleteProjectMentionByIdCommand command, CancellationToken cancellationToken)
            {
                var projectmention = await _projectmentionRepository.GetByIdAsync(command.Id);
                if (projectmention == null) throw new ApiException($"Project Mention Not Found.");
                await _projectmentionRepository.DeleteAsync(projectmention);
                return new Response<Guid>(projectmention.Id);
            }
        }
    }
}
