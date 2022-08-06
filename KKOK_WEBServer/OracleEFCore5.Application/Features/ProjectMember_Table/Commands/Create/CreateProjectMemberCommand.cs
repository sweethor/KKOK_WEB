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
    public partial class CreateProjectMemberCommand : IRequest<Response<Guid>>
    {
        public string Pjt_Code { get; set; }
        public string Member_Code { get; set; }
        public string Member_Name { get; set; }
        public string Member_Job { get; set; }
        public string Member_Pjt_Permission { get; set; }
    }
    public class CreateProjectMemberCommandHandler : IRequestHandler<CreateProjectMemberCommand, Response<Guid>>
    {
        private readonly IProjectMemberRepositoryAsync _projectmemberRepository;
        private readonly IMapper _mapper;
        public CreateProjectMemberCommandHandler(IProjectMemberRepositoryAsync projectmemberRepository, IMapper mapper)
        {
            _projectmemberRepository = projectmemberRepository;
            _mapper = mapper;
        }

        public async Task<Response<Guid>> Handle(CreateProjectMemberCommand request, CancellationToken cancellationToken)
        {
            var projectmember = _mapper.Map<Pjt_Member>(request);
            await _projectmemberRepository.AddAsync(projectmember);
            return new Response<Guid>(projectmember.Id);
        }
    }
}
