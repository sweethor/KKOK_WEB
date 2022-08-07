using MediatR;
using OracleEFCore5.Application.Exceptions;
using OracleEFCore5.Application.Interfaces.Repositories;
using OracleEFCore5.Application.Wrappers;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OracleEFCore5.Application.Features.DbTestTable.Commands.Delete
{
    public class DeleteProjectPlanByIdCommand : IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }
        public class DeleteProjectPlanByIdCommandHandler : IRequestHandler<DeleteProjectPlanByIdCommand, Response<Guid>>
        {
            private readonly IProjectPlanRepositoryAsync _projectplanRepository;
            public DeleteProjectPlanByIdCommandHandler(IProjectPlanRepositoryAsync projectplanRepository)
            {
                _projectplanRepository = projectplanRepository;
            }
            public async Task<Response<Guid>> Handle(DeleteProjectPlanByIdCommand command, CancellationToken cancellationToken)
            {
                var projectplan = await _projectplanRepository.GetByIdAsync(command.Id);
                if (projectplan == null) throw new ApiException($"Projectmember Not Found.");
                await _projectplanRepository.DeleteAsync(projectplan);
                return new Response<Guid>(projectplan.Id);
            }
        }
    }
}
