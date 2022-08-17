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
    public partial class CreateProjectPlanCommand : IRequest<Response<Guid>>
    {
        public int pjt_code { get; set; }
        public int member_code { get; set; }
        public int plan_code { get; set; }
        public DateTime plan_start_date { get; set; }
        public DateTime plan_end_date { get; set; }
        public string plan_description { get; set; }
    }
    public class CreateProjectPlanCommandHandler : IRequestHandler<CreateProjectPlanCommand, Response<Guid>>
    {
        private readonly IProjectPlanRepositoryAsync _projectplanRepository;
        private readonly IMapper _mapper;
        public CreateProjectPlanCommandHandler(IProjectPlanRepositoryAsync projectplanRepository, IMapper mapper)
        {
            _projectplanRepository = projectplanRepository;
            _mapper = mapper;
        }

        public async Task<Response<Guid>> Handle(CreateProjectPlanCommand request, CancellationToken cancellationToken)
        {
            var projectplan = _mapper.Map<Pjt_Plan>(request);
            await _projectplanRepository.AddAsync(projectplan);
            return new Response<Guid>(projectplan.Id);
        }
    }
}
