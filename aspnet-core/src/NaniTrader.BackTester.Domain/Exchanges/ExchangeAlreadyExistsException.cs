using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace NaniTrader.BackTester.Exchanges
{
    public class ExchangeAlreadyExistsException : BusinessException
    {
        public ExchangeAlreadyExistsException(string name)
            : base(BackTesterDomainErrorCodes.ExchangeAlreadyExists)
        {
            WithData("name", name);
        }
    }
}
