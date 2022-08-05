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
    public class GetMemberByIdQuery : IRequest<Response<Member>>
    {
        public Guid Id { get; set; }
        public class GetMemberByIdQueryHandler : IRequestHandler<GetMemberByIdQuery, Response<Member>>
        {
            private readonly IMemberRepositoryAsync _memberRepository;
            public GetMemberByIdQueryHandler(IMemberRepositoryAsync memberRepository)
            {
                _memberRepository = memberRepository;
            }
            public async Task<Response<Member>> Handle(GetMemberByIdQuery query, CancellationToken cancellationToken)
            {
                var member = await _memberRepository.GetByIdAsync(query.Id);
                if (member == null) throw new ApiException($"Member Not Found.");
                return new Response<Member>(member);
            }
        }
    }
}
