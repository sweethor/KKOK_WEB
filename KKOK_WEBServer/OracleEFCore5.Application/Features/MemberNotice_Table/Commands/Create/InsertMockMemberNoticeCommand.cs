using MediatR;
using OracleEFCore5.Application.Interfaces.Repositories;
using OracleEFCore5.Application.Wrappers;
using System.Threading;
using System.Threading.Tasks;

namespace OracleEFCore5.Application.Features.DbTestTable.Commands.Create
{
    public partial class InsertMockMemberNoticeCommand : IRequest<Response<int>>
    {
        public int RowCount { get; set; }
    }
    public class SeedMemberNoticeCommandHandler : IRequestHandler<InsertMockMemberNoticeCommand, Response<int>>
    {
        private readonly IMemberNoticeRepositoryAsync _membernoticeRepository;
        public SeedMemberNoticeCommandHandler(IMemberNoticeRepositoryAsync membernoticeRepository)
        {
            _membernoticeRepository = membernoticeRepository;
        }

        public async Task<Response<int>> Handle(InsertMockMemberNoticeCommand request, CancellationToken cancellationToken)
        {
            await _membernoticeRepository.SeedDataAsync(request.RowCount);
            return new Response<int>(request.RowCount);
        }
    }
}
