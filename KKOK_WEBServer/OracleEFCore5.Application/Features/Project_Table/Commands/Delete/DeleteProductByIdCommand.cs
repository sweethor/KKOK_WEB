using MediatR;
using OracleEFCore5.Application.Exceptions;
using OracleEFCore5.Application.Interfaces.Repositories;
using OracleEFCore5.Application.Wrappers;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OracleEFCore5.Application.Features.Project_Table.Commands.Delete
{
    public class DeleteProjectByIdCommand : IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }
        public class DeleteProjectByIdCommandHandler : IRequestHandler<DeleteProjectByIdCommand, Response<Guid>>
        {
            private readonly IProjectRepositoryAsync _projectRepository;
            public DeleteProjectByIdCommandHandler(IProjectRepositoryAsync projectRepository)
            {
                _projectRepository = projectRepository;
            }
            public async Task<Response<Guid>> Handle(DeleteProjectByIdCommand command, CancellationToken cancellationToken)
            {
                var project = await _projectRepository.GetByIdAsync(command.Id);
                if (project == null) throw new ApiException($"project Not Found.");
                await _projectRepository.DeleteAsync(project);
                return new Response<Guid>(project.Id);
            }
        }
    }
}
