using MediatR;
using OracleEFCore5.Application.Interfaces.Repositories;
using OracleEFCore5.Application.Wrappers;
using System.Threading;
using System.Threading.Tasks;

namespace OracleEFCore5.Application.Features.DbTestTable.Commands.Create
{
    public partial class InsertMockMemberCommand : IRequest<Response<int>>
    {
        public int RowCount { get; set; }
    }
    public class SeedMemberCommandHandler : IRequestHandler<InsertMockMemberCommand, Response<int>>
    {
        private readonly IMemberRepositoryAsync _memberRepository;
        public SeedMemberCommandHandler(IMemberRepositoryAsync memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public async Task<Response<int>> Handle(InsertMockMemberCommand request, CancellationToken cancellationToken)
        {
            await _memberRepository.SeedDataAsync(request.RowCount);
            return new Response<int>(request.RowCount);
        }
    }
}
