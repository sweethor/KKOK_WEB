using MediatR;
using OracleEFCore5.Application.Exceptions;
using OracleEFCore5.Application.Interfaces.Repositories;
using OracleEFCore5.Application.Wrappers;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OracleEFCore5.Application.Features.DbTestTable.Commands.Update
{
    public class UpdateMemberCommand : IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }
        public string Member_Code { get; set; }
        public string Member_ID { get; set; }
        public string Member_PWD { get; set; }
        public string Member_Name { get; set; }
        public string Member_Email { get; set; }
        public string Member_Phone { get; set; }
        public string Member_Permission { get; set; }
        public class UpdateMemberCommandHandler : IRequestHandler<UpdateMemberCommand, Response<Guid>>
        {
            private readonly IMemberRepositoryAsync _memberRepository;
            public UpdateMemberCommandHandler(IMemberRepositoryAsync memberRepository)
            {
                _memberRepository = memberRepository;
            }
            public async Task<Response<Guid>> Handle(UpdateMemberCommand command, CancellationToken cancellationToken)
            {
                var member = await _memberRepository.GetByIdAsync(command.Id);

                if (member == null)
                {
                    throw new ApiException($"Member Not Found.");
                }
                else
                {
                    member.Member_Code = command.Member_Code;
                    member.Member_Name = command.Member_Name;
                    member.Member_Email = command.Member_Email;
                    member.Member_Phone = command.Member_Phone;
                    member.Member_ID = command.Member_ID;
                    member.Member_PWD = member.Member_PWD;
                    member.Member_Permission = member.Member_Permission;
                    await _memberRepository.UpdateAsync(member);
                    return new Response<Guid>(member.Id);
                }
            }
        }
    }
}
