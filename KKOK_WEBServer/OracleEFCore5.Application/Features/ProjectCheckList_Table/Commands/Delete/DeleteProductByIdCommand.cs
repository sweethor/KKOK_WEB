using MediatR;
using OracleEFCore5.Application.Exceptions;
using OracleEFCore5.Application.Interfaces.Repositories;
using OracleEFCore5.Application.Wrappers;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OracleEFCore5.Application.Features.DbTestTable.Commands.Delete
{
    public class DeleteProjectPlanCheckListByIdCommand : IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }
        public class DeleteProjectPlanCheckListByIdCommandHandler : IRequestHandler<DeleteProjectPlanCheckListByIdCommand, Response<Guid>>
        {
            private readonly IProjectPlanCheckListRepositoryAsync _projectplanchecklistRepository;
            public DeleteProjectPlanCheckListByIdCommandHandler(IProjectPlanCheckListRepositoryAsync projectplanchecklistRepository)
            {
                _projectplanchecklistRepository = projectplanchecklistRepository;
            }
            public async Task<Response<Guid>> Handle(DeleteProjectPlanCheckListByIdCommand command, CancellationToken cancellationToken)
            {
                var projectplanchecklist = await _projectplanchecklistRepository.GetByIdAsync(command.Id);
                if (projectplanchecklist == null) throw new ApiException($"Project Plan CheckList Not Found.");
                await _projectplanchecklistRepository.DeleteAsync(projectplanchecklist);
                return new Response<Guid>(projectplanchecklist.Id);
            }
        }
    }
}
