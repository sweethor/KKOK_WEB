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
    public class ProjectPlanRepositoryAsync : GenericRepositoryAsync<Pjt_Plan>, IProjectPlanRepositoryAsync
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<Pjt_Plan> projectplan;
        private IDataShapeHelper<Pjt_Plan> _dataShaper;
        private readonly IMockService _mockData;

        public ProjectPlanRepositoryAsync(ApplicationDbContext dbContext,
            IDataShapeHelper<Pjt_Plan> dataShaper, IMockService mockData) : base(dbContext)
        {
            _dbContext = dbContext;
            projectplan = dbContext.Set<Pjt_Plan>();
            _dataShaper = dataShaper;
            _mockData = mockData;
        }

        public async Task<bool> IsUniqueProjectPlanCodeAsync(string code)
        {
            return await projectplan
                .AllAsync(p => p.Pjt_Code.ToString() != code);
        }

        public async Task<bool> SeedDataAsync(int rowCount)
        {
            foreach (Pjt_Plan projectplan in _mockData.GetProjectPlans(rowCount))
            {
                await this.AddAsync(projectplan);
            }
            return true;
        }

        public async Task<(IEnumerable<Entity> data, RecordsCount recordsCount)> GetPagedProjectPlanReponseAsync(GetProjectPlansQuery requestParameter)
        {
            var pjt_code = requestParameter.Pjt_Code;
            var mem_code = requestParameter.Member_Code;
            var plan_code = requestParameter.Plan_Code;
            var plan_start_date = requestParameter.Plan_Start_Date;
            var plan_end_date = requestParameter.Plan_End_Date;
            var plan_description = requestParameter.Plan_Description;

            var pageNumber = requestParameter.PageNumber;
            var pageSize = requestParameter.PageSize;
            var orderBy = requestParameter.OrderBy;
            var fields = requestParameter.Fields;

            int recordsTotal, recordsFiltered;

            // Setup IQueryable
            var result = projectplan
                .AsNoTracking()
                .AsExpandable();

            // Count records total
            recordsTotal = await result.CountAsync();

            // filter data
            FilterByColumn(ref result, plan_code);

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
                result = result.Select<Pjt_Plan>("new(" + fields + ")");
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

        private void FilterByColumn(ref IQueryable<Pjt_Plan> projectplans, int code)
        {
            if (!projectplans.Any())
                return;

            if (string.IsNullOrEmpty(code.ToString()))
                return;

            var predicate = PredicateBuilder.New<Pjt_Plan>();

            if (!string.IsNullOrEmpty(code.ToString()))
                predicate = predicate.Or(p => p.Pjt_Code.ToString().Contains(code.ToString().Trim()));

            projectplans = projectplans.Where(predicate);
        }
    }
}
