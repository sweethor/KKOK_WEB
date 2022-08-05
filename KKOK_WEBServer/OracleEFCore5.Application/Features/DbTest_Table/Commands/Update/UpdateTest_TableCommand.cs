using MediatR;
using OracleEFCore5.Application.Exceptions;
using OracleEFCore5.Application.Interfaces.Repositories;
using OracleEFCore5.Application.Wrappers;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OracleEFCore5.Application.Features.DbTestTable.Commands.Update
{
    public class UpdateTestTableCommand : IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }
        public string testName { get; set; }
        public class UpdateTestTableCommandHandler : IRequestHandler<UpdateTestTableCommand, Response<Guid>>
        {
            private readonly ITestTableRepositoryAsync _testtableRepository;
            public UpdateTestTableCommandHandler(ITestTableRepositoryAsync testtableRepository)
            {
                _testtableRepository = testtableRepository;
            }
            public async Task<Response<Guid>> Handle(UpdateTestTableCommand command, CancellationToken cancellationToken)
            {
                var testTable = await _testtableRepository.GetByIdAsync(command.Id);

                if (testTable == null)
                {
                    throw new ApiException($"TestTable Not Found.");
                }
                else
                {
                    testTable.test_name = command.testName;
                    await _testtableRepository.UpdateAsync(testTable);
                    return new Response<Guid>(testTable.Id);
                }
            }
        }
    }
}
