using AutoMapper;
using MediatR;
using OracleEFCore5.Application.Interfaces.Repositories;
using OracleEFCore5.Application.Wrappers;
using OracleEFCore5.Domain.Entities;
using OracleEFCore5.Domain.Entities.DBTables;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OracleEFCore5.Application.Features.DbTestTable.Commands.Create
{
    public partial class CreateProjectPlanCheckListCommand : IRequest<Response<Guid>>
    {
        public int Plan_Code { get; set; }

        public int Pjt_Code { get; set; }

        public int Plan_CheckList_Code { get; set; }

        public int Member_Code { get; set; }

        public string Plan_CheckList_Name { get; set; }

        public int Plan_CheckList_State { get; set; }
    }
    public class CreateProjectPlanCheckListCommandHandler : IRequestHandler<CreateProjectPlanCheckListCommand, Response<Guid>>
    {
        private readonly IProjectPlanCheckListRepositoryAsync _projectplanchecklistRepository;
        private readonly IMapper _mapper;
        public CreateProjectPlanCheckListCommandHandler(IProjectPlanCheckListRepositoryAsync projectplanchecklistRepository, IMapper mapper)
        {
            _projectplanchecklistRepository = projectplanchecklistRepository;
            _mapper = mapper;
        }

        public async Task<Response<Guid>> Handle(CreateProjectPlanCheckListCommand request, CancellationToken cancellationToken)
        {
            var projectplanchecklist = _mapper.Map<Pjt_Plan_CheckList>(request);
            await _projectplanchecklistRepository.AddAsync(projectplanchecklist);
            return new Response<Guid>(projectplanchecklist.Id);
        }
    }
}
