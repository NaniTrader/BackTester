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

namespace NaniTrader.BackTester.Exchanges
{
    public class EfCoreExchangeRepository
    : EfCoreRepository<BackTesterDbContext, Exchange, Guid>,
        IExchangeRepository
    {
        public EfCoreExchangeRepository(IDbContextProvider<BackTesterDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public async Task<Exchange?> FindByNameAsync(string name)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet.FirstOrDefaultAsync(exchange => exchange.Name == name);
        }

        public async Task<List<Exchange>> GetPagedListWithNameFilterAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string? filter)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet
                .WhereIf(!filter.IsNullOrWhiteSpace(), exchange => exchange.Name.Contains(filter!))
                .OrderBy(sorting)
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }
    }
}
