using LinqKit;
using Microsoft.EntityFrameworkCore;
using OracleEFCore5.Application.Features.DbTestTable.Queries.Gets;
using OracleEFCore5.Application.Features.Project_Table.Queries.Gets;
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
    public class ProjectRepositoryAsync : GenericRepositoryAsync<Project>, IProjectRepositoryAsync
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<Project> project;
        private IDataShapeHelper<Project> _dataShaper;
        private readonly IMockService _mockData;

        public ProjectRepositoryAsync(ApplicationDbContext dbContext,
            IDataShapeHelper<Project> dataShaper, IMockService mockData) : base(dbContext)
        {
            _dbContext = dbContext;
            project = dbContext.Set<Project>();
            _dataShaper = dataShaper;
            _mockData = mockData;
        }

        public async Task<bool> IsUniqueProjectCodeAsync(string code)
        {
            return await project
                .AllAsync(p => p.pjt_code != code);
        }

        public async Task<bool> SeedDataAsync(int rowCount)
        {
            foreach (Project project in _mockData.GetProjects(rowCount))
            {
                await this.AddAsync(project);
            }
            return true;
        }

        public async Task<(IEnumerable<Entity> data, RecordsCount recordsCount)> GetPagedProjectReponseAsync(GetProjectrsQuery requestParameter)
        {
            var code = requestParameter.pjt_code;
            var name = requestParameter.pjt_name;
            var startdate = requestParameter.pjt_startdate;
            var enddate = requestParameter.pjt_enddate;

            var pageNumber = requestParameter.PageNumber;
            var pageSize = requestParameter.PageSize;
            var orderBy = requestParameter.OrderBy;
            var fields = requestParameter.Fields;

            int recordsTotal, recordsFiltered;

            // Setup IQueryable
            var result = project
                .AsNoTracking()
                .AsExpandable();

            // Count records total
            recordsTotal = await result.CountAsync();

            // filter data
            FilterByColumn(ref result, code);

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
                result = result.Select<Project>("new(" + fields + ")");
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

        private void FilterByColumn(ref IQueryable<Project> project, string code)
        {
            if (!project.Any())
                return;

            if (string.IsNullOrEmpty(code.ToString()))
                return;

            var predicate = PredicateBuilder.New<Project>();

            if (!string.IsNullOrEmpty(code.ToString()))
                predicate = predicate.Or(p => p.pjt_code.Contains(code.ToString().Trim()));

            project = project.Where(predicate);
        }
    }
}
