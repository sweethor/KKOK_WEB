using MediatR;
using OracleEFCore5.Application.Interfaces.Repositories;
using OracleEFCore5.Application.Wrappers;
using System.Threading;
using System.Threading.Tasks;

namespace OracleEFCore5.Application.Features.DbTestTable.Commands.Create
{
    public partial class InsertMockTestTableCommand : IRequest<Response<int>>
    {
        public int RowCount { get; set; }
    }
    public class SeedTestTableCommandHandler : IRequestHandler<InsertMockTestTableCommand, Response<int>>
    {
        private readonly ITestTableRepositoryAsync _testtableRepository;
        public SeedTestTableCommandHandler(ITestTableRepositoryAsync testtableRepository)
        {
            _testtableRepository = testtableRepository;
        }

        public async Task<Response<int>> Handle(InsertMockTestTableCommand request, CancellationToken cancellationToken)
        {
            await _testtableRepository.SeedDataAsync(request.RowCount);
            return new Response<int>(request.RowCount);
        }
    }
}
