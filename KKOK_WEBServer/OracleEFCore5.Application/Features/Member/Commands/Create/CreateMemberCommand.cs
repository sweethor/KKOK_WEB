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
    public partial class CreateMemberCommand : IRequest<Response<Guid>>
    {
        public string Member_Code { get; set; }
        public string Member_ID { get; set; }
        public string Member_PWD { get; set; }
        public string Member_Name { get; set; }
        public string Member_Email { get; set; }
        public string Member_Phone { get; set; }
        public string Member_Permission { get; set; }
    }
    public class CreateMemberCommandHandler : IRequestHandler<CreateMemberCommand, Response<Guid>>
    {
        private readonly IMemberRepositoryAsync _memberRepository;
        private readonly IMapper _mapper;
        public CreateMemberCommandHandler(IMemberRepositoryAsync memberRepository, IMapper mapper)
        {
            _memberRepository = memberRepository;
            _mapper = mapper;
        }

        public async Task<Response<Guid>> Handle(CreateMemberCommand request, CancellationToken cancellationToken)
        {
            var member = _mapper.Map<Member>(request);
            await _memberRepository.AddAsync(member);
            return new Response<Guid>(member.Id);
        }
    }
}
