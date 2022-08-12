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
    public partial class CreateMemberNoticeCommand : IRequest<Response<Guid>>
    {
        public int Pjt_Code { get; set; }

        public int Member_Code { get; set; }

        public int Plan_Code { get; set; }

        public int Issue_Code { get; set; }

        public string Notice_Name { get; set; }
    }
    public class CreateMemberNoticeCommandHandler : IRequestHandler<CreateMemberNoticeCommand, Response<Guid>>
    {
        private readonly IMemberNoticeRepositoryAsync _membernoticeRepository;
        private readonly IMapper _mapper;
        public CreateMemberNoticeCommandHandler(IMemberNoticeRepositoryAsync membernoticeRepository, IMapper mapper)
        {
            _membernoticeRepository = membernoticeRepository;
            _mapper = mapper;
        }

        public async Task<Response<Guid>> Handle(CreateMemberNoticeCommand request, CancellationToken cancellationToken)
        {
            var membernotice = _mapper.Map<Member_Notice>(request);
            await _membernoticeRepository.AddAsync(membernotice);
            return new Response<Guid>(membernotice.Id);
        }
    }
}
