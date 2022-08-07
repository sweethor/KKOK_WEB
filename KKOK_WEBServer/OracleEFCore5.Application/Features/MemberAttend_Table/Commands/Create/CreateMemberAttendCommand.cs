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
    public partial class CreateMemberAttendCommand : IRequest<Response<Guid>>
    {
        public int Pjt_Code { get; set; }
        public int Member_Code { get; set; }
        public string Member_Name { get; set; }
        public int Member_Issue_Cnt { get; set; }
        public int Member_Com_Issue { get; set; }
    }
    public class CreateMemberAttendCommandHandler : IRequestHandler<CreateMemberAttendCommand, Response<Guid>>
    {
        private readonly IMemberAttendRepositoryAsync _memberattendRepository;
        private readonly IMapper _mapper;
        public CreateMemberAttendCommandHandler(IMemberAttendRepositoryAsync memberattendRepository, IMapper mapper)
        {
            _memberattendRepository = memberattendRepository;
            _mapper = mapper;
        }

        public async Task<Response<Guid>> Handle(CreateMemberAttendCommand request, CancellationToken cancellationToken)
        {
            var memberattend = _mapper.Map<Member_Attend>(request);
            await _memberattendRepository.AddAsync(memberattend);
            return new Response<Guid>(memberattend.Id);
        }
    }
}
