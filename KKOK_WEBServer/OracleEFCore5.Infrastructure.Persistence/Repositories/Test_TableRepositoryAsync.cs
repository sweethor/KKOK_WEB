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
    public class TestTableRepositoryAsync : GenericRepositoryAsync<TestTable>, ITestTableRepositoryAsync
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<TestTable> testtable;
        private IDataShapeHelper<TestTable> _dataShaper;
        private readonly IMockService _mockData;

        public TestTableRepositoryAsync(ApplicationDbContext dbContext,
            IDataShapeHelper<TestTable> dataShaper, IMockService mockData) : base(dbContext)
        {
            _dbContext = dbContext;
            testtable = dbContext.Set<TestTable>();
            _dataShaper = dataShaper;
            _mockData = mockData;
        }

        public async Task<bool> IsUniqueTestNameAsync(string testName)
        {
            return await testtable
                .AllAsync(p => p.test_name != testName);
        }

        public async Task<bool> SeedDataAsync(int rowCount)
        {
            foreach (TestTable testTable in _mockData.GetTestTables(rowCount))
            {
                await this.AddAsync(testTable);
            }
            return true;
        }

        public async Task<(IEnumerable<Entity> data, RecordsCount recordsCount)> GetPagedTestTableReponseAsync(GetTestTablesQuery requestParameter)
        {
            var testName = requestParameter.TestName;

            var pageNumber = requestParameter.PageNumber;
            var pageSize = requestParameter.PageSize;
            var orderBy = requestParameter.OrderBy;
            var fields = requestParameter.Fields;

            int recordsTotal, recordsFiltered;

            // Setup IQueryable
            var result = testtable
                .AsNoTracking()
                .AsExpandable();

            // Count records total
            recordsTotal = await result.CountAsync();

            // filter data
            FilterByColumn(ref result, testName);

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
                result = result.Select<TestTable>("new(" + fields + ")");
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

        private void FilterByColumn(ref IQueryable<TestTable> testTables, string testName)
        {
            if (!testTables.Any())
                return;

            if (string.IsNullOrEmpty(testName))
                return;

            var predicate = PredicateBuilder.New<TestTable>();

            if (!string.IsNullOrEmpty(testName))
                predicate = predicate.Or(p => p.test_name.Contains(testName.Trim()));

            testTables = testTables.Where(predicate);
        }
    }
}
