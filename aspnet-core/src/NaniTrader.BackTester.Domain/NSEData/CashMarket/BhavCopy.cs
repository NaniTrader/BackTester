using Scriban.Functions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace NaniTrader.BackTester.NSEData.CashMarket
{
    public class BhavCopy : FullAuditedAggregateRoot<Guid>
    {
        // here for ef core
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor.
        private BhavCopy() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor.

        public DateOnly Date { get; private set; }

        public FileStatus FileStatus { get; private set; }

        public BhavCopyData? BhavCopyData { get; private set; }

        public BhavCopy(Guid id, DateOnly fileDate, FileStatus fileStatus) : base(id)
        {
            Date = fileDate;
            FileStatus = fileStatus;
        }

        public BhavCopy(Guid id, DateOnly fileDate, FileStatus fileStatus, BhavCopyData bhavCopyData) : base(id)
        {
            Date = fileDate;
            FileStatus = fileStatus;
            BhavCopyData = bhavCopyData;
        }
    }
}
