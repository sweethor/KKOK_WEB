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
    public class GetTestTableByIdQuery : IRequest<Response<TestTable>>
    {
        public Guid Id { get; set; }
        public class GetTestTableByIdQueryHandler : IRequestHandler<GetTestTableByIdQuery, Response<TestTable>>
        {
            private readonly ITestTableRepositoryAsync _testtableRepository;
            public GetTestTableByIdQueryHandler(ITestTableRepositoryAsync testtableRepository)
            {
                _testtableRepository = testtableRepository;
            }
            public async Task<Response<TestTable>> Handle(GetTestTableByIdQuery query, CancellationToken cancellationToken)
            {
                var testTable = await _testtableRepository.GetByIdAsync(query.Id);
                if (testTable == null) throw new ApiException($"TestTable Not Found.");
                return new Response<TestTable>(testTable);
            }
        }
    }
}
