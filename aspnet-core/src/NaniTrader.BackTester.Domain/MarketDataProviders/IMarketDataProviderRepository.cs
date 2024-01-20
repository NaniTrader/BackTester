using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace NaniTrader.BackTester.MarketDataProviders
{
    public interface IMarketDataProviderRepository : IRepository<MarketDataProvider, Guid>
    {
        Task<MarketDataProvider?> FindByNameAsync(string name);

        Task<List<MarketDataProvider>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string? filter
        );
    }
}
