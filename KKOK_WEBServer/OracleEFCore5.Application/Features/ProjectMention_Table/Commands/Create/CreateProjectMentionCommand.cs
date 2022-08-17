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
    public partial class CreateProjectMentionCommand : IRequest<Response<Guid>>
    {
        public int Comment_Code { get; set; }

        public int Pjt_Code { get; set; }

        public int Plan_Code { get; set; }

        public int Issue_Code { get; set; }

        public int Member_Code { get; set; }

        public int Ref_Member_Code { get; set; }

        public string Ref_Member_Name { get; set; }
    }
    public class CreateProjectMentionCommandHandler : IRequestHandler<CreateProjectMentionCommand, Response<Guid>>
    {
        private readonly IProjectMentionRepositoryAsync _projectmentionRepository;
        private readonly IMapper _mapper;
        public CreateProjectMentionCommandHandler(IProjectMentionRepositoryAsync projectmentionRepository, IMapper mapper)
        {
            _projectmentionRepository = projectmentionRepository;
            _mapper = mapper;
        }

        public async Task<Response<Guid>> Handle(CreateProjectMentionCommand request, CancellationToken cancellationToken)
        {
            var projectmention = _mapper.Map<Pjt_Mention>(request);
            await _projectmentionRepository.AddAsync(projectmention);
            return new Response<Guid>(projectmention.Id);
        }
    }
}
