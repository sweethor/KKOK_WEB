using MediatR;
using OracleEFCore5.Application.Exceptions;
using OracleEFCore5.Application.Interfaces.Repositories;
using OracleEFCore5.Application.Wrappers;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OracleEFCore5.Application.Features.DbTestTable.Commands.Update
{
    public class UpdateMemberAttendCommand : IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }
        public int Pjt_Code { get; set; }
        public int Member_Code { get; set; }
        public string Member_Name { get; set; }
        public int Member_Issue_Cnt { get; set; }
        public int Member_Com_Issue { get; set; }
        public class UpdateMemberAttendCommandHandler : IRequestHandler<UpdateMemberAttendCommand, Response<Guid>>
        {
            private readonly IMemberAttendRepositoryAsync _memberattendRepository;
            public UpdateMemberAttendCommandHandler(IMemberAttendRepositoryAsync memberattendRepository)
            {
                _memberattendRepository = memberattendRepository;
            }
            public async Task<Response<Guid>> Handle(UpdateMemberAttendCommand command, CancellationToken cancellationToken)
            {
                var memberattend = await _memberattendRepository.GetByIdAsync(command.Id);

                if (memberattend == null)
                {
                    throw new ApiException($"Member Attend Not Found.");
                }
                else
                {
                    memberattend.Pjt_Code = command.Pjt_Code;
                    memberattend.Member_Code = command.Member_Code;
                    memberattend.Member_Name = command.Member_Name;
                    memberattend.Member_Issue_Cnt = command.Member_Issue_Cnt;
                    memberattend.Member_Com_Issue = command.Member_Com_Issue;
                    return new Response<Guid>(memberattend.Id);
                }
            }
        }
    }
}
