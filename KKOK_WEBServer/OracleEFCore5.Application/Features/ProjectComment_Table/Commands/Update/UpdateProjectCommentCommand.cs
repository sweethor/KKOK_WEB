using MediatR;
using OracleEFCore5.Application.Exceptions;
using OracleEFCore5.Application.Interfaces.Repositories;
using OracleEFCore5.Application.Wrappers;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OracleEFCore5.Application.Features.DbTestTable.Commands.Update
{
    public class UpdateProjectCommentCommand : IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }
        public int Pjt_Code { get; set; }

        public int Plan_Code { get; set; }

        public int Issue_Code { get; set; }

        public int Comment_Code { get; set; }

        public int Member_Code { get; set; }

        public string Member_Name { get; set; }

        public string Comment_Description { get; set; }

        public int Wr_Member_Code { get; set; }

        public string Wr_Member_Name { get; set; }  
        public class UpdateProjectCommentCommandHandler : IRequestHandler<UpdateProjectCommentCommand, Response<Guid>>
        {
            private readonly IProjectCommentRepositoryAsync _projectcommentRepository;
            public UpdateProjectCommentCommandHandler(IProjectCommentRepositoryAsync projectcommentRepository)
            {
                _projectcommentRepository = projectcommentRepository;
            }
            public async Task<Response<Guid>> Handle(UpdateProjectCommentCommand command, CancellationToken cancellationToken)
            {
                var projectcomment = await _projectcommentRepository.GetByIdAsync(command.Id);

                if (projectcomment == null)
                {
                    throw new ApiException($"Project Comment Not Found.");
                }
                else
                {
                    projectcomment.Pjt_Code = command.Pjt_Code;
                    projectcomment.Plan_Code = command.Plan_Code;
                    projectcomment.Issue_Code = command.Issue_Code;
                    projectcomment.Comment_Code = command.Comment_Code;
                    projectcomment.Member_Code = command.Member_Code;
                    projectcomment.Member_Name = command.Member_Name;
                    projectcomment.Comment_Description = command.Comment_Description;
                    projectcomment.Wr_Member_Code = command.Wr_Member_Code;
                    projectcomment.Wr_Member_Name = command.Wr_Member_Name;
                    return new Response<Guid>(projectcomment.Id);
                }
            }
        }
    }
}
