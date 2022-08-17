using LinqKit;
using Microsoft.EntityFrameworkCore;
using OracleEFCore5.Application.Features.DbTestTable.Queries.Gets;
using OracleEFCore5.Application.Interfaces;
using OracleEFCore5.Application.Interfaces.Repositories;
using OracleEFCore5.Application.Parameters;
using OracleEFCore5.Domain.Entities;
using OracleEFCore5.Domain.Entities.DBTables;
using OracleEFCore5.Infrastructure.Persistence.Contexts;
using OracleEFCore5.Infrastructure.Persistence.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace OracleEFCore5.Infrastructure.Persistence.Repositories
{
    public class ProjectCommentRepositoryAsync : GenericRepositoryAsync<Pjt_Comment>, IProjectCommentRepositoryAsync
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<Pjt_Comment> projectcomment;
        private IDataShapeHelper<Pjt_Comment> _dataShaper;
        private readonly IMockService _mockData;

        public ProjectCommentRepositoryAsync(ApplicationDbContext dbContext,
            IDataShapeHelper<Pjt_Comment> dataShaper, IMockService mockData) : base(dbContext)
        {
            _dbContext = dbContext;
            projectcomment = dbContext.Set<Pjt_Comment>();
            _dataShaper = dataShaper;
            _mockData = mockData;
        }

        public async Task<bool> IsUniqueProjectCommentCodeAsync(string code)
        {
            return await projectcomment
                .AllAsync(p => p.Pjt_Code.ToString() != code);
        }

        public async Task<bool> SeedDataAsync(int rowCount)
        {
            foreach (Pjt_Comment projectcomment in _mockData.GetProjectComments(rowCount))
            {
                await this.AddAsync(projectcomment);
            }
            return true;
        }

        public async Task<(IEnumerable<Entity> data, RecordsCount recordsCount)> GetPagedProjectCommentReponseAsync(GetProjectCommentsQuery requestParameter)
        {
            var pjt_code = requestParameter.Pjt_Code;
            var plan_code = requestParameter.Plan_Code;
            var issue_code = requestParameter.Issue_Code;
            var comment_code = requestParameter.Comment_Code;
            var mem_code = requestParameter.Member_Code;
            var mem_name = requestParameter.Member_Name;
            var comment_description = requestParameter.Comment_Description;
            var wr_mem_code = requestParameter.Wr_Member_Code;
            var wr_mem_name = requestParameter.Wr_Member_Name;

            var pageNumber = requestParameter.PageNumber;
            var pageSize = requestParameter.PageSize;
            var orderBy = requestParameter.OrderBy;
            var fields = requestParameter.Fields;

            int recordsTotal, recordsFiltered;

            // Setup IQueryable
            var result = projectcomment
                .AsNoTracking()
                .AsExpandable();

            // Count records total
            recordsTotal = await result.CountAsync();

            // filter data
            FilterByColumn(ref result, pjt_code);

            // Count records after filter
            recordsFiltered = await result.CountAsync();

            //set Record counts
            var recordsCount = new RecordsCount
            {
                RecordsFiltered = recordsFiltered,
                RecordsTotal = recordsTotal
            };

            // set order by
            if (!string.IsNullOrWhiteSpace(orderBy))
            {
                result = result.OrderBy(orderBy);
            }

            // select columns
            if (!string.IsNullOrWhiteSpace(fields))
            {
                result = result.Select<Pjt_Comment>("new(" + fields + ")");
            }
            // paging
            result = result
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);

            // retrieve data to list
            var resultData = await result.ToListAsync();
            // shape data
            var shapeData = _dataShaper.ShapeData(resultData, fields);

            return (shapeData, recordsCount);
        }

        private void FilterByColumn(ref IQueryable<Pjt_Comment> projectComments, int code)
        {
            if (!projectComments.Any())
                return;

            if (string.IsNullOrEmpty(code.ToString()))
                return;

            var predicate = PredicateBuilder.New<Pjt_Comment>();

            if (!string.IsNullOrEmpty(code.ToString()))
                predicate = predicate.Or(p => p.Pjt_Code.ToString().Contains(code.ToString().Trim()));

            projectComments = projectComments.Where(predicate);
        }
    }
}
