using MediatR;
using OracleEFCore5.Application.Exceptions;
using OracleEFCore5.Application.Interfaces.Repositories;
using OracleEFCore5.Application.Wrappers;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OracleEFCore5.Application.Features.DbTestTable.Commands.Update
{
    public class UpdateMemberNoticeCommand : IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }
        public int Pjt_Code { get; set; }

        public int Member_Code { get; set; }

        public int Plan_Code { get; set; }

        public int Issue_Code { get; set; }

        public string Notice_Name { get; set; }
        public class UpdateMemberNoticeCommandHandler : IRequestHandler<UpdateMemberNoticeCommand, Response<Guid>>
        {
            private readonly IMemberNoticeRepositoryAsync _membernoticeRepository;
            public UpdateMemberNoticeCommandHandler(IMemberNoticeRepositoryAsync membernoticeRepository)
            {
                _membernoticeRepository = membernoticeRepository;
            }
            public async Task<Response<Guid>> Handle(UpdateMemberNoticeCommand command, CancellationToken cancellationToken)
            {
                var membernotice = await _membernoticeRepository.GetByIdAsync(command.Id);

                if (membernotice == null)
                {
                    throw new ApiException($"Member Notice Not Found.");
                }
                else
                {
                    membernotice.Pjt_Code = command.Pjt_Code;
                    membernotice.Member_Code = command.Member_Code;
                    membernotice.Plan_Code = command.Plan_Code;
                    membernotice.Issue_Code = command.Issue_Code;
                    membernotice.Notice_Name = command.Notice_Name;
                    return new Response<Guid>(membernotice.Id);
                }
            }
        }
    }
}
