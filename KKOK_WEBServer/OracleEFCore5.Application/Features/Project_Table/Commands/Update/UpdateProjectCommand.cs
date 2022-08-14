using MediatR;
using OracleEFCore5.Application.Exceptions;
using OracleEFCore5.Application.Interfaces.Repositories;
using OracleEFCore5.Application.Wrappers;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OracleEFCore5.Application.Features.Project_Table.Commands.Update
{
    public class UpdateProjectCommand : IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }
        public string pjt_code { get; set; }
        public string pjt_name { get; set; }
        public DateTime pjt_startdate { get; set; }
        public DateTime pjt_enddate { get; set; }
        public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, Response<Guid>>
        {
            private readonly IProjectRepositoryAsync _projectRepository;
            public UpdateProjectCommandHandler(IProjectRepositoryAsync projectRepository)
            {
                _projectRepository = projectRepository;
            }
            public async Task<Response<Guid>> Handle(UpdateProjectCommand command, CancellationToken cancellationToken)
            {
                var project = await _projectRepository.GetByIdAsync(command.Id);

                if (project == null)
                {
                    throw new ApiException($"project Not Found.");
                }
                else
                {
                    project.pjt_code = command.pjt_code;
                    project.pjt_name = command.pjt_name;
                    project.pjt_startdate = command.pjt_startdate;
                    project.pjt_enddate = command.pjt_enddate;
                    await _projectRepository.UpdateAsync(project);
                    return new Response<Guid>(project.Id);
                }
            }
        }
    }
}
