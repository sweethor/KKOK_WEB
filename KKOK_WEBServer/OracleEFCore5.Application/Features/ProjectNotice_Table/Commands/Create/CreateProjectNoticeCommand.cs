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
    public partial class CreateProjectNoticeCommand : IRequest<Response<Guid>>
    {
        public int Pjt_Code { get; set; }

        public int Member_Code { get; set; }

        public int Notice_Code { get; set; }

        public string Member_Name { get; set; }

        public DateTime Notice_Date { get; set; }

        public string Notice_Name { get; set; }

        public string Notice_Description { get; set; }
    }
    public class CreateProjectNoticeCommandHandler : IRequestHandler<CreateProjectNoticeCommand, Response<Guid>>
    {
        private readonly IProjectNoticeRepositoryAsync _projectnoticeRepository;
        private readonly IMapper _mapper;
        public CreateProjectNoticeCommandHandler(IProjectNoticeRepositoryAsync projectnoticeRepository, IMapper mapper)
        {
            _projectnoticeRepository = projectnoticeRepository;
            _mapper = mapper;
        }

        public async Task<Response<Guid>> Handle(CreateProjectNoticeCommand request, CancellationToken cancellationToken)
        {
            var projectnotice = _mapper.Map<Pjt_Notice>(request);
            await _projectnoticeRepository.AddAsync(projectnotice);
            return new Response<Guid>(projectnotice.Id);
        }
    }
}
