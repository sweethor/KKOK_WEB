using MediatR;
using OracleEFCore5.Application.Exceptions;
using OracleEFCore5.Application.Interfaces.Repositories;
using OracleEFCore5.Application.Wrappers;
using OracleEFCore5.Domain.Entities;
using OracleEFCore5.Domain.Entities.DBTables;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OracleEFCore5.Application.Features.DbTestTable.Queries.GetById
{
    public class GetMemberAttendByIdQuery : IRequest<Response<Member_Attend>>
    {
        public Guid Id { get; set; }
        public class GetMemberAttendByIdQueryHandler : IRequestHandler<GetMemberAttendByIdQuery, Response<Member_Attend>>
        {
            private readonly IMemberAttendRepositoryAsync _memberattendRepository;
            public GetMemberAttendByIdQueryHandler(IMemberAttendRepositoryAsync memberattendRepository)
            {
                _memberattendRepository = memberattendRepository;
            }
            public async Task<Response<Member_Attend>> Handle(GetMemberAttendByIdQuery query, CancellationToken cancellationToken)
            {
                var memberattend = await _memberattendRepository.GetByIdAsync(query.Id);
                if (memberattend == null) throw new ApiException($"Member Attend Not Found.");
                return new Response<Member_Attend>(memberattend);
            }
        }
    }
}
