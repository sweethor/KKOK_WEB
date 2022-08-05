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
    public partial class CreateTestTableCommand : IRequest<Response<Guid>>
    {
        public string TestName { get; set; }
    }
    public class CreateTestTableCommandHandler : IRequestHandler<CreateTestTableCommand, Response<Guid>>
    {
        private readonly ITestTableRepositoryAsync _testtableRepository;
        private readonly IMapper _mapper;
        public CreateTestTableCommandHandler(ITestTableRepositoryAsync testtableRepository, IMapper mapper)
        {
            _testtableRepository = testtableRepository;
            _mapper = mapper;
        }

        public async Task<Response<Guid>> Handle(CreateTestTableCommand request, CancellationToken cancellationToken)
        {
            var TestTable = _mapper.Map<TestTable>(request);
            await _testtableRepository.AddAsync(TestTable);
            return new Response<Guid>(TestTable.Id);
        }
    }
}
