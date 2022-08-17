using MediatR;
using OracleEFCore5.Application.Exceptions;
using OracleEFCore5.Application.Interfaces.Repositories;
using OracleEFCore5.Application.Wrappers;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OracleEFCore5.Application.Features.DbTestTable.Commands.Delete
{
    public class DeleteProjectMemberByIdCommand : IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }
        public class DeleteProjectMemberByIdCommandHandler : IRequestHandler<DeleteProjectMemberByIdCommand, Response<Guid>>
        {
            private readonly IProjectMemberRepositoryAsync _projectmemberRepository;
            public DeleteProjectMemberByIdCommandHandler(IProjectMemberRepositoryAsync projectmemberRepository)
            {
                _projectmemberRepository = projectmemberRepository;
            }
            public async Task<Response<Guid>> Handle(DeleteProjectMemberByIdCommand command, CancellationToken cancellationToken)
            {
                var projectmember = await _projectmemberRepository.GetByIdAsync(command.Id);
                if (projectmember == null) throw new ApiException($"Projectmember Not Found.");
                await _projectmemberRepository.DeleteAsync(projectmember);
                return new Response<Guid>(projectmember.Id);
            }
        }
    }
}
