using MediatR;
using OracleEFCore5.Application.Interfaces.Repositories;
using OracleEFCore5.Application.Wrappers;
using System.Threading;
using System.Threading.Tasks;

namespace OracleEFCore5.Application.Features.DbTestTable.Commands.Create
{
    public partial class InsertMockMemberAttendCommand : IRequest<Response<int>>
    {
        public int RowCount { get; set; }
    }
    public class SeedMemberAttendCommandHandler : IRequestHandler<InsertMockMemberAttendCommand, Response<int>>
    {
        private readonly IMemberAttendRepositoryAsync _memberattendRepository;
        public SeedMemberAttendCommandHandler(IMemberAttendRepositoryAsync memberattendRepository)
        {
            _memberattendRepository = memberattendRepository;
        }

        public async Task<Response<int>> Handle(InsertMockMemberAttendCommand request, CancellationToken cancellationToken)
        {
            await _memberattendRepository.SeedDataAsync(request.RowCount);
            return new Response<int>(request.RowCount);
        }
    }
}
