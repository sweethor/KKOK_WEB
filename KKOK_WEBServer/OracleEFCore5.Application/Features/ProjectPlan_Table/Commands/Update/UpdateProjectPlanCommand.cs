using MediatR;
using OracleEFCore5.Application.Exceptions;
using OracleEFCore5.Application.Interfaces.Repositories;
using OracleEFCore5.Application.Wrappers;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OracleEFCore5.Application.Features.DbTestTable.Commands.Update
{
    public class UpdateProjectPlanCommand : IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }
        public int Pjt_Code { get; set; }
        public int Member_Code { get; set; }
        public int Plan_Code { get; set; }
        public DateTime Plan_Start_Date { get; set; }
        public DateTime Plan_End_Date { get; set; }
        public string Plan_Description { get; set; }
        public class UpdateProjectPlanCommandHandler : IRequestHandler<UpdateProjectPlanCommand, Response<Guid>>
        {
            private readonly IProjectPlanRepositoryAsync _projectplanRepository;
            public UpdateProjectPlanCommandHandler(IProjectPlanRepositoryAsync projectplanRepository)
            {
                _projectplanRepository = projectplanRepository;
            }
            public async Task<Response<Guid>> Handle(UpdateProjectPlanCommand command, CancellationToken cancellationToken)
            {
                var projectplan = await _projectplanRepository.GetByIdAsync(command.Id);

                if (projectplan == null)
                {
                    throw new ApiException($"ProjectMember Not Found.");
                }
                else
                {
                    projectplan.Pjt_Code = command.Pjt_Code;
                    projectplan.Member_Code = command.Member_Code;
                    projectplan.Plan_Code = command.Plan_Code;
                    projectplan.Plan_Start_Date = command.Plan_Start_Date;
                    projectplan.Plan_End_Date = command.Plan_End_Date;
                    projectplan.Plan_Description = command.Plan_Description;
                    return new Response<Guid>(projectplan.Id);
                }
            }
        }
    }
}
