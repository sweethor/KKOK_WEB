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
    public class MemberAttendRepositoryAsync : GenericRepositoryAsync<Member_Attend>, IMemberAttendRepositoryAsync
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<Member_Attend> memberattend;
        private IDataShapeHelper<Member_Attend> _dataShaper;
        private readonly IMockService _mockData;

        public MemberAttendRepositoryAsync(ApplicationDbContext dbContext,
            IDataShapeHelper<Member_Attend> dataShaper, IMockService mockData) : base(dbContext)
        {
            _dbContext = dbContext;
            memberattend = dbContext.Set<Member_Attend>();
            _dataShaper = dataShaper;
            _mockData = mockData;
        }

        public async Task<bool> IsUniqueMemberAttendCodeAsync(string code)
        {
            return await memberattend
                .AllAsync(p => p.Pjt_Code.ToString() != code);
        }

        public async Task<bool> SeedDataAsync(int rowCount)
        {
            foreach (Member_Attend memberattend in _mockData.GetMembersAttend(rowCount))
            {
                await this.AddAsync(memberattend);
            }
            return true;
        }

        public async Task<(IEnumerable<Entity> data, RecordsCount recordsCount)> GetPagedMemberAttendReponseAsync(GetMembersAttendQuery requestParameter)
        {
            var pjt_code = requestParameter.Pjt_Code;
            var mem_code = requestParameter.Member_Code;
            var mem_name = requestParameter.Member_Name;
            var mem_issue_cnt = requestParameter.Member_Issue_Cnt;
            var mem_com_issue = requestParameter.Member_Com_Issue;

            var pageNumber = requestParameter.PageNumber;
            var pageSize = requestParameter.PageSize;
            var orderBy = requestParameter.OrderBy;
            var fields = requestParameter.Fields;

            int recordsTotal, recordsFiltered;

            // Setup IQueryable
            var result = memberattend
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
                result = result.Select<Member_Attend>("new(" + fields + ")");
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

        private void FilterByColumn(ref IQueryable<Member_Attend> membersattend, int code)
        {
            if (!membersattend.Any())
                return;

            if (string.IsNullOrEmpty(code.ToString()))
                return;

            var predicate = PredicateBuilder.New<Pjt_Member>();

            if (!string.IsNullOrEmpty(code.ToString()))
                predicate = predicate.Or(p => p.Pjt_Code.ToString().Contains(code.ToString().Trim()));

            membersattend = membersattend.Where(predicate);
        }
    }
}
