using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace NaniTrader.BackTester.NSEData.CashMarket
{
    public class BhavCopyAlreadyExistsException : BusinessException
    {
        public BhavCopyAlreadyExistsException(DateOnly name)
            : base(BackTesterDomainErrorCodes.BhavCopyAlreadyExists)
        {
            WithData("name", name);
        }
    }
}
