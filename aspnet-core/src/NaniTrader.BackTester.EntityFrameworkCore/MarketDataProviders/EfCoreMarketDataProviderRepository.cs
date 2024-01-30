using Microsoft.EntityFrameworkCore;
using NaniTrader.BackTester.EntityFrameworkCore;
using System;
using System.Linq.Dynamic.Core;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace NaniTrader.BackTester.MarketDataProviders
{
    public class EfCoreMarketDataProviderRepository
    : EfCoreRepository<BackTesterDbContext, MarketDataProvider, Guid>,
        IMarketDataProviderRepository
    {
        public EfCoreMarketDataProviderRepository(IDbContextProvider<BackTesterDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public async Task<MarketDataProvider?> FindByNameAsync(string name)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet.FirstOrDefaultAsync(marketDataProvider => marketDataProvider.Name == name);
        }
    }
}
