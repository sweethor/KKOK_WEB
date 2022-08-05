using MediatR;
using OracleEFCore5.Application.Exceptions;
using OracleEFCore5.Application.Interfaces.Repositories;
using OracleEFCore5.Application.Wrappers;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OracleEFCore5.Application.Features.DbTestTable.Commands.Delete
{
    public class DeleteTestTableByIdCommand : IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }
        public class DeleteTestTableByIdCommandHandler : IRequestHandler<DeleteTestTableByIdCommand, Response<Guid>>
        {
            private readonly ITestTableRepositoryAsync _testtableRepository;
            public DeleteTestTableByIdCommandHandler(ITestTableRepositoryAsync testtableRepository)
            {
                _testtableRepository = testtableRepository;
            }
            public async Task<Response<Guid>> Handle(DeleteTestTableByIdCommand command, CancellationToken cancellationToken)
            {
                var testTable = await _testtableRepository.GetByIdAsync(command.Id);
                if (testTable == null) throw new ApiException($"TestTable Not Found.");
                await _testtableRepository.DeleteAsync(testTable);
                return new Response<Guid>(testTable.Id);
            }
        }
    }
}
