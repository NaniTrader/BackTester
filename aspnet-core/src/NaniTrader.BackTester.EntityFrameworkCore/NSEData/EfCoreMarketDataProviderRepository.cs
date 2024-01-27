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
using NaniTrader.BackTester.NSEData.CashMarket;

namespace NaniTrader.BackTester.NSEData
{
    public class EfCoreBhavCopyRepository
    : EfCoreRepository<BackTesterDbContext, BhavCopy, Guid>,
        IBhavCopyRepository
    {
        public EfCoreBhavCopyRepository(IDbContextProvider<BackTesterDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public async Task<BhavCopy?> FindByDateAsync(DateOnly date)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet.FirstOrDefaultAsync(bhavCopy => bhavCopy.Date == date);
        }
    }
}
