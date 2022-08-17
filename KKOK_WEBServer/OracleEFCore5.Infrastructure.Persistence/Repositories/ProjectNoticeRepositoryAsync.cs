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
    public class ProjectNoticeRepositoryAsync : GenericRepositoryAsync<Pjt_Notice>, IProjectNoticeRepositoryAsync
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<Pjt_Notice> projectnotice;
        private IDataShapeHelper<Pjt_Notice> _dataShaper;
        private readonly IMockService _mockData;

        public ProjectNoticeRepositoryAsync(ApplicationDbContext dbContext,
            IDataShapeHelper<Pjt_Notice> dataShaper, IMockService mockData) : base(dbContext)
        {
            _dbContext = dbContext;
            projectnotice = dbContext.Set<Pjt_Notice>();
            _dataShaper = dataShaper;
            _mockData = mockData;
        }

        public async Task<bool> IsUniqueProjectNoticeCodeAsync(string code)
        {
            return await projectnotice
                .AllAsync(p => p.Pjt_Code.ToString() != code);
        }

        public async Task<bool> SeedDataAsync(int rowCount)
        {
            foreach (Pjt_Notice projectnotice in _mockData.GetProjectNotices(rowCount))
            {
                await this.AddAsync(projectnotice);
            }
            return true;
        }

        public async Task<(IEnumerable<Entity> data, RecordsCount recordsCount)> GetPagedProjectNoticeReponseAsync(GetProjectNoticesQuery requestParameter)
        {
            var pjt_code = requestParameter.Pjt_Code;
            var mem_code = requestParameter.Member_Code;
            var mem_name = requestParameter.Member_Name;
            var notice_code = requestParameter.Notice_Code;
            var notice_date = requestParameter.Notice_Date;
            var notice_name = requestParameter.Notice_Name;
            var notice_description = requestParameter.Notice_Description;

            var pageNumber = requestParameter.PageNumber;
            var pageSize = requestParameter.PageSize;
            var orderBy = requestParameter.OrderBy;
            var fields = requestParameter.Fields;

            int recordsTotal, recordsFiltered;

            // Setup IQueryable
            var result = projectnotice
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
                result = result.Select<Pjt_Notice>("new(" + fields + ")");
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

        private void FilterByColumn(ref IQueryable<Pjt_Notice> projectnotices, int code)
        {
            if (!projectnotices.Any())
                return;

            if (string.IsNullOrEmpty(code.ToString()))
                return;

            var predicate = PredicateBuilder.New<Pjt_Notice>();

            if (!string.IsNullOrEmpty(code.ToString()))
                predicate = predicate.Or(p => p.Pjt_Code.ToString().Contains(code.ToString().Trim()));

            projectnotices = projectnotices.Where(predicate);
        }
    }
}
