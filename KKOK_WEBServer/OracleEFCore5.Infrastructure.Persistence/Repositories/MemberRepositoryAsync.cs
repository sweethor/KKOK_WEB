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
    public class MemberRepositoryAsync : GenericRepositoryAsync<Member>, IMemberRepositoryAsync
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<Member> member;
        private IDataShapeHelper<Member> _dataShaper;
        private readonly IMockService _mockData;

        public MemberRepositoryAsync(ApplicationDbContext dbContext,
            IDataShapeHelper<Member> dataShaper, IMockService mockData) : base(dbContext)
        {
            _dbContext = dbContext;
            member = dbContext.Set<Member>();
            _dataShaper = dataShaper;
            _mockData = mockData;
        }

        public async Task<bool> IsUniqueMemberCodeAsync(string code)
        {
            return await member
                .AllAsync(p => p.Member_Code.ToString() != code);
        }

        public async Task<bool> SeedDataAsync(int rowCount)
        {
            foreach (Member member in _mockData.GetMembers(rowCount))
            {
                await this.AddAsync(member);
            }
            return true;
        }

        public async Task<(IEnumerable<Entity> data, RecordsCount recordsCount)> GetPagedMemberReponseAsync(GetMembersQuery requestParameter)
        {
            var code = requestParameter.Member_Code;
            var name = requestParameter.Member_Name;
            var mem_id = requestParameter.Member_ID;
            var mem_pwd = requestParameter.Member_PWD;
            var mem_email = requestParameter.Member_Email;
            var mem_phone = requestParameter.Member_Phone;
            var mem_permission = requestParameter.Member_Permission;

            var pageNumber = requestParameter.PageNumber;
            var pageSize = requestParameter.PageSize;
            var orderBy = requestParameter.OrderBy;
            var fields = requestParameter.Fields;

            int recordsTotal, recordsFiltered;

            // Setup IQueryable
            var result = member
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
                result = result.Select<Member>("new(" + fields + ")");
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

        private void FilterByColumn(ref IQueryable<Member> members, int code)
        {
            if (!members.Any())
                return;

            if (string.IsNullOrEmpty(code.ToString()))
                return;

            var predicate = PredicateBuilder.New<Member>();

            if (!string.IsNullOrEmpty(code.ToString()))
                predicate = predicate.Or(p => p.Member_Code.ToString().Contains(code.ToString().Trim()));

            members = members.Where(predicate);
        }
    }
}
