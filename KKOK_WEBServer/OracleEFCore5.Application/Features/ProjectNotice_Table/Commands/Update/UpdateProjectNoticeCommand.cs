using MediatR;
using OracleEFCore5.Application.Exceptions;
using OracleEFCore5.Application.Interfaces.Repositories;
using OracleEFCore5.Application.Wrappers;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OracleEFCore5.Application.Features.DbTestTable.Commands.Update
{
    public class UpdateProjectNoticeCommand : IRequest<Response<Guid>>
    {
        public Guid Id { get; set; }
        public int Pjt_Code { get; set; }

        public int Member_Code { get; set; }

        public int Notice_Code { get; set; }

        public string Member_Name { get; set; }

        public DateTime Notice_Date { get; set; }

        public string Notice_Name { get; set; }

        public string Notice_Description { get; set; }
        public class UpdateProjectNoticeCommandHandler : IRequestHandler<UpdateProjectNoticeCommand, Response<Guid>>
        {
            private readonly IProjectNoticeRepositoryAsync _projectnoticeRepository;
            public UpdateProjectNoticeCommandHandler(IProjectNoticeRepositoryAsync projectnoticeRepository)
            {
                _projectnoticeRepository = projectnoticeRepository;
            }
            public async Task<Response<Guid>> Handle(UpdateProjectNoticeCommand command, CancellationToken cancellationToken)
            {
                var projectnotice = await _projectnoticeRepository.GetByIdAsync(command.Id);

                if (projectnotice == null)
                {
                    throw new ApiException($"Project Notice Not Found.");
                }
                else
                {
                    projectnotice.Pjt_Code = command.Pjt_Code;
                    projectnotice.Member_Code = command.Member_Code;
                    projectnotice.Member_Name = command.Member_Name;
                    projectnotice.Notice_Code = command.Notice_Code;
                    projectnotice.Notice_Date = command.Notice_Date;
                    projectnotice.Notice_Name = command.Notice_Name;
                    projectnotice.Notice_Description = command.Notice_Description;
                    return new Response<Guid>(projectnotice.Id);
                }
            }
        }
    }
}
