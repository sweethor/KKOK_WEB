using MediatR;
using OracleEFCore5.Application.Interfaces.Repositories;
using OracleEFCore5.Application.Wrappers;
using System.Threading;
using System.Threading.Tasks;

namespace OracleEFCore5.Application.Features.DbTestTable.Commands.Create
{
    public partial class InsertMockProjectNoticeCommand : IRequest<Response<int>>
    {
        public int RowCount { get; set; }
    }
    public class SeedProjectNoticeCommandHandler : IRequestHandler<InsertMockProjectNoticeCommand, Response<int>>
    {
        private readonly IProjectNoticeRepositoryAsync _projectnoticeRepository;
        public SeedProjectNoticeCommandHandler(IProjectNoticeRepositoryAsync projectnoticeRepository)
        {
            _projectnoticeRepository = projectnoticeRepository;
        }

        public async Task<Response<int>> Handle(InsertMockProjectNoticeCommand request, CancellationToken cancellationToken)
        {
            await _projectnoticeRepository.SeedDataAsync(request.RowCount);
            return new Response<int>(request.RowCount);
        }
    }
}
