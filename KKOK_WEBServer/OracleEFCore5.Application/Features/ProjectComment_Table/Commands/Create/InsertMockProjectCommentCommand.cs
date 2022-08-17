using MediatR;
using OracleEFCore5.Application.Interfaces.Repositories;
using OracleEFCore5.Application.Wrappers;
using System.Threading;
using System.Threading.Tasks;

namespace OracleEFCore5.Application.Features.DbTestTable.Commands.Create
{
    public partial class InsertMockProjectCommentCommand : IRequest<Response<int>>
    {
        public int RowCount { get; set; }
    }
    public class SeedProjectCommentCommandHandler : IRequestHandler<InsertMockProjectCommentCommand, Response<int>>
    {
        private readonly IProjectCommentRepositoryAsync _projectcommentRepository;
        public SeedProjectCommentCommandHandler(IProjectCommentRepositoryAsync projectcommentRepository)
        {
            _projectcommentRepository = projectcommentRepository;
        }

        public async Task<Response<int>> Handle(InsertMockProjectCommentCommand request, CancellationToken cancellationToken)
        {
            await _projectcommentRepository.SeedDataAsync(request.RowCount);
            return new Response<int>(request.RowCount);
        }
    }
}
