using MediatR;
using OracleEFCore5.Application.Interfaces.Repositories;
using OracleEFCore5.Application.Wrappers;
using System.Threading;
using System.Threading.Tasks;

namespace OracleEFCore5.Application.Features.Project_Table.Commands.Create
{
    public partial class InsertMockProjectCommand : IRequest<Response<int>>
    {
        public int RowCount { get; set; }
    }
    public class SeedProjectCommandHandler : IRequestHandler<InsertMockProjectCommand, Response<int>>
    {
        private readonly IProjectRepositoryAsync _projectRepository;
        public SeedProjectCommandHandler(IProjectRepositoryAsync projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<Response<int>> Handle(InsertMockProjectCommand request, CancellationToken cancellationToken)
        {
            await _projectRepository.SeedDataAsync(request.RowCount);
            return new Response<int>(request.RowCount);
        }
    }
}
