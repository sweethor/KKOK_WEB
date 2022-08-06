using OracleEFCore5.Application.Interfaces;
using OracleEFCore5.Domain.Entities;
using OracleEFCore5.Domain.Entities.DBTables;
using OracleEFCore5.Infrastructure.Shared.Mock;
using System.Collections.Generic;

namespace OracleEFCore5.Infrastructure.Shared.Services
{
    public class MockService : IMockService
    {
        public List<TestTable> GetTestTables(int rowCount)
        {
            var positionFaker = new TestTableInsertBogusConfig();
            return positionFaker.Generate(rowCount);
        }
        public List<TestTable> SeedTestTables(int rowCount)
        {
            var seedPositionFaker = new TestTableSeedBogusConfig();
            return seedPositionFaker.Generate(rowCount);
        }
        public List<Member> GetMembers(int rowCount)
        {
            var positionFaker = new MemberInsertBogusConfig();
            return positionFaker.Generate(rowCount);
        }
        public List<Member> SeedMembers(int rowCount)
        {
            var seedPositionFaker = new MemberSeedBogusConfig();
            return seedPositionFaker.Generate(rowCount);
        }

        public List<Pjt_Member> GetProjectMembers(int rowCount)
        {
            var positionFaker = new ProjectMemberInsertBogusConfig();
            return positionFaker.Generate(rowCount);
        }
        public List<Pjt_Member> SeedProjectMembers(int rowCount)
        {
            var seedPositionFaker = new ProjectMemberSeedBogusConfig();
            return seedPositionFaker.Generate(rowCount);
        }
    }
}
