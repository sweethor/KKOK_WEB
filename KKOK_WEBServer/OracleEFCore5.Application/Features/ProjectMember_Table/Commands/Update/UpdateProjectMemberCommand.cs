using MediatR;
using OracleEFCore5.Application.Exceptions;
using OracleEFCore5.Application.Interfaces.Repositories;
using OracleEFCore5.Application.Wrappers;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OracleEFCore5.Application.Features.DbTestTable.Commands.Update
{
    public class UpdateProjectMemberCommand : IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }
        public int Pjt_Code { get; set; }
        public int Member_Code { get; set; }
        public string Member_Name { get; set; }
        public string Member_Job { get; set; }
        public string Member_Pjt_Permission { get; set; }
        public class UpdateProjectMemberCommandHandler : IRequestHandler<UpdateProjectMemberCommand, Response<Guid>>
        {
            private readonly IProjectMemberRepositoryAsync _projectmemberRepository;
            public UpdateProjectMemberCommandHandler(IProjectMemberRepositoryAsync projectmemberRepository)
            {
                _projectmemberRepository = projectmemberRepository;
            }
            public async Task<Response<Guid>> Handle(UpdateProjectMemberCommand command, CancellationToken cancellationToken)
            {
                var projectmember = await _projectmemberRepository.GetByIdAsync(command.Id);

                if (projectmember == null)
                {
                    throw new ApiException($"ProjectMember Not Found.");
                }
                else
                {
                    projectmember.Pjt_Code = command.Pjt_Code;
                    projectmember.Member_Code = command.Member_Code;
                    projectmember.Member_Name = command.Member_Name;
                    projectmember.Member_Job = command.Member_Job;
                    projectmember.Member_Pjt_Permission = command.Member_Pjt_Permission;
                    return new Response<Guid>(projectmember.Id);
                }
            }
        }
    }
}
