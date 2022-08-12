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
    public class ProjectPlanCheckListRepositoryAsync : GenericRepositoryAsync<Pjt_Plan_CheckList>, IProjectPlanCheckListRepositoryAsync
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<Pjt_Plan_CheckList> projectplanchecklist;
        private IDataShapeHelper<Pjt_Plan_CheckList> _dataShaper;
        private readonly IMockService _mockData;

        public ProjectPlanCheckListRepositoryAsync(ApplicationDbContext dbContext,
            IDataShapeHelper<Pjt_Plan_CheckList> dataShaper, IMockService mockData) : base(dbContext)
        {
            _dbContext = dbContext;
            projectplanchecklist = dbContext.Set<Pjt_Plan_CheckList>();
            _dataShaper = dataShaper;
            _mockData = mockData;
        }

        public async Task<bool> IsUniqueProjectPlanCheckListCodeAsync(string code)
        {
            return await projectplanchecklist
                .AllAsync(p => p.Pjt_Code.ToString() != code);
        }

        public async Task<bool> SeedDataAsync(int rowCount)
        {
            foreach (Pjt_Plan_CheckList projectplanchecklist in _mockData.GetProjectPlanCheckLists(rowCount))
            {
                await this.AddAsync(projectplanchecklist);
            }
            return true;
        }

        public async Task<(IEnumerable<Entity> data, RecordsCount recordsCount)> GetPagedProjectPlanCheckListReponseAsync(GetProjectPlanCheckListsQuery requestParameter)
        {
            var pjt_code = requestParameter.Pjt_Code;
            var mem_code = requestParameter.Member_Code;
            var pjt_plan_code = requestParameter.Plan_Code;
            var plan_checklist_code = requestParameter.Plan_CheckList_Code;
            var plan_checklist_name = requestParameter.Plan_CheckList_Name;
            var plan_checklist_state = requestParameter.Plan_CheckList_State;

            var pageNumber = requestParameter.PageNumber;
            var pageSize = requestParameter.PageSize;
            var orderBy = requestParameter.OrderBy;
            var fields = requestParameter.Fields;

            int recordsTotal, recordsFiltered;

            // Setup IQueryable
            var result = projectplanchecklist
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
                result = result.Select<Pjt_Plan_CheckList>("new(" + fields + ")");
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

        private void FilterByColumn(ref IQueryable<Pjt_Plan_CheckList> projectplanchecklists, int code)
        {
            if (!projectplanchecklists.Any())
                return;

            if (string.IsNullOrEmpty(code.ToString()))
                return;

            var predicate = PredicateBuilder.New<Pjt_Plan_CheckList>();

            if (!string.IsNullOrEmpty(code.ToString()))
                predicate = predicate.Or(p => p.Pjt_Code.ToString().Contains(code.ToString().Trim()));

            projectplanchecklists = projectplanchecklists.Where(predicate);
        }
    }
}
