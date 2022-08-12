using MediatR;
using OracleEFCore5.Application.Exceptions;
using OracleEFCore5.Application.Interfaces.Repositories;
using OracleEFCore5.Application.Wrappers;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OracleEFCore5.Application.Features.DbTestTable.Commands.Update
{
    public class UpdateProjectMentionCommand : IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }
        public int Comment_Code { get; set; }

        public int Pjt_Code { get; set; }

        public int Plan_Code { get; set; }

        public int Issue_Code { get; set; }

        public int Member_Code { get; set; }

        public int Ref_Member_Code { get; set; }

        public string Ref_Member_Name { get; set; }

        public class UpdateProjectMentionCommandHandler : IRequestHandler<UpdateProjectMentionCommand, Response<Guid>>
        {
            private readonly IProjectMentionRepositoryAsync _projectmentionRepository;
            public UpdateProjectMentionCommandHandler(IProjectMentionRepositoryAsync projectmentionRepository)
            {
                _projectmentionRepository = projectmentionRepository;
            }
            public async Task<Response<Guid>> Handle(UpdateProjectMentionCommand command, CancellationToken cancellationToken)
            {
                var projectmention = await _projectmentionRepository.GetByIdAsync(command.Id);

                if (projectmention == null)
                {
                    throw new ApiException($"Project Mention Not Found.");
                }
                else
                {
                    projectmention.Comment_Code = command.Comment_Code;
                    projectmention.Pjt_Code = command.Pjt_Code;
                    projectmention.Plan_Code = command.Plan_Code;
                    projectmention.Issue_Code = command.Issue_Code;
                    projectmention.Member_Code = command.Member_Code;
                    projectmention.Ref_Member_Code = command.Ref_Member_Code;
                    projectmention.Ref_Member_Name = command.Ref_Member_Name;
                    return new Response<Guid>(projectmention.Id);
                }
            }
        }
    }
}
