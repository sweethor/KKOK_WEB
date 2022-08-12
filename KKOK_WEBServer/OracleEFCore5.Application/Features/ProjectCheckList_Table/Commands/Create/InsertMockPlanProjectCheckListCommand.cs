using MediatR;
using OracleEFCore5.Application.Interfaces.Repositories;
using OracleEFCore5.Application.Wrappers;
using System.Threading;
using System.Threading.Tasks;

namespace OracleEFCore5.Application.Features.DbTestTable.Commands.Create
{
    public partial class InsertMockProjectPlanCheckListCommand : IRequest<Response<int>>
    {
        public int RowCount { get; set; }
    }
    public class SeedProjectPlanCheckListCommandHandler : IRequestHandler<InsertMockProjectPlanCheckListCommand, Response<int>>
    {
        private readonly IProjectPlanCheckListRepositoryAsync _projectplanchecklistRepository;
        public SeedProjectPlanCheckListCommandHandler(IProjectPlanCheckListRepositoryAsync projectplanchecklistRepository)
        {
            _projectplanchecklistRepository = projectplanchecklistRepository;
        }

        public async Task<Response<int>> Handle(InsertMockProjectPlanCheckListCommand request, CancellationToken cancellationToken)
        {
            await _projectplanchecklistRepository.SeedDataAsync(request.RowCount);
            return new Response<int>(request.RowCount);
        }
    }
}
