using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;
using OracleEFCore5.Application.Interfaces;
using OracleEFCore5.Domain.Common;
using OracleEFCore5.Domain.Entities;
using OracleEFCore5.Domain.Entities.DBTables;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OracleEFCore5.Infrastructure.Persistence.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IDateTimeService _dateTime;
        private readonly ILoggerFactory _loggerFactory;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,
            IDateTimeService dateTime,
            ILoggerFactory loggerFactory
            ) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _dateTime = dateTime;
            _loggerFactory = loggerFactory;
        }
        public DbSet<TestTable> TestTables { get; set; }
        public DbSet<Member> Members { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = _dateTime.NowUtc;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModified = _dateTime.NowUtc;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<TestTable>().HasData(Seedtesttables());
            builder.Entity<Member>().HasData(Seedmembers());
            builder.HasDefaultSchema("C##TEST");

            base.OnModelCreating(builder);


        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(_loggerFactory);
        }

        private List<TestTable> Seedtesttables()
        {
            var _mockData = this.Database.GetService<IMockService>();
            var TestTables = _mockData.SeedTestTables(1000);
            return TestTables;
        }
        private List<Member> Seedmembers()
        {
            var _mockData = this.Database.GetService<IMockService>();
            var Members = _mockData.SeedMembers(1000);
            return Members;
        }
    }
}
