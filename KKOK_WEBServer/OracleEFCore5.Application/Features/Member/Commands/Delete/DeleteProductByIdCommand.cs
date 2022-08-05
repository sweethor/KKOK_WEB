using MediatR;
using OracleEFCore5.Application.Exceptions;
using OracleEFCore5.Application.Interfaces.Repositories;
using OracleEFCore5.Application.Wrappers;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OracleEFCore5.Application.Features.DbTestTable.Commands.Delete
{
    public class DeleteMemberByIdCommand : IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }
        public class DeleteMemberByIdCommandHandler : IRequestHandler<DeleteMemberByIdCommand, Response<Guid>>
        {
            private readonly IMemberRepositoryAsync _memberRepository;
            public DeleteMemberByIdCommandHandler(IMemberRepositoryAsync memberRepository)
            {
                _memberRepository = memberRepository;
            }
            public async Task<Response<Guid>> Handle(DeleteMemberByIdCommand command, CancellationToken cancellationToken)
            {
                var member = await _memberRepository.GetByIdAsync(command.Id);
                if (member == null) throw new ApiException($"member Not Found.");
                await _memberRepository.DeleteAsync(member);
                return new Response<Guid>(member.Id);
            }
        }
    }
}
