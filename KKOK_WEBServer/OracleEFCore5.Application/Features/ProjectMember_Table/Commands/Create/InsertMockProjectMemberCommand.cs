using MediatR;
using OracleEFCore5.Application.Interfaces.Repositories;
using OracleEFCore5.Application.Wrappers;
using System.Threading;
using System.Threading.Tasks;

namespace OracleEFCore5.Application.Features.DbTestTable.Commands.Create
{
    public partial class InsertMockProjectMemberCommand : IRequest<Response<int>>
    {
        public int RowCount { get; set; }
    }
    public class SeedProjectMemberCommandHandler : IRequestHandler<InsertMockProjectMemberCommand, Response<int>>
    {
        private readonly IProjectMemberRepositoryAsync _projectmemberRepository;
        public SeedProjectMemberCommandHandler(IProjectMemberRepositoryAsync projectmemberRepository)
        {
            _projectmemberRepository = projectmemberRepository;
        }

        public async Task<Response<int>> Handle(InsertMockProjectMemberCommand request, CancellationToken cancellationToken)
        {
            await _projectmemberRepository.SeedDataAsync(request.RowCount);
            return new Response<int>(request.RowCount);
        }
    }
}
