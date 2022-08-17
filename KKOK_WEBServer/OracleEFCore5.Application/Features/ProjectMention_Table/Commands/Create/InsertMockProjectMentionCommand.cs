using MediatR;
using OracleEFCore5.Application.Interfaces.Repositories;
using OracleEFCore5.Application.Wrappers;
using System.Threading;
using System.Threading.Tasks;

namespace OracleEFCore5.Application.Features.DbTestTable.Commands.Create
{
    public partial class InsertMockProjectMentionCommand : IRequest<Response<int>>
    {
        public int RowCount { get; set; }
    }
    public class SeedProjectMentionCommandHandler : IRequestHandler<InsertMockProjectMentionCommand, Response<int>>
    {
        private readonly IProjectMentionRepositoryAsync _projectmentionRepository;
        public SeedProjectMentionCommandHandler(IProjectMentionRepositoryAsync projectmentionRepository)
        {
            _projectmentionRepository = projectmentionRepository;
        }

        public async Task<Response<int>> Handle(InsertMockProjectMentionCommand request, CancellationToken cancellationToken)
        {
            await _projectmentionRepository.SeedDataAsync(request.RowCount);
            return new Response<int>(request.RowCount);
        }
    }
}
