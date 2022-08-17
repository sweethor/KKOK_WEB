using MediatR;
using OracleEFCore5.Application.Exceptions;
using OracleEFCore5.Application.Interfaces.Repositories;
using OracleEFCore5.Application.Wrappers;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OracleEFCore5.Application.Features.DbTestTable.Commands.Delete
{
    public class DeleteProjectNoticeByIdCommand : IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }
        public class DeleteProjectNoticeByIdCommandHandler : IRequestHandler<DeleteProjectNoticeByIdCommand, Response<Guid>>
        {
            private readonly IProjectNoticeRepositoryAsync _projectnoticeRepository;
            public DeleteProjectNoticeByIdCommandHandler(IProjectNoticeRepositoryAsync projectnoticeRepository)
            {
                _projectnoticeRepository = projectnoticeRepository;
            }
            public async Task<Response<Guid>> Handle(DeleteProjectNoticeByIdCommand command, CancellationToken cancellationToken)
            {
                var projectnotice = await _projectnoticeRepository.GetByIdAsync(command.Id);
                if (projectnotice == null) throw new ApiException($"Project Notice Not Found.");
                await _projectnoticeRepository.DeleteAsync(projectnotice);
                return new Response<Guid>(projectnotice.Id);
            }
        }
    }
}
