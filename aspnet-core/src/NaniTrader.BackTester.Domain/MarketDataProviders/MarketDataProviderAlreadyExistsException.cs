using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace NaniTrader.BackTester.MarketDataProviders
{
    public class MarketDataProviderAlreadyExistsException : BusinessException
    {
        public MarketDataProviderAlreadyExistsException(string name)
            : base(BackTesterDomainErrorCodes.MarketDataProviderAlreadyExists)
        {
            WithData("name", name);
        }
    }
}
