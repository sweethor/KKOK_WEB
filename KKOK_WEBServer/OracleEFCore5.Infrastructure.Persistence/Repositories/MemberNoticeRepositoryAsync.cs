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
    public class MemberNoticeRepositoryAsync : GenericRepositoryAsync<Member_Notice>, IMemberNoticeRepositoryAsync
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<Member_Notice> membernotice;
        private IDataShapeHelper<Member_Notice> _dataShaper;
        private readonly IMockService _mockData;

        public MemberNoticeRepositoryAsync(ApplicationDbContext dbContext,
            IDataShapeHelper<Member_Notice> dataShaper, IMockService mockData) : base(dbContext)
        {
            _dbContext = dbContext;
            membernotice = dbContext.Set<Member_Notice>();
            _dataShaper = dataShaper;
            _mockData = mockData;
        }

        public async Task<bool> IsUniqueMemberNoticeCodeAsync(string code)
        {
            return await membernotice
                .AllAsync(p => p.Pjt_Code.ToString() != code);
        }

        public async Task<bool> SeedDataAsync(int rowCount)
        {
            foreach (Member_Notice membernotice in _mockData.GetMembersNotice(rowCount))
            {
                await this.AddAsync(membernotice);
            }
            return true;
        }

        public async Task<(IEnumerable<Entity> data, RecordsCount recordsCount)> GetPagedMemberNoticeReponseAsync(GetMembersNoticeQuery requestParameter)
        {
            var pjt_code = requestParameter.Pjt_Code;
            var mem_code = requestParameter.Member_Code;
            var plan_code = requestParameter.Plan_Code;
            var issue_code = requestParameter.Issue_Code;
            var notice_name = requestParameter.Notice_Name;

            var pageNumber = requestParameter.PageNumber;
            var pageSize = requestParameter.PageSize;
            var orderBy = requestParameter.OrderBy;
            var fields = requestParameter.Fields;

            int recordsTotal, recordsFiltered;

            // Setup IQueryable
            var result = membernotice
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
                result = result.Select<Member_Notice>("new(" + fields + ")");
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

        private void FilterByColumn(ref IQueryable<Member_Notice> membersnotice, int code)
        {
            if (!membersnotice.Any())
                return;

            if (string.IsNullOrEmpty(code.ToString()))
                return;

            var predicate = PredicateBuilder.New<Pjt_Member>();

            if (!string.IsNullOrEmpty(code.ToString()))
                predicate = predicate.Or(p => p.Pjt_Code.ToString().Contains(code.ToString().Trim()));

            membersnotice = membersnotice.Where(predicate);
        }
    }
}
