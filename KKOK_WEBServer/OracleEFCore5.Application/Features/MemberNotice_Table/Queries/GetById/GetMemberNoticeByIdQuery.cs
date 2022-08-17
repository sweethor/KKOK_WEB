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
    public class GetMemberNoticeByIdQuery : IRequest<Response<Member_Notice>>
    {
        public Guid Id { get; set; }
        public class GetMemberNoticeByIdQueryHandler : IRequestHandler<GetMemberNoticeByIdQuery, Response<Member_Notice>>
        {
            private readonly IMemberNoticeRepositoryAsync _membernoticeRepository;
            public GetMemberNoticeByIdQueryHandler(IMemberNoticeRepositoryAsync membernoticeRepository)
            {
                _membernoticeRepository = membernoticeRepository;
            }
            public async Task<Response<Member_Notice>> Handle(GetMemberNoticeByIdQuery query, CancellationToken cancellationToken)
            {
                var membernotice = await _membernoticeRepository.GetByIdAsync(query.Id);
                if (membernotice == null) throw new ApiException($"Member Notice Not Found.");
                return new Response<Member_Notice>(membernotice);
            }
        }
    }
}
