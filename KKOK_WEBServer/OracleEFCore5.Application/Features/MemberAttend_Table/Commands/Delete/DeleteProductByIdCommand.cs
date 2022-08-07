using MediatR;
using OracleEFCore5.Application.Exceptions;
using OracleEFCore5.Application.Interfaces.Repositories;
using OracleEFCore5.Application.Wrappers;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OracleEFCore5.Application.Features.DbTestTable.Commands.Delete
{
    public class DeleteMemberAttendByIdCommand : IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }
        public class DeleteMemberAttendByIdCommandHandler : IRequestHandler<DeleteMemberAttendByIdCommand, Response<Guid>>
        {
            private readonly IMemberAttendRepositoryAsync _memberattendRepository;
            public DeleteMemberAttendByIdCommandHandler(IMemberAttendRepositoryAsync memberattendRepository)
            {
                _memberattendRepository = memberattendRepository;
            }
            public async Task<Response<Guid>> Handle(DeleteMemberAttendByIdCommand command, CancellationToken cancellationToken)
            {
                var memberattend = await _memberattendRepository.GetByIdAsync(command.Id);
                if (memberattend == null) throw new ApiException($"member attend Not Found.");
                await _memberattendRepository.DeleteAsync(memberattend);
                return new Response<Guid>(memberattend.Id);
            }
        }
    }
}
