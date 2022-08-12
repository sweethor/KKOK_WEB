using MediatR;
using OracleEFCore5.Application.Exceptions;
using OracleEFCore5.Application.Interfaces.Repositories;
using OracleEFCore5.Application.Wrappers;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OracleEFCore5.Application.Features.DbTestTable.Commands.Update
{
    public class UpdateProjectPlanCheckListCommand : IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }

        public int Plan_Code { get; set; }

        public int Pjt_Code { get; set; }

        public int Plan_CheckList_Code { get; set; }

        public int Member_Code { get; set; }

        public string Plan_CheckList_Name { get; set; }

        public int Plan_CheckList_State { get; set; }

        public class UpdateProjectPlanCheckListCommandHandler : IRequestHandler<UpdateProjectPlanCheckListCommand, Response<Guid>>
        {
            private readonly IProjectPlanCheckListRepositoryAsync _projectplanchecklistRepository;
            public UpdateProjectPlanCheckListCommandHandler(IProjectPlanCheckListRepositoryAsync projectplanchecklistRepository)
            {
                _projectplanchecklistRepository = projectplanchecklistRepository;
            }
            public async Task<Response<Guid>> Handle(UpdateProjectPlanCheckListCommand command, CancellationToken cancellationToken)
            {
                var projectplanchecklist = await _projectplanchecklistRepository.GetByIdAsync(command.Id);

                if (projectplanchecklist == null)
                {
                    throw new ApiException($"Project PlanCheckList Not Found.");
                }
                else
                {
                    projectplanchecklist.Plan_Code = command.Plan_Code;
                    projectplanchecklist.Pjt_Code = command.Pjt_Code;
                    projectplanchecklist.Member_Code = command.Member_Code;
                    projectplanchecklist.Plan_CheckList_Code = command.Plan_CheckList_Code;
                    projectplanchecklist.Plan_CheckList_Name = command.Plan_CheckList_Name;
                    projectplanchecklist.Plan_CheckList_State = command.Plan_CheckList_State;
                    return new Response<Guid>(projectplanchecklist.Id);
                }
            }
        }
    }
}
