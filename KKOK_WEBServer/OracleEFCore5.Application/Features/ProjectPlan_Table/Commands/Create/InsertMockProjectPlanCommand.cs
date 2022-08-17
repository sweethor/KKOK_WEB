using MediatR;
using OracleEFCore5.Application.Interfaces.Repositories;
using OracleEFCore5.Application.Wrappers;
using System.Threading;
using System.Threading.Tasks;

namespace OracleEFCore5.Application.Features.DbTestTable.Commands.Create
{
    public partial class InsertMockProjectPlanCommand : IRequest<Response<int>>
    {
        public int RowCount { get; set; }
    }
    public class SeedProjectPlanCommandHandler : IRequestHandler<InsertMockProjectPlanCommand, Response<int>>
    {
        private readonly IProjectPlanRepositoryAsync _projectplanRepository;
        public SeedProjectPlanCommandHandler(IProjectPlanRepositoryAsync projectplanRepository)
        {
            _projectplanRepository = projectplanRepository;
        }

        public async Task<Response<int>> Handle(InsertMockProjectPlanCommand request, CancellationToken cancellationToken)
        {
            await _projectplanRepository.SeedDataAsync(request.RowCount);
            return new Response<int>(request.RowCount);
        }
    }
}
