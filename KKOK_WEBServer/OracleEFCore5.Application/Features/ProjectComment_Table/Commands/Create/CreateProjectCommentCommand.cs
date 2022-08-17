using AutoMapper;
using MediatR;
using OracleEFCore5.Application.Interfaces.Repositories;
using OracleEFCore5.Application.Wrappers;
using OracleEFCore5.Domain.Entities;
using OracleEFCore5.Domain.Entities.DBTables;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OracleEFCore5.Application.Features.DbTestTable.Commands.Create
{
    public partial class CreateProjectCommentCommand : IRequest<Response<Guid>>
    {
        public int Pjt_Code { get; set; }

        public int Plan_Code { get; set; }

        public int Issue_Code { get; set; }

        public int Comment_Code { get; set; }

        public int Member_Code { get; set; }

        public string Member_Name { get; set; }

        public string Comment_Description { get; set; }

        public int Wr_Member_Code { get; set; }

        public string Wr_Member_Name { get; set; }
    }
    public class CreateProjectCommentCommandHandler : IRequestHandler<CreateProjectCommentCommand, Response<Guid>>
    {
        private readonly IProjectCommentRepositoryAsync _projectcommentRepository;
        private readonly IMapper _mapper;
        public CreateProjectCommentCommandHandler(IProjectCommentRepositoryAsync projectcommentRepository, IMapper mapper)
        {
            _projectcommentRepository = projectcommentRepository;
            _mapper = mapper;
        }

        public async Task<Response<Guid>> Handle(CreateProjectCommentCommand request, CancellationToken cancellationToken)
        {
            var Commentcomment = _mapper.Map<Pjt_Comment>(request);
            await _projectcommentRepository.AddAsync(Commentcomment);
            return new Response<Guid>(Commentcomment.Id);
        }
    }
}
