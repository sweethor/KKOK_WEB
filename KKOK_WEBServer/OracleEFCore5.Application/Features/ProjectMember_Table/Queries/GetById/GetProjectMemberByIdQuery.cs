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
    public class GetProjectMemberByIdQuery : IRequest<Response<Pjt_Member>>
    {
        public Guid Id { get; set; }
        public class GetProjectMemberByIdQueryHandler : IRequestHandler<GetProjectMemberByIdQuery, Response<Pjt_Member>>
        {
            private readonly IProjectMemberRepositoryAsync _projectmemberRepository;
            public GetProjectMemberByIdQueryHandler(IProjectMemberRepositoryAsync projectmemberRepository)
            {
                _projectmemberRepository = projectmemberRepository;
            }
            public async Task<Response<Pjt_Member>> Handle(GetProjectMemberByIdQuery query, CancellationToken cancellationToken)
            {
                var projectmember = await _projectmemberRepository.GetByIdAsync(query.Id);
                if (projectmember == null) throw new ApiException($"ProjectMember Not Found.");
                return new Response<Pjt_Member>(projectmember);
            }
        }
    }
}
