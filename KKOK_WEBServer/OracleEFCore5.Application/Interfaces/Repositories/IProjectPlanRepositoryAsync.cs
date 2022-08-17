using OracleEFCore5.Application.Features.DbTestTable.Queries.Gets;
using OracleEFCore5.Application.Parameters;
using OracleEFCore5.Domain.Entities;
using OracleEFCore5.Domain.Entities.DBTables;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OracleEFCore5.Application.Interfaces.Repositories
{
    public interface IProjectPlanRepositoryAsync : IGenericRepositoryAsync<Pjt_Plan>
    {
        Task<bool> IsUniqueProjectPlanCodeAsync(string code);

        Task<bool> SeedDataAsync(int rowCount);

        Task<(IEnumerable<Entity> data, RecordsCount recordsCount)> GetPagedProjectPlanReponseAsync(GetProjectPlansQuery requestParameters);
    }
}
