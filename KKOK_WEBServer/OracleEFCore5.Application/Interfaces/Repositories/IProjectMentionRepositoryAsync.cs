using OracleEFCore5.Application.Features.DbTestTable.Queries.Gets;
using OracleEFCore5.Application.Parameters;
using OracleEFCore5.Domain.Entities;
using OracleEFCore5.Domain.Entities.DBTables;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OracleEFCore5.Application.Interfaces.Repositories
{
    public interface IProjectMentionRepositoryAsync : IGenericRepositoryAsync<Pjt_Mention>
    {
        Task<bool> IsUniqueProjectMentionCodeAsync(string code);

        Task<bool> SeedDataAsync(int rowCount);

        Task<(IEnumerable<Entity> data, RecordsCount recordsCount)> GetPagedProjectMentionReponseAsync(GetProjectMentionsQuery requestParameters);
    }
}
