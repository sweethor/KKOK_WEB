using AutoMapper;
using MediatR;
using OracleEFCore5.Application.Interfaces;
using OracleEFCore5.Application.Interfaces.Repositories;
using OracleEFCore5.Application.Parameters;
using OracleEFCore5.Application.Wrappers;
using OracleEFCore5.Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace OracleEFCore5.Application.Features.DbTestTable.Queries.Gets
{
    public class GetProjectCommentsQuery : QueryParameter, IRequest<PagedResponse<IEnumerable<Entity>>>
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

    public class GetAllProjectCommentsQueryHandler : IRequestHandler<GetProjectCommentsQuery, PagedResponse<IEnumerable<Entity>>>
    {
        private readonly IProjectCommentRepositoryAsync _projectcommentRepository;
        private readonly IMapper _mapper;
        private readonly IModelHelper _modelHelper;

        public GetAllProjectCommentsQueryHandler(IProjectCommentRepositoryAsync projectcommentRepository, IMapper mapper, IModelHelper modelHelper)
        {
            _projectcommentRepository = projectcommentRepository;
            _mapper = mapper;
            _modelHelper = modelHelper;
        }

        public async Task<PagedResponse<IEnumerable<Entity>>> Handle(GetProjectCommentsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = request;
            var pagination = request;
            //filtered fields security
            if (!string.IsNullOrEmpty(validFilter.Fields))
            {
                //limit to fields in view model
                validFilter.Fields = _modelHelper.ValidateModelFields<ProjectCommentsData>(validFilter.Fields);
            }
            if (string.IsNullOrEmpty(validFilter.Fields))
            {
                //default fields from view model
                validFilter.Fields = _modelHelper.GetModelFields<ProjectCommentsData>();
            }
            // query based on filter
            var entitymembers = await _projectcommentRepository.GetPagedProjectCommentReponseAsync(validFilter);
            var data = entitymembers.data;
            RecordsCount recordCount = entitymembers.recordsCount;
            // response wrapper
            return new PagedResponse<IEnumerable<Entity>>(data, validFilter.PageNumber, validFilter.PageSize, recordCount);
        }
    }
}
