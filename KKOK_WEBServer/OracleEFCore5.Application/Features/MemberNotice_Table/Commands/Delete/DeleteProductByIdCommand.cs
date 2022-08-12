using MediatR;
using OracleEFCore5.Application.Exceptions;
using OracleEFCore5.Application.Interfaces.Repositories;
using OracleEFCore5.Application.Wrappers;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OracleEFCore5.Application.Features.DbTestTable.Commands.Delete
{
    public class DeleteMemberNoticeByIdCommand : IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }
        public class DeleteMemberNoticeByIdCommandHandler : IRequestHandler<DeleteMemberNoticeByIdCommand, Response<Guid>>
        {
            private readonly IMemberNoticeRepositoryAsync _membernoticeRepository;
            public DeleteMemberNoticeByIdCommandHandler(IMemberNoticeRepositoryAsync membernoticeRepository)
            {
                _membernoticeRepository = membernoticeRepository;
            }
            public async Task<Response<Guid>> Handle(DeleteMemberNoticeByIdCommand command, CancellationToken cancellationToken)
            {
                var membernotice = await _membernoticeRepository.GetByIdAsync(command.Id);
                if (membernotice == null) throw new ApiException($"member notice Not Found.");
                await _membernoticeRepository.DeleteAsync(membernotice);
                return new Response<Guid>(membernotice.Id);
            }
        }
    }
}
