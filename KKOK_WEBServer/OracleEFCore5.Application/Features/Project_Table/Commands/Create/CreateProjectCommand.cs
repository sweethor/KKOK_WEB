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
    public partial class CreateProjectCommand : IRequest<Response<Guid>>
    {
        public string pjt_code { get; set; }
        public string pjt_name { get; set; }
        public DateTime pjt_startdate { get; set; }
        public DateTime pjt_enddate { get; set; }
    }
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, Response<Guid>>
    {
        private readonly IProjectRepositoryAsync _projectRepository;
        private readonly IMapper _mapper;
        public CreateProjectCommandHandler(IProjectRepositoryAsync projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        public async Task<Response<Guid>> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = _mapper.Map<Project>(request);
            await _projectRepository.AddAsync(project);
            return new Response<Guid>(project.Id);
        }
    }
}
