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
    public class GetProjectNoticeByIdQuery : IRequest<Response<Pjt_Notice>>
    {
        public Guid Id { get; set; }
        public class GetProjectNoticeByIdQueryHandler : IRequestHandler<GetProjectNoticeByIdQuery, Response<Pjt_Notice>>
        {
            private readonly IProjectNoticeRepositoryAsync _projectnoticeRepository;
            public GetProjectNoticeByIdQueryHandler(IProjectNoticeRepositoryAsync projectnoticeRepository)
            {
                _projectnoticeRepository = projectnoticeRepository;
            }
            public async Task<Response<Pjt_Notice>> Handle(GetProjectNoticeByIdQuery query, CancellationToken cancellationToken)
            {
                var projectnotice = await _projectnoticeRepository.GetByIdAsync(query.Id);
                if (projectnotice == null) throw new ApiException($"Project Notice Not Found.");
                return new Response<Pjt_Notice>(projectnotice);
            }
        }
    }
}
