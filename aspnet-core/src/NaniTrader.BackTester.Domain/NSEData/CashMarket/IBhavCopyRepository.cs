using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace NaniTrader.BackTester.NSEData.CashMarket
{
    public interface IBhavCopyRepository : IRepository<BhavCopy, Guid>
    {
        Task<BhavCopy?> FindByDateAsync(DateOnly date);
    }
}
